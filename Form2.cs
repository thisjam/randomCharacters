using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace randomCharacters
{
    public partial class Form2 : Form
    {

        private static Form2 instance;
        public static Form2 Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new Form2();
                }

                return instance;
            }
        }


        private Form2()
        {
            InitializeComponent();

        }


       


        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;//顺序不能颠倒 否则会出现多出显示器的分辨率
            this.WindowState = FormWindowState.Maximized;


            this.BackColor = Color.Black;
            pictureBox1.BackColor = Color.Black;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Width = this.Width;
            pictureBox1.Height = this.Height;


        }

        private void Form2_Resize(object sender, EventArgs e)
        {

        }

        public void ChangeImg(Image img)
        {
            pictureBox1.Image = img;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

            if (!Tools.isCanPlay|| Tools.sucecssCount ==-1)
                return;
           

            MouseEventArgs mouseArgs = (MouseEventArgs)e;
            Tools.currentClickPos.X = mouseArgs.X;
            Tools.currentClickPos.Y= mouseArgs.Y;
            (string word, Point clickPos) = Tools.getCurrentRealPos();
            if (word == "")
            {
                return;
            }
            var cpos = getCurrentRealPos(Tools.sucecssCount);
            if (Tools.IsPosInBox(Tools.currentClickPos, cpos, getRightBottomPos(cpos))){
                Tools.sucecssCount++;
            }
            else
            {
                Tools.sucecssCount = -1;
            }
        }


        //获取当前真实数字坐标
       
        
        Point getRightBottomPos(Point cpos)
        {
            return new Point(cpos.X + Tools.area, cpos.Y+Tools.area);
            
        }
        Point getCurrentRealPos(int cindex)
        {

            return Tools.sortDic.First(x => x.Key == cindex).Value;

        }
    }
}
