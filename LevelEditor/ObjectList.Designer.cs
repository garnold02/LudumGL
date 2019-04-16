namespace LevelEditor
{
    partial class ObjectList
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
            this.objectListBox = new System.Windows.Forms.ListBox();
            this.addObjectButton = new System.Windows.Forms.Button();
            this.editObjectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // objectListBox
            // 
            this.objectListBox.FormattingEnabled = true;
            this.objectListBox.Location = new System.Drawing.Point(12, 12);
            this.objectListBox.Name = "objectListBox";
            this.objectListBox.Size = new System.Drawing.Size(215, 355);
            this.objectListBox.TabIndex = 0;
            this.objectListBox.SelectedIndexChanged += new System.EventHandler(this.objectListBox_SelectedIndexChanged);
            // 
            // addObjectButton
            // 
            this.addObjectButton.Location = new System.Drawing.Point(12, 373);
            this.addObjectButton.Name = "addObjectButton";
            this.addObjectButton.Size = new System.Drawing.Size(215, 23);
            this.addObjectButton.TabIndex = 1;
            this.addObjectButton.Text = "Add Object";
            this.addObjectButton.UseVisualStyleBackColor = true;
            this.addObjectButton.Click += new System.EventHandler(this.addObjectButton_Click);
            // 
            // editObjectButton
            // 
            this.editObjectButton.Enabled = false;
            this.editObjectButton.Location = new System.Drawing.Point(12, 402);
            this.editObjectButton.Name = "editObjectButton";
            this.editObjectButton.Size = new System.Drawing.Size(215, 23);
            this.editObjectButton.TabIndex = 2;
            this.editObjectButton.Text = "Edit object";
            this.editObjectButton.UseVisualStyleBackColor = true;
            this.editObjectButton.Click += new System.EventHandler(this.editObjectButton_Click);
            // 
            // ObjectList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 433);
            this.Controls.Add(this.editObjectButton);
            this.Controls.Add(this.addObjectButton);
            this.Controls.Add(this.objectListBox);
            this.Name = "ObjectList";
            this.Text = "Object list";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox objectListBox;
        private System.Windows.Forms.Button addObjectButton;
        private System.Windows.Forms.Button editObjectButton;
    }
}