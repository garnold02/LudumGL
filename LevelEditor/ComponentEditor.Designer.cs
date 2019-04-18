namespace LevelEditor
{
    partial class ComponentEditor
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
            this.componentList = new System.Windows.Forms.ListBox();
            this.propertyComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.removeComponentButton = new System.Windows.Forms.Button();
            this.addComponentButton = new System.Windows.Forms.Button();
            this.propertyValueBox = new System.Windows.Forms.TextBox();
            this.componentSelectorBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // componentList
            // 
            this.componentList.FormattingEnabled = true;
            this.componentList.Location = new System.Drawing.Point(15, 30);
            this.componentList.Name = "componentList";
            this.componentList.Size = new System.Drawing.Size(120, 160);
            this.componentList.TabIndex = 0;
            this.componentList.SelectedIndexChanged += new System.EventHandler(this.componentList_SelectedIndexChanged);
            // 
            // propertyComboBox
            // 
            this.propertyComboBox.FormattingEnabled = true;
            this.propertyComboBox.Location = new System.Drawing.Point(144, 30);
            this.propertyComboBox.Name = "propertyComboBox";
            this.propertyComboBox.Size = new System.Drawing.Size(121, 21);
            this.propertyComboBox.TabIndex = 1;
            this.propertyComboBox.SelectedIndexChanged += new System.EventHandler(this.propertyComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Property editor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Component list";
            // 
            // removeComponentButton
            // 
            this.removeComponentButton.Enabled = false;
            this.removeComponentButton.Location = new System.Drawing.Point(144, 167);
            this.removeComponentButton.Name = "removeComponentButton";
            this.removeComponentButton.Size = new System.Drawing.Size(121, 23);
            this.removeComponentButton.TabIndex = 4;
            this.removeComponentButton.Text = "Remove component";
            this.removeComponentButton.UseVisualStyleBackColor = true;
            // 
            // addComponentButton
            // 
            this.addComponentButton.Location = new System.Drawing.Point(144, 111);
            this.addComponentButton.Name = "addComponentButton";
            this.addComponentButton.Size = new System.Drawing.Size(121, 23);
            this.addComponentButton.TabIndex = 5;
            this.addComponentButton.Text = "Add component";
            this.addComponentButton.UseVisualStyleBackColor = true;
            // 
            // propertyValueBox
            // 
            this.propertyValueBox.Location = new System.Drawing.Point(144, 57);
            this.propertyValueBox.Name = "propertyValueBox";
            this.propertyValueBox.Size = new System.Drawing.Size(121, 20);
            this.propertyValueBox.TabIndex = 6;
            // 
            // componentSelectorBox
            // 
            this.componentSelectorBox.FormattingEnabled = true;
            this.componentSelectorBox.Location = new System.Drawing.Point(144, 140);
            this.componentSelectorBox.Name = "componentSelectorBox";
            this.componentSelectorBox.Size = new System.Drawing.Size(121, 21);
            this.componentSelectorBox.TabIndex = 7;
            this.componentSelectorBox.SelectedIndexChanged += new System.EventHandler(this.componentSelectorBox_SelectedIndexChanged);
            // 
            // ComponentEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 206);
            this.Controls.Add(this.componentSelectorBox);
            this.Controls.Add(this.propertyValueBox);
            this.Controls.Add(this.addComponentButton);
            this.Controls.Add(this.removeComponentButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.propertyComboBox);
            this.Controls.Add(this.componentList);
            this.Name = "ComponentEditor";
            this.Text = "Component editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox componentList;
        private System.Windows.Forms.ComboBox propertyComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button removeComponentButton;
        private System.Windows.Forms.Button addComponentButton;
        private System.Windows.Forms.TextBox propertyValueBox;
        private System.Windows.Forms.ComboBox componentSelectorBox;
    }
}