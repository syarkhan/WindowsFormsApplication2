using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class q3 : Form
    {
        const int AW_SLIDE = 0X40000;
        const int AW_HOR_POSITIVE = 0X1;
        const int AW_HOR_NEGATIVE = 0X2;
        const int AW_BLEND = 0X80000;

        [DllImport("user32")]
        static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);
        public q3()
        {
            InitializeComponent();
            Resize += Form1_Resize;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);

        }
        private void Form1_Resize(object sender, System.EventArgs e)
        {
            this.Update();
        }

        private void q3Click(object sender, EventArgs e)
        {
            PictureBox imgObj = sender as PictureBox;

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


            //    Form1.qanswers.Add(1);

            //    //this.Close();

            //}
            //else if (imgObj.Tag == pictureBox2.Tag)
            //{
            //    Form1.qanswers.Add(2);
            //}
            //else
            //{
            //    Form1.qanswers.Add(3);
            //}

            q4 q4Obj = new q4();
            q4Obj.Show();
            this.Close();



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

            //Animate form
            AnimateWindow(this.Handle, 500, AW_SLIDE | AW_HOR_POSITIVE);
        }

        private void q3_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
