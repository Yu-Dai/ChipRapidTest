using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathWorks.MATLAB.NET.Arrays;
using PolyFit_NPlot;
using hg_data_Separate;
using White_Lorentz_and_Gaussian;

namespace ChipRapidTest
{
    class Method
    {

        public static List<double> Hg_Ar_PassNgTest(List<double> HgArIntensity, string SC_ID)
        {
            List<double> Result = new List<double>();
            HgPassNgTest hg_Ar_PassNgTest = new HgPassNgTest();
            MWArray HgArIntensity_M = (MWNumericArray)HgArIntensity.ToArray();
            MWCharArray ID = (MWCharArray)SC_ID;
            MWArray Result_Parameter_M = hg_Ar_PassNgTest.hg_data_Separate(HgArIntensity_M, ID);
            double[,] Result_Parameter = (double[,])((MWNumericArray)Result_Parameter_M).ToArray(MWArrayComponent.Real);
            for (int i = 0; i < Result_Parameter.Length; i++)
            {
                Result.Add(Result_Parameter[0, i]);
            }
            hg_Ar_PassNgTest.Dispose();
            return Result;
        }

        public static List<double> White_PassNgTest(List<double> WhitetIntensity, string SC_ID)
        {
            List<double> Result = new List<double>();
            WhitePassNgTest Whitet_PassNgTest = new WhitePassNgTest();
            MWArray Intensity_M = (MWNumericArray)WhitetIntensity.ToArray();
            MWCharArray ID = (MWCharArray)SC_ID;
            MWArray Result_Parameter_M = Whitet_PassNgTest.White_Lorentz_and_Gaussian(Intensity_M, ID);
            double[,] Result_Parameter = (double[,])((MWNumericArray)Result_Parameter_M).ToArray(MWArrayComponent.Real);
            for (int i = 0; i < Result_Parameter.Length; i++)
            {
                Result.Add(Result_Parameter[0, i]);
            }
            Whitet_PassNgTest.Dispose();
            return Result;
        }
        public static List<double> get_Original_Intensity(Bitmap input_image)
        {
            int W;
            int H;
            W = input_image.Width;
            H = input_image.Height;
            Bitmap im1 = new Bitmap(W, H);//讀出原圖X軸 pixel
            int Pixel_x = 0;//正在被掃描的點
            int Pixel_y = 0;
            double[] ARed = new double[W];
            double[] AGreen = new double[W];
            double[] ABlue = new double[W];
            double[] AGray = new double[W];
            double[] IntensityRed = new double[W];
            double[] IntensityGreen = new double[W];
            double[] IntensityBlue = new double[W];
            double[] IntensityGray = new double[W];
            for (Pixel_x = 0; Pixel_x < W; Pixel_x++)
            {
                for (Pixel_y = 0; Pixel_y < H; Pixel_y++)
                {
                    //先把圖變灰階

                    Color p0 = input_image.GetPixel(Pixel_x, Pixel_y);//太快會閃退，全世界都在用image_roi
                    int R = p0.R, G = p0.G, B = p0.B;
                    int gray = (R * 313524 + G * 615514 + B * 119538) >> 20;
                    Color p1 = Color.FromArgb(gray, gray, gray);

                    ARed[Pixel_x] = ARed[Pixel_x] + R;
                    AGreen[Pixel_x] = AGreen[Pixel_x] + G;
                    ABlue[Pixel_x] = ABlue[Pixel_x] + B;
                    AGray[Pixel_x] = AGray[Pixel_x] + gray;
                }
                IntensityRed[Pixel_x] = ARed[Pixel_x] / H;//平均
                IntensityGreen[Pixel_x] = AGreen[Pixel_x] / H;//平均
                IntensityBlue[Pixel_x] = ABlue[Pixel_x] / H;//平均
                IntensityGray[Pixel_x] = AGray[Pixel_x] / H;//平均
            }
            return IntensityGray.ToList();
        }
        public static List<double> Polynomial_Fitting(List<double> X_Pixles, List<double> Y_Wavelength, int order)
        {

            MWArray order_M = (MWNumericArray)order;
            MWArray X_Pixles_M = (MWNumericArray)X_Pixles.ToArray();
            MWArray Y_Wavelength_M = (MWNumericArray)Y_Wavelength.ToArray();



            List<double> Coef_List = new List<double>();
            PF_NP pf_np = new PF_NP();

            MWArray Fit = pf_np.PolyFit_NPlot(X_Pixles_M, Y_Wavelength_M, order_M);


            return MWArray2Array(Fit).ToList();

        }
        public static List<int> Bitmap2List(Bitmap image)
        {
            List<int> list = new List<int>();

            for (int x = 0; x < image.Width; x++)
                for (int y = 0; y < image.Height; y++)
                    list.Add(Color_RGB2GrayScale(image.GetPixel(x, y)));

            return list;
        }
        private static int Color_RGB2GrayScale(Color RGB)
        {
            int R = RGB.R, G = RGB.G, B = RGB.B;
            int gray = (R * 313524 + G * 615514 + B * 119538) >> 20;
            return gray;
        }
        public static List<int> Control_EXP(byte[] image_buffer)
        {
            int speed = 0;
            Bitmap bmp = BufferToImage(image_buffer);

            int Max = Bitmap2List(bmp).Max();



            if (Max > 220)
            {
                if (Max > 240) /*超亮*/
                {
                    speed = 2;//亮度剖半
                }
                else/*一點太亮191~220*/
                {
                    speed = 1;//微調一格
                }

            }
            else if (Max < 190)
            {
                if (Max < 50)  /*根本看不到0~15*/
                {

                    speed = -3;

                }
                else if (Max < 100)/*超暗*/
                {

                    speed = -2;

                }
                else/*一點太暗100~170*/
                {
                    speed = -1; //微調一格
                }


            }
            else
            {
                speed = 0;
            }



            List<int> result = new List<int>();
            result.Add(speed);//[0] speed
            result.Add(Max);//[1] 此時的值

            return result;
        }
        public static List<double> Control_EXP_List(List<double> Input_List)
        {
            int speed = 0;


            double Max = Input_List.Max();



            if (Max > 220)
            {
                if (Max > 240) /*超亮*/
                {
                    speed = 2;//亮度剖半
                }
                else/*一點太亮191~220*/
                {
                    speed = 1;//微調一格
                }

            }
            else if (Max < 190)
            {
                if (Max < 50)  /*根本看不到0~50*/
                {

                    speed = -3;

                }
                else if (Max < 180)/*超暗50~180*/
                {

                    speed = -2;

                }
                else/*一點太暗180~190*/
                {
                    speed = -1; //微調一格
                }


            }
            else
            {
                speed = 0;
            }



            List<double> result = new List<double>();
            result.Add(speed);//[0] speed
            result.Add(Max);//[1] 此時的值

            return result;
        }
        private static double[] MWArray2Array(MWArray Array_M)
        {


            double[,] dd;
            dd = (double[,])((MWNumericArray)Array_M).ToArray();
            double[] d = new double[5];//預設大小是5，用來放POLY擬和後的參數
            for (int i = 0; i < dd.Length; i++) d[i] = dd[0, dd.Length - i - 1];

            return d;
        }
        public static Bitmap BufferToBitmap(byte[] Buffer) //改
        {
            if (Buffer == null || Buffer.Length == 0) { return null; }
            byte[] data = null;
            Image oImage = null;
            Bitmap oBitmap = null;
            //建立副本
            data = (byte[])Buffer.Clone();
            try
            {
                MemoryStream oMemoryStream = new MemoryStream(Buffer);
                //設定資料流位置
                oMemoryStream.Position = 0;
                oImage = System.Drawing.Image.FromStream(oMemoryStream);
                //建立副本
                oBitmap = new Bitmap(oImage);
            }
            catch
            {
                throw;
            }
            //return oImage;
            return oBitmap;
        }
        /// <summary>
        /// X方向ROI掃描,輸入bitmap格式影像
        /// </summary>
        /// <param name="input_image0"></param>
        /// <returns></returns>
        public static IDictionary<string, int> RoiScan_X(Bitmap input_image0 ,int skiplength)
        {
            Bitmap input_image = new Bitmap(input_image0.Width, input_image0.Height);
            input_image = input_image0;
            IDictionary<string, int> ROI = new Dictionary<string, int>();
            int progressBar = 0;
            int now_y = 0;
            int roi_fixHeight = 20; //掃描矩形的寬度
            int Pixel_x = 0;//正在被掃描的點
            int Pixel_y = 0;
            int sum_gray = 0;
            int clip = skiplength; //掃描起點，跳過起始較暗區域，進而增快速度
            List<int> sum4eachROI = new List<int>();
            now_y = clip;

            while (now_y < (input_image0.Height - roi_fixHeight))
            {
                for (Pixel_x = 0; Pixel_x < input_image0.Width; Pixel_x++)
                {
                    for (Pixel_y = now_y; Pixel_y < (now_y + roi_fixHeight); Pixel_y++)//初始值為now_y掃到now_y+20
                    {
                        Color p0 = input_image.GetPixel(Pixel_x, Pixel_y);
                        int R = p0.R, G = p0.G, B = p0.B;
                        int gray = (R * 313524 + G * 615514 + B * 119538) >> 20;

                        sum_gray = sum_gray + gray;
                    }

                }
                // Add parts to the list.
                sum4eachROI.Add(sum_gray);
                sum_gray = 0;
                now_y++;
                progressBar++;

            }
            int max = sum4eachROI.Max();
            var MAX_y = sum4eachROI.IndexOf(max) + clip;

            ROI.Add("x", 0);
            ROI.Add("y", Convert.ToInt32(MAX_y));
            ROI.Add("w", input_image0.Width);
            ROI.Add("h", roi_fixHeight);
            Console.WriteLine(progressBar);
            return ROI;
        }

