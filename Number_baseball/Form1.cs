using NYa9_Server;
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

namespace Number_baseball
{
    public partial class Form1 : Form
    {
        delegate void AppendTextDelegate(Control ctrl, string s);
        AppendTextDelegate _textAppender;
        Socket mainSock;
        IPAddress thisAddress;

        int count = 10;
        string number="";
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

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
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

            textBox1.Text = thisAddress.ToString();
        }

        void OnConnectToServer(object sender, EventArgs e)
        {
            if (mainSock.Connected)
            {
                MsgBoxHelper.Error("이미 연결되어 있습니다!");
                return;
            }

            int port;
            if (!int.TryParse(txtPort.Text, out port))
            {
                MsgBoxHelper.Error("포트 번호가 잘못 입력되었거나 입력되지 않았습니다.");
                txtPort.Focus();
                txtPort.SelectAll();
                return;
            }

            try { mainSock.Connect("172.16.52.226", port); }
            catch (Exception ex)
            {
                MsgBoxHelper.Error("연결에 실패했습니다!\n오류 내용: {0}", MessageBoxButtons.OK, ex.Message);
                return;
            }

            // 연결 완료되었다는 메세지를 띄워준다.
            AppendText(textBox1, "서버와 연결되었습니다.");

            // 연결 완료, 서버에서 데이터가 올 수 있으므로 수신 대기한다.
            AsyncObject obj = new AsyncObject(4096);
            obj.WorkingSocket = mainSock;
            mainSock.BeginReceive(obj.Buffer, 0, obj.BufferSize, 0, DataReceived, obj);
        }

        void DataReceived(IAsyncResult ar)
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
            AppendText(textBox1, string.Format("[받음]{0}: {1}", ip, msg));

            // 클라이언트에선 데이터를 전달해줄 필요가 없으므로 바로 수신 대기한다.
            // 데이터를 받은 후엔 다시 버퍼를 비워주고 같은 방법으로 수신을 대기한다.
            obj.ClearBuffer();

            // 수신 대기
            obj.WorkingSocket.BeginReceive(obj.Buffer, 0, 4096, 0, DataReceived, obj);
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
            if (string.IsNullOrEmpty(number))
            {
                MsgBoxHelper.Warn("숫자가 입력되지 않았습니다!");
                return;
            }

            if (number.Length < 3)
            {
                MsgBoxHelper.Warn("3자리 숫자를 입력해주세요.");
                return;
            }

            if (number.Length > 3)
            {
                MsgBoxHelper.Warn("3자리 숫자를 입력해주세요.");
                btn1.Image = null;
                btn2.Image = null;
                btn3.Image = null;
                number = "";
                return;
            }

            // 서버 ip 주소와 메세지를 담도록 만든다.
            IPEndPoint ip = (IPEndPoint)mainSock.LocalEndPoint;
            string addr = ip.Address.ToString();

            // 문자열을 utf8 형식의 바이트로 변환한다.
            byte[] buffer = Encoding.UTF8.GetBytes(addr + '\x01' + number);

            // 서버에 전송한다.
            mainSock.Send(buffer);

            // 이미지를 초기화한다.
            btn1.Image = null;
            btn2.Image = null;
            btn3.Image = null;

            // 모든 버튼을 활성화 시킨다.
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button0.Enabled = true;

