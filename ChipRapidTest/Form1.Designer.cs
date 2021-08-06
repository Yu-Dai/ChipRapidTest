namespace ChipRapidTest
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProcessLog_txb = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.Result_Label = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.Result = new System.Windows.Forms.Label();
            this.BaseLineRMSE_threshold = new System.Windows.Forms.TextBox();
            this.Gamma_Level = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.FWHM_RMSE_threshold = new System.Windows.Forms.TextBox();
            this.EXP_Level = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.AutoScale_txb = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_DG = new System.Windows.Forms.Label();
            this.label_Back_Light = new System.Windows.Forms.Label();
            this.label_Gamma = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ROI_StartPoint_txb = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.checkBox_OnlyFirstTimeROI = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.DrawCanvas = new System.Windows.Forms.PictureBox();
            this.CCDImage = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ROIImage = new System.Windows.Forms.PictureBox();
            this.chart_original = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label22 = new System.Windows.Forms.Label();
            this.Nomal_mode_btn = new System.Windows.Forms.RadioButton();
            this.HgAr_Mode_btn = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrawCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CCDImage)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ROIImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_original)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chart_original, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1159, 667);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(582, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.66263F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.33737F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(574, 661);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.HgAr_Mode_btn);
            this.panel1.Controls.Add(this.Nomal_mode_btn);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.ProcessLog_txb);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.AutoScale_txb);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 284);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 374);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // ProcessLog_txb
            // 
            this.ProcessLog_txb.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ProcessLog_txb.ForeColor = System.Drawing.Color.Yellow;
            this.ProcessLog_txb.Location = new System.Drawing.Point(394, 23);
            this.ProcessLog_txb.Multiline = true;
            this.ProcessLog_txb.Name = "ProcessLog_txb";
            this.ProcessLog_txb.ReadOnly = true;
            this.ProcessLog_txb.Size = new System.Drawing.Size(171, 73);
            this.ProcessLog_txb.TabIndex = 37;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label21.Location = new System.Drawing.Point(390, 3);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(95, 19);
            this.label21.TabIndex = 36;
            this.label21.Text = "當前狀況:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.Result_Label);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.Result);
            this.groupBox3.Controls.Add(this.BaseLineRMSE_threshold);
            this.groupBox3.Controls.Add(this.Gamma_Level);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.FWHM_RMSE_threshold);
            this.groupBox3.Controls.Add(this.EXP_Level);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.Location = new System.Drawing.Point(4, 181);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(450, 126);
            this.groupBox3.TabIndex = 35;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PassNgTest";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(456, 196);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 53);
            this.button2.TabIndex = 35;
            this.button2.Text = "參數存檔";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label17.Location = new System.Drawing.Point(5, 98);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(130, 19);
            this.label17.TabIndex = 26;
            this.label17.Text = "BaseRMSE < :";
            // 
            // Result_Label
            // 
            this.Result_Label.AutoSize = true;
            this.Result_Label.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Result_Label.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Result_Label.Location = new System.Drawing.Point(85, 36);
            this.Result_Label.Name = "Result_Label";
            this.Result_Label.Size = new System.Drawing.Size(37, 19);
            this.Result_Label.TabIndex = 32;
            this.Result_Label.Text = "----";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label20.Location = new System.Drawing.Point(213, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(144, 19);
            this.label20.TabIndex = 34;
            this.label20.Text = "Gamma_Level<:";
            // 
            // Result
            // 
            this.Result.AutoSize = true;
            this.Result.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Result.Location = new System.Drawing.Point(12, 35);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(67, 19);
            this.Result.TabIndex = 31;
            this.Result.Text = "Result:";
            // 
            // BaseLineRMSE_threshold
            // 
            this.BaseLineRMSE_threshold.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.BaseLineRMSE_threshold.Location = new System.Drawing.Point(141, 90);
            this.BaseLineRMSE_threshold.Name = "BaseLineRMSE_threshold";
            this.BaseLineRMSE_threshold.Size = new System.Drawing.Size(54, 33);
            this.BaseLineRMSE_threshold.TabIndex = 25;
            this.BaseLineRMSE_threshold.Text = "5";
            // 
            // Gamma_Level
            // 
            this.Gamma_Level.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Gamma_Level.Location = new System.Drawing.Point(373, 15);
            this.Gamma_Level.Name = "Gamma_Level";
            this.Gamma_Level.Size = new System.Drawing.Size(73, 33);
            this.Gamma_Level.TabIndex = 33;
            this.Gamma_Level.Text = "350";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label19.Location = new System.Drawing.Point(180, 58);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(177, 19);
            this.label19.TabIndex = 30;
            this.label19.Text = "Back_Light_Level<:";
            // 
            // FWHM_RMSE_threshold
            // 
            this.FWHM_RMSE_threshold.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FWHM_RMSE_threshold.Location = new System.Drawing.Point(373, 89);
            this.FWHM_RMSE_threshold.Name = "FWHM_RMSE_threshold";
            this.FWHM_RMSE_threshold.Size = new System.Drawing.Size(73, 33);
            this.FWHM_RMSE_threshold.TabIndex = 27;
            this.FWHM_RMSE_threshold.Text = "8";
            // 
            // EXP_Level
            // 
            this.EXP_Level.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.EXP_Level.Location = new System.Drawing.Point(373, 53);
            this.EXP_Level.Name = "EXP_Level";
            this.EXP_Level.Size = new System.Drawing.Size(73, 33);
            this.EXP_Level.TabIndex = 29;
            this.EXP_Level.Text = "4";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label18.Location = new System.Drawing.Point(212, 96);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(149, 19);
            this.label18.TabIndex = 28;
            this.label18.Text = "FWHM_RMSE<:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.Location = new System.Drawing.Point(4, 110);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(166, 19);
            this.label13.TabIndex = 24;
            this.label13.Text = "Auto Scaling to %:";
            // 
            // AutoScale_txb
            // 
            this.AutoScale_txb.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.AutoScale_txb.Location = new System.Drawing.Point(170, 105);
            this.AutoScale_txb.Name = "AutoScale_txb";
            this.AutoScale_txb.Size = new System.Drawing.Size(35, 33);
            this.AutoScale_txb.TabIndex = 23;
            this.AutoScale_txb.Text = "85";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("新細明體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(220, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 52);
            this.button1.TabIndex = 22;
            this.button1.Text = "Measure";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(4, 147);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 19);
            this.label9.TabIndex = 21;
            this.label9.Text = "ID:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox1.Location = new System.Drawing.Point(46, 142);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(159, 33);
            this.textBox1.TabIndex = 20;
            this.textBox1.Text = "SC-ID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label_DG);
            this.groupBox2.Controls.Add(this.label_Back_Light);
            this.groupBox2.Controls.Add(this.label_Gamma);
            this.groupBox2.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 103);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "感測器參數";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(8, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "DG";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(8, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gamma";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(8, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Back_Light";
            // 
            // label_DG
            // 
            this.label_DG.AutoSize = true;
            this.label_DG.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_DG.Location = new System.Drawing.Point(127, 30);
            this.label_DG.Name = "label_DG";
            this.label_DG.Size = new System.Drawing.Size(30, 19);
            this.label_DG.TabIndex = 3;
            this.label_DG.Text = "---";
            // 
            // label_Back_Light
            // 
            this.label_Back_Light.AutoSize = true;
            this.label_Back_Light.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Back_Light.Location = new System.Drawing.Point(127, 74);
            this.label_Back_Light.Name = "label_Back_Light";
            this.label_Back_Light.Size = new System.Drawing.Size(30, 19);
            this.label_Back_Light.TabIndex = 5;
            this.label_Back_Light.Text = "---";
            // 
            // label_Gamma
            // 
            this.label_Gamma.AutoSize = true;
            this.label_Gamma.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_Gamma.Location = new System.Drawing.Point(127, 51);
            this.label_Gamma.Name = "label_Gamma";
            this.label_Gamma.Size = new System.Drawing.Size(30, 19);
            this.label_Gamma.TabIndex = 4;
            this.label_Gamma.Text = "---";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ROI_StartPoint_txb);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.checkBox_OnlyFirstTimeROI);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(208, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 166);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ROI";
            // 
            // ROI_StartPoint_txb
            // 
            this.ROI_StartPoint_txb.Location = new System.Drawing.Point(130, 127);
            this.ROI_StartPoint_txb.Name = "ROI_StartPoint_txb";
            this.ROI_StartPoint_txb.Size = new System.Drawing.Size(47, 33);
            this.ROI_StartPoint_txb.TabIndex = 20;
            this.ROI_StartPoint_txb.Text = "100";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(2, 135);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(129, 19);
            this.label16.TabIndex = 19;
            this.label16.Text = "由此開始掃描";
            // 
            // checkBox_OnlyFirstTimeROI
            // 
            this.checkBox_OnlyFirstTimeROI.AutoSize = true;
            this.checkBox_OnlyFirstTimeROI.Checked = true;
            this.checkBox_OnlyFirstTimeROI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_OnlyFirstTimeROI.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.checkBox_OnlyFirstTimeROI.Location = new System.Drawing.Point(6, 29);
            this.checkBox_OnlyFirstTimeROI.Name = "checkBox_OnlyFirstTimeROI";
            this.checkBox_OnlyFirstTimeROI.Size = new System.Drawing.Size(158, 20);
            this.checkBox_OnlyFirstTimeROI.TabIndex = 18;
            this.checkBox_OnlyFirstTimeROI.Text = "僅初測時掃描ROI";
            this.checkBox_OnlyFirstTimeROI.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(12, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 19);
            this.label8.TabIndex = 9;
            this.label8.Text = "X";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(121, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 19);
            this.label6.TabIndex = 17;
            this.label6.Text = "20";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(92, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 19);
            this.label7.TabIndex = 10;
            this.label7.Text = "Y";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(40, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 19);
            this.label10.TabIndex = 16;
            this.label10.Text = "1280";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(41, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 19);
            this.label5.TabIndex = 12;
            this.label5.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(92, 100);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 19);
            this.label11.TabIndex = 15;
            this.label11.Text = "H";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(121, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 19);
            this.label4.TabIndex = 13;
            this.label4.Text = "---";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label12.Location = new System.Drawing.Point(12, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 19);
            this.label12.TabIndex = 14;
            this.label12.Text = "W";
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnStart.Location = new System.Drawing.Point(8, 313);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(137, 52);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Camera_Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.18182F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.818182F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(568, 275);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.52831F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.4717F));
            this.tableLayoutPanel4.Controls.Add(this.panel4, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(562, 241);
            this.tableLayoutPanel4.TabIndex = 25;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.trackBar1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(421, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(138, 235);
            this.panel4.TabIndex = 25;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(3, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "ROI_Y";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(16, 45);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(27, 19);
            this.label15.TabIndex = 30;
            this.label15.Text = "W";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(54, 3);
            this.trackBar1.Maximum = 960;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 238);
            this.trackBar1.TabIndex = 28;
            this.trackBar1.Value = 300;
            this.trackBar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseUp);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.DrawCanvas);
            this.panel3.Controls.Add(this.CCDImage);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(412, 235);
            this.panel3.TabIndex = 27;
            // 
            // DrawCanvas
            // 
            this.DrawCanvas.BackColor = System.Drawing.Color.Transparent;
            this.DrawCanvas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DrawCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DrawCanvas.Location = new System.Drawing.Point(0, 21);
            this.DrawCanvas.Margin = new System.Windows.Forms.Padding(0);
            this.DrawCanvas.MinimumSize = new System.Drawing.Size(8, 9);
            this.DrawCanvas.Name = "DrawCanvas";
            this.DrawCanvas.Size = new System.Drawing.Size(275, 10);
            this.DrawCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DrawCanvas.TabIndex = 4;
            this.DrawCanvas.TabStop = false;
            this.DrawCanvas.Visible = false;
            // 
            // CCDImage
            // 
            this.CCDImage.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CCDImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CCDImage.Cursor = System.Windows.Forms.Cursors.Cross;
            this.CCDImage.Location = new System.Drawing.Point(0, 0);
            this.CCDImage.Margin = new System.Windows.Forms.Padding(0);
            this.CCDImage.Name = "CCDImage";
            this.CCDImage.Size = new System.Drawing.Size(275, 164);
            this.CCDImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CCDImage.TabIndex = 1;
            this.CCDImage.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Controls.Add(this.ROIImage);
            this.panel2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Location = new System.Drawing.Point(2, 249);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(291, 24);
            this.panel2.TabIndex = 27;
            this.panel2.Visible = false;
            // 
            // ROIImage
            // 
            this.ROIImage.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ROIImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ROIImage.Cursor = System.Windows.Forms.Cursors.Cross;
            this.ROIImage.Location = new System.Drawing.Point(-44, 14);
            this.ROIImage.Margin = new System.Windows.Forms.Padding(0);
            this.ROIImage.Name = "ROIImage";
            this.ROIImage.Size = new System.Drawing.Size(480, 288);
            this.ROIImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ROIImage.TabIndex = 6;
            this.ROIImage.TabStop = false;
            this.ROIImage.Visible = false;
            // 
            // chart_original
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_original.ChartAreas.Add(chartArea1);
            this.chart_original.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart_original.Location = new System.Drawing.Point(3, 3);
            this.chart_original.Name = "chart_original";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.chart_original.Series.Add(series1);
            this.chart_original.Size = new System.Drawing.Size(573, 661);
            this.chart_original.TabIndex = 2;
            this.chart_original.Text = "chart1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Yellow;
            this.label22.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label22.Location = new System.Drawing.Point(397, 99);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(135, 19);
            this.label22.TabIndex = 38;
            this.label22.Text = "測量模式選項:";
            // 
            // Nomal_mode_btn
            // 
            this.Nomal_mode_btn.AutoSize = true;
            this.Nomal_mode_btn.BackColor = System.Drawing.Color.Transparent;
            this.Nomal_mode_btn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Nomal_mode_btn.Location = new System.Drawing.Point(416, 123);
            this.Nomal_mode_btn.Name = "Nomal_mode_btn";
            this.Nomal_mode_btn.Size = new System.Drawing.Size(111, 20);
            this.Nomal_mode_btn.TabIndex = 39;
            this.Nomal_mode_btn.TabStop = true;
            this.Nomal_mode_btn.Text = "單雷射模式";
            this.Nomal_mode_btn.UseVisualStyleBackColor = false;
            // 
            // HgAr_Mode_btn
            // 
            this.HgAr_Mode_btn.AutoSize = true;
            this.HgAr_Mode_btn.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.HgAr_Mode_btn.Location = new System.Drawing.Point(416, 149);
            this.HgAr_Mode_btn.Name = "HgAr_Mode_btn";
            this.HgAr_Mode_btn.Size = new System.Drawing.Size(145, 20);
            this.HgAr_Mode_btn.TabIndex = 40;
            this.HgAr_Mode_btn.TabStop = true;
            this.HgAr_Mode_btn.Text = "汞氬燈測試模式";
            this.HgAr_Mode_btn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 667);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DrawCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CCDImage)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ROIImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_original)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_DG;
        private System.Windows.Forms.Label label_Back_Light;
        private System.Windows.Forms.Label label_Gamma;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_original;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox ROIImage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox AutoScale_txb;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox DrawCanvas;
        private System.Windows.Forms.PictureBox CCDImage;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox checkBox_OnlyFirstTimeROI;
        private System.Windows.Forms.TextBox ROI_StartPoint_txb;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label Result_Label;
        private System.Windows.Forms.Label Result;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox EXP_Level;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox FWHM_RMSE_threshold;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox BaseLineRMSE_threshold;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox Gamma_Level;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox ProcessLog_txb;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.RadioButton HgAr_Mode_btn;
        private System.Windows.Forms.RadioButton Nomal_mode_btn;
        private System.Windows.Forms.Label label22;
    }
}

