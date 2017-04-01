namespace CrazyStock
{
    partial class WaterOne
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
            this.btn_Search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Up = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Volume5 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_VolumeUp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Smooth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_ThresholdPercent = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_ThresholdDay = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(419, 109);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 0;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "漲幅:";
            // 
            // txt_Up
            // 
            this.txt_Up.Location = new System.Drawing.Point(79, 10);
            this.txt_Up.Name = "txt_Up";
            this.txt_Up.Size = new System.Drawing.Size(100, 22);
            this.txt_Up.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "五日均量大於:";
            // 
            // txt_Volume5
            // 
            this.txt_Volume5.Location = new System.Drawing.Point(339, 10);
            this.txt_Volume5.Name = "txt_Volume5";
            this.txt_Volume5.Size = new System.Drawing.Size(100, 22);
            this.txt_Volume5.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(484, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "成交量大於五日均量(倍):";
            // 
            // txt_VolumeUp
            // 
            this.txt_VolumeUp.Location = new System.Drawing.Point(626, 10);
            this.txt_VolumeUp.Name = "txt_VolumeUp";
            this.txt_VolumeUp.Size = new System.Drawing.Size(100, 22);
            this.txt_VolumeUp.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(747, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "連續盤整超過(天):";
            // 
            // txt_Smooth
            // 
            this.txt_Smooth.Location = new System.Drawing.Point(853, 10);
            this.txt_Smooth.Name = "txt_Smooth";
            this.txt_Smooth.Size = new System.Drawing.Size(100, 22);
            this.txt_Smooth.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "盤整閥值(%):";
            // 
            // txt_ThresholdPercent
            // 
            this.txt_ThresholdPercent.Location = new System.Drawing.Point(79, 48);
            this.txt_ThresholdPercent.Name = "txt_ThresholdPercent";
            this.txt_ThresholdPercent.Size = new System.Drawing.Size(100, 22);
            this.txt_ThresholdPercent.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(257, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "盤整閥值(天):";
            // 
            // txt_ThresholdDay
            // 
            this.txt_ThresholdDay.Location = new System.Drawing.Point(339, 48);
            this.txt_ThresholdDay.Name = "txt_ThresholdDay";
            this.txt_ThresholdDay.Size = new System.Drawing.Size(100, 22);
            this.txt_ThresholdDay.TabIndex = 12;
            // 
            // WaterOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 516);
            this.Controls.Add(this.txt_ThresholdDay);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_ThresholdPercent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Smooth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_VolumeUp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Volume5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Up);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Search);
            this.Name = "WaterOne";
            this.Text = "WaterOne";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Up;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Volume5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_VolumeUp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Smooth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_ThresholdPercent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_ThresholdDay;
    }
}