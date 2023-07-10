namespace randomCharacters
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_start = new Button();
            checkBox1 = new CheckBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox3 = new TextBox();
            button1 = new Button();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            SuspendLayout();
            // 
            // btn_start
            // 
            btn_start.Location = new Point(168, 229);
            btn_start.Name = "btn_start";
            btn_start.Size = new Size(79, 37);
            btn_start.TabIndex = 0;
            btn_start.Text = "start";
            btn_start.UseVisualStyleBackColor = true;
            btn_start.Click += btn_start_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(238, 156);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(80, 21);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "数字/文字";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(141, 85);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(67, 23);
            textBox1.TabIndex = 2;
            textBox1.Text = "50";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(358, 83);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(67, 23);
            textBox2.TabIndex = 3;
            textBox2.Text = "5000";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 87);
            label1.Name = "label1";
            label1.Size = new Size(68, 17);
            label1.TabIndex = 4;
            label1.Text = "画多少张图";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(238, 87);
            label2.Name = "label2";
            label2.Size = new Size(105, 17);
            label2.TabIndex = 5;
            label2.Text = "图片显示时间(ms)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 156);
            label3.Name = "label3";
            label3.Size = new Size(56, 17);
            label3.TabIndex = 7;
            label3.Text = "字体大小";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(141, 154);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(67, 23);
            textBox3.TabIndex = 6;
            textBox3.Text = "200";
            // 
            // button1
            // 
            button1.Location = new Point(291, 229);
            button1.Name = "button1";
            button1.Size = new Size(79, 37);
            button1.TabIndex = 8;
            button1.Text = "stop";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(74, 238);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(75, 21);
            checkBox2.TabIndex = 9;
            checkBox2.Text = "保存图片";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Checked = true;
            checkBox3.CheckState = CheckState.Checked;
            checkBox3.Location = new Point(358, 156);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(128, 21);
            checkBox3.TabIndex = 10;
            checkBox3.Text = "（游戏/观察）模式";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(515, 333);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(checkBox1);
            Controls.Add(btn_start);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_start;
        private CheckBox checkBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox3;
        private Button button1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
    }
}