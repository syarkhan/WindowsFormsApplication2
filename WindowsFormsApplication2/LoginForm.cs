using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApplication2
{
    public partial class LoginForm : Form
    {
        public static string UName = "";
        public static string Email = "";

        public LoginForm()
        {
            InitializeComponent();
            Resize += Form1_Resize;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);
        }
        private void Form1_Resize(object sender, System.EventArgs e)
        {
            this.Update();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            lblerror.Visible = false;
            pictureBox1.Visible = true;
            btn_login.Enabled = false;
            if (txtname.Text.ToString() != "" && txtemail.Text.ToString() != "")
            {

                UName = txtname.Text.ToString();
                Email = txtemail.Text.ToString();
                //db.UserDatas.Add(new UserData
                //{
                //    Name = txtname.Text,
                //    Email = txtemail.Text
                //});
                //db.SaveChanges();

                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
                string emailsPath = path + @"\emails.xlsx";

                try
                {


                    Excel.Application xlApp = new Excel.Application();
                    object misValue = System.Reflection.Missing.Value;
                    Excel.Workbook xlWorkBook;
                    //= xlApp.Workbooks.Open(emailsPath,misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue);
                    Excel.Worksheet xlWorkSheet;
                    xlApp.DisplayAlerts = false;
                    
                    xlWorkBook = xlApp.Workbooks.Add(misValue);

                    if (!File.Exists(emailsPath))
                    {
                        xlWorkBook = xlApp.Workbooks.Add();
                        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                        xlWorkSheet.Cells[1, 1] = "Name";
                        xlWorkSheet.Cells[1, 2] = "Email";
                    }
                    else
                    {
                        xlWorkBook = xlApp.Workbooks.Open(emailsPath, misValue, false, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue);
                        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    }


                    //xlWorkBook = xlApp.Workbooks.Open(emailsPath, misValue, false, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue);
                    

                    

                    //xlWorkSheet.Cells[1, 1] = "Names";
                    //xlWorkSheet.Cells[1, 2] = "Email ID";


                    Excel.Range last = xlWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                    Excel.Range range = xlWorkSheet.get_Range("A1", last);

                    int lastUsedRow = last.Row;
                    int lastUsedColumn = last.Column;

                    xlWorkSheet.Cells[lastUsedRow+1, 1] = txtname.Text.ToString();
                    xlWorkSheet.Cells[lastUsedRow+1, 2] = txtemail.Text.ToString();

                    xlWorkBook.SaveAs(emailsPath, misValue, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlNoChange, misValue, misValue, misValue, misValue, misValue);
                    //GetExcelProcess(xlApp);
                    xlWorkBook.Close(true,emailsPath,misValue);
                    System.Diagnostics.Process[] process = System.Diagnostics.Process.GetProcessesByName("Excel");
                    foreach (System.Diagnostics.Process p in process)
                    {
                        if (!string.IsNullOrEmpty(p.ProcessName))
                        {
                            try
                            {
                                p.Kill();
                            }
                            catch { }
                        }
                    }
                    //xlWorkBook.Close(0);



                    //Marshal.ReleaseComObject(xlWorkSheet);
                    //Marshal.ReleaseComObject(xlWorkBook);
                    //Marshal.ReleaseComObject(xlApp);


                    
                    xlWorkSheet = null;
                    xlWorkBook = null;
                    last = null;
                    range = null;
                    //GC();
                    //xlApp.Quit();
                    xlApp = null;
                    //GC();


                    //GetExcelProcess(xlApp);

                }
                catch(Exception ex)
                {

                }

                //var list = db.UserDatas.ToList();

                //this.Hide();
                //Home home = new Home();
                //home.Show();

                bool IsOpen = false;
                FormCollection fc = Application.OpenForms;

                foreach (Form f in fc)
                {

                    if (f.Name == "Home")
                    {
                        IsOpen = true;
                        f.Focus();
                        break;
                    }
                }

                if (IsOpen == false)
                {
                    Home home = new Home();
                    home.Show();
                }

                //this.Hide();
                //Home f1obj = new Home();
                this.Hide();

                btn_login.Enabled = true;
                pictureBox1.Visible = true;

            }
            else
            {
                lblerror.Visible = true;
                btn_login.Enabled = true;
            }
        }

        //public static void GC()
        //{
        //    System.GC.Collect();
        //    System.GC.WaitForPendingFinalizers();
        //    System.GC.Collect();
        //    System.GC.WaitForPendingFinalizers();
        //}


       
        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
