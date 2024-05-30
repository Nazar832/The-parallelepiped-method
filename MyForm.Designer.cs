
namespace ParallelepipedMethod
{
    partial class MyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel = new System.Windows.Forms.Panel();
            this.doResultsMatchLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.parallelTimeTextBox = new System.Windows.Forms.TextBox();
            this.sequentialTimeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nextLoopButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.Title = "Ітерація";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.AxisY.Title = "X(i, j)";
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Послідовно";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "Паралельно";
            this.chart.Series.Add(series1);
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(843, 502);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart";
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            title1.Name = "Title1";
            this.chart.Titles.Add(title1);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel.Controls.Add(this.doResultsMatchLabel);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.parallelTimeTextBox);
            this.panel.Controls.Add(this.sequentialTimeTextBox);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.label1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel.Location = new System.Drawing.Point(843, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(268, 586);
            this.panel.TabIndex = 13;
            // 
            // doResultsMatchLabel
            // 
            this.doResultsMatchLabel.AutoSize = true;
            this.doResultsMatchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.doResultsMatchLabel.Location = new System.Drawing.Point(32, 267);
            this.doResultsMatchLabel.Name = "doResultsMatchLabel";
            this.doResultsMatchLabel.Size = new System.Drawing.Size(0, 18);
            this.doResultsMatchLabel.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(65, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 18);
            this.label3.TabIndex = 17;
            this.label3.Text = "Час в мілісекундах";
            // 
            // parallelTimeTextBox
            // 
            this.parallelTimeTextBox.Location = new System.Drawing.Point(140, 112);
            this.parallelTimeTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.parallelTimeTextBox.Name = "parallelTimeTextBox";
            this.parallelTimeTextBox.Size = new System.Drawing.Size(100, 22);
            this.parallelTimeTextBox.TabIndex = 16;
            // 
            // sequentialTimeTextBox
            // 
            this.sequentialTimeTextBox.Location = new System.Drawing.Point(140, 68);
            this.sequentialTimeTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sequentialTimeTextBox.Name = "sequentialTimeTextBox";
            this.sequentialTimeTextBox.Size = new System.Drawing.Size(100, 22);
            this.sequentialTimeTextBox.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(28, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Паралельно:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(28, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "Послідовно:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Cornsilk;
            this.panel1.Controls.Add(this.nextLoopButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 508);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 78);
            this.panel1.TabIndex = 14;
            // 
            // nextLoopButton
            // 
            this.nextLoopButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nextLoopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.nextLoopButton.Location = new System.Drawing.Point(345, 15);
            this.nextLoopButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nextLoopButton.Name = "nextLoopButton";
            this.nextLoopButton.Size = new System.Drawing.Size(152, 46);
            this.nextLoopButton.TabIndex = 11;
            this.nextLoopButton.Text = "Наступний цикл";
            this.nextLoopButton.UseVisualStyleBackColor = true;
            this.nextLoopButton.Click += new System.EventHandler(this.nextLoopButton_Click);
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 586);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.chart);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MyForm";
            this.Text = "Форма";
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox parallelTimeTextBox;
        private System.Windows.Forms.TextBox sequentialTimeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button nextLoopButton;
        private System.Windows.Forms.Label doResultsMatchLabel;
    }
}

