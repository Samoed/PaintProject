using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class DifferentColour : Form
    {
        private Color color;
        public Color ColorForm => colorSelect1.Color;
        public DifferentColour(Color color)
        {
            InitializeComponent();
            this.color = color;
        }

        private void DifferentColour_Load(object sender, EventArgs e)
        {
            colorSelect1.Color = color;
        }
    }
}
