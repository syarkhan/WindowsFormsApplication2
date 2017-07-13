using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication2
{
    public partial class Preview : Form
    {

        //const int AW_SLIDE = 0X40000;
        //const int AW_HOR_POSITIVE = 0X1;
        //const int AW_HOR_NEGATIVE = 0X2;
        //const int AW_BLEND = 0X80000;

        //[DllImport("user32")]
        //static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);
        //public static string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
        //string consentPath = path + @"\consent";
        //string nonConsentPath = path + @"\nonConsent";
        Image image = null;
        
        public Preview(Image image)
        {
            InitializeComponent();
            this.image = image;
            Resize += Form1_Resize;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);

        }
        private void Form1_Resize(object sender, System.EventArgs e)
        {
            this.Update();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Preview_Load(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(image);
            //bmp.Height
            pictureBox1.Image = bmp;
            //pictureBox1
            
        }

        //protected override void OnLoad(EventArgs e)
        //{
        //    //Load the Form At Position of Main Form
        //    int WidthOfMain = Application.OpenForms["LoginForm"].Width;
        //    int HeightofMain = Application.OpenForms["LoginForm"].Height;
        //    int LocationMainX = Application.OpenForms["LoginForm"].Location.X;
        //    int locationMainy = Application.OpenForms["LoginForm"].Location.Y;

        //    //Set the Location
        //    this.Location = new Point(LocationMainX + WidthOfMain, locationMainy + 10);

        //    //Animate form
        //    AnimateWindow(this.Handle, 500, AW_SLIDE | AW_HOR_POSITIVE);
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            FormCameraControlTool frm = new FormCameraControlTool();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Home frm = new Home();
            frm.Show();
        }



        private void button1_Click_1(object sender, EventArgs e) //Print
        {

            Bitmap b = new Bitmap(image, pictureBox1.Width, pictureBox1.Height);
            //Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),"MyFile.jpg");



            //try
            //{
            //    // Determine whether the directory exists.
            //    if (Directory.Exists(consentPath))
            //    {
            //        //Console.WriteLine("That path exists already.");
            //        //if (!Directory.Exists(Path.Combine(consentPath, "MyFile.jpg")))
            //        //{
            //        //    //Directory.CreateDirectory(@"c:\text");
            //        b.Save(Path.Combine(consentPath, LoginForm.UName + "_" + LoginForm.Email + ".jpg"));
            //        //}

            //        //return;
            //    }
            //    else
            //    {
            //        DirectoryInfo di = Directory.CreateDirectory(consentPath);
            //        b.Save(Path.Combine(consentPath, LoginForm.UName+"_"+LoginForm.Email+".jpg"));
            //    }
            //    // Try to create the directory.

            //    //Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));

            //    // Delete the directory.
            //    //di.Delete();
            //    //Console.WriteLine("The directory was deleted successfully.");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("The process failed: {0}", ex.ToString());
            //}


            try
            {


                PrintDialog pd = new PrintDialog();
                PrintDocument doc = new PrintDocument();
                //doc.DefaultPageSettings.Landscape = true;
                doc.PrintPage += PrintPage;

                //foreach (string s in PrinterSettings.InstalledPrinters)
                //{

                //    if ((s.ToString() != "Fax") || (s.ToString() != "Send to OneNote 2016") || (s.ToString() != "Microsoft Print to PDF") || (s.ToString() != "Microsoft XPS Document Writer"))
                //    {

                //    }
                //    else
                //    {
                //        doc.PrinterSettings.PrinterName = s;
                //        doc.Print();
                //    }

                //}
                //if (pd.ShowDialog() == DialogResult.OK)
                //{
                //    doc.Print();
                //}
                doc.Print();
                //this.Hide();
                //Permission form = new Permission(b);
                //form.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Printer disconnected","Error");
            }
            this.Hide();
            Permission form = new Permission(b);
            form.Show();
            

        }

        private void PrintPage(object o, PrintPageEventArgs e)
        {
            //System.Drawing.Image img = System.Drawing.Image.FromFile(Path.Combine(consentPath, LoginForm.UName + "_" + LoginForm.Email + ".jpg"));
            Bitmap bm = new Bitmap(815, 500);

            Graphics graphic = Graphics.FromImage(bm);
            graphic.DrawImage(image, 0, 0, 815, 500);

            Bitmap bmm = new Bitmap(image);

            pictureBox1.DrawToBitmap(bmm, new Rectangle(0, 0, 815, 500));
            //Point loc = new Point(-100, -100);
            e.Graphics.DrawImage(bm, 1, 0);
            bm.Dispose();
            bmm.Dispose();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
