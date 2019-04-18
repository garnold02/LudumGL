namespace LevelEditor
{
    partial class ObjectEditor
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
            this.label1 = new System.Windows.Forms.Label();
            this.posXBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.posYBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.posZBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rotZBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rotYBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rotXBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.scaleZBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.scaleYBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.scaleXBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.customizeButton = new System.Windows.Forms.Button();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Position";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // posXBox
            // 
            this.posXBox.Location = new System.Drawing.Point(35, 67);
            this.posXBox.Name = "posXBox";
            this.posXBox.Size = new System.Drawing.Size(51, 20);
            this.posXBox.TabIndex = 1;
            this.posXBox.Text = "0";
            this.posXBox.TextChanged += new System.EventHandler(this.posXBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(92, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Y";
            // 
            // posYBox
            // 
            this.posYBox.Location = new System.Drawing.Point(112, 67);
            this.posYBox.Name = "posYBox";
            this.posYBox.Size = new System.Drawing.Size(51, 20);
            this.posYBox.TabIndex = 3;
            this.posYBox.Text = "0";
            this.posYBox.TextChanged += new System.EventHandler(this.posYBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Z";
            // 
            // posZBox
            // 
            this.posZBox.Location = new System.Drawing.Point(189, 67);
            this.posZBox.Name = "posZBox";
            this.posZBox.Size = new System.Drawing.Size(51, 20);
            this.posZBox.TabIndex = 5;
            this.posZBox.Text = "0";
            this.posZBox.TextChanged += new System.EventHandler(this.posZBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(169, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Z";
            // 
            // rotZBox
            // 
            this.rotZBox.Location = new System.Drawing.Point(189, 109);
            this.rotZBox.Name = "rotZBox";
            this.rotZBox.Size = new System.Drawing.Size(51, 20);
            this.rotZBox.TabIndex = 12;
            this.rotZBox.Text = "0";
            this.rotZBox.TextChanged += new System.EventHandler(this.rotZBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(92, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Y";
            // 
            // rotYBox
            // 
            this.rotYBox.Location = new System.Drawing.Point(112, 109);
            this.rotYBox.Name = "rotYBox";
            this.rotYBox.Size = new System.Drawing.Size(51, 20);
            this.rotYBox.TabIndex = 10;
            this.rotYBox.Text = "0";
            this.rotYBox.TextChanged += new System.EventHandler(this.rotYBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "X";
            // 
            // rotXBox
            // 
            this.rotXBox.Location = new System.Drawing.Point(35, 109);
            this.rotXBox.Name = "rotXBox";
            this.rotXBox.Size = new System.Drawing.Size(51, 20);
            this.rotXBox.TabIndex = 8;
            this.rotXBox.Text = "0";
            this.rotXBox.TextChanged += new System.EventHandler(this.rotXBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Location = new System.Drawing.Point(12, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Rotation";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(169, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Z";
            // 
            // scaleZBox
            // 
            this.scaleZBox.Location = new System.Drawing.Point(189, 151);
            this.scaleZBox.Name = "scaleZBox";
            this.scaleZBox.Size = new System.Drawing.Size(51, 20);
            this.scaleZBox.TabIndex = 19;
            this.scaleZBox.Text = "1";
            this.scaleZBox.TextChanged += new System.EventHandler(this.scaleZBox_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(92, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Y";
            // 
            // scaleYBox
            // 
            this.scaleYBox.Location = new System.Drawing.Point(112, 151);
            this.scaleYBox.Name = "scaleYBox";
            this.scaleYBox.Size = new System.Drawing.Size(51, 20);
            this.scaleYBox.TabIndex = 17;
            this.scaleYBox.Text = "1";
            this.scaleYBox.TextChanged += new System.EventHandler(this.scaleYBox_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 154);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "X";
            // 
            // scaleXBox
            // 
            this.scaleXBox.Location = new System.Drawing.Point(35, 151);
            this.scaleXBox.Name = "scaleXBox";
            this.scaleXBox.Size = new System.Drawing.Size(51, 20);
            this.scaleXBox.TabIndex = 15;
            this.scaleXBox.Text = "1";
            this.scaleXBox.TextChanged += new System.EventHandler(this.scaleXBox_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 132);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Scale";
            // 
            // customizeButton
            // 
            this.customizeButton.Location = new System.Drawing.Point(15, 177);
            this.customizeButton.Name = "customizeButton";
            this.customizeButton.Size = new System.Drawing.Size(225, 23);
            this.customizeButton.TabIndex = 21;
            this.customizeButton.Text = "Customize Components";
            this.customizeButton.UseVisualStyleBackColor = true;
            this.customizeButton.Click += new System.EventHandler(this.customizeButton_Click);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(15, 25);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(225, 20);
            this.nameBox.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Name";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(225, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Graphics editor";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ObjectEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 241);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.customizeButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.scaleZBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.scaleYBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.scaleXBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rotZBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rotYBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rotXBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.posZBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.posYBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.posXBox);
            this.Controls.Add(this.label1);
            this.Name = "ObjectEditor";
            this.Text = "Object editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox posXBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox posYBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox posZBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox rotZBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox rotYBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox rotXBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox scaleZBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox scaleYBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox scaleXBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button customizeButton;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button1;
    }
}

