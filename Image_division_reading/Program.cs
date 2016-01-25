using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Drawing.Imaging;



namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 画像を読み込む
            string baseFilePath = @"C:\Users\youmain\Desktop\新しいフォルダー\gadgetSample.jpg";
            Bitmap bmpBase = new Bitmap(baseFilePath);

            int xy = 0;
            int counter = 1;

            for (int i = 0; i < 5; i++ )
            {

                int y = 0;
                y = xy * 290;

                //X座標の移動
                for (int i2 = 0; i2 < 5; i2++ )
                {
                    
                    int x = 250 * i2;
                    // 画像を切り抜く
                    Rectangle rect = new Rectangle(x, y, 250, 290);
                    Bitmap bmpNew = bmpBase.Clone(rect, bmpBase.PixelFormat);

                    // 画像をJpeg形式で保存
                    string newFilePath = @"C:\Users\youmain\Desktop\新しいフォルダー\hoge" + ( counter++ ) + ".jpg";
                    bmpNew.Save(newFilePath, ImageFormat.Jpeg);

                    // 画像リソースを解放                    
                    bmpNew.Dispose();
                }

                xy++;

            }

            bmpBase.Dispose();
        }
    }
}
