using Firedump.Forms.mysql;
using Firedump.models.pojos;
using Firedump.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private firedumpdbDataSetTableAdapters.mysql_serversTableAdapter serverAdapter = new firedumpdbDataSetTableAdapters.mysql_serversTableAdapter();
        private firedumpdbDataSet.mysql_serversRow server;
        private firedumpdbDataSet.mysql_serversDataTable serverdataTable = new firedumpdbDataSet.mysql_serversDataTable();

        private List<JobDetail> newJobs = new List<JobDetail>();

        public SchedulerForm()
        {
            InitializeComponent();
            firedumpdbDataSetTableAdapters.schedulesTableAdapter scheduleAdapter = new firedumpdbDataSetTableAdapters.schedulesTableAdapter();
            firedumpdbDataSet.schedulesDataTable scheduleTable = new firedumpdbDataSet.schedulesDataTable();
            scheduleAdapter.FillOrderByDate(scheduleTable);

            dataGridView1.DataSource = scheduleTable;
        }

        private void SchedulerForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'firedumpdbDataSet.schedules' table. You can move, or remove it, as needed.
            //this.schedulesTableAdapter.Fill(this.firedumpdbDataSet.schedules);
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

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //change activated value witch is 0 or 1 to true false, true for 0 false for 1
            
            if(e.RowIndex > 0)
            {
                dataGridView1.Rows[e.RowIndex - 1].Cells[1].Value = "Delete";
                int num = 0;
                if (int.TryParse(dataGridView1.Rows[e.RowIndex - 1].Cells[6].Value.ToString(), out num))
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex - 1].Cells[0];
                    if (num == 0)
                    {
                        chk.Value = true;
                    }
                    else
                        chk.Value = false;
                }                  
            }
            
        }


        private void newJobClick(object sender, EventArgs e)
        {
            //run as admin
            //stop service

            //use adds new server-database
            NewJobForm jobForm = new NewJobForm();
            jobForm.setJobDetails += onJobSetDetails;
            jobForm.ShowDialog();
            //service will start at applyChanges button
        }


        private void onJobSetDetails(JobDetail jobDetails)
        {

            Random rnd = new Random();
            int sec = rnd.Next(10,50);
            jobDetails.Second = sec;

            newJobs.Add(jobDetails);
            Console.WriteLine(jobDetails.DayOfWeek);
            
            firedumpdbDataSetTableAdapters.schedulesTableAdapter scheduleAdapter = new firedumpdbDataSetTableAdapters.schedulesTableAdapter();
            scheduleAdapter.Insert((int)jobDetails.Server.id, jobDetails.Name,DateTime.Now,0, jobDetails.Hour, jobDetails.Database,"-",jobDetails.Minute,jobDetails.Second,jobDetails.DayOfWeek);           
            firedumpdbDataSet.schedulesDataTable scheduleTable = new firedumpdbDataSet.schedulesDataTable();
            scheduleAdapter.FillOrderByDate(scheduleTable);

            Console.WriteLine("day:"+scheduleTable[1].day);
            dataGridView1.DataSource = scheduleTable;
            
        }


        private void reloadserverData(int id)
        {           
            serverAdapter.Fill(serverdataTable);
            int i = 0;
            foreach (firedumpdbDataSet.mysql_serversRow row in serverdataTable)
            {
                if (row.id == id)
                {
                    //
                    break;
                }
                i++;
            }
        }

        private void newmysqlserver_click(object sender, EventArgs e)
        {
            NewMySQLServer newMysqlServer = new NewMySQLServer();
            newMysqlServer.ReloadServerData += reloadserverData;
            newMysqlServer.ShowDialog();
        }



        private void applychangesClick(object sender, EventArgs e)
        {
            ServiceController sc = GetServiceStatus();
            if (sc == null)
            {
                MessageBox.Show("Install the Service First!");
                return;
            }

            try
            {
                //Start  the service
                Process proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "servicerestart.bat",
                        UseShellExecute = true,
                        Verb = "runas",
                        CreateNoWindow = true
                    }
                };

                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex) { }

            //after that , check to see if the service started successfully 
            sc = GetServiceStatus();
            if (sc == null)
            {
                MessageBox.Show("Error, cant start the service");
            }
            else
            {
                if (sc.Status == ServiceControllerStatus.Running)
                {
                    MessageBox.Show("Service started");
                }

            }

        }

        /// <summary>
        /// See ServiceControllerStatus for enum info
        /// </summary>
        /// <returns>serviceController.Status enum, null if service is not installed</returns>
        public ServiceController GetServiceStatus()
        {
            ServiceController sc = ServiceController.GetServices()
               .FirstOrDefault(s => s.ServiceName == Consts.SERVICE_NAME);
            if (sc == null)
                return null;

            return sc;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 1)
            {
                int scheduleId = 0;
                if(int.TryParse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(),out scheduleId))
                {
                   if(scheduleId != -1)
                    {
                        DialogResult result = MessageBox.Show("Are you sure you want to delete this Job and its locations?", "Delete Schedule-Job", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            //firt delete backuplocations if any
                            //then delete savelocations
                            //and finally delete from schedule
                        }
                    }
                }
            }
        }
    }
}
