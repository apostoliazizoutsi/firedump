using Dropbox.Api;
using Dropbox.Api.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firedump.Forms.location
{
    public partial class DropboxForm : Form
    {
        //for test
        private string myTestAccessToken = "";
        private string appkey = "";
        private string appsecret = "";

        private LocationSwitchboard locswitch;

        private DropboxClient dbx;
        private FullAccount full;
        public DropboxForm(LocationSwitchboard locswitch)
        {
            InitializeComponent();
            this.locswitch = locswitch;
        }


        private async void Run()
        {
            //dbx = new DropboxClient(myTestAccessToken);

            //full = await dbx.Users.GetCurrentAccountAsync();
            //Console.WriteLine("{0} - {1}", full.Name.DisplayName, full.Email);
        }

        private void bsaveconnect_Click(object sender, EventArgs e)
        {
            string appkey = tbappkey.Text;
            string appsecret = tbappsecret.Text;
            string token = tbtoken.Text;

            if (String.IsNullOrEmpty(appkey) || String.IsNullOrEmpty(appsecret) || String.IsNullOrEmpty(token))
            {
                MessageBox.Show("Must fill all fields, visit https://www.dropbox.com/developers/apps to get the credentials");
                return;
            }


        }
    }
}
