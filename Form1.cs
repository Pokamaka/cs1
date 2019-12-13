using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace а_ля_фотошоп
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap image;
        Bitmap save_img;

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) 
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                savedialog.ShowHelp = false;
                if (savedialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
                {
                    try
                    {
                        image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {      
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All files (*.*)|*.*";
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.pictureBox2.Visible = false;
                    this.label1.Visible = false;
                    image = new Bitmap(open_dialog.FileName);
                    //вместо pictureBox1 укажите pictureBox, в который нужно загрузить изображение 
                    this.pictureBox1.Size = image.Size;
                    this.pictureBox1.Image = image;
                    save_img = new Bitmap(pictureBox1.Image);
                    this.pictureBox1.Invalidate();
                    if (this.pictureBox1.Size != this.Size)
                    {
                        this.Size = this.pictureBox1.Size;
                        this.StartPosition = FormStartPosition.CenterScreen;
                    }
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void нормальныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void обрезаннаяКартинкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void автоРазмерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void центрированиеИзображенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void зумToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void поворотНа180ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_img = new Bitmap(pictureBox1.Image);
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

        }

        private void поворотНа90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_img = new Bitmap(pictureBox1.Image);
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void поворотНа45ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_img = new Bitmap(pictureBox1.Image);
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }
       
        private void тёмнаяТемаToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* this.BackColor = Color.FromArgb(31, 28, 28);
            this.panel1.BackColor = Color.FromArgb(31, 28, 28);
            this.menuStrip1.BackColor = Color.FromArgb(31, 28, 28); */
        }

        private void черноБелоеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (черноБелоеToolStripMenuItem.Checked == true)
            {
                if (pictureBox1.Image != null) // если изображение в pictureBox1 имеется
                {
                    save_img = new Bitmap(pictureBox1.Image);
                    Bitmap input = new Bitmap(pictureBox1.Image);
                    Bitmap output = new Bitmap(input.Width, input.Height);
                    for (int j = 0; j < input.Height; j++)
                        for (int i = 0; i < input.Width; i++)
                        {
                            // получаем (i, j) пиксель
                            UInt32 pixel = (UInt32)(input.GetPixel(i, j).ToArgb());
                            // получаем компоненты цветов пикселя
                            float R = (float)((pixel & 0x00FF0000) >> 16);
                            float G = (float)((pixel & 0x0000FF00) >> 8);
                            float B = (float)(pixel & 0x000000FF);
                            // делаем цвет черно-белым (оттенки серого) - находим среднее арифметическое
                            R = G = B = (R + G + B) / 3.0f;
                            // собираем новый пиксель по частям (по каналам)
                            UInt32 newPixel = 0xFF000000 | ((UInt32)R << 16) | ((UInt32)G << 8) | ((UInt32)B);
                            output.SetPixel(i, j, Color.FromArgb((int)newPixel));
                        }
                    pictureBox1.Image = output;
                }
            }
            else
            {
                this.pictureBox1.Image = save_img;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void отразить1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void отразитьНа180ПоХToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_img = new Bitmap(pictureBox1.Image);
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipX);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

        }

        private void отразитьНа180ПоYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_img = new Bitmap(pictureBox1.Image);
            pictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void шагНазадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = save_img;
        }
    }

}

