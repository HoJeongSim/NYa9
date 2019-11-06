namespace Number_baseball
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button0 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.lbcount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::Number_baseball.Properties.Resources.판;
            this.panel3.Controls.Add(this.txtPort);
            this.panel3.Controls.Add(this.btnSend);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(12, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(296, 588);
            this.panel3.TabIndex = 7;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(14, 47);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(197, 21);
            this.txtPort.TabIndex = 9;
            this.txtPort.Text = "9000";
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(217, 47);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(64, 21);
            this.btnSend.TabIndex = 18;
            this.btnSend.Text = "서버연결";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.OnConnectToServer);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(14, 77);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(267, 467);
            this.textBox1.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(47)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(15)))), ((int)(((byte)(24)))));
            this.label4.Location = new System.Drawing.Point(109, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "HISTORY";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::Number_baseball.Properties.Resources.숫자_판;
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Location = new System.Drawing.Point(456, 154);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(386, 429);
            this.panel2.TabIndex = 6;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.button0);
            this.panel8.Controls.Add(this.button13);
            this.panel8.Controls.Add(this.button11);
            this.panel8.Controls.Add(this.button9);
            this.panel8.Controls.Add(this.button8);
            this.panel8.Controls.Add(this.button7);
            this.panel8.Controls.Add(this.button6);
            this.panel8.Controls.Add(this.button5);
            this.panel8.Controls.Add(this.button4);
            this.panel8.Controls.Add(this.button3);
            this.panel8.Controls.Add(this.button2);
            this.panel8.Controls.Add(this.button1);
            this.panel8.Location = new System.Drawing.Point(13, 130);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(360, 285);
            this.panel8.TabIndex = 1;
            // 
            // button0
            // 
            this.button0.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button0.BackgroundImage = global::Number_baseball.Properties.Resources._0번;
            this.button0.Location = new System.Drawing.Point(145, 205);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(65, 65);
            this.button0.TabIndex = 21;
            this.button0.UseVisualStyleBackColor = false;
            this.button0.Click += new System.EventHandler(this.button0_Click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button13.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button13.Location = new System.Drawing.Point(212, 205);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(65, 65);
            this.button13.TabIndex = 20;
            this.button13.Text = "전 송";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.OnSendData);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button11.Location = new System.Drawing.Point(78, 205);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(65, 65);
            this.button11.TabIndex = 18;
            this.button11.Text = "지우기";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button9.BackgroundImage = global::Number_baseball.Properties.Resources._9번;
            this.button9.Location = new System.Drawing.Point(213, 142);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(65, 65);
            this.button9.TabIndex = 17;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.Button9_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button8.BackgroundImage = global::Number_baseball.Properties.Resources._8번;
            this.button8.Location = new System.Drawing.Point(145, 142);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(65, 65);
            this.button8.TabIndex = 16;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.Button8_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button7.BackgroundImage = global::Number_baseball.Properties.Resources._7번;
            this.button7.Location = new System.Drawing.Point(78, 142);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(65, 65);
            this.button7.TabIndex = 15;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.Button7_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button6.BackgroundImage = global::Number_baseball.Properties.Resources._6번;
            this.button6.Location = new System.Drawing.Point(213, 77);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(65, 65);
            this.button6.TabIndex = 14;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button5.BackgroundImage = global::Number_baseball.Properties.Resources._5번;
            this.button5.Location = new System.Drawing.Point(145, 77);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(65, 65);
            this.button5.TabIndex = 13;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button4.BackgroundImage = global::Number_baseball.Properties.Resources._4번;
            this.button4.Location = new System.Drawing.Point(78, 77);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(65, 65);
            this.button4.TabIndex = 12;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button3.BackgroundImage = global::Number_baseball.Properties.Resources._3번;
            this.button3.Location = new System.Drawing.Point(213, 11);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(65, 65);
            this.button3.TabIndex = 11;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button2.BackgroundImage = global::Number_baseball.Properties.Resources._2번;
            this.button2.Location = new System.Drawing.Point(145, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 65);
            this.button2.TabIndex = 10;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button1.BackgroundImage = global::Number_baseball.Properties.Resources._1번;
            this.button1.Location = new System.Drawing.Point(78, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 65);
            this.button1.TabIndex = 9;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Location = new System.Drawing.Point(13, 13);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(360, 111);
            this.panel7.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.BackgroundImage = global::Number_baseball.Properties.Resources.숫자_위_판;
            this.panel9.Controls.Add(this.btn3);
            this.panel9.Controls.Add(this.btn1);
            this.panel9.Controls.Add(this.btn2);
            this.panel9.Location = new System.Drawing.Point(62, 18);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(234, 75);
            this.panel9.TabIndex = 1;
            // 
            // btn3
            // 
            this.btn3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn3.Location = new System.Drawing.Point(150, 6);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(65, 65);
            this.btn3.TabIndex = 20;
            this.btn3.UseVisualStyleBackColor = false;
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn1.Location = new System.Drawing.Point(20, 6);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(65, 65);
            this.btn1.TabIndex = 18;
            this.btn1.UseVisualStyleBackColor = false;
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn2.Location = new System.Drawing.Point(85, 6);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(65, 65);
            this.btn2.TabIndex = 19;
            this.btn2.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Number_baseball.Properties.Resources.제목;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel12);
            this.panel1.Controls.Add(this.panel11);
            this.panel1.Location = new System.Drawing.Point(329, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(667, 111);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(17)))), ((int)(((byte)(47)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(196, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 40);
            this.label1.TabIndex = 9;
            this.label1.Text = "숫자를 맞춰주세요";
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.lbcount);
            this.panel12.Controls.Add(this.label2);
            this.panel12.Location = new System.Drawing.Point(552, 7);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(101, 94);
            this.panel12.TabIndex = 9;
            // 
            // lbcount
            // 
            this.lbcount.AutoSize = true;
            this.lbcount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbcount.Location = new System.Drawing.Point(2, 49);
            this.lbcount.Name = "lbcount";
            this.lbcount.Size = new System.Drawing.Size(97, 29);
            this.lbcount.TabIndex = 9;
            this.lbcount.Text = "10 / 10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "남은 기회";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.SystemColors.Window;
            this.panel11.Controls.Add(this.pictureBox1);
            this.panel11.Location = new System.Drawing.Point(12, 8);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(94, 94);
            this.panel11.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Number_baseball.Properties.Resources.캐릭터;
            this.pictureBox1.Location = new System.Drawing.Point(0, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1007, 616);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "NYa9_Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbcount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

