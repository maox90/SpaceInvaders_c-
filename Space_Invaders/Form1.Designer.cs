namespace Space_Invaders
{
    partial class SpaceInvadersIntro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpaceInvadersIntro));
            this.pictureBoxmMulty = new System.Windows.Forms.PictureBox();
            this.pictureBoxExit = new System.Windows.Forms.PictureBox();
            this.pictureBoxSingle = new System.Windows.Forms.PictureBox();
            this.pictureBoxClassic = new System.Windows.Forms.PictureBox();
            this.pictureBoxModern = new System.Windows.Forms.PictureBox();
            this.pictureBoxBack = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxmMulty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSingle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClassic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxModern)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBack)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxmMulty
            // 
            this.pictureBoxmMulty.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxmMulty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxmMulty.InitialImage = null;
            this.pictureBoxmMulty.Location = new System.Drawing.Point(37, 201);
            this.pictureBoxmMulty.Name = "pictureBoxmMulty";
            this.pictureBoxmMulty.Size = new System.Drawing.Size(291, 50);
            this.pictureBoxmMulty.TabIndex = 4;
            this.pictureBoxmMulty.TabStop = false;
            this.pictureBoxmMulty.Click += new System.EventHandler(this.pictureBoxmMulty_Click);
            // 
            // pictureBoxExit
            // 
            this.pictureBoxExit.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxExit.Location = new System.Drawing.Point(651, 266);
            this.pictureBoxExit.Name = "pictureBoxExit";
            this.pictureBoxExit.Size = new System.Drawing.Size(216, 50);
            this.pictureBoxExit.TabIndex = 5;
            this.pictureBoxExit.TabStop = false;
            this.pictureBoxExit.Click += new System.EventHandler(this.pictureBoxExit_Click);
            // 
            // pictureBoxSingle
            // 
            this.pictureBoxSingle.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSingle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSingle.Location = new System.Drawing.Point(56, 257);
            this.pictureBoxSingle.Name = "pictureBoxSingle";
            this.pictureBoxSingle.Size = new System.Drawing.Size(216, 50);
            this.pictureBoxSingle.TabIndex = 6;
            this.pictureBoxSingle.TabStop = false;
            this.pictureBoxSingle.Click += new System.EventHandler(this.pictureBoxSingle_Click);
            // 
            // pictureBoxClassic
            // 
            this.pictureBoxClassic.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxClassic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxClassic.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxClassic.Image")));
            this.pictureBoxClassic.Location = new System.Drawing.Point(56, 201);
            this.pictureBoxClassic.Name = "pictureBoxClassic";
            this.pictureBoxClassic.Size = new System.Drawing.Size(216, 50);
            this.pictureBoxClassic.TabIndex = 7;
            this.pictureBoxClassic.TabStop = false;
            this.pictureBoxClassic.Click += new System.EventHandler(this.pictureBoxClassic_Click);
            // 
            // pictureBoxModern
            // 
            this.pictureBoxModern.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxModern.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxModern.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxModern.Image")));
            this.pictureBoxModern.Location = new System.Drawing.Point(56, 257);
            this.pictureBoxModern.Name = "pictureBoxModern";
            this.pictureBoxModern.Size = new System.Drawing.Size(216, 50);
            this.pictureBoxModern.TabIndex = 8;
            this.pictureBoxModern.TabStop = false;
            this.pictureBoxModern.Click += new System.EventHandler(this.pictureBoxModern_Click);
            // 
            // pictureBoxBack
            // 
            this.pictureBoxBack.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxBack.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxBack.Image")));
            this.pictureBoxBack.Location = new System.Drawing.Point(673, 0);
            this.pictureBoxBack.Name = "pictureBoxBack";
            this.pictureBoxBack.Size = new System.Drawing.Size(216, 50);
            this.pictureBoxBack.TabIndex = 9;
            this.pictureBoxBack.TabStop = false;
            this.pictureBoxBack.Click += new System.EventHandler(this.pictureBoxBack_Click);
            // 
            // SpaceInvadersIntro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(792, 306);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBoxBack);
            this.Controls.Add(this.pictureBoxModern);
            this.Controls.Add(this.pictureBoxClassic);
            this.Controls.Add(this.pictureBoxSingle);
            this.Controls.Add(this.pictureBoxExit);
            this.Controls.Add(this.pictureBoxmMulty);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SpaceInvadersIntro";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.Load += new System.EventHandler(this.SpaceInvadersIntro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxmMulty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSingle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClassic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxModern)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxmMulty;
        private System.Windows.Forms.PictureBox pictureBoxExit;
        private System.Windows.Forms.PictureBox pictureBoxSingle;
        private System.Windows.Forms.PictureBox pictureBoxClassic;
        private System.Windows.Forms.PictureBox pictureBoxModern;
        private System.Windows.Forms.PictureBox pictureBoxBack;

    }
}

