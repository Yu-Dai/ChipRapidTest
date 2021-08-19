using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GitHub.secile.Video;

namespace ChipRapidTest
{
    public partial class Form1 : Form
    {
        public bool updatelock = false;
        public bool isBack_NeedCorrection = false;
        public int AutoScaling_process = 20;
        //進度顯示
        public string Process_Now = "";
        //筏值
        public double BaseLineRMSE_threshold_number, FWHM_RMSE_threshold_number;
        public int EXP_Level_number, Gamma_Level_number;
        public int gamma_number = 100;
        public bool isPass = false, isNg = false , Is_back_number_Max = false;
        public bool isScalePass = false, isScaleNg = false;
        public List<double> Hg_Ar_PassNg = new List<double>();
        public List<double> White_PassNg = new List<double>();
        Point ROI_Point;
        delegate void FormUpdata3(List<double> Data);
        #region AutoScaling
        private List<int> exp_recorder = new List<int>();
        public int Scaling_Times = 0;
        public int back_number = 0;
        public bool isGetROI = false;
        delegate void Dg_Update(int dg);
        delegate void Gamma_Update(int gamma);
        delegate void Back_Update(int back);
        delegate void set_camera_prop_dele(string item, int prop_num);
        // List<double> result_buffer = new List<double>();
        List<double> dg_set = new List<double>();
        List<double> Max_Intensity = new List<double>();
        public string final_dg = "";
        public string final_gamma = "";
        public string final_back = "";
        public double Index_of_Max = 0;
        public double dark_avg = 0;
        #endregion
        public bool isAutoScalingEnd = false;
        public string File_Name = "";
        delegate void FormUpdata(int ROI_Yx);
        private bool isMeasureEnd;
        private static int iTask = 999999;
        private static int inTimer = 0;
        private bool bCameraLive;
        UsbCamera camera;
        #region 比例參數
        private static int scaleX = 1;
        private static int scaleY = 1;
        #endregion
        #region Roi
        private static int ROI_Xx = 0;
        private static int ROI_Yx = 0;
        private static int ROI_Wx = 1280;
        private static int ROI_Hx = 20;
        private static int ROI_Xy = 0;
        private static int ROI_Yy = 0;
        private static int ROI_Wy = 20;
        private static int ROI_Hy = 960;
        public static int ROI_3_X = 0;
        public static int ROI_3_Y = 0;
        #endregion
        //===============================================================
        #region Intensity
        public List<double> RealTime_Original_Intensity = new List<double>();
        public List<double> Dark_Intensity = new List<double>();
        private bool isGetDarkIntensity = false;
        #endregion
        public Form1()
        {
            InitializeComponent();
        }
        void load_Matlab()
        {
            List<double> forTest = new List<double>() { 2, 4 };
            List<double> forTest2 = new List<double>() { 6, 8 };
            List<double> Loading = Method.Polynomial_Fitting(forTest, forTest2, 1);
            MessageBox.Show("載入完成");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (bCameraLive == false)
            {
                set_camera_prop("exp", -2);
                set_camera_prop("bright", 500);
                set_camera_prop("con", 0);

                set_camera_prop("hue", -2000);
                set_camera_prop("sat", 0);
                set_camera_prop("sharp", 1);
                //gamma
                set_camera_prop("white", 2800);
                //back
                //gain
                set_camera_prop("gain", 150);

                set_camera_prop("gamma", 100);
                set_camera_prop("back", 2);

                load_Matlab();

                bCameraLive = true;
                camera.Start();

                //var bmp = camera.GetBitmap();
                btnStart.Text = "Stop";
                // show image in PictureBox.
                timer1.Start();
                button1.Enabled = true;
            }
            else
            {
                bCameraLive = false;
                btnStart.Text = "Start";
                timer1.Stop();
                camera.Stop();
                button1.Enabled = false;
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            int cameraIndex = 0;
            // check format.
            string[] devices = UsbCamera.FindDevices();
            if (devices.Length == 0) return; // no camera.

            UsbCamera.VideoFormat[] formats = UsbCamera.GetVideoFormat(cameraIndex);
            //for (int i = 0; i < formats.Length; i++) Console.WriteLine("{0}:{1}", i, formats[i]);

            // create usb camera and start.
            camera = new UsbCamera(cameraIndex, formats[11]); //1280*960
            Console.WriteLine(formats[8] + "\n" + formats[9] + "\n" + formats[10] + "\n" + formats[11]);
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            //========================Timer1用來執行:定時取像(刷影像)，畫圖============================

            #region 每N秒取像，畫圖
            Bitmap myBitmap = camera.GetBitmap();
            myBitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);//影像轉向 才能符合正確光譜圖形
            scaleX = camera.Size.Width / CCDImage.Width;
            scaleY = camera.Size.Height / CCDImage.Height;
            int x = DrawCanvas.Left * scaleX;
            int y = DrawCanvas.Top * scaleY;
            int w = DrawCanvas.Width * scaleX;
            int h = DrawCanvas.Height * scaleY;
            Rectangle cloneRect = new Rectangle(x, y, w, h);
            System.Drawing.Imaging.PixelFormat format = myBitmap.PixelFormat;
            Bitmap cloneBitmap = Method.crop(myBitmap, cloneRect);
            //Bitmap cloneBitmap = myBitmap.Clone(cloneRect, format);
            //Bitmap cloneBitmap_For_Pbox = myBitmap.Clone(cloneRect, format);
            //CCDImage.Image = myBitmap;
            //ROIImage.Image = cloneBitmap;          
            ROIImage.Left = DrawCanvas.Left;
            ROIImage.Top = DrawCanvas.Top;
            ROIImage.Height = DrawCanvas.Height;
            ROIImage.Width = DrawCanvas.Width;
            byte[] FULLBuffer = Method.ImageToBuffer(myBitmap, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] ROIBuffer = Method.ImageToBuffer(cloneBitmap, System.Drawing.Imaging.ImageFormat.Bmp);
            displayOriginal(ROIBuffer, 0);

            #region 畫ROI矩形
            if (isGetROI)
            {
                Graphics g = Graphics.FromImage(myBitmap);
                Rectangle rect1 = new Rectangle(ROI_Xx, ROI_Yx, ROI_Wx, ROI_Hx);
                g.DrawRectangle(new Pen(Color.White, 2), rect1);
            }
            #endregion
            CCDImage.Image = myBitmap;
            ROIImage.Image = cloneBitmap;

            if (Interlocked.Exchange(ref inTimer, 1) == 1)
                return;

            if (ROIBuffer == null)
            {
                Interlocked.Exchange(ref inTimer, 0);
                return;
            }
            Text = "Process...";
            //Image Process
            var processTask1 = SpertroImageProcess(FULLBuffer);
            Task processFinishTask1 = await Task.WhenAny(processTask1);
            Interlocked.Exchange(ref inTimer, 0);
            #endregion

        }
        private async Task<bool> SpertroImageProcess(byte[] FULLimgbuffer)
        {
            FormUpdata formcontrl = new FormUpdata(FormUpdataMethod);
            FormUpdata3 formcontrl3 = new FormUpdata3(ImageSave);
            await Task.Run(() =>
            {
                //=========================程式的主要區域(每個步驟)===========================
                #region 主要區域
                switch (iTask)
                {
                    case 0:
                        Process_Now = "";
                        MessageBox.Show("測量結束");
                        iTask = 99999999;
                        isMeasureEnd = true;
                        break;
                    case 1:
                        Process_Now = "測量開始(0%)";
                        iTask = 3;
                        break;
                    case 3:
                       // Set_Dg(150);
                        //Set_Gamma(100);
                        //Set_Back(2);
                        iTask = 5;
                        Thread.Sleep(500);
                        Process_Now = "取暗光譜(5%)";
                        break;
                    case 5:
                        if (isGetDarkIntensity == false)
                        {
                            Dark_Intensity = RealTime_Original_Intensity;
                            dark_avg = Dark_Intensity.Average();
                            isGetDarkIntensity = true;
                        }
                        iTask = 50;
                        Process_Now = "ROI_SCAN開始(10%)";
                        break;

                    case 50:
                        if (isGetROI == false)
                        {
                            Bitmap Image_0 = Method.BufferToBitmap(FULLimgbuffer);
                            IDictionary<string, int> ROI_x = Method.RoiScan_X(Image_0,Convert.ToInt32(ROI_StartPoint_txb.Text));
                            ROI_Xx = ROI_x["x"]; ROI_Yx = ROI_x["y"]; ROI_Wx = ROI_x["w"]; ROI_Hx = ROI_x["h"];
                            isGetROI = true;
                        }
                        iTask = 75;
                        break;

                    case 75:
                        Process_Now = "重置Gamma(15%)";
                        Set_Gamma(100);
                        iTask = 80;
                        break;
                    case 80:
                        Process_Now = "AutoScaling開始(20%)";
                        iTask = 100;
                        break;

                    case 100:
                        Set_Dg(220);
                        if (back_number > 3)//注意此時back_numer = 4 AutoScaling算完要校正回3
                        {
                            isBack_NeedCorrection = true;
                            if (gamma_number > 300)
                            {
                                Process_Now = "所有亮度參數已達最高(Error)";
                                iTask = 0;
                                MessageBox.Show("所有亮度參數已達最高仍無法達標，請降低AutoScaling%標準");
                            }
                            else
                            {
                                AutoScaling_process += 5;
                                Process_Now = "AutoScal設定Gamma : " + gamma_number.ToString() + "(" + AutoScaling_process.ToString() + "%)";
                                Set_Gamma(gamma_number);
                                Is_back_number_Max = true;
                                iTask = 150;
                            }
                        }
                        else
                        {
                            AutoScaling_process+=5;
                            Process_Now = "AutoScal設定Back : "+back_number.ToString()+"("+ AutoScaling_process.ToString()+ "%)";
                            Set_Back(back_number);
                            iTask = 150;
                        }
                        Thread.Sleep(1000);
                        break;

                    case 150:
                        Thread.Sleep(1500);
                        dg_set.Clear();
                        Max_Intensity.Clear();
                        //Step 0 找到最大值的位置 紀錄此時的"dg,max",index
                        List<double> result_buffer = Smart_Calibrate_DG_Intensity(RealTime_Original_Intensity, Index_of_Max); //輸出一個dg值
                        if (result_buffer[1] >= 250)// - dark_avg)
                        {
                            iTask = 150;
                            Index_of_Max = 0;
                            Scaling_Times++;
                            if (result_buffer[0] == 32 && Scaling_Times >= 2)
                            {
                                iTask = 0;
                                MessageBox.Show("DG以達最低");
                            }
                        }
                        else
                        {
                            dg_set.Add(result_buffer[0]);
                            Max_Intensity.Add(result_buffer[1]);
                            Index_of_Max = result_buffer[2];
                            //  Set_Dg_half();//-------------
                            iTask = 200;
                        }
                        Thread.Sleep(3000);
                        break;

                    case 200:
                        double max_ = Convert.ToDouble(AutoScale_txb.Text);
                        int Goal_intensity = Convert.ToInt32(256 * (max_ / 100));
                        //Step 1 根據最大值的位置 找到dg/2後的dg,"max",index
                        List<double> result_buffer2 = Smart_Calibrate_DG_Intensity(RealTime_Original_Intensity, Index_of_Max); //輸出一個dg值
                        dg_set.Add(result_buffer2[0]);
                        Max_Intensity.Add(result_buffer2[1]);

                        List<double> Auto_Scaling_Coef = Method.Polynomial_Fitting(Max_Intensity, dg_set, 1);

                        int show_new_dg = (int)Math.Round((Auto_Scaling_Coef[0] + Auto_Scaling_Coef[1] * Goal_intensity), 2);
                        if (show_new_dg >= 254)// - dark_avg)
                        {
                            if (Is_back_number_Max)
                            {
                                gamma_number += 100;
                            }
                            else
                            {
                                    back_number++;
                            }
                            Index_of_Max = 0;
                            iTask = 100;
                        }
                        else
                        {
                            if (show_new_dg < 32)
                            {
                                Set_Dg(32);
                            }
                            else
                            {
                                Task.Delay(300);
                                Process_Now = "AutoScal設定DG : " + show_new_dg.ToString() + "(60%)";
                                Set_Dg(show_new_dg); 
                            }
                            isAutoScalingEnd = true;
                            iTask = 220;
                        }
                        break;

                    case 220:
                        Thread.Sleep(1500);
                        iTask = 230;
                        break;

                    case 230:
                        if (isBack_NeedCorrection)//是否需校正
                        {
                            back_number = 3;  //back_number校正回3
                        }
                        iTask = 235;
                        Process_Now = "AutoScaling完成(65%)";
                        break;
                    case 235:
                        iTask = 250;
                        Process_Now = "存AutoScaling後光譜(70%)";
                        break;
                    case 250://====================================================分歧點: 如果測量為汞氬燈或白光則繼續往下===================================
                        this.Invoke(formcontrl3, RealTime_Original_Intensity);
                        if (HgAr_Mode_btn.Checked)
                        {
                            iTask = 300;
                            Process_Now = "計算汞氬燈各項數據(75%)";
                        }
                        else if (White_Mode_btn.Checked) 
                        {
                            iTask = 300;
                            Process_Now = "計算白光各項數據(75%)";
                        }
                        else
                        {
                            iTask = 275;
                            Process_Now = "亮度參數通過判定(75%)";
                        }
                        break;

                    case 275://亮度通過與否判定 -----#一般單雷射模式
                        if (back_number < EXP_Level_number &&gamma_number < Gamma_Level_number)
                        {
                            isPass = true;
                        }
                        else
                        {
                            isNg = true;
                        }
                        Thread.Sleep(1500);
                        //CaptureWindow("Result_AfterLorentz And addBaseLine");//截圖
                        iTask = 375;

                        Process_Now = "判定結束(90%)";
                        break;

                    case 300://通過與否判定 -----#汞氬燈模式 或 白光模式
                        if (HgAr_Mode_btn.Checked)
                        {
                            Hg_Ar_PassNg = Method.Hg_Ar_PassNgTest(RealTime_Original_Intensity, textBox1.Text);
                            iTask = 350;
                            Process_Now = "通過與否判定開始(85%)";
                        }
                        else if (White_Mode_btn.Checked) {
                            White_PassNg = Method.White_PassNgTest(RealTime_Original_Intensity, textBox1.Text);
                            iTask = 350;
                            Process_Now = "通過與否判定開始(85%)";
                        }
                       
                        break;
                    case 350:
                        if (HgAr_Mode_btn.Checked)
                        {
                            if (Hg_Ar_PassNg[1] < BaseLineRMSE_threshold_number &&
                            Hg_Ar_PassNg[2] < FWHM_RMSE_threshold_number &&
                            back_number < EXP_Level_number &&
                            gamma_number < Gamma_Level_number)
                            {                           
                                    isPass = true;                              
                            }
                            else
                            {
                                isNg = true;
                            }
                            if (hg_scale_passng_CKB.Checked)
                            {
                                if (Hg_Ar_PassNg[7] > Convert.ToDouble(P1_Scale_txb.Text)
                                  && Hg_Ar_PassNg[8] > Convert.ToDouble(P2_Scale_txb.Text)
                                  && Hg_Ar_PassNg[9] > Convert.ToDouble(P3_Scale_txb.Text))
                                {
                                    isScalePass = true;
                                }
                                else { isScaleNg = true; }
                            }
                                                  
                        }
                        else if (White_Mode_btn.Checked)
                        {
                            if (White_PassNg[1] < Convert.ToDouble(LedBlueFWHM_threshold.Text) &&
                            White_PassNg[2] < Convert.ToDouble(LedYellowFWHM_threshold.Text) &&
                            back_number < EXP_Level_number &&
                            gamma_number < Gamma_Level_number)
                            {                             
                                    isPass = true;                              
                            }
                            else
                            {
                                isNg = true;
                            }
                            if (White_scale_passng_CKB.Checked)
                            {
                                if (White_PassNg[3] > Convert.ToDouble(Blue_Scale_txb.Text))
                                {
                                    isScalePass = true;
                                }
                                else { isScaleNg = true; }
                            }
                        }

                        Thread.Sleep(1500);
                        //CaptureWindow("Result_AfterLorentz And addBaseLine");//截圖
                        iTask = 375;

                        Process_Now = "判定結束(90%)";
                        break;

                    case 375:  //========================================方法分崎後的匯集點=================================
                        isMeasureEnd = true;
                        iTask = 400;
                        Process_Now = "結果存檔(95%)";
                        break;

                    case 400:
                        this.Invoke(formcontrl3, RealTime_Original_Intensity);
                        iTask = 0;
                        Process_Now = "測量完畢(100%)";
                        break;
                }
                this.Invoke(formcontrl, Convert.ToInt32(ROI_Yx / scaleY));
                #endregion
            });

            return true;
        }
        void ImageSave(List<double> Intensity)
        {
            
            if (isMeasureEnd)
            {
                chart_original.SaveImage(@"量測結果\" + File_Name + @"\" + File_Name + "_(Pixel)_Image" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm") + ".jpg", ImageFormat.Bmp);
            }
            else
            {
                trackBar1.Value = ROI_Yx;
                List<string> Save = new List<string>();
                for (int i = 0; i < Intensity.Count; i++)
                {
                    Save.Add(Intensity[i].ToString());
                }
                File.WriteAllLines(@"量測結果\" + File_Name + @"\" + File_Name + "_Raw_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm") + ".txt", Save.ToArray());
                CCDImage.Image.Save(@"量測結果\" + File_Name + @"\" + File_Name + "_FullImage" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm") + ".jpg");
                ROIImage.Image.Save(@"量測結果\" + File_Name + @"\" + File_Name + "_RoiImage" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm") + ".jpg");
            }
        }
        private void displayOriginal(byte[] input_image_buffer, int start_pixel)//育代
        {
            Bitmap input_image = Method.BufferToImage(input_image_buffer);
            int W;
            int H;
            W = input_image.Width;
            H = input_image.Height;

            int Pixel_x = 0;//正在被掃描的點
            int Pixel_y = 0;

            System.Windows.Forms.DataVisualization.Charting.Series seriesGray = new System.Windows.Forms.DataVisualization.Charting.Series("灰階", 2000);
            RealTime_Original_Intensity = Method.get_Original_Intensity(input_image);
            /* if (isGetDarkIntensity)
             {
                 RealTime_Original_Intensity = Method.Remove_BaseLine(RealTime_Original_Intensity,Dark_Intensity);
             }*/
            //設定座標大小
            this.chart_original.ChartAreas[0].AxisY.Minimum = 0;
            this.chart_original.ChartAreas[0].AxisY.Maximum = 300;
            this.chart_original.ChartAreas[0].AxisX.Minimum = start_pixel;
            this.chart_original.ChartAreas[0].AxisX.Maximum = start_pixel + W;

            input_image.Dispose();

            //設定標題
            this.chart_original.Titles.Clear();
            this.chart_original.Titles.Add("S01");
            if (isMeasureEnd)
            {
                if (HgAr_Mode_btn.Checked)
                {
                    this.chart_original.Titles[0].Text = File_Name + "  原始雷射光譜" + "\r\n"
                        + "DG,Gamma,BackLight :" + label_DG.Text + "," + label_Gamma.Text + "," + label_Back_Light.Text + "\r\n"
                        + "BaseLine_RMSE : " + Math.Round(Hg_Ar_PassNg[1], 2).ToString() + "\r\n" + "FWHM_RMSE : " + Math.Round(Hg_Ar_PassNg[2], 2).ToString() + "\r\n" 
                        + "P1/P3 : " + Math.Round(Hg_Ar_PassNg[7], 2).ToString() + "P2/P3 : " + Math.Round(Hg_Ar_PassNg[8], 2).ToString() + "P4/P3 : " + Math.Round(Hg_Ar_PassNg[9], 2).ToString();
                }
                else if (White_Mode_btn.Checked)
                {
                    this.chart_original.Titles[0].Text = File_Name + "  原始雷射光譜" + "\r\n"
                        + "DG,Gamma,BackLight :" + label_DG.Text + "," + label_Gamma.Text + "," + label_Back_Light.Text + "\r\n"
                        + "BaseLine_RMSE : " + Math.Round(White_PassNg[1], 2).ToString() + "\r\n" + "FWHM_RMSE : " + Math.Round(White_PassNg[2], 2).ToString() + "\r\n"
                        +"Blue_Scale : " + Math.Round(White_PassNg[3], 2).ToString();
                }
                else
                {
                    this.chart_original.Titles[0].Text = File_Name + "  原始雷射光譜" + "\r\n"
                        + "DG,Gamma,BackLight :" + label_DG.Text + "," + label_Gamma.Text + "," + label_Back_Light.Text;
                }
            }
            else
            {
                this.chart_original.Titles[0].Text = File_Name + "  原始雷射光譜";
            }
            this.chart_original.Titles[0].ForeColor = Color.Black;
            this.chart_original.Titles[0].Font = new System.Drawing.Font("標楷體", 16F);
            //設定顏色
            seriesGray.Color = Color.Blue;

            //設定樣式
            seriesGray.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //迴圈二
            for (Pixel_x = 0; Pixel_x < W; Pixel_x++)
            {
                //給入數據畫圖
                seriesGray.Points.AddXY(Pixel_x + start_pixel, RealTime_Original_Intensity[Pixel_x]);
                this.chart_original.Series.Clear();
                this.chart_original.Series.Add(seriesGray);
            }
        }
        #region 相機參數調整_DG_GAMMA_BACK
        private bool Calibrate_EXP(byte[] Input_Image)
        {
            //  int prop = camera.Properties[DirectShow.CameraControlProperty.Exposure];
            int speed;
            int Max;
            int def_exp = -5;
            int max_exp = -2;
            int min_exp = -11;
            //  displayOriginal(imgbuffer, x, x + imgbuffer.Width);
            //影像處理程序 把Do While 刪除 寫在這
            //測試用

            //     Test_Image = Input_Image.Clone(cloneRect_original, format);

            List<int> Speed_and_Max = new List<int>();
            Speed_and_Max = Method.Control_EXP(Input_Image);
            speed = Speed_and_Max[0];
            Max = Speed_and_Max[1];
            //    var Last_EXP = camera.Properties[DirectShow.CameraControlProperty.Exposure];
            UsbCamera.PropertyItems.Property prop;
            prop = camera.Properties[DirectShow.CameraControlProperty.Exposure];
            if (prop.Available)
            {
                max_exp = prop.Max;
                min_exp = prop.Min;
                def_exp = prop.Default;

            }
            set_camera_prop_dele camera_prop = new set_camera_prop_dele(set_camera_prop);
            switch (speed)
            {
                case 2:
                    // this.Invoke(camera_prop, "exp", (def_exp - min_exp) /2+ min_exp);
                    this.Invoke(camera_prop, "exp", def_exp - 1);
                    break;
                case 1:
                    this.Invoke(camera_prop, "exp", def_exp - 1);
                    break;
                case 0:
                    Console.WriteLine("Good");
                    break;
                case -1:
                    this.Invoke(camera_prop, "exp", def_exp + 1);
                    break;
                case -2:
                    this.Invoke(camera_prop, "exp", def_exp + 1);
                    break;
                case -3:
                    this.Invoke(camera_prop, "exp", def_exp + 1);
                    break;
                default:
                    Console.WriteLine("The color is unknown.");
                    break;
            }




            if (speed == 0) return true;
            else return false;

        }

        private List<double> Smart_Calibrate_DG_Intensity(List<double> Input_List, double index) //.
        {




            int Max = 1;
            int def_dg = 100;
            int max_dg = 255;
            int min_dg = 32;
            List<double> result = new List<double>();



            UsbCamera.PropertyItems.Property prop;
            set_camera_prop_dele camera_prop = new set_camera_prop_dele(set_camera_prop);
            prop = camera.Properties[DirectShow.VideoProcAmpProperty.Gain];
            if (prop.Available)
            {
                max_dg = prop.Max;
                min_dg = prop.Min;
                def_dg = prop.Default;

            }


            //  this.Invoke(camera_prop, "gain", def_dg);
            if (index == 0)
            {
                double Max_Intensity = Input_List.Max();
                int Index_of_Max = Input_List.IndexOf(Max_Intensity);
                result.Add(def_dg);//[0] 是否過曝  0:
                result.Add(Max_Intensity);//[0] 此時的值
                result.Add(Index_of_Max);//[1] 發生的位置
                this.Invoke(camera_prop, "gain", Convert.ToInt32(def_dg / 2));
            }
            else
            {
                double New_Max_Intensity = Input_List[Convert.ToInt32(index)];
                result.Add(def_dg);//[0] 是否過曝  0:
                result.Add(New_Max_Intensity);//[0] 此時的值
                result.Add(Convert.ToInt32(index));//[1] 發生的位置


            }



            return result;


        }

        private bool Calibrate_DG_Intensity(List<double> Input_List)
        {
            //  int prop = camera.Properties[DirectShow.CameraControlProperty.Exposure];
            double speed;
            double Max;
            int def_dg = -5;
            int max_dg = -2;
            int min_dg = -11;
            //  displayOriginal(imgbuffer, x, x + imgbuffer.Width);
            //影像處理程序 把Do While 刪除 寫在這
            //測試用

            //     Test_Image = Input_Image.Clone(cloneRect_original, format);

            List<double> Speed_and_Max = new List<double>();
            Speed_and_Max = Method.Control_EXP_List(Input_List);
            speed = Speed_and_Max[0];
            Max = Speed_and_Max[1];
            //    var Last_EXP = camera.Properties[DirectShow.CameraControlProperty.Exposure];
            UsbCamera.PropertyItems.Property prop;
            prop = camera.Properties[DirectShow.VideoProcAmpProperty.Gain];
            if (prop.Available)
            {
                max_dg = prop.Max;
                min_dg = prop.Min;
                def_dg = prop.Default;

            }
            set_camera_prop_dele camera_prop = new set_camera_prop_dele(set_camera_prop);
            switch (speed)
            {
                case 2:
                    // this.Invoke(camera_prop, "exp", (def_exp - min_exp) /2+ min_exp);
                    this.Invoke(camera_prop, "gain", def_dg - 25);
                    break;
                case 1:
                    this.Invoke(camera_prop, "gain", def_dg - 8);
                    break;
                case 0:
                    Console.WriteLine("Good");
                    break;
                case -1:
                    this.Invoke(camera_prop, "gain", def_dg + 5);
                    break;
                case -2:
                    this.Invoke(camera_prop, "gain", def_dg + 30);
                    break;
                case -3:
                    this.Invoke(camera_prop, "gain", def_dg + 50);
                    break;
                default:
                    Console.WriteLine("The color is unknown.");
                    break;
            }

            if (speed == 0) return true;
            else return false;

        }
        private bool Calibrate_DG(byte[] Input_Image)
        {
            //  int prop = camera.Properties[DirectShow.CameraControlProperty.Exposure];
            int speed;
            int Max;
            int def_dg = -5;
            int max_dg = -2;
            int min_dg = -11;
            //  displayOriginal(imgbuffer, x, x + imgbuffer.Width);
            //影像處理程序 把Do While 刪除 寫在這
            //測試用

            //     Test_Image = Input_Image.Clone(cloneRect_original, format);

            List<int> Speed_and_Max = new List<int>();
            Speed_and_Max = Method.Control_EXP(Input_Image);
            speed = Speed_and_Max[0];
            Max = Speed_and_Max[1];
            //    var Last_EXP = camera.Properties[DirectShow.CameraControlProperty.Exposure];
            UsbCamera.PropertyItems.Property prop;
            prop = camera.Properties[DirectShow.VideoProcAmpProperty.Gain];
            if (prop.Available)
            {
                max_dg = prop.Max;
                min_dg = prop.Min;
                def_dg = prop.Default;

            }
            set_camera_prop_dele camera_prop = new set_camera_prop_dele(set_camera_prop);
            switch (speed)
            {
                case 2:
                    // this.Invoke(camera_prop, "exp", (def_exp - min_exp) /2+ min_exp);
                    this.Invoke(camera_prop, "gain", def_dg - 25);
                    break;
                case 1:
                    this.Invoke(camera_prop, "gain", def_dg - 8);
                    break;
                case 0:
                    Console.WriteLine("Good");
                    break;
                case -1:
                    this.Invoke(camera_prop, "gain", def_dg + 5);
                    break;
                case -2:
                    this.Invoke(camera_prop, "gain", def_dg + 20);
                    break;
                case -3:
                    this.Invoke(camera_prop, "gain", def_dg + 50);
                    break;
                default:
                    Console.WriteLine("The color is unknown.");
                    break;
            }

            if (speed == 0) return true;
            else return false;

        }

        private void Set_Dg_half()
        {

            int def_dg = 100;
            int max_dg = 255;
            int min_dg = 32;

            UsbCamera.PropertyItems.Property prop;
            set_camera_prop_dele camera_prop = new set_camera_prop_dele(set_camera_prop);
            prop = camera.Properties[DirectShow.VideoProcAmpProperty.Gain];
            if (prop.Available)
            {
                max_dg = prop.Max;
                min_dg = prop.Min;
                def_dg = prop.Default;

            }

            this.Invoke(camera_prop, "gain", Convert.ToInt32(def_dg));
        }

        private void Set_Dg(int new_dg)
        {
            Dg_Update dg_Update = new Dg_Update(Update_Dg);
            this.Invoke(dg_Update, new_dg);
            int def_dg = 100;
            int max_dg = 255;
            int min_dg = 32;

            UsbCamera.PropertyItems.Property prop;
            set_camera_prop_dele camera_prop = new set_camera_prop_dele(set_camera_prop);
            prop = camera.Properties[DirectShow.VideoProcAmpProperty.Gain];
            if (prop.Available)
            {
                max_dg = prop.Max;
                min_dg = prop.Min;
                def_dg = prop.Default;

            }
            if (new_dg >= 255)
            {
                this.Invoke(camera_prop, "gain", 255);
                // MessageBox.Show("其他參數調太暗了!已無法更亮");
            }
            else if (new_dg <= 32)
            {
                this.Invoke(camera_prop, "gain", 32);
                //MessageBox.Show("其他參數調太亮了!已無法更暗");

            }
            else
            {
                this.Invoke(camera_prop, "gain", new_dg);
            }

        }
        void set_camera_prop(string item, int prop_num)
        {
            UsbCamera.PropertyItems.Property prop;
            switch (item)
            {
                case "exp":
                    prop = camera.Properties[DirectShow.CameraControlProperty.Exposure];
                    if (prop.Available && prop.CanAuto)
                    {
                        prop.SetValue(DirectShow.CameraControlFlags.Auto, 0);
                    }
                    break;

                case "bright":
                    prop = camera.Properties[DirectShow.VideoProcAmpProperty.Brightness];
                    break;
                case "con":
                    prop = camera.Properties[DirectShow.VideoProcAmpProperty.Contrast];
                    break;
                case "hue":
                    prop = camera.Properties[DirectShow.VideoProcAmpProperty.Hue];
                    break;
                case "sat":
                    prop = camera.Properties[DirectShow.VideoProcAmpProperty.Saturation];
                    break;
                case "sharp":
                    prop = camera.Properties[DirectShow.VideoProcAmpProperty.Sharpness];
                    break;
                case "gamma":
                    prop = camera.Properties[DirectShow.VideoProcAmpProperty.Gamma];
                    break;
                case "white":
                    prop = camera.Properties[DirectShow.VideoProcAmpProperty.WhiteBalance];
                    break;
                case "back":
                    prop = camera.Properties[DirectShow.VideoProcAmpProperty.BacklightCompensation];
                    break;
                case "gain":
                    prop = camera.Properties[DirectShow.VideoProcAmpProperty.Gain];
                    break;
                default:
                    prop = camera.Properties[DirectShow.VideoProcAmpProperty.Gain];
                    break;


            }

            if (prop.Available)
            {
                var min = prop.Min;
                var max = prop.Max;
                var def = prop.Default;
                var step = prop.Step;


                if (prop_num <= min)
                {
                    prop.Default = min;
                }
                else if (prop_num >= max)
                {

                    prop.Default = max;
                }
                else
                {
                    prop.Default = prop_num;
                }
                exp_recorder.Add(prop.Default);
                Console.WriteLine(exp_recorder);
                prop.SetValue(DirectShow.CameraControlFlags.Manual, prop.Default);




            }

            var q = from p in exp_recorder
                    group p by p.ToString() into g
                    where g.Count() > 2//出現1次以上的數字
                    select new
                    {
                        g.Key,
                        NumProducts = g.Count()
                    };
            foreach (var x in q)
            {
                Console.WriteLine(x.Key);//陣列中 每個數字出現的數量
            }
            Console.ReadLine();

        }
        private void Set_Gamma(int new_gamma)
        {
            Gamma_Update gamma_Update = new Gamma_Update(Update_Gamma);
            this.Invoke(gamma_Update, new_gamma);
            int def_gamma = 100;
            int max_gamma = 100;
            int min_gamma = 300;

            UsbCamera.PropertyItems.Property prop;
            set_camera_prop_dele camera_prop = new set_camera_prop_dele(set_camera_prop);
            prop = camera.Properties[DirectShow.VideoProcAmpProperty.Gamma];
            if (prop.Available)
            {
                max_gamma = prop.Max;
                min_gamma = prop.Min;
                def_gamma = prop.Default;

            }
            if (new_gamma >= 300)
            {
                this.Invoke(camera_prop, "gamma", 300);
                //MessageBox.Show("其他參數調太暗了!已無法更亮");
            }
            else if (new_gamma <= 100)
            {
                this.Invoke(camera_prop, "gamma", 100);
                //MessageBox.Show("其他參數調太亮了!已無法更暗");

            }
            else
            {
                this.Invoke(camera_prop, "gamma", new_gamma);
            }

        }

        private void Set_Back(int new_back)
        {
            Gamma_Update back_Update = new Gamma_Update(Update_Back);
            this.Invoke(back_Update, new_back);
            int def_back = 1;
            int max_back = 3;
            int min_back = 0;

            UsbCamera.PropertyItems.Property prop;
            set_camera_prop_dele camera_prop = new set_camera_prop_dele(set_camera_prop);
            prop = camera.Properties[DirectShow.VideoProcAmpProperty.BacklightCompensation];
            if (prop.Available)
            {
                max_back = prop.Max;
                min_back = prop.Min;
                def_back = prop.Default;

            }
            if (new_back >= 3)
            {
                this.Invoke(camera_prop, "back", 3);
                //MessageBox.Show("其他參數調太暗了!已無法更亮");
            }
            else if (new_back <= 0)
            {
                this.Invoke(camera_prop, "back", 0);
                //MessageBox.Show("其他參數調太亮了!已無法更暗");

            }
            else
            {
                this.Invoke(camera_prop, "back", new_back);
            }

        }
        private void Update_Dg(int dg)
        {
            label_DG.Text = dg.ToString();
            if (dg > 255)
            { }
            else if (dg < 32)
            { }
            else
            {
            }
        }
        private void Update_Gamma(int gamma)
        {
            label_Gamma.Text = gamma.ToString();
            if (gamma > 300)
            { }
            else if (gamma < 100)
            { }
            else
            {
                
            }
        }
        private void Update_Back(int back)
        {
            label_Back_Light.Text = back.ToString();
            if (back > 3)
            { }
            else if (back < 0)
            { }
            else
            {
    
            }
        }


        private List<double> Smart_Calibrate_DG(byte[] Input_Image, double index) //.
        {

            int Max = 1;
            int def_dg = 100;
            int max_dg = 255;
            int min_dg = 32;
            List<double> result = new List<double>();



            UsbCamera.PropertyItems.Property prop;
            set_camera_prop_dele camera_prop = new set_camera_prop_dele(set_camera_prop);
            prop = camera.Properties[DirectShow.VideoProcAmpProperty.Gain];
            if (prop.Available)
            {
                max_dg = prop.Max;
                min_dg = prop.Min;
                def_dg = prop.Default;

            }


            //  this.Invoke(camera_prop, "gain", def_dg);
            if (index == 0)
            {
                int Max_Intensity = Input_Image.Max();
                int Index_of_Max = Array.IndexOf(Input_Image, Max_Intensity);
                result.Add(def_dg);//[0] 是否過曝  0:
                result.Add(Max_Intensity);//[0] 此時的值
                result.Add(Index_of_Max);//[1] 發生的位置
                this.Invoke(camera_prop, "gain", Convert.ToInt32(def_dg / 2));
            }
            else
            {
                int New_Max_Intensity = Input_Image[Convert.ToInt32(index)];
                result.Add(def_dg);//[0] 是否過曝  0:
                result.Add(New_Max_Intensity);//[0] 此時的值
                result.Add(Convert.ToInt32(index));//[1] 發生的位置


            }



            return result;


        }

        #endregion
        void FormUpdataMethod(int ROI_Yx)
        {
            DrawCanvas.Top = ROI_Yx;
            label4.Text = (ROI_Yx*scaleY).ToString();
            //trackBar1.Value = ROI_Yx* scaleY;
            label15.Text = (ROI_Yx* scaleY).ToString();
            //=====================比例判定======================
            if (isScalePass)
            { Scale_Result_Label.Text = "Pass"; Scale_Result_Label.ForeColor = Color.Green; isScalePass = false; }
            else if (isScaleNg)
            { Scale_Result_Label.Text = "NG"; Scale_Result_Label.ForeColor = Color.Red; isScaleNg = false; }
            //==================================================
            if (isPass)
            { Result_Label.Text = "Pass"; Result_Label.ForeColor = Color.Green; isPass = false; }
            else if (isNg)
            { Result_Label.Text = "NG"; Result_Label.ForeColor = Color.Red; isNg = false; }

            //=========================測量結束 更新控件鎖定狀態======================
            if (isMeasureEnd)
            {
                Nomal_mode_btn.Enabled = true;
                HgAr_Mode_btn.Enabled = true;
            }

            //========================更新進度textbox==================================
            if (string.IsNullOrEmpty(Process_Now) == false)
            {
                ProcessLog_txb.Text += DateTime.Now.ToString("yyyy/MM/dd/hh/mm/ss") + " : " + "\r\n" + Process_Now + "\r\n";
                ProcessLog_txb.ScrollBars = ScrollBars.Vertical;
                ProcessLog_txb.SelectionStart = ProcessLog_txb.Text.Length;
                ProcessLog_txb.ScrollToCaret();
            }
            //==========================================================================
            if (isAutoScalingEnd)
            {
                List<string> Parameter = new List<string>();
                Parameter.Add("DG: " + label_DG.Text);
                Parameter.Add("AG(gamma): " + label_Gamma.Text);
                Parameter.Add("EXP(Back_Light): " + label_Back_Light.Text);
                File.WriteAllLines(@"量測結果\" + File_Name + @"\" + File_Name+"_Parameter_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm") + ".txt", Parameter.ToArray());
                isAutoScalingEnd = false;
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string Hg_Scale = "OFF";
            string White_Scale = "OFF";
            if (hg_scale_passng_CKB.Checked)
            { Hg_Scale = "ON"; }
            if (White_scale_passng_CKB.Checked)
            { White_Scale = "ON"; }
            if (HgAr_Mode_btn.Checked)//==========================汞氬燈模式========================
            {
                if (checkBox_OnlyFirstTimeROI.Checked)
                {
                    DialogResult Message_Result =
                        MessageBox.Show("參數設定為" + "\r\n" +
                        "模式 : " + "汞氬燈量測模式" + "\r\n" +
                        "比例判定 : " + Hg_Scale + "\r\n" +
                        "校正晶片ID : " + textBox1.Text + "\r\n" +
                        "ROI : 除第一次外,不掃描" + "\r\n" +
                        "AutoScaling強度至 :" + AutoScale_txb.Text + "\r\n" +
                        "GammaLevel需 <" + Gamma_Level.Text + "\r\n" +
                        "Back Light_Level需 <" + EXP_Level.Text + "\r\n" +
                        "BaseLine_RMSE需 <" + BaseLineRMSE_threshold.Text + "\r\n" +
                        "FWHM_RMSE需 <" + FWHM_RMSE_threshold.Text + "\r\n" +
                        "\r\n" +
                        "\r\n" +
                        "確認無誤 請按YES開始測量" + "\r\n" +
                        "按 NO 停止測量"

                        , "確認參數訊息", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (Message_Result.ToString() == "Yes")
                    {
                        Result_Label.Text = "----"; Result_Label.ForeColor = Color.Black;
                        BaseLineRMSE_threshold_number = Convert.ToDouble(BaseLineRMSE_threshold.Text);
                        FWHM_RMSE_threshold_number = Convert.ToDouble(FWHM_RMSE_threshold.Text);
                        EXP_Level_number = Convert.ToInt32(EXP_Level.Text);
                        Gamma_Level_number = Convert.ToInt32(Gamma_Level.Text);
                        //==================================================================
                        Nomal_mode_btn.Enabled = false;
                        HgAr_Mode_btn.Enabled = false;
                        isMeasureEnd = false;
                        Is_back_number_Max = false;
                        File_Name = textBox1.Text;
                        isBack_NeedCorrection = false;
                        AutoScaling_process = 20;
                        if (checkBox_OnlyFirstTimeROI.Checked == false)
                        {
                            isGetROI = false;
                        }
                        back_number = 0;
                        gamma_number = 100;
                        Index_of_Max = 0;
                        iTask = 1;
                        Directory.CreateDirectory(@"量測結果\" + File_Name + @"\");
                    }
                }
                else
                {
                    DialogResult Message_Result =
                       MessageBox.Show("參數設定為" + "\r\n" +
                       "模式 : " + "汞氬燈量測模式" + "\r\n" +
                       "比例判定 : " + Hg_Scale + "\r\n" +
                       "校正晶片ID : " + textBox1.Text + "\r\n" +
                       "ROI : 每次測量皆於" + ROI_StartPoint_txb.Text + "開始掃描" + "\r\n" +
                       "AutoScaling強度至 :" + AutoScale_txb.Text + "\r\n" +
                       "GammaLevel需 <" + Gamma_Level.Text + "\r\n" +
                       "Back Light_Level需 <" + EXP_Level.Text + "\r\n" +
                       "BaseLine_RMSE需 <" + BaseLineRMSE_threshold.Text + "\r\n" +
                       "FWHM_RMSE需 <" + FWHM_RMSE_threshold.Text + "\r\n" +
                       "\r\n" +
                       "\r\n" +
                       "確認無誤 請按YES開始測量" + "\r\n" +
                       "按 NO 停止測量"

                       , "確認參數訊息", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (Message_Result.ToString() == "Yes")
                    {
                        Result_Label.Text = "----"; Result_Label.ForeColor = Color.Black;
                        BaseLineRMSE_threshold_number = Convert.ToDouble(BaseLineRMSE_threshold.Text);
                        FWHM_RMSE_threshold_number = Convert.ToDouble(FWHM_RMSE_threshold.Text);
                        EXP_Level_number = Convert.ToInt32(EXP_Level.Text);
                        Gamma_Level_number = Convert.ToInt32(Gamma_Level.Text);
                        //==================================================================
                        Nomal_mode_btn.Enabled = false;
                        HgAr_Mode_btn.Enabled = false;
                        isMeasureEnd = false;
                        Is_back_number_Max = false;
                        File_Name = textBox1.Text;
                        isBack_NeedCorrection = false;
                        AutoScaling_process = 20;
                        if (checkBox_OnlyFirstTimeROI.Checked == false)
                        {
                            isGetROI = false;
                        }
                        back_number = 0;
                        gamma_number = 100;
                        Index_of_Max = 0;
                        iTask = 1;
                        Directory.CreateDirectory(@"量測結果\" + File_Name + @"\");
                    }
                }
            }
            else if (White_Mode_btn.Checked)//===============================白光模式========================================
            {
                if (checkBox_OnlyFirstTimeROI.Checked)
                {
                    DialogResult Message_Result =
                        MessageBox.Show("參數設定為" + "\r\n" +
                        "模式 : " + "白光量測模式" + "\r\n" +
                        "比例判定 : " + White_Scale + "\r\n" +
                        "校正晶片ID : " + textBox1.Text + "\r\n" +
                        "ROI : 除第一次外,不掃描" + "\r\n" +
                        "AutoScaling強度至 :" + AutoScale_txb.Text + "\r\n" +
                        "GammaLevel需 <" + Gamma_Level.Text + "\r\n" +
                        "Back Light_Level需 <" + EXP_Level.Text + "\r\n" +
                        "BaseLine_RMSE需 <" + BaseLineRMSE_threshold.Text + "\r\n" +
                        "FWHM_RMSE需 <" + FWHM_RMSE_threshold.Text + "\r\n" +
                        "\r\n" +
                        "\r\n" +
                        "確認無誤 請按YES開始測量" + "\r\n" +
                        "按 NO 停止測量"

                        , "確認參數訊息", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (Message_Result.ToString() == "Yes")
                    {
                        Result_Label.Text = "----"; Result_Label.ForeColor = Color.Black;
                        BaseLineRMSE_threshold_number = Convert.ToDouble(BaseLineRMSE_threshold.Text);
                        FWHM_RMSE_threshold_number = Convert.ToDouble(FWHM_RMSE_threshold.Text);
                        EXP_Level_number = Convert.ToInt32(EXP_Level.Text);
                        Gamma_Level_number = Convert.ToInt32(Gamma_Level.Text);
                        //==================================================================
                        Nomal_mode_btn.Enabled = false;
                        HgAr_Mode_btn.Enabled = false;
                        isMeasureEnd = false;
                        Is_back_number_Max = false;
                        File_Name = textBox1.Text;
                        isBack_NeedCorrection = false;
                        AutoScaling_process = 20;
                        if (checkBox_OnlyFirstTimeROI.Checked == false)
                        {
                            isGetROI = false;
                        }
                        back_number = 0;
                        gamma_number = 100;
                        Index_of_Max = 0;
                        iTask = 1;
                        Directory.CreateDirectory(@"量測結果\" + File_Name + @"\");
                    }
                }
                else
                {
                    DialogResult Message_Result =
                       MessageBox.Show("參數設定為" + "\r\n" +
                       "模式 : " + "白光量測模式" + "\r\n" +
                       "比例判定 : " + White_Scale + "\r\n" +
                       "校正晶片ID : " + textBox1.Text + "\r\n" +
                       "ROI : 每次測量皆於" + ROI_StartPoint_txb.Text + "開始掃描" + "\r\n" +
                       "AutoScaling強度至 :" + AutoScale_txb.Text + "\r\n" +
                       "GammaLevel需 <" + Gamma_Level.Text + "\r\n" +
                       "Back Light_Level需 <" + EXP_Level.Text + "\r\n" +
                       "BaseLine_RMSE需 <" + BaseLineRMSE_threshold.Text + "\r\n" +
                       "FWHM_RMSE需 <" + FWHM_RMSE_threshold.Text + "\r\n" +
                       "\r\n" +
                       "\r\n" +
                       "確認無誤 請按YES開始測量" + "\r\n" +
                       "按 NO 停止測量"

                       , "確認參數訊息", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (Message_Result.ToString() == "Yes")
                    {
                        Result_Label.Text = "----"; Result_Label.ForeColor = Color.Black;
                        BaseLineRMSE_threshold_number = Convert.ToDouble(BaseLineRMSE_threshold.Text);
                        FWHM_RMSE_threshold_number = Convert.ToDouble(FWHM_RMSE_threshold.Text);
                        EXP_Level_number = Convert.ToInt32(EXP_Level.Text);
                        Gamma_Level_number = Convert.ToInt32(Gamma_Level.Text);
                        //==================================================================
                        Nomal_mode_btn.Enabled = false;
                        HgAr_Mode_btn.Enabled = false;
                        isMeasureEnd = false;
                        Is_back_number_Max = false;
                        File_Name = textBox1.Text;
                        isBack_NeedCorrection = false;
                        AutoScaling_process = 20;
                        if (checkBox_OnlyFirstTimeROI.Checked == false)
                        {
                            isGetROI = false;
                        }
                        back_number = 0;
                        gamma_number = 100;
                        Index_of_Max = 0;
                        iTask = 1;
                        Directory.CreateDirectory(@"量測結果\" + File_Name + @"\");
                    }
                }
            }
            else  //=========================================================   Nomal_Mode   ===============================================================
            {
                if (checkBox_OnlyFirstTimeROI.Checked)
                {
                    DialogResult Message_Result =
                        MessageBox.Show("參數設定為" + "\r\n" +
                        "模式 : " + "單雷射模式" + "\r\n" +
                        "校正晶片ID : " + textBox1.Text + "\r\n" +
                        "ROI : 除第一次外,不掃描" + "\r\n" +
                        "AutoScaling強度至 :" + AutoScale_txb.Text + "\r\n" +
                        "GammaLevel需 <" + Gamma_Level.Text + "\r\n" +
                        "Back Light_Level需 <" + EXP_Level.Text + "\r\n" +
                        "\r\n" +
                        "\r\n" +
                        "確認無誤 請按YES開始測量" + "\r\n" +
                        "按 NO 停止測量"

                        , "確認參數訊息", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (Message_Result.ToString() == "Yes")
                    {
                        Result_Label.Text = "----"; Result_Label.ForeColor = Color.Black;
                        BaseLineRMSE_threshold_number = Convert.ToDouble(BaseLineRMSE_threshold.Text);
                        FWHM_RMSE_threshold_number = Convert.ToDouble(FWHM_RMSE_threshold.Text);
                        EXP_Level_number = Convert.ToInt32(EXP_Level.Text);
                        Gamma_Level_number = Convert.ToInt32(Gamma_Level.Text);
                        //==================================================================
                        Nomal_mode_btn.Enabled = false;
                        HgAr_Mode_btn.Enabled = false;
                        isMeasureEnd = false;
                        Is_back_number_Max = false;
                        File_Name = textBox1.Text;
                        isBack_NeedCorrection = false;
                        AutoScaling_process = 20;
                        if (checkBox_OnlyFirstTimeROI.Checked == false)
                        {
                            isGetROI = false;
                        }
                        back_number = 0;
                        gamma_number = 100;
                        Index_of_Max = 0;
                        iTask = 1;
                        Directory.CreateDirectory(@"量測結果\" + File_Name + @"\");
                    }
                }
                else
                {
                    DialogResult Message_Result =
                       MessageBox.Show("參數設定為" + "\r\n" +
                       "模式 : " + "單雷射模式" + "\r\n" +
                       "校正晶片ID : " + textBox1.Text + "\r\n" +
                       "ROI : 每次測量皆於" + ROI_StartPoint_txb.Text + "開始掃描" + "\r\n" +
                       "AutoScaling強度至 :" + AutoScale_txb.Text + "\r\n" +
                       "GammaLevel需 <" + Gamma_Level.Text + "\r\n" +
                       "Back Light_Level需 <" + EXP_Level.Text + "\r\n" +
                       "BaseLine_RMSE需 <" + BaseLineRMSE_threshold.Text + "\r\n" +
                       "FWHM_RMSE需 <" + FWHM_RMSE_threshold.Text + "\r\n" +
                       "\r\n" +
                       "\r\n" +
                       "確認無誤 請按YES開始測量" + "\r\n" +
                       "按 NO 停止測量"

                       , "確認參數訊息", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (Message_Result.ToString() == "Yes")
                    {
                        Result_Label.Text = "----"; Result_Label.ForeColor = Color.Black;
                        BaseLineRMSE_threshold_number = Convert.ToDouble(BaseLineRMSE_threshold.Text);
                        FWHM_RMSE_threshold_number = Convert.ToDouble(FWHM_RMSE_threshold.Text);
                        EXP_Level_number = Convert.ToInt32(EXP_Level.Text);
                        Gamma_Level_number = Convert.ToInt32(Gamma_Level.Text);
                        //==================================================================
                        Nomal_mode_btn.Enabled = false;
                        HgAr_Mode_btn.Enabled = false;
                        isMeasureEnd = false;
                        Is_back_number_Max = false;
                        File_Name = textBox1.Text;
                        isBack_NeedCorrection = false;
                        AutoScaling_process = 20;
                        if (checkBox_OnlyFirstTimeROI.Checked == false)
                        {
                            isGetROI = false;
                        }
                        back_number = 0;
                        gamma_number = 100;
                        Index_of_Max = 0;
                        iTask = 1;
                        Directory.CreateDirectory(@"量測結果\" + File_Name + @"\");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> parameter = new List<string>();
            parameter.Add(Gamma_Level.Text);
            parameter.Add(EXP_Level.Text);
            parameter.Add(BaseLineRMSE_threshold.Text);
            parameter.Add(FWHM_RMSE_threshold.Text);
            parameter.Add(AutoScale_txb.Text);
            parameter.Add(ROI_StartPoint_txb.Text);
            if (checkBox_OnlyFirstTimeROI.Checked)
            {
                parameter.Add("T");
            }
            else { parameter.Add("F"); }
            if(Nomal_mode_btn.Checked)
            {
                parameter.Add("T");
            }
            else { parameter.Add("F"); }
            if (HgAr_Mode_btn.Checked)
            {
                parameter.Add("T");
            }
            else { parameter.Add("F"); }
            parameter.Add(P1_Scale_txb.Text);
            parameter.Add(P2_Scale_txb.Text);
            parameter.Add(P3_Scale_txb.Text);
            parameter.Add(LedBlueFWHM_threshold.Text);
            parameter.Add(LedYellowFWHM_threshold.Text);
            parameter.Add(Blue_Scale_txb.Text);
            File.WriteAllLines("parameter.txt", parameter);
            MessageBox.Show("參數更改成功\r\n下次開始程式時自動載入");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //=====================載入參數============================
            string[] parameter_load = File.ReadAllLines("parameter.txt");
            Gamma_Level.Text = parameter_load[0];
            EXP_Level.Text = parameter_load[1];
            BaseLineRMSE_threshold.Text = parameter_load[2];
            FWHM_RMSE_threshold.Text = parameter_load[3];
            AutoScale_txb.Text = parameter_load[4];
            ROI_StartPoint_txb.Text = parameter_load[5];
            if (parameter_load[6] == "T")
            {
                checkBox_OnlyFirstTimeROI.Checked = true;
            }
            else
            {
                checkBox_OnlyFirstTimeROI.Checked = false;
            }
            if (parameter_load[7] == "T")
            {
                Nomal_mode_btn.Checked = true;
            }
            else
            {
                Nomal_mode_btn.Checked = false;
            }
            if (parameter_load[8] == "T")
            {
                HgAr_Mode_btn.Checked = true;
            }
            else
            {
                HgAr_Mode_btn.Checked = false;
            }
            P1_Scale_txb.Text = parameter_load[9];
            P2_Scale_txb.Text = parameter_load[10];
            P3_Scale_txb.Text = parameter_load[11];
            LedBlueFWHM_threshold.Text = parameter_load[12];
            LedYellowFWHM_threshold.Text = parameter_load[13];
            Blue_Scale_txb.Text = parameter_load[14];           
            //=======================================================
            DrawCanvas.Parent = CCDImage;
            ROIImage.Parent = panel1;
            //初始化 ROI位置
            ROI_Point.X = 0;
            ROI_Point.Y = 0;
            DrawCanvas.Left = ROI_Point.X;
            DrawCanvas.Top = ROI_Point.Y;

            CCDImage.Width = 320;
            CCDImage.Height = 240;
            panel1.Width = 320;
            panel1.Height = 240;
            ROIImage.Width = 320;
            ROIImage.Height = 240;

            DrawCanvas.Width = CCDImage.Width;
            DrawCanvas.Height = 10;

        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            ROI_Yx = trackBar1.Value;
           label15.Text = trackBar1.Value.ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
