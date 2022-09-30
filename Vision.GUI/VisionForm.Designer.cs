namespace Vision.GUI
{
    partial class VisionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VisionForm));
            this.IconPicturebox = new System.Windows.Forms.PictureBox();
            this.Brandlabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.AlarmPicturebox = new System.Windows.Forms.PictureBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SurveillanceWorker = new System.ComponentModel.BackgroundWorker();
            this.Warninglabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.IconPicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // IconPicturebox
            // 
            this.IconPicturebox.Image = ((System.Drawing.Image)(resources.GetObject("IconPicturebox.Image")));
            this.IconPicturebox.Location = new System.Drawing.Point(98, 27);
            this.IconPicturebox.Name = "IconPicturebox";
            this.IconPicturebox.Size = new System.Drawing.Size(137, 93);
            this.IconPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IconPicturebox.TabIndex = 2;
            this.IconPicturebox.TabStop = false;
            // 
            // Brandlabel
            // 
            this.Brandlabel.AutoSize = true;
            this.Brandlabel.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Brandlabel.ForeColor = System.Drawing.Color.Black;
            this.Brandlabel.Location = new System.Drawing.Point(86, 134);
            this.Brandlabel.Name = "Brandlabel";
            this.Brandlabel.Size = new System.Drawing.Size(161, 45);
            this.Brandlabel.TabIndex = 3;
            this.Brandlabel.Text = "VISION";
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.SystemColors.Control;
            this.StartButton.BackgroundImage = global::Vision.GUI.Properties.Resources.start_button;
            this.StartButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.StartButton.FlatAppearance.BorderSize = 0;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.ForeColor = System.Drawing.SystemColors.Control;
            this.StartButton.Location = new System.Drawing.Point(112, 213);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(102, 73);
            this.StartButton.TabIndex = 4;
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // AlarmPicturebox
            // 
            this.AlarmPicturebox.Image = global::Vision.GUI.Properties.Resources.alarm;
            this.AlarmPicturebox.Location = new System.Drawing.Point(23, 27);
            this.AlarmPicturebox.Name = "AlarmPicturebox";
            this.AlarmPicturebox.Size = new System.Drawing.Size(45, 39);
            this.AlarmPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AlarmPicturebox.TabIndex = 5;
            this.AlarmPicturebox.TabStop = false;
            this.AlarmPicturebox.Visible = false;
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.Firebrick;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CloseButton.Location = new System.Drawing.Point(257, 12);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(60, 26);
            this.CloseButton.TabIndex = 6;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SurveillanceWorker
            // 
            this.SurveillanceWorker.WorkerSupportsCancellation = true;
            this.SurveillanceWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SurveillanceWorker_DoWork);
            this.SurveillanceWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SurveillanceWorker_RunWorkerCompleted);
            // 
            // Warninglabel
            // 
            this.Warninglabel.AutoSize = true;
            this.Warninglabel.Font = new System.Drawing.Font("Tempus Sans ITC", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Warninglabel.ForeColor = System.Drawing.Color.Brown;
            this.Warninglabel.Location = new System.Drawing.Point(86, 300);
            this.Warninglabel.Name = "Warninglabel";
            this.Warninglabel.Size = new System.Drawing.Size(166, 31);
            this.Warninglabel.TabIndex = 7;
            this.Warninglabel.Text = "KEEP AWAY!";
            this.Warninglabel.Visible = false;
            // 
            // VisionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 349);
            this.Controls.Add(this.Warninglabel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.AlarmPicturebox);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.Brandlabel);
            this.Controls.Add(this.IconPicturebox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VisionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VisionForm";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.IconPicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmPicturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox IconPicturebox;
        private Label Brandlabel;
        private Button StartButton;
        private PictureBox AlarmPicturebox;
        private Button CloseButton;
        private System.ComponentModel.BackgroundWorker SurveillanceWorker;
        private Label Warninglabel;
    }
}