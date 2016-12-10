﻿using Firedump.models.dump;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using Firedump.models.location;
using Firedump.models.sqlimport;
using Firedump.models.configuration.dynamicconfig;

namespace Firedump
{
    public partial class Test1 : Form,IImportAdapterListener
    {
        public Test1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            Compression comp = new Compression();
            comp.absolutePath = "D:\\test\\test 1\\file test.sql";
            comp.doCompress7z();*/
            //Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            /*
            CommonOpenFileDialog cofd = new CommonOpenFileDialog();
            cofd.IsFolderPicker = true;
            cofd.ShowDialog();*/

        }

        private void bLocLocal_Click(object sender, EventArgs e)
        {
            UIServiceDemo usd = new UIServiceDemo();
            usd.demo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UIServiceDemo usd = new UIServiceDemo();
            usd.demoFTP();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ImportCredentialsConfig config = new ImportCredentialsConfig();
            config.host = "127.0.0.1";
            config.port = 3306;
            config.username = "root";
            config.password = "poisodagger9598";
            config.scriptPath = "D:\\MyStuff\\desktop\\anime.sql";
            ImportAdapter adapter = new ImportAdapter(this,config);
            adapter.executeScript();
        }

        public void onImportInit(int maxprogress)
        {
            Console.WriteLine("Max progress: "+maxprogress);
        }

        public void onImportProgress(int progress)
        {
            Console.WriteLine(progress);
        }

        public void onImportComplete(ImportResultSet result)
        {
            Console.WriteLine("Import complete!");
            Console.WriteLine("Result.wasSuccessful = "+result.wasSuccessful);
            Console.WriteLine("Result errormessage = "+result.errorMessage);
        }

        public void onImportError(string message)
        {
            Console.WriteLine(message);
        }
    }
}
