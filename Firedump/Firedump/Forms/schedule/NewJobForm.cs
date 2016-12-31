﻿using Firedump.models.databaseUtils;
using Firedump.models.pojos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump.Forms.schedule
{
    public partial class NewJobForm : Form
    {
        public delegate void onSetJobDetails(JobDetail jobDetail);
        public event onSetJobDetails setJobDetails;
        private List<string> tables;
        private bool IsInit { get; set; }
        private void OnSetJobDetails(JobDetail jobDetail)
        {
            setJobDetails?.Invoke(jobDetail);
        }

        private firedumpdbDataSet.mysql_serversDataTable serverData;
        private firedumpdbDataSetTableAdapters.mysql_serversTableAdapter mysql_serversAdapter = new firedumpdbDataSetTableAdapters.mysql_serversTableAdapter();

        public NewJobForm()
        {
            InitializeComponent();
            backgroundWorker1.DoWork += fillDatabaseCmb;
            IsInit = true;
            loadComboBoxServers();            
        }


        private void loadComboBoxServers()
        {
            serverData = new firedumpdbDataSet.mysql_serversDataTable();
            mysql_serversAdapter = new firedumpdbDataSetTableAdapters.mysql_serversTableAdapter();
            mysql_serversAdapter.Fill(serverData);
            cmbServers.DataSource = serverData;
            cmbServers.DisplayMember = "name";
            cmbServers.ValueMember = "id";
            if (cmbServers.Items.Count > 0)
            {
                cmbServers.SelectedIndex = 0;
                backgroundWorker1.RunWorkerAsync();
            }
        }


        private void setjobclick(object sender, EventArgs e)
        {
            //validate inputs
            //check if other schedule is in same minute.
            string jobname = tbjobname.Text;
            if (String.IsNullOrEmpty(jobname))
            {
                MessageBox.Show("Job must have a Name!");
                return;
            }

            int day = (int)numericDay.Value;
            int hour = (int)numericHour.Value;
            int minute = (int)numericMinute.Value;
            if (!isTimeValid(day, hour, minute))
            {
                MessageBox.Show("Cant set this!Other Job is with Same Date/Time");
                return;
            }

            DbConnection con = new DbConnection();           
            con.Host = (string)serverData.Rows[cmbServers.SelectedIndex]["host"];
            con.port = unchecked((int)(long)serverData.Rows[cmbServers.SelectedIndex]["port"]);
            con.username = (string)serverData.Rows[cmbServers.SelectedIndex]["username"];
            con.password = (string)serverData.Rows[cmbServers.SelectedIndex]["password"];

            try {
                if (con.testConnection().wasSuccessful)
                {
                    tables = con.getTables(cmbdatabase.SelectedItem.ToString());

                    JobDetail jobdetails = new JobDetail();
                    jobdetails.DayOfWeek = day;
                    jobdetails.Hour = hour;
                    jobdetails.Minute = minute;
                    jobdetails.Name = jobname;
                    jobdetails.Database = cmbdatabase.SelectedItem.ToString();
                    jobdetails.Tables = tables;
                    jobdetails.Server = (firedumpdbDataSet.mysql_serversRow)serverData.Rows[cmbServers.SelectedIndex];

                    OnSetJobDetails(jobdetails);
                    this.Close();
                } else
                {
                    MessageBox.Show("Error connection to server");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }    

        }


        private bool isTimeValid(int day, int hour, int minute)
        {

            firedumpdbDataSetTableAdapters.schedulesTableAdapter scheduleAdapter = new firedumpdbDataSetTableAdapters.schedulesTableAdapter();
            firedumpdbDataSet.schedulesDataTable scheduletable = new firedumpdbDataSet.schedulesDataTable();
            scheduleAdapter.FillOrderByDate(scheduletable);
            if(scheduletable.Count > 0)
            {
                foreach(firedumpdbDataSet.schedulesRow row in scheduletable)
                {
                    if (isScheduleOverLap(row, day, hour, minute))
                        return false;
                }
            }

            return true;
        }

        private bool isScheduleOverLap(firedumpdbDataSet.schedulesRow row,int day,int hour,int minute)
        {
            if (row.day == day && row.hours == hour && row.minutes == minute)
                return true;
            return false;
        }

        private void fillDatabaseCmb(object sender, DoWorkEventArgs args)
        {
            
            if (cmbServers.Items.Count == 0) { return; } //ama den iparxei kanenas server den to kanei           
            DbConnection con = new DbConnection();

            if(!IsInit)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    con.Host = (string)serverData.Rows[cmbServers.SelectedIndex]["host"];
                    con.port = unchecked((int)(long)serverData.Rows[cmbServers.SelectedIndex]["port"]);
                    con.username = (string)serverData.Rows[cmbServers.SelectedIndex]["username"];
                    con.password = (string)serverData.Rows[cmbServers.SelectedIndex]["password"];
                });
            } else
            {
                con.Host = (string)serverData.Rows[cmbServers.SelectedIndex]["host"];
                con.port = unchecked((int)(long)serverData.Rows[cmbServers.SelectedIndex]["port"]);
                con.username = (string)serverData.Rows[cmbServers.SelectedIndex]["username"];
                con.password = (string)serverData.Rows[cmbServers.SelectedIndex]["password"];
            }
            
            Console.WriteLine("cmbServers.Items.Count" + cmbServers.Items.Count);
            //edw prepei na bei to database kai mia if then else apo katw analoga ama kanei connect se server i se database
            try {
                ConnectionResultSet result = con.testConnection();
                if (result.wasSuccessful)
                {
                    List<string> databases = con.getDatabases();

                    databases.Remove("information_schema");
                    databases.Remove("mysql");
                    databases.Remove("performance_schema");
                    databases.Remove("sys");

                    if (!IsInit)
                    {
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            cmbdatabase.Items.Clear();
                        });
                    } else
                    {
                        cmbdatabase.Items.Clear();
                    }

                    foreach (string database in databases)
                    {
                        if (!IsInit)
                        {
                            this.Invoke((MethodInvoker)delegate ()
                            {
                                TreeNode node = new TreeNode(database);
                                node.ImageIndex = 0;
                                cmbdatabase.Items.Add(database);
                                Console.WriteLine(database);
                            });
                        } else
                        {
                            TreeNode node = new TreeNode(database);
                            node.ImageIndex = 0;
                            cmbdatabase.Items.Add(database);
                            Console.WriteLine(database);
                        }
                    }

                    if (!IsInit)
                    {
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            if (cmbdatabase.Items.Count > 0)
                                cmbdatabase.SelectedIndex = 0;
                        });
                    } else
                    {
                        if (cmbdatabase.Items.Count > 0)
                            cmbdatabase.SelectedIndex = 0;
                    }

                }
                else
                {
                    if (!IsInit)
                    {
                        this.Invoke((MethodInvoker)delegate ()
                        {
                            MessageBox.Show("Connection failed: \n" + result.errorMessage, "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });
                    } else
                    {
                        MessageBox.Show("Connection failed: \n" + result.errorMessage, "Test Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            IsInit = false;
        }

        private void cmbServers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                if(cmbServers.Items.Count > 0)
                    backgroundWorker1.RunWorkerAsync();
            }

        }
    }
}