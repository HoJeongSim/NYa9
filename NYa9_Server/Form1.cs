using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NYa9_Server
{
    public partial class Form1 : Form
    {
        delegate void AppendTextDelegate(Control ctrl, string s);
        AppendTextDelegate _textAppender;
        Socket mainSock;
        IPAddress thisAddress;

        int RandomNum;
        bool bStartFlag = false;
        String result;
        public Form1()
        {
            InitializeComponent();
            mainSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            _textAppender = new AppendTextDelegate(AppendText);
        }

        void AppendText(Control ctrl, string s)
        {
            if (ctrl.InvokeRequired) ctrl.Invoke(_textAppender, ctrl, s);
            else
            {
                string source = ctrl.Text;
                ctrl.Text = source + Environment.NewLine + s;
            }
        }

        void OnFormLoaded(object sender, EventArgs e)
        {
            IPHostEntry he = Dns.GetHostEntry(Dns.GetHostName());

            // 처음으로 발견되는 ipv4 주소를 사용한다.
            foreach (IPAddress addr in he.AddressList)
            {
                if (addr.AddressFamily == AddressFamily.InterNetwork)
                {
                    thisAddress = addr;
                    break;
                }
            }

            // 주소가 없다면
            if (thisAddress == null)
                // 로컬호스트 주소를 사용한다.
                thisAddress = IPAddress.Loopback;

            txtAddress.Text = thisAddress.ToString();
            CreateRandomNum();
        }
        void BeginStartServer(object sender, EventArgs e)
        {
            int port;
            if (!int.TryParse(txtPort.Text, out port))
            {
                MsgBoxHelper.Error("포트 번호가 잘못 입력되었거나 입력되지 않았습니다.");
                txtPort.Focus();
                txtPort.SelectAll();
                return;
            }

            // 서버에서 클라이언트의 연결 요청을 대기하기 위해
            // 소켓을 열어둔다.
            IPEndPoint serverEP = new IPEndPoint(thisAddress, port);
            mainSock.Bind(serverEP);
            mainSock.Listen(10);

            // 비동기적으로 클라이언트의 연결 요청을 받는다.
            mainSock.BeginAccept(AcceptCallback, null);
        }

        List<Socket> connectedClients = new List<Socket>();
        void AcceptCallback(IAsyncResult ar)
        {
            // 클라이언트의 연결 요청을 수락한다.
            Socket client = mainSock.EndAccept(ar);

            // 또 다른 클라이언트의 연결을 대기한다.
            mainSock.BeginAccept(AcceptCallback, null);

            AsyncObject obj = new AsyncObject(4096);
            obj.WorkingSocket = client;

            // 연결된 클라이언트 리스트에 추가해준다.
            connectedClients.Add(client);

            // 텍스트박스에 클라이언트가 연결되었다고 써준다.
            AppendText(txtHistory, string.Format("클라이언트 (@ {0})가 연결되었습니다.", client.RemoteEndPoint));

            // 클라이언트의 데이터를 받는다.
            client.BeginReceive(obj.Buffer, 0, 4096, 0, DataReceived, obj);
        }

        void DataReceived(IAsyncResult ar)
        {
            try
            {
                // BeginReceive에서 추가적으로 넘어온 데이터를 AsyncObject 형식으로 변환한다.
                AsyncObject obj = (AsyncObject)ar.AsyncState;

                // 데이터 수신을 끝낸다.
                int received = obj.WorkingSocket.EndReceive(ar);

                // 받은 데이터가 없으면(연결끊어짐) 끝낸다.
                if (received <= 0)
                {
                    obj.WorkingSocket.Close();
                    return;
                }

                // 텍스트로 변환한다.
                string text = Encoding.UTF8.GetString(obj.Buffer);

                // 0x01 기준으로 짜른다.
                // tokens[0] - 보낸 사람 IP
                // tokens[1] - 보낸 메세지
                string[] tokens = text.Split('\x01');
                string ip = tokens[0];
                string msg = tokens[1];

                // 텍스트박스에 추가해준다.
                // 비동기식으로 작업하기 때문에 폼의 UI 스레드에서 작업을 해줘야 한다.
                // 따라서 대리자를 통해 처리한다.
                AppendText(txtHistory, string.Format("[받음]{0}: {1}", ip, msg));

                // 결과 체크
                result = BaseballGame_ResultCheck(RandomNum.ToString(), msg);

                // for을 통해 "역순"으로 클라이언트에게 데이터를 보낸다.
                for (int i = connectedClients.Count - 1; i >= 0; i--)
                {
                    Socket socket = connectedClients[i];
                    if (socket != obj.WorkingSocket)
                    {
                        try { socket.Send(obj.Buffer); }
                        catch
                        {
                            // 오류 발생하면 전송 취소하고 리스트에서 삭제한다.
                            try { socket.Dispose(); } catch { }
                            connectedClients.RemoveAt(i);
                        }
                    }
                }

                // 문자열을 utf8 형식의 바이트로 변환한다.
                byte[] bDts = Encoding.UTF8.GetBytes(thisAddress.ToString() + '\x01' + result);

                // 연결된 모든 클라이언트에게 전송한다.
                for (int i = connectedClients.Count - 1; i >= 0; i--)
                {
                    Socket socket = connectedClients[i];
                    try { socket.Send(bDts); }
                    catch
                    {
                        // 오류 발생하면 전송 취소하고 리스트에서 삭제한다.
                        try { socket.Dispose(); } catch { }
                        connectedClients.RemoveAt(i);
                    }
                }

                // 전송 완료 후 텍스트박스에 추가하고, 원래의 내용은 지운다.
                AppendText(txtHistory, string.Format("[보냄]{0}: {1}", thisAddress.ToString(), result));

                // 데이터를 받은 후엔 다시 버퍼를 비워주고 같은 방법으로 수신을 대기한다.
                obj.ClearBuffer();

                // 수신 대기
                obj.WorkingSocket.BeginReceive(obj.Buffer, 0, 4096, 0, DataReceived, obj);
            }
            catch(Exception e) { }
       
        }

        void OnSendData(object sender, EventArgs e)
        {
            // 서버가 대기중인지 확인한다.
            if (!mainSock.IsBound)
            {
                MsgBoxHelper.Warn("서버가 실행되고 있지 않습니다!");
                return;
            }

            // 보낼 텍스트
            // 문자열을 utf8 형식의 바이트로 변환한다.
            byte[] bDts = Encoding.UTF8.GetBytes(thisAddress.ToString() + '\x01' + result);

            // 연결된 모든 클라이언트에게 전송한다.
            for (int i = connectedClients.Count - 1; i >= 0; i--)
            {
                Socket socket = connectedClients[i];
                try { socket.Send(bDts); }
                catch
                {
                    // 오류 발생하면 전송 취소하고 리스트에서 삭제한다.
                    try { socket.Dispose(); } catch { }
                    connectedClients.RemoveAt(i);
                }
            }

            // 전송 완료 후 텍스트박스에 추가하고, 원래의 내용은 지운다.
            AppendText(txtHistory, string.Format("[보냄]{0}: {1}", thisAddress.ToString(), result));
        }

        //입력된 숫자 또는 난수의 중복된 숫자 체크
        private bool BaseballGame_OverlapCheck(String str)
        {
            String[] _str = new String[3];

            for (int i = 0; i < _str.Length; i++)   //하나씩 잘라서 넣기 
            {
                _str[i] = str.Substring(i, 1);
            }

            for (int i = 0; i < _str.Length; i++)
            {
                for (int j = 0; j < _str.Length; j++)
                {
                    if (i != j)
                    {
                        if (_str[i].Equals(_str[j]))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        //결과 체크 함수
        private String BaseballGame_ResultCheck(string strRandomNum, string strInput)
        {
            int nStrike = 0;
            int nBall = 0;

            String str = "OUT!";

            //정답과 입력된 숫자를 한자리씩 배열로 나눈다.
            String[] arrayRandomNum = new String[3];
            String[] arrayInput = new String[3];

            for (int i = 0; i < arrayRandomNum.Length; i++)
            {
                arrayRandomNum[i] = strRandomNum.Substring(i, 1);
            }

            for (int i = 0; i < arrayInput.Length; i++)
            {
                arrayInput[i] = strInput.Substring(i, 1);
            }


            for (int i = 0; i < arrayInput.Length; i++)
            {
                for (int j = 0; j < arrayRandomNum.Length; j++)
                {
                    if (arrayInput[i].Equals(arrayRandomNum[j]))  //같은 숫자가 있는지 판단.
                    {
                        if (i == j) //자리수가 같으면 스트라이크
                        {
                            nStrike++;
                        }
                        else
                        {
                            nBall++;
                        }
                    }
                }
            }

            if (nStrike != 0 || nBall != 0)     // 체크결과 반환
            {
                str = "스트라이크 : " + nStrike + " / 볼 : " + nBall;
            }

            if (nStrike.Equals(3))   //3 스트라이크일 경우 정답 반환
            {
                bStartFlag = false;
                return "정답";
            }
            return str;
        }

        //난수 생성
        private void CreateRandomNum()
        {
            Random r = new Random();

            while (true)
            {
                this.RandomNum = r.Next(100, 999);

                if (BaseballGame_OverlapCheck(this.RandomNum.ToString()))  //정답에 중복되는 숫자가 있는지 체크
                {
                    break;
                }
            }
            txtHistory.AppendText("난수가 생성되었습니다!");
            bStartFlag = true;
        }

        //난수 생성 버튼
        private void CreateNum(object sender, EventArgs e)
        {
            Random r = new Random();

            while (true)
            {
                this.RandomNum = r.Next(100, 999);

                if (BaseballGame_OverlapCheck(this.RandomNum.ToString()))  //정답에 중복되는 숫자가 있는지 체크
                {
                    break;
                }
            }
            txtHistory.AppendText("\r\n난수가 생성되었습니다!");
            bStartFlag = true;
        }

        //정답확인 버튼
        private void ShowAnswer(object sender, EventArgs e)
        {
            MessageBox.Show(this.RandomNum.ToString(),"정답");
        }

    }
}
