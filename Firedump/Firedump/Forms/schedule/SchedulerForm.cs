using Firedump.service;
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

namespace Firedump.Forms.schedule
{
    public partial class SchedulerForm : Form
    {
        public SchedulerForm()
        {
            InitializeComponent();
        }

        private void SchedulerForm_Load(object sender, EventArgs e)
        {
            ServiceController sc = serviceManager1.GetServiceStatus();
            if(sc == null)
            {
                serviceManager1.setPictureIcon(false);
                serviceManager1.setStatusText("Firedump Schedule service is not installed");
            }
            else if (sc.Status == ServiceControllerStatus.Running)
            {
                serviceManager1.setPictureIcon(true);
                serviceManager1.setStatusText("Firedump Schedule service is Running");
            } else if(sc.Status == ServiceControllerStatus.Stopped)
            {
                serviceManager1.setPictureIcon(false);
                serviceManager1.setStatusText("Firedump Schedule service is Stopped");
            }
                
        }

        
    }
}
