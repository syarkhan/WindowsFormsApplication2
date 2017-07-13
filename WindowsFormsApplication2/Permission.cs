using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Permission : Form
    {

        const int AW_SLIDE = 0X40000;
        const int AW_HOR_POSITIVE = 0X1;
        const int AW_HOR_NEGATIVE = 0X2;
        const int AW_BLEND = 0X80000;

        [DllImport("user32")]
        static extern bool AnimateWindow(IntPtr hwnd, int time, int flags);
        string choice = "";
        Bitmap b = null;
        public static string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
        string consentPath = path + @"\consent";
        string nonConsentPath = path + @"\nonConsent";
        public Permission(Bitmap b)
        {
            this.b = b;
            InitializeComponent();
            Resize += Form1_Resize;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);

        }
        private void Form1_Resize(object sender, System.EventArgs e)
        {
            this.Update();
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
            choice = "yes";
            radioButton1.Checked = true;
        }

        private void Permission_Load(object sender, EventArgs e)
        {
            choice = "yes";
            radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Determine whether the directory exists.

                if (choice == "yes")
                {
                    if (Directory.Exists(consentPath))
                    {

                        b.Save(Path.Combine(consentPath, LoginForm.UName + "_" + LoginForm.Email + ".jpg"));

                    }
                    else
                    {
                       
                            DirectoryInfo di = Directory.CreateDirectory(consentPath);
                            b.Save(Path.Combine(consentPath, LoginForm.UName + "_" + LoginForm.Email + ".jpg"));
                        
                        
                    }
                }
                else if (choice == "no")
                {
                    if (Directory.Exists(nonConsentPath))
                    {

                        b.Save(Path.Combine(nonConsentPath, LoginForm.UName + "_" + LoginForm.Email + ".jpg"));

                    }
                    else
                    {

                        DirectoryInfo di = Directory.CreateDirectory(nonConsentPath);
                        b.Save(Path.Combine(nonConsentPath, LoginForm.UName + "_" + LoginForm.Email + ".jpg"));


                    }
                }

                this.Hide();
                LoginForm form = new LoginForm();
                form.Show();




            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            choice = "yes";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            choice = "no";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
