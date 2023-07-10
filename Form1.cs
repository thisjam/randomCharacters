using System.Drawing.Imaging;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Security.Cryptography;
using System;
using System.Runtime.Intrinsics.Arm;
using System.Media;
using System.Reflection;

namespace randomCharacters
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false; // ½ûÓÃ×î´ó»¯°´Å¥
            this.MinimizeBox = true; // ½ûÓÃ×îĞ¡»¯°´Å¥
           
            zh = this.zh.Replace("\n", "").Replace(" ", "").Replace("£¬", "").Replace("\r", "").Replace("¡£", "");
            arrZh = zh.ToCharArray();
            arrNum = initNumArr();

        }

        Form2 form2;
        string zh = """
           Ê«´ÊÇú¸³£¬Ï·¾çËµ³ª£¬ÅıÅÃÇÙÉª£¬Âàïïï¬ïÏ¡£
           óÏóïÎØÑÊ£¬ÎÔµÑÓÆÑï£¬óİÒô±¼·Ü£¬ßïÄÅ¸ß¿º¡£
           ¾£ºÆ¿ïÂ®£¬¶­Ô´äìÏæ£¬Ã×ÜÀĞ´Òâ£¬±¯ºè¿¥°º¡£
           ±ÊÄ«Ö½Ñâ£¬ØÒé¹éº°ñ£¬¿¬Á¥×­¿Ì£¬±®Ìû²İ¿ñ¡£
           ¶Ø»ÍÊ¯¿ß£¬³¤³ÇÎ°Ç½£¬ÇàÍ­¼×¹Ç£¬ÂÆÒÂÉ´ÉÑ¡£
           »¢·ûÔ½½££¬ÌÕÂíÙ¸Ôá£¬²Ê´É±¦ÎÍ£¬Ë¿³ñËûÏç¡£
           ·²¶ûÈü¹¬£¬½ğ×ÖËş×´£¬Ì©¼§ÁêÄ¹£¬±ËµÃ½ÌÌÃ¡£
           ×ÔÓÉÅ®Éñ£¬Ï£À°ËÜÏñ£¬×îºóÍí²Í£¬´´ÔìÑÇµ±¡£
           Í¤é¿Â¥¸ó£¬ËÂÃíµîÀÈ£¬ÅîÃÅÜê»§£¬ÕÉÊÒÂÌ´°¡£
           ¸®µÜ±ğÊû£¬»­¶°µñÁº£¬Í¥ÔºÌ¤²½£¬Ó°ÆÁÄ»ÕÏ¡£
           ³Ğ³¾Ôå¾®£¬Àé°ÊÖù×®£¬ÏÏ¶æ·ö¿¿£¬Æ¾À¸Ì÷Íû¡£
           ĞüÑÂÇÍ±Ú£¬·åÂÍµşáÖ£¬ÈªÅçá°ÕÖ£¬ÍÄ¼±ÆÙå´¡£
           Ï¿¹µÌ¶Ô¨£¬Ïª½§Á÷ÌÊ£¬³ØÇşÑß°Ó£¬ÕÓÔóÄàÌÁ¡£
           äöÎĞ´ø²¨£¬½¸ÓìÁ¬½­£¬ĞÚÓ¿ÅìÅÈ£¬¾ªÌÎº§ÀË¡£
           ÔÖÀÔÒçĞº£¬Ñ´³±¸¡ÕÇ£¬²ÔËÉÊÙ°Ø£¬´¹ÁøÃ«Ñî¡£
           °Å½¶ÆÑÉÈ£¬°ßÖñóú¿ğ£¬»±´»ÓÜèë£¬É¼¹ğéÅÕÁ£¬
           Õ«ìé½ô±Õ£¬Õ¤Ô·±ôÅÔ£¬ÆºÆÒÀ³Òğ£¬·Æ¿úÎë·»¡£
           Ç¾Ş±ôæõÑ£¬ÆÎºÊÎµÃ££¬ÔÌµÙ¼ÔĞ¾£¬İíÀÙÁÕÀÅ¡£
           Ææ»¨Òì»Ü£¬ÑŞÀöÈÙÑí£¬À¼ºÉ¾ÕÃ·£¬ËÄ¼¾·Ò·¼¡£
           ¶Å¾éÆüÑª£¬Ü½ÈØ¼ªÏé£¬ÜÔÀòğ¥Óô£¬Ãµ¹å´ÌÃ¢¡£
           ¹Ï¹ûÊß²Ë£¬´ĞËâ¾Â½ª£¬Üî½·ÇÛ¿û£¬Æ¤½æÀ±½´¡£           
           """;
        int[] arrNum;
        char[] arrZh;
        int showTime;
        int transitionTime = 2000;
        uint generateNum;
        int fontSize;
        PictureBox pictureBox;
        Task task;
        bool isRunning = false;
        List<Point> Retangels;
        int wordnum = 10;
        CancellationTokenSource token;




        int[] initNumArr()
        {
            this.arrNum = new int[wordnum];
            for (int i = 0; i < this.arrNum.Length; i++)
            {
                arrNum[i] = i;
            }
            return this.arrNum;
        }
        private void btn_start_Click(object sender, EventArgs e)
        {

            if (checkInut() && isRunning == false)
            {
                Retangels = SplitRetangle();
                Start();
            }

        }



        void Start()
        {

            try
            {
                isRunning = true;
                form2 = Form2.Instance;
                form2.Show();
                pictureBox = form2.Controls.Find("pictureBox1", false)[0] as PictureBox;
                token = new CancellationTokenSource();
                task = Task.Factory.StartNew(() =>
                {

                    DrawReady();
                    if(checkBox3.Checked)
                    {
                        DrawImgTofrom2AndPlay();
                    }
                    else
                    {
                        DrawImgTofrom2(checkBox3.Checked);
                    }
                   


                }, token.Token);


            }
            catch (Exception)
            {

                throw;
            }


        }





        bool checkInut()
        {
            try
            {


                generateNum = Convert.ToUInt32(textBox1.Text);
                showTime = Convert.ToInt32(textBox2.Text);

                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                return false;
            }

        }

        char[] getRandomZh()
        {

            HashSet<char> arr = new HashSet<char>();
            Random rd;
            while (true)
            {
                rd = new Random();
                int index = rd.Next(0, arrZh.Length);
                arr.Add(arrZh[index]);
                if (arr.Count == wordnum) return arr.ToArray();
            }

        }

        int[] getRandomNum()
        {

            HashSet<int> arr = new HashSet<int>();
            Random rd;
            while (true)
            {
                rd = new Random();
                int index = rd.Next(0, arrNum.Length);
                arr.Add(arrNum[index]);
                Trace.WriteLine(Retangels[index]);
                if (arr.Count == wordnum) return arr.ToArray();
            }

        }


        List<Point> SplitRetangle()
        {
            try
            {
                fontSize = Convert.ToInt32(textBox3.Text);
                Tools.area = fontSize / 2;
            }
            catch (Exception)
            {

                throw;
            }

            int width = 1920;
            int height = 1080;
            int squareSide = fontSize;

            int rows = (int)MathF.Floor(height / squareSide);
            int cols = (int)MathF.Floor(width / squareSide);
            List<Point> list = new List<Point>();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int x = j * squareSide;
                    int y = i * squareSide;
                    //Trace.WriteLine($"x: {x}, y: {y}");
                    if (x != 0 && y != 0)
                        list.Add(new Point(x, y));
                }
            }
            return list;


        }

        int getRdRetangelIndex(List<int> listExisted)
        {
            int index = RandomNumberGenerator.GetInt32(0, Retangels.Count);
            if (listExisted.Count == 0)
            {
                return index;
            }
            while (true)
            {
                if (listExisted.Contains(index) == false)
                {
                    return index;
                }
                else
                {
                    index = RandomNumberGenerator.GetInt32(0, Retangels.Count);
                }
            }


        }






        #region Éú³ÉÍ¼Æ¬µ½ÎÄ¼ş¼Ğ±£´æ
        void GreateImg(bool isNum = false)
        {
            int imgWeight = form2.Width;
            int imgheight = form2.Height;
            int generateNum = Convert.ToInt32(textBox1.Text);

            for (int i = 0; i < generateNum; i++)
            {

                Bitmap bmp = new Bitmap(imgWeight, imgheight);
                using (Graphics graphics = Graphics.FromImage(bmp))
                {

                    Font font = new Font("Arial", 28);
                    Brush brushBlack = Brushes.Black;
                    Brush brushWhite = Brushes.White;
                    graphics.FillRectangle(brushBlack, 0, 0, imgWeight, imgheight);
                    var arrzh = getRandomZh();
                    var arrnum = getRandomNum();
                    Random rd = new Random();
                    Random rd2 = new Random();
                    int range = 50;

                    if (isNum)
                    {

                        foreach (var item in arrnum)
                        {
                            var rdw = rd.Next(range, imgWeight - range);
                            var rdh = rd.Next(range, imgheight - range);
                            graphics.DrawString(item.ToString(), font, brushWhite, rdw, rdh);
                        }
                    }
                    else
                    {
                        foreach (var item in arrzh)
                        {
                            var rdw = rd.Next(range, imgWeight - range);
                            var rdh = rd.Next(range, imgheight - range);
                            graphics.DrawString(item.ToString(), font, brushWhite, rdw, rdh);
                        }

                    }

                    string name = isNum ? "num-" : "zh-";
                    bmp.Save(name + Guid.NewGuid().ToString() + ".png", ImageFormat.Png);

                }




            }
            MessageBox.Show("Íê³É");
        }
        #endregion


        void DrawReady()
        {
            int w = form2.Width;
            int h = form2.Height;
            for (int i = 5; i > 0; i--)
            {
                var img = GetDrawImg(i.ToString(), w / 2 - 25, h / 2 - 25, w, h);
                this.Invoke(new Action(() =>
                {
                    pictureBox.Image = img;
                }));
                Thread.Sleep(1000);
                this.Invoke(new Action(() =>
                {
                    pictureBox.Image = null;

                }));
                img.Dispose();

            }
            Thread.Sleep(1000);






        }

        Image GetDrawImg(string words, int x, int y, int w, int h)
        {
            Image img = new Bitmap(w, h);
            Font font = new Font("Arial", 50);
            Brush brushBlack = Brushes.Black;
            Brush brushWhite = Brushes.White;
            using (Graphics graphics = Graphics.FromImage(img))
            {
                graphics.FillRectangle(brushBlack, 0, 0, w, h);
                graphics.DrawString(words, font, brushWhite, x, y);
                return img;
            }
        }


        void DrawImgTofrom2(bool isNum = false)
        {
            int imgWeight = form2.Width;
            int imgheight = form2.Height;


            List<int> listExisted;
            for (int i = 0; i < generateNum; i++)
            {

                listExisted = new List<int>();
                Image img = new Bitmap(imgWeight, imgheight);
                if (isRunning == false)
                {
                    this.Invoke(new Action(() =>
                    {
                        i = 10000;
                        form2.Close();
                        this.button1.Enabled = true;
                        return;
                    }));
                }
                using (Graphics graphics = Graphics.FromImage(img))
                {

                    Font font = new Font("Arial", this.fontSize / 2, GraphicsUnit.Pixel);
                    Brush brushBlack = Brushes.Black;
                    Brush brushWhite = Brushes.White;
                    graphics.FillRectangle(brushBlack, 0, 0, imgWeight, imgheight);
                    var arrzh = getRandomZh();
                    var arrnum = getRandomNum();
                    int range = 80;
                    //Êı×Ö»òÖĞÎÄ¼¯ºÏ listwords
                    dynamic listwords = isNum ? arrnum : arrzh;
                    //ÑµÁ·ÏÂ±ê  ÒòÎª listwordsÊÇ dynamic
                    int listindex = 0;
                    foreach (var item in listwords)
                    {

                        listExisted.Add(getRdRetangelIndex(listExisted));
                        graphics.DrawString(item.ToString(), font, brushWhite, Retangels[listExisted[listindex]]);

                        listindex++;
                    }
                    if (checkBox2.Checked)
                    {
                        img.Save(Guid.NewGuid().ToString() + ".png");
                    }
                    this.Invoke(new Action(() =>
                    {
                        pictureBox.Image = img;
                    }));
                    Thread.Sleep(showTime);
                    foreach (var index in listExisted)
                    {
                        graphics.FillRectangle(brushWhite, new Rectangle(Retangels[index], new Size(fontSize / 2, fontSize / 2)));

                    }
                    this.Invoke(new Action(() =>
                    {
                        pictureBox.Image = null;
                        pictureBox.Image = img;
                    }));
                    Thread.Sleep(transitionTime);
                    this.Invoke(new Action(() =>
                    {
                        pictureBox.Image = null;

                    }));
                    Thread.Sleep(transitionTime);

                }
                img.Dispose();



            }



        }



        async void DrawImgTofrom2AndPlay()
        {
            int imgWeight = form2.Width;
            int imgheight = form2.Height;

            List<int> listExisted;
            for (int i = 0; i < generateNum; i++)
            {

                listExisted = new List<int>();
                Image img = new Bitmap(imgWeight, imgheight);
                if (isRunning == false)
                {
                    this.Invoke(new Action(() =>
                    {
                        i = 10000;
                        form2.Close();
                        this.button1.Enabled = true;
                        return;
                    }));
                }
                using (Graphics graphics = Graphics.FromImage(img))
                {

                    Font font = new Font("Arial", this.fontSize / 2, GraphicsUnit.Pixel);
                    Brush brushBlack = Brushes.Black;
                    Brush brushWhite = Brushes.White;
                    graphics.FillRectangle(brushBlack, 0, 0, imgWeight, imgheight);
                    var arrnum = getRandomNum();

                    for (int index = 0; index < arrnum.Length; index++)
                    {
                        listExisted.Add(getRdRetangelIndex(listExisted));
                        graphics.DrawString(arrnum[index].ToString(), font, brushWhite, Retangels[listExisted[index]]);
                        Tools.sortDic.Add(arrnum[index], Retangels[listExisted[index]]);
                    }

                    if (checkBox2.Checked)
                    {
                        img.Save(Guid.NewGuid().ToString() + ".png");
                    }
                    this.Invoke(new Action(() =>
                    {
                        pictureBox.Image = img;
                    }));
                    Thread.Sleep(showTime);
                    foreach (var index in listExisted)
                    {
                        graphics.FillRectangle(brushWhite, new Rectangle(Retangels[index], new Size(fontSize / 2, fontSize / 2)));
                     
                    }
                    this.Invoke(new Action(() =>
                    {
                        pictureBox.Image = null;
                        pictureBox.Image = img;
                    }));
                    Tools.isCanPlay = true;
                    await isNext(graphics, pictureBox, img);
                    Tools.isCanPlay = true;

                    Thread.Sleep(transitionTime);
                    this.Invoke(new Action(() =>
                    {
                        pictureBox.Image = null;

                    }));
                    Thread.Sleep(transitionTime);

                }
                img.Dispose();



            }



        }



        async Task<bool> isNext(Graphics graphics, PictureBox pic, Image img)
        {
            bool flag = true;
            //int dawTtime = 0;
            while (flag)
            {

                if (Tools.sucecssCount == 0)
                {
                    await Task.Delay(200);
                    continue;
                }
                if (Tools.sucecssCount == -1)
                {
                    (string word, Point clickBoxPos) = Tools.getCurrentRealPos();
                    graphics.FillRectangle(Brushes.Black, new Rectangle(clickBoxPos, new Size(fontSize / 2, fontSize / 2)));
                    Font font = new Font("Arial", this.fontSize / 2, GraphicsUnit.Pixel);

                    graphics.DrawString(word, font, Brushes.Red, clickBoxPos);
                    this.BeginInvoke(() =>
                    {
                        pic.Image = img;
                        pic.Refresh();
                    });
                    //MessageBox.Show("failed!");
                    Tools.reset();
                    await Task.Delay(200);
                    return true;
                }
                else if (Tools.sucecssCount == wordnum)
                {
                    graphics.FillRectangle(Brushes.Black, new Rectangle(Tools.getCurrentRealPos(Tools.sucecssCount - 1), new Size(fontSize / 2, fontSize / 2)));
                    this.BeginInvoke(() =>
                    {
                        pic.Image = img;
                        pic.Refresh();
                    });
                    Tools.reset();
                    await Task.Delay(200);
                    return true;
                }
                else
                {
                    if (isRunning == false)
                    {
                        form2.Close();
                        this.button1.Enabled = true;
                        flag = false;
                        Task.WaitAll();

                    };

                    graphics.FillRectangle(Brushes.Black, new Rectangle(Tools.getCurrentRealPos(Tools.sucecssCount - 1), new Size(fontSize / 2, fontSize / 2)));

                    this.BeginInvoke(() =>
                    {
                        pic.Image = img;
                        pic.Refresh();
                    });
                    await Task.Delay(200);

                }



            }
            return false;
        }




        private void button1_Click(object sender, EventArgs e)
        {

            isRunning = false;
            try
            {
                this.button1.Enabled = false;
                token.Cancel();

            }
            catch (TaskCanceledException)
            {
                Trace.WriteLine("Task canceled TaskCanceledException.");
            }
            catch (Exception ex)
            {
                Trace.WriteLine("Unexpected exception: " + ex.Message);
            }


        }
    }
}