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
    public partial class Home : Form
    {

        const int AW_SLIDE = 0X40000;
        const int AW_HOR_POSITIVE = 0X1;
        const int AW_HOR_NEGATIVE = 0X2;
        const int AW_BLEND = 0X80000;

        [DllImport("user32")]
        static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);

        public Home()
        {
            InitializeComponent();
            Resize += Form1_Resize;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);

        }

        private void Form1_Resize(object sender, System.EventArgs e)
        {
            this.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            bool IsOpen = false;
            FormCollection fc = Application.OpenForms;
            
            foreach (Form f in fc)
            {
                
                if (f.Name == "Form1")
                {
                    IsOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (IsOpen == false)
            {
                Form1 form = new Form1();
                form.Show();
            }

            //this.Hide();
            //Home f1obj = new Home();
            this.Hide();
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

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