        public static Bitmap BufferToImage(byte[] Buffer) //改
        {
            if (Buffer == null || Buffer.Length == 0) { return null; }
            byte[] data = null;
            Image oImage = null;
            Bitmap oBitmap = null;
            //建立副本
            data = (byte[])Buffer.Clone();
            try
            {
                MemoryStream oMemoryStream = new MemoryStream(Buffer);
                //設定資料流位置
                oMemoryStream.Position = 0;
                oImage = System.Drawing.Image.FromStream(oMemoryStream);
                //建立副本
                oBitmap = new Bitmap(oImage);
            }
            catch
            {
                throw;
            }
            //return oImage;
            return oBitmap;
        }
        public static Bitmap crop(Bitmap src, Rectangle cropRect)
        {
            // Rectangle cropRect = new Rectangle(0, 0, 400, 400);
            Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);

            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(src, new Rectangle(0, 0, target.Width, target.Height),
                      cropRect,
                      GraphicsUnit.Pixel);
            }
            return target;
        }
        public static byte[] ImageToBuffer(Image Image, System.Drawing.Imaging.ImageFormat imageFormat)
        {
            if (Image == null) { return null; }
            byte[] data = null;
            using (MemoryStream oMemoryStream = new MemoryStream())
            {
                //建立副本
                using (Bitmap oBitmap = new Bitmap(Image))
                {
                    //儲存圖片到 MemoryStream 物件，並且指定儲存影像之格式
                    oBitmap.Save(oMemoryStream, imageFormat);
                    //設定資料流位置
                    oMemoryStream.Position = 0;
                    //設定 buffer 長度
                    data = new byte[oMemoryStream.Length];
                    //將資料寫入 buffer
                    oMemoryStream.Read(data, 0, Convert.ToInt32(oMemoryStream.Length));
                    //將所有緩衝區的資料寫入資料流
                    oMemoryStream.Flush();
                }
            }
            return data;
        }
    }
}
