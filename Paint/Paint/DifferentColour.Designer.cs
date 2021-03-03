
namespace Paint
{
    partial class DifferentColour
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
            this.colorSelect1 = new CustomColorDialog.ColorSelect(MainForm.CurColor);
            this.SuspendLayout();
            // 
            // colorSelect1
            // 
            this.colorSelect1.Location = new System.Drawing.Point(12, 12);
            this.colorSelect1.Name = "colorSelect1";
            this.colorSelect1.Size = new System.Drawing.Size(314, 182);
            this.colorSelect1.TabIndex = 0;
            // 
            // DifferentColour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 212);
            this.Controls.Add(this.colorSelect1);
            this.Name = "DifferentColour";
            this.Text = "DifferentColour";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomColorDialog.ColorSelect colorSelect1;
    }
}