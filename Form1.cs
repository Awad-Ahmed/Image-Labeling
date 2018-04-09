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
             
            string[] PicName;
            protected string[] pFileNames;
            protected int pCurrentImage = -1;
            string ColorName;
            string itemTextCar;
            string noPlate;
            string carType;
            int orientationId = 0x0112;
        
            
            //////////////////////////////////////////////////////////
            ToolStripMenuItem NameTOOL = new ToolStripMenuItem();
            StreamWriter file;
            FolderBrowserDialog Savefolder = new FolderBrowserDialog();
            ColorDialog ColorSelection = new ColorDialog();
            Point contextmenupos;
            OpenFileDialog open = new OpenFileDialog();
            PictureBoxClass pictureBox = new PictureBoxClass();
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
       
            //////////////////////////////////////////////////////////
            private Rectangle Rect2 = new Rectangle();
            private Brush selectionBrush = new SolidBrush(Color.FromArgb(128, 72, 145, 220));
            private Brush selectionBrush2 = new SolidBrush(Color.FromArgb(60, 255, 255, 255));
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
        //get last image
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
        //get next image
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
        //get next image func
            private void Next()
            {
                Rect = new Rectangle();
                Rect3 = new Rectangle();
                pCurrentImage = pCurrentImage == pFileNames.Length - 1 ? 0 : ++pCurrentImage;
                ShowCurrentImage();
                pictureBox.Refresh();
                pictureBox.Invalidate();
                pictureBox.Update();
            
                textBox1.Text = "";
            
            }
        //get previous image func
            private void Previous()
            {
                Rect = new Rectangle();
                Rect3 = new Rectangle();
                pCurrentImage = pCurrentImage == 0 ? pFileNames.Length - 1 : --pCurrentImage;
                ShowCurrentImage();
                pictureBox.Refresh();
                pictureBox.Refresh();
                pictureBox.Invalidate();
                pictureBox.Update();
          
                textBox1.Text = "";
           
            }
        //view image selected from the browser
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
        //open image opens the windows browser dialog to show images
            private void OpenImage()
            {
            
                //image filters

                image = Image.FromFile(open.FileName);
                PicName = open.SafeFileNames;
                pFileNames = open.FileNames;
                pCurrentImage = 0;
                ShowCurrentImage();
                Rect3 = new Rectangle();
                Rect = new Rectangle();
                pictureBox.Refresh();
                //assigning the opened image to pictureBox 
                pictureBox.Image = image;
                Debug.WriteLine("image before " + image.Width + " " + image.Height);
                pictureBox.ClientSize = image.Size;
                pictureBox.Height = image.Height;
                pictureBox.Width = image.Width;
                pictureBox.Size=pic_panel.Size ;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                Debug.WriteLine(" image after " + pictureBox.Width + " " + pictureBox.Height);
                ratio1 = (float)(pictureBox.Image.Width) / pictureBox.Width;
                ratio2 = (float)(pictureBox.Image.Height) / pictureBox.Height;
                Debug.WriteLine(ratio1 + " \n" + ratio2);
                if (pictureBox.Image.PropertyIdList.Contains(orientationId))
                {
                    var orientation = (int)image.GetPropertyItem(orientationId).Value[0];
                
                    if (orientation!=1)
                    {
                      pictureBox.Image.RemovePropertyItem(orientationId);
                      pictureBox.Image.Save(open.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                
                }
                pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
                pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
                pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
                pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
                pic_panel.Controls.Add(pictureBox);
            }
        //calls current image from the list to show it on the picture box
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
                    ratio1 = (float)(pictureBox.Image.Width) / pictureBox.Width;
                    ratio2 = (float)(pictureBox.Image.Height) / pictureBox.Height;
                }
            }
        //function to capture initial mouse click on the picture box
            private void pictureBox_MouseDown(object sender, MouseEventArgs e)
            {
                RectStartPoint = e.Location;
                RectStartPoint2 = e.Location;
                Invalidate();
            }
      //drag function to calculate the mouse offset and calculate the rectange dimensions
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
        //fills the rectangles with the color and draw it on the picture box
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
        //releases the drag operation
            private void pictureBox_MouseUp(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (Rect3.Contains(e.Location))
                    {
                        //Debug.WriteLine("Right click");
                        //  ContextMNU.Show();
                        // ContextMNU.AutoClose = false;
                        ContextMNU.Show(PointToScreen(e.Location));
                        contextmenupos = e.Location;
                    }
                }
            }
        //close the windows
            private void NeuralNetworksGUI_FormClosing(object sender, FormClosingEventArgs e)
            {
                if (pictureBox.Image != null)
                {
                    pictureBox.Dispose();
                }
            }
        //clear the selected image
            private void ClrButton_Click(object sender, EventArgs e)
            {
                if (pictureBox.Image != null)
                {
                    pictureBox.Image = null;
                  //  pictureBox.Invalidate();
                    Rect = new Rectangle();
                    Rect3 = new Rectangle();
                    //Rect2 = new Rectangle();
                    //form2.Refresh();
                    pictureBox.Refresh();
                    NameField.Text = "  ";
                    textBox1.Text = "";
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
        //chooses the directory to save the output files into
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
        //saves the output file
            private void Save()
            {
                carType = itemTextCar;
                noPlate = textBox1.Text;
                if (noPlate.StartsWith("#"))
                {
                    //noPlate = noPlate.Remove(0);
                }
                else
                {
                    noPlate = noPlate.Replace(' ', '_');

                    if(noPlate.Contains('ا'))
                        noPlate = noPlate.Replace('ا', 'أ');

                    if (noPlate.Contains('إ'))
                        noPlate = noPlate.Replace('إ', 'أ');

                    if (noPlate.Contains('ي'))
                        noPlate = noPlate.Replace('ي', 'ى');

                    if (noPlate.StartsWith("_"))
                    {
                        noPlate = noPlate.Remove(0);
                    }
                }
                /*
                rect3 = rectangle of the car
                rect = rectangle of the number plate
                */
                //exception handling for potential  errors
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
                else if (ColorName == null)
                {
                    const string message =
                    "Please Choose a Color";
                    const string caption = "Warning!";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (carType == null)
                {
                    const string message =
                    "Please Choose a Type";
                    const string caption = "Warning!";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (noPlate == null)
                {
                    const string message =
                    "Please Enter no.Plate";
                    const string caption = "Warning!";
                    var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }  
                else
                {//printing the coordinates color and car type in the file 
                    try
                    {
                        string imageName;
                        int index = NameField.Text.LastIndexOf('.');
                        imageName = NameField.Text.Substring(0, index);
                        if (Savefolder.SelectedPath != "")
                        {
                            using (file = new StreamWriter(Savefolder.SelectedPath + "\\" + imageName + ".txt"))
                            {
                                file.WriteLine(NameField.Text + "  " + (int)(Rect3.X * ratio1) + " " + (int)(Rect3.Y * ratio2) + " "
                                + (int)(Rect3.Width * ratio1) + " " + (int)(Rect3.Height * ratio2) + " "
                                + (int)(Rect.X * ratio1) + " " + (int)(Rect.Y * ratio2)
                                + " " + (int)(Rect.Width * ratio1) + " " + (int)(Rect.Height * ratio2) +
                                " " + ColorName + " " + carType + " " + noPlate);
                            }

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
        //calls the save funciton
            private void SaveButton_Click(object sender, EventArgs e)
            {            
           
                Save();
            }              
        //crops the rectangle to verify the coordinates in the prievew button
            private  Bitmap cropAtRect(Bitmap b, Rectangle r)
            {
                Bitmap nb = new Bitmap(r.Width, r.Height);
                Graphics g = Graphics.FromImage(nb);        
                g.DrawImage(b, -r.X, -r.Y);   
                return nb;
            }
        //preview button to show the highlighted image
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
        //handles the closing of the preview window
            private void form2_closed(object sender, FormClosingEventArgs e)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true;
                    form2.Hide();
                }           
            }
        //select color ContextMenu
            private void Colorselect_Click(object sender, EventArgs e)
            {
                ColorSelection.ShowDialog();           
                ContextMNU.Show(PointToScreen(contextmenupos));
                ColorName = ColorSelection.Color.Name;     
                Debug.WriteLine(ColorName);
            }
            private void Help_button_Click(object sender, EventArgs e)
            {
                const string message =
               " 1-Select a picture(or Pictures, By highlighting several pictures at once)." +
               "\n 2-Choose a Directory to sace your work in." +
               "\n 3-Highlight The Car First Using RightClick and Drag." +
               "\n 3-Highlight the Number Plate using LeftClick."+
               "\n 4-After Highligthting the No.Plate, select Color first then Type in order to close the contextmenu, right the car NO in the Noplate Text Box. " +
               "\n#some color names might be saved in HEX format if their name is not available# "+
               "\n 5-Click Save to Write your work into a file."+
               "\n 6-Please Make Sure to save each image before Handling the Next one. " + 
               "\n7-You Can Preview a Rectangle you're uncertain about its \n  coordinates. " + 
               "\n\n NOTE: Incase of non-structured no plates please type # befor the numbers. \n\n LEGEND:"+
               "\n 1-CTRL+S to Save.  \n 3-CTRL+O to Choose Directory." +
               "\n 4-CTRL+N to Choose an Image. \n 5-CTRL+LeftArrowkey Previous, CTRL+RightArrowKey Next. ";
                const string caption = "Help";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Information);
            }
       //keyboard shortcuts
            private void NeuralNetworksAPPGUI_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Control && e.KeyCode == Keys.S)
                {
                    Save();
                }
                else if (e.Control && e.KeyCode == Keys.O)
                {
                    ChooseDirectory();
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
        //gets car type
            private void Get_Carname(object sender, EventArgs e)
            {
                itemTextCar = (sender as ToolStripMenuItem).Text;
                //Debug.WriteLine(itemTextCar);
                // ContextMNU.Show(PointToScreen(contextmenupos));
            }
        //select and frees the textbox out of focus.
            private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == (char)Keys.Enter || e.KeyChar== (char)Keys.Return)
                {

                    label3.Focus();
                }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.BackColor==Color.White)
            { 
            this.BackColor = Color.FromArgb(255,64,64,64);
            ChooseDirectoryBTN.BackColor = Color.FromArgb(255, 64, 64, 64);
            ShowButton.BackColor = Color.FromArgb(255, 64, 64, 64);
            SaveButton.BackColor = Color.FromArgb(255, 64, 64, 64);
            ClrButton.BackColor = Color.FromArgb(255, 64, 64, 64);
            label1.BackColor = Color.FromArgb(255, 64, 64, 64);
            label2.BackColor = Color.FromArgb(255, 64, 64, 64);
            label3.BackColor = Color.FromArgb(255, 64, 64, 64);
            button1.BackColor = Color.FromArgb(255, 64, 64, 64);
            Help_button.BackColor = Color.FromArgb(255, 64, 64, 64);
            button2.BackColor = Color.FromArgb(255, 64, 64, 64);
            ShowButton.ForeColor = Color.HotPink;
            SaveButton.ForeColor = Color.HotPink;
            ClrButton.ForeColor = Color.HotPink;
            label1.ForeColor = Color.HotPink;
            label2.ForeColor = Color.HotPink;
            label3.ForeColor = Color.HotPink;
            button1.ForeColor = Color.HotPink;
            Help_button.ForeColor = Color.HotPink;
            button2.ForeColor = Color.HotPink;
            ChooseDirectoryBTN.ForeColor = Color.HotPink;
            }else
            {
                this.BackColor = Color.White;
                ChooseDirectoryBTN.BackColor = Color.White;
                ShowButton.BackColor = Color.White;
                SaveButton.BackColor = Color.White;
                ClrButton.BackColor = Color.White;
                label1.BackColor = Color.White;
                label2.BackColor = Color.White;
                label3.BackColor = Color.White;
                button1.BackColor = Color.White;
                Help_button.BackColor = Color.White;
                button2.BackColor = Color.White;
                ShowButton.ForeColor = Color.Black;
                SaveButton.ForeColor = Color.Black;
                ClrButton.ForeColor = Color.Black;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                button1.ForeColor = Color.Black;
                Help_button.ForeColor = Color.Black;
                button2.ForeColor = Color.Black;
                ChooseDirectoryBTN.ForeColor = Color.Black;
            }

        }
    }
     }
