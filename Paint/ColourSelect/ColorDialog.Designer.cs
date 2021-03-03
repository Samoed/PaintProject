namespace CustomColorDialog
{
    partial class ColorSelect 
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.decRadioButton = new System.Windows.Forms.RadioButton();
            this.hexRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.readyButton = new System.Windows.Forms.Button();
            this.greenColourText = new ColourSelect.ColourText(this.components);
            this.blueColourText = new ColourSelect.ColourText(this.components);
            this.redColourText = new ColourSelect.ColourText(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(48, 36);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(55, 13);
            this.label.TabIndex = 1;
            this.label.Text = "Красный:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Зеленый:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Синий:";
            // 
            // decRadioButton
            // 
            this.decRadioButton.AutoSize = true;
            this.decRadioButton.Checked = true;
            this.decRadioButton.Location = new System.Drawing.Point(0, 13);
            this.decRadioButton.Name = "decRadioButton";
            this.decRadioButton.Size = new System.Drawing.Size(47, 17);
            this.decRadioButton.TabIndex = 8;
            this.decRadioButton.TabStop = true;
            this.decRadioButton.Text = "DEC";
            this.decRadioButton.UseVisualStyleBackColor = true;
            this.decRadioButton.CheckedChanged += new System.EventHandler(this.decRadioButton_CheckedChanged);
            // 
            // hexRadioButton
            // 
            this.hexRadioButton.AutoSize = true;
            this.hexRadioButton.Location = new System.Drawing.Point(52, 13);
            this.hexRadioButton.Name = "hexRadioButton";
            this.hexRadioButton.Size = new System.Drawing.Size(47, 17);
            this.hexRadioButton.TabIndex = 9;
            this.hexRadioButton.Text = "HEX";
            this.hexRadioButton.UseVisualStyleBackColor = true;
            this.hexRadioButton.CheckedChanged += new System.EventHandler(this.hexRadioButton_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.decRadioButton);
            this.groupBox1.Controls.Add(this.hexRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(57, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(106, 36);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(169, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 114);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // readyButton
            // 
            this.readyButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.readyButton.Location = new System.Drawing.Point(109, 153);
            this.readyButton.Name = "readyButton";
            this.readyButton.Size = new System.Drawing.Size(75, 23);
            this.readyButton.TabIndex = 12;
            this.readyButton.Text = "Готово";
            this.readyButton.UseVisualStyleBackColor = true;
            // 
            // greenColourText
            // 
            this.greenColourText.Location = new System.Drawing.Point(109, 62);
            this.greenColourText.Name = "greenColourText";
            this.greenColourText.Size = new System.Drawing.Size(53, 20);
            this.greenColourText.TabIndex = 15;
            this.greenColourText.TextChanged += new System.EventHandler(this.colourTextBox_TextChanged);
            // 
            // blueColourText
            // 
            this.blueColourText.Location = new System.Drawing.Point(109, 88);
            this.blueColourText.Name = "blueColourText";
            this.blueColourText.Size = new System.Drawing.Size(53, 20);
            this.blueColourText.TabIndex = 14;
            this.blueColourText.TextChanged += new System.EventHandler(this.colourTextBox_TextChanged);
            // 
            // redColourText
            // 
            this.redColourText.Location = new System.Drawing.Point(110, 36);
            this.redColourText.Name = "redColourText";
            this.redColourText.Size = new System.Drawing.Size(53, 20);
            this.redColourText.TabIndex = 13;
            this.redColourText.TextChanged += new System.EventHandler(this.colourTextBox_TextChanged);
            // 
            // ColorSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.greenColourText);
            this.Controls.Add(this.blueColourText);
            this.Controls.Add(this.redColourText);
            this.Controls.Add(this.readyButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label);
            this.Name = "ColorSelect";
            this.Size = new System.Drawing.Size(314, 182);
            this.Load += new System.EventHandler(this.ColorSelect_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton decRadioButton;
        private System.Windows.Forms.RadioButton hexRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button readyButton;
        private ColourSelect.ColourText redColourText;
        private ColourSelect.ColourText blueColourText;
        private ColourSelect.ColourText greenColourText;
    }
}
