using System;
using System.ServiceProcess;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualBasic;

namespace StopStartMSSqlServer
{
    public partial class FrmMains : Form
    {
        public FrmMains()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                ServiceController service = new ServiceController("MSSQLSERVER", "DESKTOP-3EIH3C3");
                if ((service.Status.Equals(ServiceControllerStatus.Stopped))
                    | ((service.Status.Equals(ServiceControllerStatus.StopPending))))
                {
                    label1.Text = "السيرفر متوقف حاليا";
                    label1.ForeColor = Color.Red;
                    button1.Enabled = true;

                }
                else
                {
                    label1.Text = "السيرفر يعمل حاليا";
                    label1.ForeColor = Color.Green;
                    button1.Enabled = false;
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceController service = new ServiceController("MSSQLSERVER", "DESKTOP-3EIH3C3");
#pragma warning disable CA1416 // Validate platform compatibility
                if ((service.Status.Equals(ServiceControllerStatus.Stopped))
#pragma warning restore CA1416 // Validate platform compatibility
                    | ((service.Status.Equals(ServiceControllerStatus.StopPending))))
                {
                    service.Start();
                   
                    label1.Text = "السيرفر يعمل حاليا";
                    label1.ForeColor = Color.Green;
                    Interaction.MsgBox("تم تفعيل السيرفر");
                    button1.Enabled = false;
                }

            }
            catch (Exception )
            {
                if (Interaction.MsgBox("لم نتمكن من تفعيل السيرف ", MsgBoxStyle.Exclamation, "الاتصال بالسيرفر") == MsgBoxResult.Retry)
                {
                    button1_Click(sender, e);
                }
            }
        }


    }

}
