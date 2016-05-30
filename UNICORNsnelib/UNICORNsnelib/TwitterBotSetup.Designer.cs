namespace UNICORNsnelib
{
    partial class TwitterBotSetup
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
            this.Apply = new System.Windows.Forms.Button();
            this.ConsumerKey = new System.Windows.Forms.TextBox();
            this.ConsumerSecret = new System.Windows.Forms.TextBox();
            this.AccessTokenSecret = new System.Windows.Forms.TextBox();
            this.AccessToken = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Access = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instagramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facebookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.howToGetCredentialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Apply
            // 
            this.Apply.Location = new System.Drawing.Point(630, 282);
            this.Apply.Name = "Apply";
            this.Apply.Size = new System.Drawing.Size(115, 39);
            this.Apply.TabIndex = 1;
            this.Apply.Text = "Apply";
            this.Apply.UseVisualStyleBackColor = true;
            this.Apply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // ConsumerKey
            // 
            this.ConsumerKey.Location = new System.Drawing.Point(249, 62);
            this.ConsumerKey.Name = "ConsumerKey";
            this.ConsumerKey.Size = new System.Drawing.Size(496, 26);
            this.ConsumerKey.TabIndex = 2;
            // 
            // ConsumerSecret
            // 
            this.ConsumerSecret.Location = new System.Drawing.Point(249, 114);
            this.ConsumerSecret.Name = "ConsumerSecret";
            this.ConsumerSecret.Size = new System.Drawing.Size(496, 26);
            this.ConsumerSecret.TabIndex = 3;
            // 
            // AccessTokenSecret
            // 
            this.AccessTokenSecret.Location = new System.Drawing.Point(249, 219);
            this.AccessTokenSecret.Name = "AccessTokenSecret";
            this.AccessTokenSecret.Size = new System.Drawing.Size(496, 26);
            this.AccessTokenSecret.TabIndex = 4;
            // 
            // AccessToken
            // 
            this.AccessToken.Location = new System.Drawing.Point(249, 168);
            this.AccessToken.Name = "AccessToken";
            this.AccessToken.Size = new System.Drawing.Size(496, 26);
            this.AccessToken.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Consumer Key:";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Consumer Secret:";
            // 
            // Access
            // 
            this.Access.AutoSize = true;
            this.Access.Location = new System.Drawing.Point(123, 174);
            this.Access.Name = "Access";
            this.Access.Size = new System.Drawing.Size(113, 20);
            this.Access.TabIndex = 8;
            this.Access.Text = "Access Token:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Access Token Secret:";
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(757, 33);
            this.menuStrip2.TabIndex = 10;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.twitterToolStripMenuItem,
            this.instagramToolStripMenuItem,
            this.facebookToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(70, 29);
            this.editToolStripMenuItem.Text = "Select";
            // 
            // twitterToolStripMenuItem
            // 
            this.twitterToolStripMenuItem.Name = "twitterToolStripMenuItem";
            this.twitterToolStripMenuItem.Size = new System.Drawing.Size(177, 30);
            this.twitterToolStripMenuItem.Text = "Twitter";
            // 
            // instagramToolStripMenuItem
            // 
            this.instagramToolStripMenuItem.Name = "instagramToolStripMenuItem";
            this.instagramToolStripMenuItem.Size = new System.Drawing.Size(177, 30);
            this.instagramToolStripMenuItem.Text = "Instagram";
            // 
            // facebookToolStripMenuItem
            // 
            this.facebookToolStripMenuItem.Name = "facebookToolStripMenuItem";
            this.facebookToolStripMenuItem.Size = new System.Drawing.Size(177, 30);
            this.facebookToolStripMenuItem.Text = "Facebook";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1,
            this.howToGetCredentialsToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(61, 29);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(276, 30);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // howToGetCredentialsToolStripMenuItem
            // 
            this.howToGetCredentialsToolStripMenuItem.Name = "howToGetCredentialsToolStripMenuItem";
            this.howToGetCredentialsToolStripMenuItem.Size = new System.Drawing.Size(276, 30);
            this.howToGetCredentialsToolStripMenuItem.Text = "How to get credentials";
            this.howToGetCredentialsToolStripMenuItem.Click += new System.EventHandler(this.howToGetCredentialsToolStripMenuItem_Click);
            // 
            // TwitterBotSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 358);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Access);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AccessToken);
            this.Controls.Add(this.AccessTokenSecret);
            this.Controls.Add(this.ConsumerSecret);
            this.Controls.Add(this.ConsumerKey);
            this.Controls.Add(this.Apply);
            this.Controls.Add(this.menuStrip2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TwitterBotSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TwitterBotSetup";
            this.Load += new System.EventHandler(this.TwitterBotSetup_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Apply;
        private System.Windows.Forms.TextBox ConsumerKey;
        private System.Windows.Forms.TextBox ConsumerSecret;
        private System.Windows.Forms.TextBox AccessTokenSecret;
        private System.Windows.Forms.TextBox AccessToken;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Access;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem twitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instagramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facebookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem howToGetCredentialsToolStripMenuItem;
    }
}