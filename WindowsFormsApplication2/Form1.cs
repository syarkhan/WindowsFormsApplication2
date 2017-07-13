using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication2
{

   

    public partial class Form1 : Form
    {
        //Constants
        const int AW_SLIDE = 0X40000;
        const int AW_HOR_POSITIVE = 0X1;
        const int AW_HOR_NEGATIVE = 0X2;
        const int AW_BLEND = 0X80000;

        [DllImport("user32")]
        static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);

        public static List<int> qanswers = new List<int>();
        public static string tago;
        public Form1()
        {
            InitializeComponent();
            Resize += Form1_Resize;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);

        }
        private void Form1_Resize(object sender, System.EventArgs e)
        {
            this.Update();
        }
        private void q1Click(object sender, EventArgs e)
        {
            PictureBox imgObj = sender as PictureBox;
            //this.Hide();
            if (Convert.ToInt16(imgObj.Tag) == 1)
            {


                Form1.qanswers.Add(1);

                //this.Close();

            }
            else if (Convert.ToInt16(imgObj.Tag) == 2)
            {
                Form1.qanswers.Add(2);
            }
            else if (Convert.ToInt16(imgObj.Tag) == 3)
            {
                Form1.qanswers.Add(3);
            }
            //if (imgObj.Tag == pictureBox1.Tag)
            //{


            //    qanswers.Add(1);

            //    //this.Close();

            //}
            //else if (imgObj.Tag == pictureBox2.Tag)
            //{
            //    qanswers.Add(2);
            //}
            //else
            //{
            //   qanswers.Add(3);
            //}


            bool IsOpen = false;
            FormCollection fc = Application.OpenForms;
            foreach (Form f in fc)
            {
                if (f.Name == "q2")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                q2 q2Obj = new q2();
                q2Obj.Show();
            }

            //Form1 f1obj = new Form1();
            this.Hide();

            //q2 q2Obj = new q2();
            //q2Obj.ShowDialog();

        }


        protected override void OnLoad(EventArgs e)
        {
            //Load the Form At Position of Main Form
            int WidthOfMain = Application.OpenForms["LoginForm"].Width;
            int HeightofMain = Application.OpenForms["LoginForm"].Height;
            int LocationMainX = Application.OpenForms["LoginForm"].Location.X;
            int locationMainy = Application.OpenForms["LoginForm"].Location.Y;

            //Set the Location
            this.Location = new Point(LocationMainX + WidthOfMain, locationMainy + 10);
            //this.BackgroundImage = Application.OpenForms["Home"].BackgroundImage;

            //Animate form
            AnimateWindow(this.Handle, 500, AW_SLIDE | AW_HOR_POSITIVE);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
