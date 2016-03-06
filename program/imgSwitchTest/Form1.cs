using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System.Threading;

//using System.Drawing;
using System.Drawing.Imaging;


namespace imgSwitchTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            init();
        }

        //初期設定!!
        private void init() 
        {
            //ウインドウサイズの固定
            this.SetBounds(0, 0, 250, 290, BoundsSpecified.Size);
            //メインプログラム
            imgKomagire();
            
        }

        /***********************************************************************************************************
         * 
         *              以下プログラム
         * 
         * *********************************************************************************************************/

        private Bitmap[] currentImage = new Bitmap[26];
        private Bitmap[] imga = new Bitmap[26];
        //Bitmap bmpBase = new Bitmap(@"C:\Users\youmain\Desktop\新しいフォルダー\front_01.png");
        //Image currentImage = Image.FromFile(@"C:\Users\youmain\Desktop\新しいフォルダー\hoge1.bmp");

        

        //画像を細切れにするｗ
        private void imgKomagire()
        {
            // 画像を読み込む
            string baseFilePath = @"C:\Users\youmain\Desktop\新しいフォルダー\front_01.png";
            Bitmap bmpBase = new Bitmap(baseFilePath);

            int xy = 0;
            int counter = 1;

            for (int i = 0; i < 5; i++)
            {

                int y = 0;
                y = xy * 290;

                //X座標の移動
                for (int i2 = 0; i2 < 5; i2++)
                {

                    int x = 250 * i2;
                    // 画像を切り抜く
                    Rectangle rect = new Rectangle(x, y, 250, 290); //ここで細切れにする
                    Bitmap bmpNew = bmpBase.Clone(rect, bmpBase.PixelFormat); //ここでコピーする


                    imga[counter++] = new Bitmap( bmpNew );

                    // 画像をPNG形式で保存
                    //string newFilePath = @"C:\Users\youmain\Desktop\新しいフォルダー\hoge" + (counter++) + ".png";
                    //bmpNew.Save(newFilePath, ImageFormat.Png);

                    
                    //bmpNew.Save(hoge, ImageFormat.Png);
                    //currentImage[counter++] = bmpNew;

                    // 画像リソースを解放                    
                    bmpNew.Dispose();
                }

                xy++;

            }

            bmpBase.Dispose();
        }


        
        //////////////////////////////////////////////////////////
        //
        //      自動生成()
        //
        //////////////////////////////////////////////////////////


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //描画
        private  void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            if ( imga[2] != null)
            {
                int  x = 1;

                //while (true)
                //{
                    //DrawImageメソッドで画像を座標(0, 0)の位置に表示する
                    e.Graphics.DrawImage(imga[x], 0, 0, 250, 290);
                    //x++;

                    //時間を止める
                    Thread.Sleep(2000);

                    //whileを抜ける
                   // if (x == 25) { break; }
                //}
            }
            this.Close();
            
        }
    }
}
