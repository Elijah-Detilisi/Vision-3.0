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
            this.StartButton.BackColor = System.Drawing.Color.Transparent;
            this.StartButton.BackgroundImage = global::Vision.GUI.Properties.Resources.start_button;
            this.StartButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.StartButton.FlatAppearance.BorderSize = 0;
            this.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButton.Location = new System.Drawing.Point(121, 205);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(102, 73);
            this.StartButton.TabIndex = 4;
            this.StartButton.UseVisualStyleBackColor = false;
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
            // 
            // VisionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 336);
            this.Controls.Add(this.AlarmPicturebox);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.Brandlabel);
            this.Controls.Add(this.IconPicturebox);
            this.Name = "VisionForm";
            this.Text = "VisionForm";
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
    }
}