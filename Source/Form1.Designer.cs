namespace WindowsFormsApp1
{
    partial class Form1
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
            this.BtnLoadImage = new System.Windows.Forms.Button();
            this.Count = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.BtnTrain = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnStatus = new System.Windows.Forms.Button();
            this.Btn_Train = new System.Windows.Forms.Button();
            this.ImageBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnLoadImage
            // 
            this.BtnLoadImage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnLoadImage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnLoadImage.Location = new System.Drawing.Point(154, 299);
            this.BtnLoadImage.Name = "BtnLoadImage";
            this.BtnLoadImage.Size = new System.Drawing.Size(91, 38);
            this.BtnLoadImage.TabIndex = 2;
            this.BtnLoadImage.Text = "Load Image";
            this.BtnLoadImage.UseVisualStyleBackColor = true;
            this.BtnLoadImage.Click += new System.EventHandler(this.BtnLoadImage_Click);
            // 
            // Count
            // 
            this.Count.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Count.Location = new System.Drawing.Point(154, 245);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(91, 38);
            this.Count.TabIndex = 3;
            this.Count.Text = "Count";
            this.Count.UseVisualStyleBackColor = true;
            this.Count.Click += new System.EventHandler(this.Count_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLabel.Location = new System.Drawing.Point(110, 328);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 24);
            this.resultLabel.TabIndex = 4;
            this.resultLabel.Visible = false;
            // 
            // BtnTrain
            // 
            this.BtnTrain.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnTrain.Location = new System.Drawing.Point(19, 299);
            this.BtnTrain.Name = "BtnTrain";
            this.BtnTrain.Size = new System.Drawing.Size(91, 38);
            this.BtnTrain.TabIndex = 5;
            this.BtnTrain.Text = "Annottate";
            this.BtnTrain.UseVisualStyleBackColor = true;
            this.BtnTrain.Click += new System.EventHandler(this.BtnTrain_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnStatus);
            this.panel1.Controls.Add(this.Btn_Train);
            this.panel1.Controls.Add(this.Count);
            this.panel1.Controls.Add(this.BtnTrain);
            this.panel1.Controls.Add(this.resultLabel);
            this.panel1.Controls.Add(this.BtnLoadImage);
            this.panel1.Controls.Add(this.ImageBox);
            this.panel1.Location = new System.Drawing.Point(203, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(394, 394);
            this.panel1.TabIndex = 0;
            // 
            // BtnStatus
            // 
            this.BtnStatus.Location = new System.Drawing.Point(154, 353);
            this.BtnStatus.Name = "BtnStatus";
            this.BtnStatus.Size = new System.Drawing.Size(91, 38);
            this.BtnStatus.TabIndex = 7;
            this.BtnStatus.Text = "Check Status";
            this.BtnStatus.UseVisualStyleBackColor = true;
            this.BtnStatus.Click += new System.EventHandler(this.BtnStatus_Click);
            // 
            // Btn_Train
            // 
            this.Btn_Train.Location = new System.Drawing.Point(278, 299);
            this.Btn_Train.Name = "Btn_Train";
            this.Btn_Train.Size = new System.Drawing.Size(91, 38);
            this.Btn_Train.TabIndex = 6;
            this.Btn_Train.Text = "Train";
            this.Btn_Train.UseVisualStyleBackColor = true;
            this.Btn_Train.Click += new System.EventHandler(this.Btn_Train_Click);
            // 
            // ImageBox
            // 
            this.ImageBox.BackColor = System.Drawing.Color.White;
            this.ImageBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ImageBox.Location = new System.Drawing.Point(35, 20);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(311, 205);
            this.ImageBox.TabIndex = 1;
            this.ImageBox.TabStop = false;
            this.ImageBox.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(204)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "An Intelligent Crowd Counting System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnLoadImage;
        private System.Windows.Forms.Button Count;
        public System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Button BtnTrain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox ImageBox;
        private System.Windows.Forms.Button Btn_Train;
        private System.Windows.Forms.Button BtnStatus;
    }
}

