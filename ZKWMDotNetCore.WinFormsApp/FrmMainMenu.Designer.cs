namespace ZKWMDotNetCore.WinFormsApp
{
    partial class FrmMainMenu
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
            menuStrip1 = new MenuStrip();
            blogToolStripMenuItem = new ToolStripMenuItem();
            newBLogToolStripMenuItem = new ToolStripMenuItem();
            blogListToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { blogToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // blogToolStripMenuItem
            // 
            blogToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newBLogToolStripMenuItem, blogListToolStripMenuItem });
            blogToolStripMenuItem.Name = "blogToolStripMenuItem";
            blogToolStripMenuItem.Size = new Size(43, 20);
            blogToolStripMenuItem.Text = "Blog";
            // 
            // newBLogToolStripMenuItem
            // 
            newBLogToolStripMenuItem.Name = "newBLogToolStripMenuItem";
            newBLogToolStripMenuItem.Size = new Size(180, 22);
            newBLogToolStripMenuItem.Text = "New Blog";
            newBLogToolStripMenuItem.Click += newBLogToolStripMenuItem_Click;
            // 
            // blogListToolStripMenuItem
            // 
            blogListToolStripMenuItem.Name = "blogListToolStripMenuItem";
            blogListToolStripMenuItem.Size = new Size(180, 22);
            blogListToolStripMenuItem.Text = "Blog List";
            blogListToolStripMenuItem.Click += blogListToolStripMenuItem_Click;
            // 
            // FrmMainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmMainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main Menu";
            Load += FrmMainMenu_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem blogToolStripMenuItem;
        private ToolStripMenuItem newBLogToolStripMenuItem;
        private ToolStripMenuItem blogListToolStripMenuItem;
    }
}