            // 전송 완료 후 텍스트박스에 추가하고, 원래의 내용은 지운다.
            AppendText(textBox1, string.Format("[보냄]{0}: {1}", addr, number));
            number = "";
            count--;
            lbcount.Text = count.ToString("D2") + " / 10";
            if (count == 0)
            {
                MessageBox.Show("남은 기회가 없습니다.","Message");

            }
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            number = number + "1";
            if (btn1.Image == null && btn2.Image == null && btn3.Image == null)
            {
                btn1.Image = Properties.Resources._1번;
                button1.Enabled = false;
            }
            else if (btn1.Image != null && btn2.Image == null && btn3.Image == null)
            {
                btn2.Image = Properties.Resources._1번;
                button1.Enabled = false;
            }
            else if (btn1.Image != null && btn2.Image != null && btn3.Image == null)
            {
                btn3.Image = Properties.Resources._1번;
                button1.Enabled = false;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            number = number + "2";
            if (btn1.Image == null && btn2.Image == null && btn3.Image == null)
            {
                btn1.Image = Properties.Resources._2번;
                button2.Enabled = false;
            }
            else if (btn1.Image != null && btn2.Image == null && btn3.Image == null && btn1.Image!=Properties.Resources._2번)
            {
                btn2.Image = Properties.Resources._2번;
                button2.Enabled = false;
            }
            else if (btn1.Image != null && btn2.Image != null && btn3.Image == null)
            {
                btn3.Image = Properties.Resources._2번;
                button2.Enabled = false;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            number = number + "3";
            if (btn1.Image == null && btn2.Image == null && btn3.Image == null)
            {
                btn1.Image = Properties.Resources._3번;
                button3.Enabled = false;
            }
            else if (btn1.Image != null && btn2.Image == null && btn3.Image == null)
            {
                btn2.Image = Properties.Resources._3번;
                button3.Enabled = false;
            }
            else if (btn1.Image != null && btn2.Image != null && btn3.Image == null)
            {
                btn3.Image = Properties.Resources._3번;
                button3.Enabled = false;
            }

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            number = number + "4";
            if (btn1.Image == null && btn2.Image == null && btn3.Image == null)
            {
                btn1.Image = Properties.Resources._4번;
                button4.Enabled = false;
            }
            else if (btn1.Image != null && btn2.Image == null && btn3.Image == null)
            {
                btn2.Image = Properties.Resources._4번;
                button4.Enabled = false;
            }
            else if (btn1.Image != null && btn2.Image != null && btn3.Image == null)
            {
                btn3.Image = Properties.Resources._4번;
                button4.Enabled = false;
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            number = number + "5";
            if (btn1.Image == null && btn2.Image == null && btn3.Image == null)
            {
                btn1.Image = Properties.Resources._5번;
                button5.Enabled = false;
            }
            else if (btn1.Image != null && btn2.Image == null && btn3.Image == null)
            {
                btn2.Image = Properties.Resources._5번;
                button5.Enabled = false;
            }
            else if (btn1.Image != null && btn2.Image != null && btn3.Image == null)
            {
                btn3.Image = Properties.Resources._5번;
                button5.Enabled = false;
            }

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            number = number + "6";
            if (btn1.Image == null && btn2.Image == null && btn3.Image == null)
            {
                btn1.Image = Properties.Resources._6번;
                button6.Enabled = false;
            }
            else if (btn1.Image != null && btn2.Image == null && btn3.Image == null)
            {
                btn2.Image = Properties.Resources._6번;
                button6.Enabled = false;
            }
            else if (btn1.Image != null && btn2.Image != null && btn3.Image == null)
            {
                btn3.Image = Properties.Resources._6번;
                button6.Enabled = false;
            }

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            number = number + "7";
            if (btn1.Image == null && btn2.Image == null && btn3.Image == null)
            {
                btn1.Image = Properties.Resources._7번;
                button7.Enabled = false;
            }
            else if (btn1.Image != null && btn2.Image == null && btn3.Image == null)
            {
                btn2.Image = Properties.Resources._7번;
                button7.Enabled = false;
            }
            else if (btn1.Image != null && btn2.Image != null && btn3.Image == null)
            {
                btn3.Image = Properties.Resources._7번;
                button7.Enabled = false;
            }

        }

        private void Button8_Click(object sender, EventArgs e)
        {
            number = number + "8";
            if (btn1.Image == null && btn2.Image == null && btn3.Image == null)
            {
                btn1.Image = Properties.Resources._8번;
                button8.Enabled = false;
            }
            else if (btn1.Image != null && btn2.Image == null && btn3.Image == null)
            {
                btn2.Image = Properties.Resources._8번;
                button8.Enabled = false;
            }
            else if (btn1.Image != null && btn2.Image != null && btn3.Image == null)
            {
                btn3.Image = Properties.Resources._8번;
                button8.Enabled = false;
            }

        }

        private void Button9_Click(object sender, EventArgs e)
        {
            number = number + "9";
            if (btn1.Image == null && btn2.Image == null && btn3.Image == null)
            {
                btn1.Image = Properties.Resources._9번;
                button9.Enabled = false;
            }
            else if (btn1.Image != null && btn2.Image == null && btn3.Image == null)
            {
                btn2.Image = Properties.Resources._9번;
                button9.Enabled = false;
            }
            else if (btn1.Image != null && btn2.Image != null && btn3.Image == null)
            {
                btn3.Image = Properties.Resources._9번;
                button9.Enabled = false;
            }

        }

        private void button0_Click(object sender, EventArgs e)
        {
            number = number + "0";
            if (btn1.Image == null && btn2.Image == null && btn3.Image == null)
            {
                btn1.Image = Properties.Resources._0번;
                button0.Enabled = false;
            }
            else if (btn1.Image != null && btn2.Image == null && btn3.Image == null)
            {
                btn2.Image = Properties.Resources._0번;
                button0.Enabled = false;
            }
            else if (btn1.Image != null && btn2.Image != null && btn3.Image == null)
            {
                btn3.Image = Properties.Resources._0번;
                button0.Enabled = false;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            number = "";
            btn1.Image = null;
            btn2.Image = null;
            btn3.Image = null;

            // 모든 버튼을 활성화 시킨다.
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button0.Enabled = true;

        }
    }
}
