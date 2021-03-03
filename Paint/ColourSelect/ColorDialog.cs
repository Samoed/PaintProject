using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CustomColorDialog
{
    public partial class ColorSelect : UserControl
    {
        private Bitmap bmp;
        private Color color;
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                Color = value;
            }
        }

        public ColorSelect(Color c)
        {
            InitializeComponent();
            color = c;
        }

        private void ColorSelect_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);

            redColourText.Text = color.R.ToString();
            greenColourText.Text = color.G.ToString();
            blueColourText.Text = color.B.ToString();
        }

        private void colourTextBox_TextChanged(object sender, EventArgs e)
        {
            int bas = hexRadioButton.Checked ? 16 : 10;
            int red = 0, green = 0, blue = 0;
            Regex.Replace(redColourText.Text, @"\s+", "");
            Regex.Replace(greenColourText.Text, @"\s+", "");
            Regex.Replace(blueColourText.Text, @"\s+", "");

            if (redColourText.Text != "" && blueColourText.Text != "" && greenColourText.Text != ""
                && !String.IsNullOrEmpty(redColourText.Text) && !String.IsNullOrEmpty(greenColourText.Text) && !String.IsNullOrEmpty(blueColourText.Text))   ////добавил
            {
                red = redColourText.Value;
                green = greenColourText.Value;
                blue = blueColourText.Value;
            }
            else    //добавил
            {
                red = 0;
                green = 0;
                blue = 0;
            }
            color = Color.FromArgb(red, green, blue);

            Graphics g = Graphics.FromImage(bmp);
            g.Clear(color);
            g.DrawImage(bmp, new Point(0, 0));
            pictureBox1.Image = bmp;
            pictureBox1.Invalidate();
        }

        private void decRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (decRadioButton.Checked)
            {
                redColourText.ChangeDecHex();
                greenColourText.ChangeDecHex();
                blueColourText.ChangeDecHex();

                redColourText.Dec = true;
                greenColourText.Dec = true;
                blueColourText.Dec = true;

                redColourText.ChangeBase = false;
                greenColourText.ChangeBase = false;
                blueColourText.ChangeBase = false;
            }
        }

        private void hexRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (hexRadioButton.Checked)
            {
                redColourText.ChangeDecHex();
                greenColourText.ChangeDecHex();
                blueColourText.ChangeDecHex();

                redColourText.Dec = false;
                greenColourText.Dec = false;
                blueColourText.Dec = false;

                redColourText.ChangeBase = false;
                greenColourText.ChangeBase = false;
                blueColourText.ChangeBase = false;
            }
        }
    }
}
