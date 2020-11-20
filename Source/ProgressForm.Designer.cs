namespace WindowsFormsApp1
{
    partial class ProgressForm
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelRetrieve = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.LblCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.progressBar.Location = new System.Drawing.Point(12, 132);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(492, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 0;
            this.progressBar.Click += new System.EventHandler(this.ProgressBar_Click);
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(243, 174);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(0, 13);
            this.progressLabel.TabIndex = 1;
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(233, 282);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(0, 13);
            this.countLabel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 39);
            this.label1.TabIndex = 3;
            this.label1.Text = ".Patience is the companion of wisdom\r\n\r\nPlease Wait...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelRetrieve
            // 
            this.labelRetrieve.AutoSize = true;
            this.labelRetrieve.Location = new System.Drawing.Point(197, 228);
            this.labelRetrieve.Name = "labelRetrieve";
            this.labelRetrieve.Size = new System.Drawing.Size(0, 13);
            this.labelRetrieve.TabIndex = 4;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(178, 253);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 13);
            this.labelStatus.TabIndex = 5;
            // 
            // LblCount
            // 
            this.LblCount.AutoSize = true;
            this.LblCount.Location = new System.Drawing.Point(208, 282);
            this.LblCount.Name = "LblCount";
            this.LblCount.Size = new System.Drawing.Size(0, 13);
            this.LblCount.TabIndex = 6;
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 325);
            this.Controls.Add(this.LblCount);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelRetrieve);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.progressBar);
            this.MaximizeBox = false;
            this.Name = "ProgressForm";
            this.Text = "Counting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProgressForm_FormClosing);
            this.Load += new System.EventHandler(this.ProgressForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelRetrieve;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label LblCount;
    }
}