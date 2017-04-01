namespace CrazyStock
{
    partial class Dashboard
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.btn_Ronche = new System.Windows.Forms.Button();
            this.btn_WaterOne = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Ronche
            // 
            this.btn_Ronche.Location = new System.Drawing.Point(39, 72);
            this.btn_Ronche.Name = "btn_Ronche";
            this.btn_Ronche.Size = new System.Drawing.Size(75, 23);
            this.btn_Ronche.TabIndex = 0;
            this.btn_Ronche.Text = "融資選股";
            this.btn_Ronche.UseVisualStyleBackColor = true;
            this.btn_Ronche.Click += new System.EventHandler(this.btn_Ronche_Click);
            // 
            // btn_WaterOne
            // 
            this.btn_WaterOne.Image = ((System.Drawing.Image)(resources.GetObject("btn_WaterOne.Image")));
            this.btn_WaterOne.Location = new System.Drawing.Point(137, 46);
            this.btn_WaterOne.Name = "btn_WaterOne";
            this.btn_WaterOne.Size = new System.Drawing.Size(75, 74);
            this.btn_WaterOne.TabIndex = 1;
            this.btn_WaterOne.UseVisualStyleBackColor = true;
            this.btn_WaterOne.Click += new System.EventHandler(this.btn_WaterOne_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(897, 505);
            this.Controls.Add(this.btn_WaterOne);
            this.Controls.Add(this.btn_Ronche);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Ronche;
        private System.Windows.Forms.Button btn_WaterOne;
    }
}

