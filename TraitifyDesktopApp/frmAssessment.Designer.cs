namespace TraitifyDesktopApp
{
    partial class frmAssessment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAssessment));
            this.pbSlide = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMe = new System.Windows.Forms.Button();
            this.btnNotMe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlide)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSlide
            // 
            this.pbSlide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSlide.Image = ((System.Drawing.Image)(resources.GetObject("pbSlide.Image")));
            this.pbSlide.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbSlide.InitialImage")));
            this.pbSlide.Location = new System.Drawing.Point(0, 0);
            this.pbSlide.Name = "pbSlide";
            this.pbSlide.Size = new System.Drawing.Size(1023, 766);
            this.pbSlide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSlide.TabIndex = 0;
            this.pbSlide.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.RoyalBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1023, 76);
            this.label1.TabIndex = 1;
            this.label1.Text = "Caption";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMe
            // 
            this.btnMe.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnMe.FlatAppearance.BorderSize = 0;
            this.btnMe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMe.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMe.ForeColor = System.Drawing.Color.White;
            this.btnMe.Location = new System.Drawing.Point(337, 679);
            this.btnMe.Name = "btnMe";
            this.btnMe.Size = new System.Drawing.Size(172, 75);
            this.btnMe.TabIndex = 2;
            this.btnMe.Text = "Me";
            this.btnMe.UseVisualStyleBackColor = false;
            this.btnMe.Click += new System.EventHandler(this.btnMe_Click);
            // 
            // btnNotMe
            // 
            this.btnNotMe.BackColor = System.Drawing.Color.Red;
            this.btnNotMe.FlatAppearance.BorderSize = 0;
            this.btnNotMe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotMe.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotMe.ForeColor = System.Drawing.Color.White;
            this.btnNotMe.Location = new System.Drawing.Point(515, 679);
            this.btnNotMe.Name = "btnNotMe";
            this.btnNotMe.Size = new System.Drawing.Size(172, 75);
            this.btnNotMe.TabIndex = 3;
            this.btnNotMe.Text = "Not Me";
            this.btnNotMe.UseVisualStyleBackColor = false;
            this.btnNotMe.Click += new System.EventHandler(this.btnNotMe_Click);
            // 
            // frmAssessment
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1023, 766);
            this.Controls.Add(this.btnNotMe);
            this.Controls.Add(this.btnMe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbSlide);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAssessment";
            this.Text = "Your Assessment";
            ((System.ComponentModel.ISupportInitialize)(this.pbSlide)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSlide;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMe;
        private System.Windows.Forms.Button btnNotMe;
    }
}