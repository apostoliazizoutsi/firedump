using Dropbox.Api;
using Dropbox.Api.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump.Forms.location
{
    public partial class DropboxForm : Form
    {
        private string token = "";

        private LocationSwitchboard locswitch;

        private DropboxClient dbx;
        private FullAccount fullAccount;
        public DropboxForm(LocationSwitchboard locswitch)
        {
            InitializeComponent();
            this.locswitch = locswitch;
            backgroundWorker1.DoWork += connect;
        }


        private async void connect(object sender, DoWorkEventArgs e) 
        {
            Thread.Sleep(2500);
            dbx = new DropboxClient(token);

            try {
                fullAccount = await dbx.Users.GetCurrentAccountAsync();

                
                this.Invoke((MethodInvoker)delegate () {
                    linfo.Text = "Name:" + fullAccount.Name.DisplayName + "  Email:" + fullAccount.Email;
                    this.UseWaitCursor = false;
                });

            }
            catch(Exception ex)
            {
                this.UseWaitCursor = false;
                MessageBox.Show(ex.Message);
            }     
        }

        private void bsaveconnect_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbtoken.Text))
            {
                MessageBox.Show("Must fill token field, visit https://www.dropbox.com/developers/apps to create app and get the token");
                return;
            }

            if (!backgroundWorker1.IsBusy)
            {
                this.UseWaitCursor = true;
                token = tbtoken.Text;
                backgroundWorker1.RunWorkerAsync();
            }
        }


    }
}
