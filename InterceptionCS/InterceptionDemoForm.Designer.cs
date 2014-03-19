namespace InterceptionCS
{
    partial class InterceptionDemoForm
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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.functionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monitorKeystrokesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monitorWithHardwareIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.functionsToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(284, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // functionsToolStripMenuItem
            // 
            this.functionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monitorKeystrokesToolStripMenuItem,
            this.monitorWithHardwareIDToolStripMenuItem});
            this.functionsToolStripMenuItem.Name = "functionsToolStripMenuItem";
            this.functionsToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.functionsToolStripMenuItem.Text = "Functions";
            // 
            // monitorKeystrokesToolStripMenuItem
            // 
            this.monitorKeystrokesToolStripMenuItem.Name = "monitorKeystrokesToolStripMenuItem";
            this.monitorKeystrokesToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.monitorKeystrokesToolStripMenuItem.Text = "Monitor Keystrokes";
            this.monitorKeystrokesToolStripMenuItem.Click += new System.EventHandler(this.monitorKeystrokesToolStripMenuItem_Click);
            // 
            // monitorWithHardwareIDToolStripMenuItem
            // 
            this.monitorWithHardwareIDToolStripMenuItem.Name = "monitorWithHardwareIDToolStripMenuItem";
            this.monitorWithHardwareIDToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.monitorWithHardwareIDToolStripMenuItem.Text = "Monitor with Hardware ID";
            this.monitorWithHardwareIDToolStripMenuItem.Click += new System.EventHandler(this.monitorWithHardwareIDToolStripMenuItem_Click);
            // 
            // InterceptionDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "InterceptionDemoForm";
            this.Text = "InterceptionDemoForm";
            this.Load += new System.EventHandler(this.InterceptionDemoForm_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem functionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monitorKeystrokesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monitorWithHardwareIDToolStripMenuItem;
    }
}