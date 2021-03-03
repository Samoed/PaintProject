using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Configuration;
using PluginInterface;
using CustomColorDialog;

namespace Paint
{
    public partial class MainForm : Form
    {
        public static Color CurColor = Color.Black;
        public static int CurWidth = 3;
        public static bool Saved = false;
        public static string Type = "";
        public MouseEventHandler mouseHandler = null;
        private Dictionary<string, IPlugin> plugins = new Dictionary<string, IPlugin>();
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            сохранитьToolStripMenuItem.Enabled = false;
            сохранитьКакToolStripMenuItem.Enabled = false;
            toolStripComboBox1.SelectedIndex = 0;
            toolStripTextBox1.Text = CurWidth.ToString();
            FindPlugins();
            CreatePluginsMenu();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Saved == false)
            {
                var result = MessageBox.Show("Сохранить перед выходом?", "", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    сохранитьКакToolStripMenuItem_Click(sender, e);
                    Application.Exit();
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            Application.Exit();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox frmAbout = new AboutBox();
            frmAbout.ShowDialog();
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            сохранитьToolStripMenuItem.Enabled = true;
            сохранитьКакToolStripMenuItem.Enabled = true;
            Canvas frmChild = new Canvas();
            frmChild.MdiParent = this;
            frmChild.Show();
        }

        private void рисунокToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            размерХолстаToolStripMenuItem.Enabled = !(ActiveMdiChild == null);
        }

        private void размерХолстаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CanvasSize cs = new CanvasSize();
            cs.CanvasWidth = ((Canvas)ActiveMdiChild).CanvasWidth;
            cs.CanvasHeight = ((Canvas)ActiveMdiChild).CanvasHeight;
            if (cs.ShowDialog() == DialogResult.OK)
            {
                ((Canvas)ActiveMdiChild).CanvasWidth = cs.CanvasWidth;
                ((Canvas)ActiveMdiChild).CanvasHeight = cs.CanvasHeight;
                
            }
        }

        #region Colors
        private void красныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurColor = Color.Red;
        }

        private void синийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurColor = Color.Blue;
        }

        private void зеленыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurColor = Color.Green;
        }

        private void другойToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                CurColor = cd.Color;*/
            DifferentColour dc = new DifferentColour(CurColor);
            if (dc.ShowDialog() == DialogResult.OK)
            {
                CurColor = dc.ColorForm;
            }
        }
        #endregion

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CurWidth = int.Parse(toolStripTextBox1.Text);
            }
            catch
            {
                MessageBox.Show("Значение должн быть целым числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                toolStripTextBox1.Text = "0";
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Windows Bitmap(*.bmp)|*.bmp|Файлы JPEG(*.jpg)|*.jpg |Файлы PNG(*.png)|*.png|Все файлы ()*.*|*.*";
            var result = dlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                Canvas frmChild = new Canvas(dlg.FileName);
                frmChild.MdiParent = this;
                frmChild.Show();
            } 
            else if (result==DialogResult.No)
            {
                ((Canvas)ActiveMdiChild).SaveAs();
                Saved = true;
            }
        }

        #region Clicks
        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((Canvas)ActiveMdiChild).SaveAs();
            Saved = true;
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((Canvas)ActiveMdiChild).Save();
            Saved = true;
        }

        private void каскадомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void сверхуВнизToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void упорядочитьЗначкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void слеваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Type = toolStripComboBox1.SelectedItem.ToString();
        }
        #endregion

        #region Addons
        private void FindPlugins()
        {
            List<string> files = new List<string>();
            if (ConfigurationManager.AppSettings.Count == 0)
            {
                // папка с плагинами
                string folder = Application.StartupPath.Replace("\\bin\\Debug", "\\dll\\");
                //MessageBox.Show(folder);
                // dll-файлы в этой папке
                files =new List<string>(Directory.GetFiles(folder, "*.dll"));
            }
            else
            {
                foreach(string path in ConfigurationManager.AppSettings.Keys)
                {
                    files.Add(ConfigurationManager.AppSettings.GetValues(path)[0]);
                }
            }
            string dialog = "Name\t\t\tAuthor\tVersion\n";
            foreach (string file in files)
                try
                {
                    Assembly assembly = Assembly.LoadFile(file);
                    foreach (Type type in assembly.GetTypes())
                    {
                        var attr = type.GetCustomAttribute<VersionAttribute>();
                        Type iface = type.GetInterface("PluginInterface.IPlugin");
                        if (iface != null)
                        {
                            IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                            plugins.Add(plugin.Name, plugin);
                            dialog += $"{plugin.Name}\t{plugin.Author}\t{attr.Major}.{attr.Minor}\n";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки плагина\n" + ex.Message);
                }
            MessageBox.Show(dialog);
        }

        private void OnPluginClick(object sender, EventArgs args)
        {
            var form = ((Canvas)ActiveMdiChild);
            IPlugin plugin = plugins[((ToolStripMenuItem)sender).Text];
            //MessageBox.Show(form.bmp.Size.ToString());
            form.bmp = plugin.Transform(form.pictureBox1.Image as Bitmap);
            form.pictureBox1.Image = form.bmp; 
            form.pictureBox1.Invalidate();
            //MessageBox.Show(form.bmp.Size.ToString());
        }

        private void CreatePluginsMenu()
        {
            foreach (var plugin in plugins)
            {
                ToolStripMenuItem toolStrip = new ToolStripMenuItem(plugin.Key);
                toolStrip.Click += OnPluginClick;
                расширенияToolStripMenuItem.DropDownItems.Add(toolStrip);
            }
        }

        #endregion
    }
}
