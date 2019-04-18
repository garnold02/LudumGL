namespace LevelEditor
{
    partial class LevelEditor
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
            this.objectListButton = new System.Windows.Forms.Button();
            this.resourceManagerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // objectListButton
            // 
            this.objectListButton.Location = new System.Drawing.Point(12, 12);
            this.objectListButton.Name = "objectListButton";
            this.objectListButton.Size = new System.Drawing.Size(75, 23);
            this.objectListButton.TabIndex = 0;
            this.objectListButton.Text = "Object list";
            this.objectListButton.UseVisualStyleBackColor = true;
            this.objectListButton.Click += new System.EventHandler(this.objectListButton_Click);
            // 
            // resourceManagerButton
            // 
            this.resourceManagerButton.Location = new System.Drawing.Point(93, 12);
            this.resourceManagerButton.Name = "resourceManagerButton";
            this.resourceManagerButton.Size = new System.Drawing.Size(109, 23);
            this.resourceManagerButton.TabIndex = 1;
            this.resourceManagerButton.Text = "Resource manager";
            this.resourceManagerButton.UseVisualStyleBackColor = true;
            this.resourceManagerButton.Click += new System.EventHandler(this.resourceManagerButton_Click);
            // 
            // LevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 46);
            this.Controls.Add(this.resourceManagerButton);
            this.Controls.Add(this.objectListButton);
            this.Name = "LevelEditor";
            this.Text = "Editor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button objectListButton;
        private System.Windows.Forms.Button resourceManagerButton;
    }
}