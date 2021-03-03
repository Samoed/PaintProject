using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Canvas : Form
    {
        private int oldX, oldY;
        public Bitmap bmp;
        private Bitmap startBmp = null;
        private Bitmap tmpBmp = null;
        private string FileName = "";
        private double zoom = 1;
        private bool SaveNeed = false;
        public Canvas()
        {
            InitializeComponent();
            bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
            pictureBox1.Image = bmp;
            MouseWheel += Zoom;
        }

        public Canvas(String FileName)
        {
            InitializeComponent();
            bmp = new Bitmap(FileName);
            this.FileName = FileName;
            Size = new Size(bmp.Width, bmp.Height);
            startBmp = new Bitmap(FileName);
            Graphics g = Graphics.FromImage(bmp);
            
            pictureBox1.Image = bmp;
            pictureBox1.Width = bmp.Width;
            pictureBox1.Height = bmp.Height;
            MouseWheel += Zoom;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            tmpBmp = new Bitmap(bmp);
            if (e.Button == MouseButtons.Left && MainForm.Type == "Обычная кисть")
            {
                Graphics g = Graphics.FromImage(bmp);
                MainForm.Saved = false;
                g.DrawLine(new Pen(MainForm.CurColor, MainForm.CurWidth), oldX, oldY, e.X, e.Y);

                oldX = e.X;
                oldY = e.Y;
            }
            else if (e.Button == MouseButtons.Left && MainForm.Type == "Ластик")
            {
                Graphics g = Graphics.FromImage(bmp);
                Pen pen;
                if (startBmp == null)
                {
                    pen = new Pen(ColorTranslator.FromHtml("#ABABAB"), MainForm.CurWidth);
                }
                else
                {
                    pen = new Pen(startBmp.GetPixel(oldX, oldY), MainForm.CurWidth);
                }
                MainForm.Saved = false;
                g.DrawLine(pen, oldX, oldY, e.X, e.Y);

                oldX = e.X;
                oldY = e.Y;
            }
            else if (e.Button == MouseButtons.Left && MainForm.Type == "Линия")
            {
                Graphics g = Graphics.FromImage(tmpBmp);
                g.DrawLine(new Pen(MainForm.CurColor, MainForm.CurWidth), oldX, oldY, e.X, e.Y);
                pictureBox1.Image = tmpBmp;
            }
            else if (e.Button == MouseButtons.Left && MainForm.Type == "Круг")
            {
                Graphics g = Graphics.FromImage(tmpBmp);
                g.DrawEllipse(new Pen(MainForm.CurColor, MainForm.CurWidth), oldX, oldY, (e.X - oldX), (e.Y - oldY));
                pictureBox1.Image = tmpBmp;
            }
            
            pictureBox1.Invalidate();
        }

        public void Zoom(object sender, MouseEventArgs e)
        {
            SaveNeed = true;
            Bitmap B = new Bitmap(bmp);
            int width, height;
            const double delta = 2;
            if (e.Delta > 0)
            {
                width = (int)(B.Width / delta);
                height = (int)(B.Height / delta);
            }
            else
            {
                width = (int)(B.Width * delta);
                height = (int)(B.Height * delta);
            }
            Graphics g = Graphics.FromImage(B);
            Rectangle R1 = new Rectangle(0, 0, B.Width, B.Height);
            Rectangle R2 = new Rectangle(e.X - width / 2, e.Y - height / 2, width, height);
            g.Clear(BackColor);
            g.DrawImage(pictureBox1.Image, R1, R2, GraphicsUnit.Pixel);
            pictureBox1.Image = B;
            pictureBox1.Invalidate();
            bmp = B;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            SaveNeed = true;
            oldX = e.X;
            oldY = e.Y;
            if (MainForm.Type == "Звезда")
            {
                PointF[] pts = new PointF[5];

                double cx = e.X;
                double cy = e.Y;

                // Start at the top.
                double theta = -Math.PI / 2;
                double dtheta = 4 * Math.PI / 5;
                for (int i = 0; i < 5; i++)
                {
                    pts[i] = new PointF(
                        (float)(cx + 40 * Math.Cos(theta)),
                        (float)(cy + 40 * Math.Sin(theta)));
                    theta += dtheta;
                }
                MainForm.Saved = false;
                Graphics g = Graphics.FromImage(bmp);
                g.DrawPolygon(new Pen(MainForm.CurColor, MainForm.CurWidth), pts);
                pictureBox1.Invalidate();
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MainForm.Saved = false;
                Graphics g = Graphics.FromImage(bmp);
                switch (MainForm.Type)
                {
                    case "Линия":
                        g.DrawLine(new Pen(MainForm.CurColor, MainForm.CurWidth), oldX, oldY, e.X, e.Y);
                        break;
                    case "Круг":
                        g.DrawEllipse(new Pen(MainForm.CurColor, MainForm.CurWidth), oldX, oldY, (e.X - oldX), (e.Y - oldY));
                        break;
                }
                pictureBox1.Image = bmp;
                pictureBox1.Invalidate();
            }
        }
        public int CanvasWidth
        {
            get
            {
                return pictureBox1.Width;
            }
            set
            {
                Size = new Size(value, CanvasHeight);
                pictureBox1.Width = value;
                bmp = new Bitmap(value, pictureBox1.Height);
                Graphics g = Graphics.FromImage(bmp);
                g.Clear(ColorTranslator.FromHtml("#ABABAB"));
                g.DrawImage(bmp, new Point(0, 0));
                pictureBox1.Image = bmp;
            }
        }

        public int CanvasHeight
        {
            get
            {
                return pictureBox1.Height;
            }
            set
            {
                Size = new Size(CanvasWidth, value);
                pictureBox1.Height = value;
                bmp = new Bitmap(pictureBox1.Width, value);
                Graphics g = Graphics.FromImage(bmp);
                g.Clear(ColorTranslator.FromHtml("#ABABAB"));
                g.DrawImage(bmp, new Point(0,0));
                pictureBox1.Image = bmp;
            }
        }

        public void SaveAs()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.AddExtension = true;
            dlg.Filter = "Windows Bitmap (*.bmp)|*.bmp| Файлы JPEG (*.jpg)|*.jpg| Файлы PNG (*.png)|*.png";
            ImageFormat[] ff = { ImageFormat.Bmp, ImageFormat.Jpeg };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileName = dlg.FileName;
                bmp.Save(dlg.FileName, ff[dlg.FilterIndex - 1]);
                SaveNeed = false;
            }
        }

        public void Save()
        {
            if (FileName == "" )
                SaveAs();
            else
            {
                bmp.Save(FileName);
                SaveNeed = false;
            }
        }

        private void Canvas_Load(object sender, EventArgs e)
        {
            
        }

        private void Canvas_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("Хотите сохранить файл перед выходом?", "Сохранение", MessageBoxButtons.YesNoCancel);
            if (res == DialogResult.Yes)
            {
                Save();
            }
            else if (res == DialogResult.Cancel)
            {
                e.Cancel=true;
                return;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
