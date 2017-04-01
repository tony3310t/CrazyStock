namespace CrazyStock
{
    partial class Ronche
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
            this.txt_RecentDay = new System.Windows.Forms.TextBox();
            this.txt_RoncheBottom = new System.Windows.Forms.TextBox();
            this.txt_RoncheAdd = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.gv_List = new System.Windows.Forms.DataGridView();
            this.txt_ForeignDay = new System.Windows.Forms.TextBox();
            this.txt_ForeignAdd = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gv_List)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_RecentDay
            // 
            this.txt_RecentDay.Location = new System.Drawing.Point(43, 43);
            this.txt_RecentDay.Name = "txt_RecentDay";
            this.txt_RecentDay.Size = new System.Drawing.Size(100, 22);
            this.txt_RecentDay.TabIndex = 0;
            // 
            // txt_RoncheBottom
            // 
            this.txt_RoncheBottom.Location = new System.Drawing.Point(271, 42);
            this.txt_RoncheBottom.Name = "txt_RoncheBottom";
            this.txt_RoncheBottom.Size = new System.Drawing.Size(100, 22);
            this.txt_RoncheBottom.TabIndex = 1;
            // 
            // txt_RoncheAdd
            // 
            this.txt_RoncheAdd.Location = new System.Drawing.Point(486, 42);
            this.txt_RoncheAdd.Name = "txt_RoncheAdd";
            this.txt_RoncheAdd.Size = new System.Drawing.Size(100, 22);
            this.txt_RoncheAdd.TabIndex = 2;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(271, 104);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(75, 23);
            this.btn_Search.TabIndex = 3;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // gv_List
            // 
            this.gv_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_List.Location = new System.Drawing.Point(43, 145);
            this.gv_List.Name = "gv_List";
            this.gv_List.RowTemplate.Height = 24;
            this.gv_List.Size = new System.Drawing.Size(776, 371);
            this.gv_List.TabIndex = 4;
            // 
            // txt_ForeignDay
            // 
            this.txt_ForeignDay.Location = new System.Drawing.Point(43, 71);
            this.txt_ForeignDay.Name = "txt_ForeignDay";
            this.txt_ForeignDay.Size = new System.Drawing.Size(100, 22);
            this.txt_ForeignDay.TabIndex = 5;
            // 
            // txt_ForeignAdd
            // 
            this.txt_ForeignAdd.Location = new System.Drawing.Point(271, 70);
            this.txt_ForeignAdd.Name = "txt_ForeignAdd";
            this.txt_ForeignAdd.Size = new System.Drawing.Size(100, 22);
            this.txt_ForeignAdd.TabIndex = 6;
            // 
            // Ronche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(850, 505);
            this.Controls.Add(this.txt_ForeignAdd);
            this.Controls.Add(this.txt_ForeignDay);
            this.Controls.Add(this.gv_List);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.txt_RoncheAdd);
            this.Controls.Add(this.txt_RoncheBottom);
            this.Controls.Add(this.txt_RecentDay);
            this.Name = "Ronche";
            this.Text = "Ronche";
            ((System.ComponentModel.ISupportInitialize)(this.gv_List)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_RecentDay;
        private System.Windows.Forms.TextBox txt_RoncheBottom;
        private System.Windows.Forms.TextBox txt_RoncheAdd;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.DataGridView gv_List;
        private System.Windows.Forms.TextBox txt_ForeignDay;
        private System.Windows.Forms.TextBox txt_ForeignAdd;
    }
}