using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Permissions;
using System.Security.Principal;
using System.Runtime.InteropServices;

namespace Line30_PLC_reset
{
    public partial class Form1 : Form
    {
        //private readonly object AdvApi32Utility;
        public string ser = "line30";

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //if(cmbService.Text != "line38")
            //{ 
            //    ServiceController MyController = new ServiceController();
            //    MyController.MachineName = "10.98.100.46";
            //    MyController.ServiceName = ser;

            //    string msg = MyController.Status.ToString();
            //    lblStatus.Text = msg;
            //    if (MyController.Status.ToString() == "Running")
            //    {
            //        btnStart.Enabled = false;
            //        btnStop.Enabled = true;
            //    }
            //    else
            //    {
            //        btnStart.Enabled = true;
            //        btnStop.Enabled = false;
            //    }
            //}
            //else 
            //{
                //Line 38 Service
                ServiceController MyController = new ServiceController();
            MyController.MachineName = "10.98.227.85"; //PC Ip address
            MyController.ServiceName = ser;

                string msg = MyController.Status.ToString();
                lblStatus.Text = msg;
                if (MyController.Status.ToString() == "Running")
                {
                    btnStart.Enabled = false;
                    btnStop.Enabled = true;
                }
                else
                {
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                }
            //}
        }
        private void label2_Click(object sender, EventArgs e)
        {
            lblStatus.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // initialize empty process
            Process pros = null;
            try
            {
                string BatFileDir = string.Format(@"C:\Users"); // directory of the file
                pros = new Process();
                pros.StartInfo.WorkingDirectory = BatFileDir;
                pros.StartInfo.FileName = ser + "start.bat"; // batch file name to be execute
                pros.StartInfo.CreateNoWindow = false;
                pros.Start(); // run batch file
                pros.WaitForExit();
                string fdBackST = "The line " + ser + " has been STARTED";
                MessageBox.Show(fdBackST);
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                Form1_Load(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Process pros = null;
            try
            {
                string BatFileDir = string.Format(@"C:\Users"); // directory of the file
                pros = new Process();
                pros.StartInfo.WorkingDirectory = BatFileDir;
                pros.StartInfo.FileName = ser + "stop.bat"; // batch file name to be execute
                pros.StartInfo.CreateNoWindow = false;
                pros.Start(); // run batch file
                pros.WaitForExit(); 
                string fdBackSP = "The line " + ser + " has been STOPPED";
                MessageBox.Show(fdBackSP);
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                Form1_Load(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace.ToString());
            }
        }
        public static void GetPassword(out string username, out string password)
        {
            
            username = "ZAESA\\za60odex";
            password = "odexbmw";
        }

        private void cmbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            ser = cmbService.Text;
            ServiceController MyController = new ServiceController();
            MyController.MachineName = "10.98.100.46";
            MyController.ServiceName = cmbService.Text;

            string msg = MyController.Status.ToString();
            lblStatus.Text = msg;
            if (MyController.Status.ToString() == "Running")
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
            }
            else
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

namespace System
{
    class ServiceModel
    {
    }
}