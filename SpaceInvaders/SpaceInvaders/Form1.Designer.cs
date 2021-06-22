
namespace SpaceInvaders
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
            this.components = new System.ComponentModel.Container();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.invadersTimer = new System.Windows.Forms.Timer(this.components);
            this.Finish = new System.Windows.Forms.Label();
            this.handleShotsTimer = new System.Windows.Forms.Timer(this.components);
            this.invaderShotTimer = new System.Windows.Forms.Timer(this.components);
            this.bulletsTimer = new System.Windows.Forms.Timer(this.components);
            this.powersTimer = new System.Windows.Forms.Timer(this.components);
            this.handlePowerTimer = new System.Windows.Forms.Timer(this.components);
            this.player = new System.Windows.Forms.PictureBox();
            this.playerTimer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.Life1 = new System.Windows.Forms.PictureBox();
            this.Life2 = new System.Windows.Forms.PictureBox();
            this.Life3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Life1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Life2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Life3)).BeginInit();
            this.SuspendLayout();
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.scoreLabel.Location = new System.Drawing.Point(0, 441);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(77, 20);
            this.scoreLabel.TabIndex = 1;
            this.scoreLabel.Text = "Score: 00";
            // 
            // invadersTimer
            // 
            this.invadersTimer.Enabled = true;
            this.invadersTimer.Interval = 300;
            this.invadersTimer.Tick += new System.EventHandler(this.inavdersTimer_Tick);
            // 
            // Finish
            // 
            this.Finish.AutoSize = true;
            this.Finish.ForeColor = System.Drawing.Color.White;
            this.Finish.Location = new System.Drawing.Point(295, 152);
            this.Finish.Name = "Finish";
            this.Finish.Size = new System.Drawing.Size(0, 13);
            this.Finish.TabIndex = 3;
            // 
            // handleShotsTimer
            // 
            this.handleShotsTimer.Enabled = true;
            this.handleShotsTimer.Tick += new System.EventHandler(this.handleShotsTimer_Tick);
            // 
            // invaderShotTimer
            // 
            this.invaderShotTimer.Enabled = true;
            this.invaderShotTimer.Interval = 900;
            this.invaderShotTimer.Tick += new System.EventHandler(this.invaderShotTimer_Tick);
            // 
            // bulletsTimer
            // 
            this.bulletsTimer.Enabled = true;
            this.bulletsTimer.Interval = 20;
            this.bulletsTimer.Tick += new System.EventHandler(this.bulletsTimer_Tick);
            // 
            // powersTimer
            // 
            this.powersTimer.Enabled = true;
            this.powersTimer.Interval = 10000;
            this.powersTimer.Tick += new System.EventHandler(this.powersTimer_Tick);
            // 
            // handlePowerTimer
            // 
            this.handlePowerTimer.Enabled = true;
            this.handlePowerTimer.Tick += new System.EventHandler(this.handlePowerTimer_Tick);
            // 
            // player
            // 
            this.player.Image = global::SpaceInvaders.Properties.Resources.playerShip;
            this.player.Location = new System.Drawing.Point(271, 406);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(20, 20);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            // 
            // playerTimer
            // 
            this.playerTimer.Enabled = true;
            this.playerTimer.Interval = 50;
            this.playerTimer.Tick += new System.EventHandler(this.playerTimer_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(456, 441);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Life: ";
            // 
            // Life1
            // 
            this.Life1.Image = global::SpaceInvaders.Properties.Resources.playerShip;
            this.Life1.Location = new System.Drawing.Point(505, 441);
            this.Life1.Name = "Life1";
            this.Life1.Size = new System.Drawing.Size(20, 20);
            this.Life1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Life1.TabIndex = 5;
            this.Life1.TabStop = false;
            // 
            // Life2
            // 
            this.Life2.Image = global::SpaceInvaders.Properties.Resources.playerShip;
            this.Life2.Location = new System.Drawing.Point(531, 441);
            this.Life2.Name = "Life2";
            this.Life2.Size = new System.Drawing.Size(20, 20);
            this.Life2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Life2.TabIndex = 6;
            this.Life2.TabStop = false;
            // 
            // Life3
            // 
            this.Life3.Image = global::SpaceInvaders.Properties.Resources.playerShip;
            this.Life3.Location = new System.Drawing.Point(557, 441);
            this.Life3.Name = "Life3";
            this.Life3.Size = new System.Drawing.Size(20, 20);
            this.Life3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Life3.TabIndex = 7;
            this.Life3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(634, 461);
            this.Controls.Add(this.Life3);
            this.Controls.Add(this.Life2);
            this.Controls.Add(this.Life1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Finish);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.player);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Life1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Life2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Life3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Timer invadersTimer;
        private System.Windows.Forms.Label Finish;
        private System.Windows.Forms.Timer handleShotsTimer;
        private System.Windows.Forms.Timer invaderShotTimer;
        private System.Windows.Forms.Timer bulletsTimer;
        private System.Windows.Forms.Timer powersTimer;
        private System.Windows.Forms.Timer handlePowerTimer;
        private System.Windows.Forms.Timer playerTimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox Life1;
        private System.Windows.Forms.PictureBox Life2;
        private System.Windows.Forms.PictureBox Life3;
    }
}

