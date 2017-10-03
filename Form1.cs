using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.IO;

namespace NeuralNetworksApp
{
    public partial class NeuralNetworksAPPGUI : Form
    {
        //to capture the images name 
        string[] PicName;
        protected string[] pFileNames;
        protected int pCurrentImage = -1;
        string ColorName;
        string itemTextCar;
        int Listindex;// to point out the lates rectangle in the list
        List<string> ColorNameCount = new List<string>();
        List<string> CarType = new List<string>();
        //////////////////////////////////////////////////////////
        ToolStripMenuItem NameTOOL = new ToolStripMenuItem();
        StreamWriter file;
        FolderBrowserDialog Savefolder = new FolderBrowserDialog();
        ColorDialog ColorSelection = new ColorDialog();
        OpenFileDialog open = new OpenFileDialog();
        //////////////////////////////////////////////////////////
        Form form2 = new Form();
        Panel p = new Panel();
        Graphics d;
        Bitmap pic;
        PictureBox pictureBox1 = new PictureBox();
        Image image;
        private Point RectStartPoint;
        private Point RectStartPoint2;
        private Rectangle Rect = new Rectangle();
        private Rectangle Rect3 = new Rectangle();
        private List<Rectangle> Lrect = new List<Rectangle>();
        private List<Rectangle> Lrect3 = new List<Rectangle>();
        //////////////////////////////////////////////////////////
        private Rectangle Rect2 = new Rectangle();
        private Brush selectionBrush = new SolidBrush(Color.FromArgb(128, 72, 145, 220));
        private Brush selectionBrush2 = new SolidBrush(Color.FromArgb(60, 124, 252, 0));
        double ratio1 = 0.0000;
        double ratio2 = 0.0000;
        //////////////////////////////////////////////////////////
        public NeuralNetworksAPPGUI()
        {
            this.AutoSize = false;
            InitializeComponent();
        }
        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        { }
        private void PrvButton_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
            {
                const string message = "Please Choose an Image First! ";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (pFileNames.Length > 0)
            {
                Previous();
            }
        }
        private void NxtButton_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image == null)
            {
                const string message = "Please Choose an Image First! ";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           else if (pFileNames.Length > 0)
            {
                Next();
            }
        }
        private void Next()
        {
            pCurrentImage = pCurrentImage == pFileNames.Length - 1 ? 0 : ++pCurrentImage;
            ShowCurrentImage();
            pictureBox.Refresh();
            pictureBox.Invalidate();
            pictureBox.Update();
            Lrect.Clear();
            Lrect3.Clear();
            ColorNameCount.Clear();
            CarType.Clear();
        }
        private void Previous()
        {
            pCurrentImage = pCurrentImage == 0 ? pFileNames.Length - 1 : --pCurrentImage;
            ShowCurrentImage();
            pictureBox.Refresh();
            pictureBox.Refresh();
            pictureBox.Invalidate();
            pictureBox.Update();
            Lrect.Clear();
            Lrect3.Clear();
            ColorNameCount.Clear();
            CarType.Clear();
        }
        private void ShowButton_Click(object sender, EventArgs e)
        {
            //open file dialog
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;*.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            open.Multiselect = true;
            if (open.ShowDialog() == DialogResult.OK)
            {
                OpenImage();
            }
        }
        private void OpenImage()
        {
            
            //image filters

            image = Image.FromFile(open.FileName);
            PicName = open.SafeFileNames;
            pFileNames = open.FileNames;
            pCurrentImage = 0;
            ShowCurrentImage();
            //assigning the opened image to pictureBox 
            pictureBox.Image = image;
            Debug.WriteLine("image before " + image.Width + " " + image.Height);
            pictureBox.ClientSize = image.Size;
            pictureBox.Height = image.Height;
            pictureBox.Width = image.Width;
            Debug.WriteLine(" image after " + pictureBox.Width + " " + pictureBox.Height);
            ratio1 = (float)(image.Width) / pictureBox.Width;
            ratio2 = (float)(image.Height) / pictureBox.Height;
            Debug.WriteLine(ratio1 + " \n" + ratio2);
            pic_panel.Controls.Add(pictureBox);
        }
        protected void ShowCurrentImage()
        {
            if (pCurrentImage >= 0 && pCurrentImage <= pFileNames.Length - 1)
            {
                pictureBox.Image = Image.FromFile(pFileNames[pCurrentImage]);
                //pictureBox1.Image = Image.FromFile(pFileNames[pCurrentImage]);
                pictureBox.Refresh();
                pictureBox.Invalidate();
                pictureBox.Update();
                NameField.Text = PicName[pCurrentImage];
                Debug.WriteLine(ratio1 + " \n" + ratio2);
            }
        }
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            RectStartPoint = e.Location;
            RectStartPoint2 = e.Location;
            Invalidate();
        }
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point tempEndPoint = e.Location;
                Rect.Location = new Point(
                    Math.Min(RectStartPoint.X, tempEndPoint.X), +
                    Math.Min(RectStartPoint.Y, tempEndPoint.Y));
                Rect.Size = new Size(
                    Math.Abs(RectStartPoint.X - tempEndPoint.X),
                    Math.Abs(RectStartPoint.Y - tempEndPoint.Y));
                pictureBox.Invalidate();
            }
            else if (e.Button == MouseButtons.Right)
            {
                Point tempEndPoint2 = e.Location;
                Rect3.Location = new Point(
                    Math.Min(RectStartPoint2.X, tempEndPoint2.X), +
                    Math.Min(RectStartPoint2.Y, tempEndPoint2.Y));
                Rect3.Size = new Size(
                    Math.Abs(RectStartPoint2.X - tempEndPoint2.X),
                    Math.Abs(RectStartPoint2.Y - tempEndPoint2.Y));
                pictureBox.Invalidate();
            }
        }
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            // Draw the rectangle...
            if (pictureBox.Image != null)
            {
                if (Rect != null && Rect.Width > 0 && Rect.Height > 0)
                {
                    e.Graphics.FillRectangle(selectionBrush, Rect);
                }
                if (Rect3 != null && Rect3.Width > 0 && Rect3.Height > 0)
                {
                    e.Graphics.FillRectangle(selectionBrush2, Rect3);
                }
            }
        }
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Rect3.Contains(e.Location))
                {
                    //Debug.WriteLine("Right click");
                    ContextMNU.Show();
                    ContextMNU.AutoClose = false;
                    ContextMNU.Show(PointToScreen(e.Location));
                }
            }
        }
        private void NeuralNetworksGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pictureBox.Image != null)
            {
                pictureBox.Dispose();
            }
        }
        private void ClrButton_Click(object sender, EventArgs e)
        {
            if (pictureBox.Image != null)
            {
                pictureBox.Image = null;
                pictureBox.Invalidate();
                //Rect = new Rectangle();
                //Rect2 = new Rectangle();
                //form2.Refresh();
                pictureBox.Refresh();
                NameField.Text = "  ";
            }
            /*
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = null;
                pictureBox1.Invalidate(); 
                form2.Refresh();
                pictureBox.Refresh();
                //NameField.Text = "  ";
                //zoomSlider.Value = 0;
            }*/
        }
        private void ChooseDirectoryBTN_Click(object sender, EventArgs e)
        {
            ChooseDirectory();
        }
        private void ChooseDirectory()
        {
            if (Savefolder.ShowDialog() == DialogResult.OK)
            {
                Debug.WriteLine(Savefolder.SelectedPath);
            }
        }
        private void Save()
        {
            /*
            rect3 = rectangle of the car
            rect = rectangle of the number plate
            */
            if (pictureBox.Image == null)
            {
                const string message = "Please Choose an Image First! ";
                const string caption = "Error";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Rect.Width == 0 || Rect3.Width == 0)
            {
                const string message =
                "Please Draw The Two Rectangles";
                const string caption = "Warning!";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    string imageName;
                    int index = NameField.Text.LastIndexOf('.');
                    imageName = NameField.Text.Substring(0, index);
                    if (Savefolder.SelectedPath != "")
                    {
                        for (int j = 0; j < Lrect.Count; j++)
                        {
                            using (file = new StreamWriter(Savefolder.SelectedPath + "\\" + imageName + ".box", true))
                                file.WriteLine(NameField.Text + "  " + (int)(Lrect3[j].X * ratio1) + " " + (int)(Lrect3[j].Y * ratio2) + " "
                                + (int)(Lrect3[j].Width * ratio1) + " " + (int)(Lrect3[j].Height * ratio2) + " "
                                + (int)(Lrect[j].X * ratio1) + " " + (int)(Lrect[j].Y * ratio2)
                                + " " + (int)(Lrect[j].Width * ratio1) + " " + (int)(Lrect[j].Height * ratio2) +
                                " " + ColorNameCount[j] + " " + CarType[j]);
                            /*  Debug.WriteLine(NameField.Text + "  " + (int)(Lrect3[j].X * ratio1) + " " + (int)(Lrect3[j].Y * ratio2) + " "
                           + (int)(Lrect3[j].Width * ratio1) + " " + (int)(Lrect3[j].Height * ratio2) + " "
                           + (int)(Lrect[j].X * ratio1) + " " + (int)(Lrect[j].Y * ratio2)
                           + " " + (int)(Lrect[j].Width * ratio1) + " " + (int)(Lrect[j].Height * ratio2) +
                           " " + ColorNameCount[j] );*/
                        }
                        file.Close();
                        Lrect.Clear();
                        Lrect3.Clear();
                        ColorNameCount.Clear();
                        CarType.Clear();
                    }
                    else
                    {
                        const string message = "Please Choose a Directory!";
                        const string caption = "Error No Choosen Directory";
                        var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    const string message = "Please Choose a Directory!";
                    const string caption = "Error No Choosen Directory";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Save();
        }
        private  Bitmap cropAtRect(Bitmap b, Rectangle r)
        {
            Bitmap nb = new Bitmap(r.Width, r.Height);
            Graphics g = Graphics.FromImage(nb);        
            g.DrawImage(b, -r.X, -r.Y);   
            return nb;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            form2.Refresh();
            form2.Update();
            Rect2.X =(int)( Rect.X*ratio1);
            Rect2.Width = (int)(Rect.Width * ratio1);
            Rect2.Height= (int)(Rect.Height * ratio2);
            Rect2.Y= (int)(Rect.Y * ratio2);
            /////////////////////////////////   
            if (Rect2.Width != 0 && Rect2.Height != 0)
            {
                 pic = new Bitmap(pictureBox.Image);
               pictureBox1.Image = cropAtRect(pic, Rect2);
            }
            else {
                const string message =
                "Please Draw A Rectangle";
                const string caption = "Warning!";
                var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }                     
            pictureBox1.Height = Rect2.Height;
            pictureBox1.Width = Rect2.Width ;
            pictureBox1.ClientSize = pictureBox.ClientSize;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            p.Dock = DockStyle.Fill;
            p.AutoScroll = true;
            /////////////////////////////////
            form2.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form2_closed);
            form2.Controls.Add(p);
            p.Controls.Add(pictureBox1);
            form2.Height = pictureBox1.Height;
            form2.Width = pictureBox1.Width;
            pictureBox1.Update();
            form2.Show();
            form2.Refresh();
            form2.Update();
            p.Refresh();        
        }
        private void form2_closed(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                form2.Hide();
            }           
        }
        private void Colorselect_Click(object sender, EventArgs e)
        {
            ColorSelection.ShowDialog();
            ColorName = ColorSelection.ToString().Split(',', '[', ']')[2];
            Debug.WriteLine(ColorName);
        }
        private void Help_button_Click(object sender, EventArgs e)
        {
            const string message =
           " 1-Choose a Directory. \n 2-Highlight The Car First Using RightClick and Drag. \n 3-Highlight the Number Plate using LeftClick. \n 4-After Highligthting the No.Plate, select Color and Type. \n 5- Click Add Rects to Save the Previous highlights you Made. \n 6-Please Make Sure to save each image before Handling the Next one. \n7-You Can Preview a Rectangle you're uncertain about its \n   coordinates. \n\n LEGEND:\n 1-CTRL+S to Save. \n 2-CTRL+A to ADDnewRect. \n 3-CTRL+Z to Remove Latest Rect Added \n or Remove The same Rect Added Twice. \n 4-CTRL+O to Choose Directory. \n 5-CTRL+N to Choose an Image. \n 6-CTRL+LeftArrowkey Previous, CTRL+RightArrowKey Next. ";
            const string caption = "Help";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Information);
        }
        private void Get_Carname(object sender, EventArgs e)
        {
            itemTextCar = (sender as ToolStripMenuItem).Text;
            Debug.WriteLine(itemTextCar);
        }
        private void ADD_RECT_Click(object sender, EventArgs e)
        {
            ADD();
        }
        private void ADD()
        {
            Lrect.Add(Rect);
            Lrect3.Add(Rect3);
            ColorNameCount.Add(ColorName);
            CarType.Add(itemTextCar);
            Debug.Write("rect added\n");
            Listindex = Lrect.IndexOf(Rect);
            Debug.WriteLine(Listindex);
        }
        private void NeuralNetworksAPPGUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                Save();
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                ADD();
            }
            else if (e.Control && e.KeyCode == Keys.O)
            {
                ChooseDirectory();
            }
            else if (e.Control && e.KeyCode == Keys.Z)
            {
                Lrect.RemoveAt(Listindex);
                Lrect3.RemoveAt(Listindex);
                CarType.RemoveAt(Listindex);
                ColorNameCount.RemoveAt(Listindex);
                Listindex--;
                // deletes latest index in the lists of a rect or the others
            }
            else if (e.Control && e.KeyCode == Keys.N)
            {
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;*.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
                open.Multiselect = true;
                if (open.ShowDialog() == DialogResult.OK)
                {
                    OpenImage();
                }
            }
            else if (e.Control && e.KeyCode==Keys.Right)
            {
                if (pFileNames.Length > 0)
                {
                    Next();
                }
            }
            else if (e.Control && e.KeyCode==Keys.Left)
            {
                if (pFileNames.Length > 0)
                {
                    Previous();
                }
            }
        }       
    }
 }
