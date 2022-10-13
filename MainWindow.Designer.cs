namespace CoolingTwoDimensionalSystem
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox_SettlementCell = new System.Windows.Forms.GroupBox();
            this.pictureBox_SettlementCell = new System.Windows.Forms.PictureBox();
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            this.buttonStart = new System.Windows.Forms.Button();
            this.button_InitialPlacement = new System.Windows.Forms.Button();
            this.textBoxCounter = new System.Windows.Forms.TextBox();
            this.groupBoxPotentialEnergy = new System.Windows.Forms.GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox_SettlementCell.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SettlementCell)).BeginInit();
            this.groupBoxPotentialEnergy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_SettlementCell
            // 
            this.groupBox_SettlementCell.Controls.Add(this.pictureBox_SettlementCell);
            this.groupBox_SettlementCell.Location = new System.Drawing.Point(12, 12);
            this.groupBox_SettlementCell.Name = "groupBox_SettlementCell";
            this.groupBox_SettlementCell.Size = new System.Drawing.Size(513, 528);
            this.groupBox_SettlementCell.TabIndex = 0;
            this.groupBox_SettlementCell.TabStop = false;
            this.groupBox_SettlementCell.Text = "Расчётная ячейка";
            // 
            // pictureBox_SettlementCell
            // 
            this.pictureBox_SettlementCell.Location = new System.Drawing.Point(6, 19);
            this.pictureBox_SettlementCell.Name = "pictureBox_SettlementCell";
            this.pictureBox_SettlementCell.Size = new System.Drawing.Size(500, 500);
            this.pictureBox_SettlementCell.TabIndex = 0;
            this.pictureBox_SettlementCell.TabStop = false;
            // 
            // timerAnimation
            // 
            this.timerAnimation.Interval = 1;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 546);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(127, 65);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Начать";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // button_InitialPlacement
            // 
            this.button_InitialPlacement.Location = new System.Drawing.Point(12, 617);
            this.button_InitialPlacement.Name = "button_InitialPlacement";
            this.button_InitialPlacement.Size = new System.Drawing.Size(127, 65);
            this.button_InitialPlacement.TabIndex = 2;
            this.button_InitialPlacement.Text = "Начальная расстановка";
            this.button_InitialPlacement.UseVisualStyleBackColor = true;
            this.button_InitialPlacement.Click += new System.EventHandler(this.button_InitialPlacement_Click);
            // 
            // textBoxCounter
            // 
            this.textBoxCounter.Location = new System.Drawing.Point(199, 546);
            this.textBoxCounter.Name = "textBoxCounter";
            this.textBoxCounter.Size = new System.Drawing.Size(100, 20);
            this.textBoxCounter.TabIndex = 3;
            // 
            // groupBoxPotentialEnergy
            // 
            this.groupBoxPotentialEnergy.Controls.Add(this.chart1);
            this.groupBoxPotentialEnergy.Location = new System.Drawing.Point(531, 12);
            this.groupBoxPotentialEnergy.Name = "groupBoxPotentialEnergy";
            this.groupBoxPotentialEnergy.Size = new System.Drawing.Size(689, 244);
            this.groupBoxPotentialEnergy.TabIndex = 4;
            this.groupBoxPotentialEnergy.TabStop = false;
            this.groupBoxPotentialEnergy.Text = "График потенциальной энергии";
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Location = new System.Drawing.Point(6, 19);
            this.chart1.Name = "chart1";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(677, 219);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chart2);
            this.groupBox1.Location = new System.Drawing.Point(531, 262);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(689, 244);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "График кинетической энергии";
            // 
            // chart2
            // 
            chartArea3.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea3);
            this.chart2.Location = new System.Drawing.Point(6, 19);
            this.chart2.Name = "chart2";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Name = "Series1";
            this.chart2.Series.Add(series3);
            this.chart2.Size = new System.Drawing.Size(677, 219);
            this.chart2.TabIndex = 0;
            this.chart2.Text = "chart2";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 753);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxPotentialEnergy);
            this.Controls.Add(this.textBoxCounter);
            this.Controls.Add(this.button_InitialPlacement);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.groupBox_SettlementCell);
            this.Name = "MainWindow";
            this.Text = "Исследование поведения двумерной системы частиц при охлаждении";
            this.groupBox_SettlementCell.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SettlementCell)).EndInit();
            this.groupBoxPotentialEnergy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_SettlementCell;
        private System.Windows.Forms.PictureBox pictureBox_SettlementCell;
        private System.Windows.Forms.Timer timerAnimation;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button button_InitialPlacement;
        private System.Windows.Forms.TextBox textBoxCounter;
        private System.Windows.Forms.GroupBox groupBoxPotentialEnergy;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
    }
}

