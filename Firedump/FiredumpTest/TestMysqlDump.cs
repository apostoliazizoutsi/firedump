﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Firedump.models.dump;
using Firedump.models.configuration.dynamicconfig;
using Firedump.models.configuration.jsonconfig;
using System.IO;
using Firedump.Forms.mysql;
using System.Collections.Generic;
using Firedump.models.databaseUtils;
using log4net;
using log4net.Config;
using System.Threading.Tasks;
using System.Threading;

namespace FiredumpTest
{
    [TestClass]
    public class TestMysqlDump
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(TestMysqlDump));
        public List<string> tables = new List<string>();
        /// <summary>
        /// runs only once at class init
        /// </summary>
        [ClassInitialize()]
        public static void initDb(TestContext context)
        {
            //num of rows to create for the dumptest to run
            //it will be deleted as the whle database at the end of the run
            //calling clearDb()
            BasicConfigurator.Configure();
            TestDbConnection.populateDb(40);
        }


        /// <summary>
        /// runs only once at class destroy
        /// </summary>
        [ClassCleanup()]
        public static void clearDb()
        {
            TestDbConnection.clearDb();
        }


        /// <summary>
        /// runs every time before every test method
        /// </summary>
        [TestInitialize()]
        public void Initialize()
        {
        }

        /// <summary>
        /// runs every time after every test method
        /// </summary>
        [TestCleanup()]
        public void Cleanup()
        {
        }


        [TestMethod]
        public void TestExecuteDump()
        {
            ConfigurationManager.getInstance().initializeConfig();

            MysqlDump mysqldump = new MysqlDump();
            mysqldump.IsTest = true;
            DumpCredentialsConfig creconfig = new DumpCredentialsConfig();
            creconfig.host = Const.host;
            creconfig.port = 3306;
            creconfig.username = Const.username;
            creconfig.password = Const.password;
            creconfig.database = Const.database;

            mysqldump.credentialsConfigInstance = creconfig;
            DumpResultSet dumpresult = mysqldump.executeDump();

            Console.WriteLine(dumpresult.ToString());
            Assert.IsTrue(dumpresult.wasSuccessful);
            Assert.AreEqual(0, dumpresult.errorNumber);
            string absfilepath = dumpresult.fileAbsPath;

            Assert.AreEqual(true,File.Exists(absfilepath));
            File.Delete(absfilepath);
            Assert.AreEqual(false, File.Exists(absfilepath));
            
        }

        /// <summary>
        /// testing with default compression and adapters event calls and includeCreateSchema to False
        /// </summary>
        [TestMethod]
         public void TestExecuteDumpPhaseTwo()
        {
            DumpCredentialsConfig creconfig = new DumpCredentialsConfig();
            creconfig.host = Const.host;
            creconfig.port = 3306;
            creconfig.username = Const.username;
            creconfig.password = Const.password;
            creconfig.database = Const.database;

            ConfigurationManager.getInstance().initializeConfig();
            ConfigurationManager.getInstance().mysqlDumpConfigInstance.includeCreateSchema = false;
            ConfigurationManager.getInstance().compressConfigInstance.enableCompression = true;

            DbConnection connection = DbConnection.Instance();
            connection.Host = Const.host;
            connection.password = Const.password;
            connection.username = Const.username;
            List<string> tables = connection.getTables(Const.database);
            int actualNumOfTables = tables.Count;

            MysqlDump mysqldump = new MysqlDump();
            mysqldump.IsTest = true;
            mysqldump.credentialsConfigInstance = creconfig;

            mysqldump.CompressProgress += compressProgress;
            mysqldump.CompressStart += onCompressStart;
            mysqldump.TableRowCount += tableRowCount;
            mysqldump.TableStartDump += onTableStartDump;

            /*
             = null;
            ManualResetEvent done = new ManualResetEvent(false);
            Thread thread = new Thread(delegate ()
            {
                dumpresult = mysqldump.executeDump();
                done.Set();
            });
            thread.Start();
            done.WaitOne();
            //Task<DumpResultSet> res = execdump(mysqldump);
            */
            DumpResultSet dumpresult = mysqldump.executeDump();
            Thread.Sleep(4500);
            
            Assert.IsTrue(dumpresult.wasSuccessful);
            Assert.IsTrue(File.Exists(dumpresult.fileAbsPath));
            File.Delete(dumpresult.fileAbsPath);
            Assert.AreEqual(false, File.Exists(dumpresult.fileAbsPath));
            validateOnTableStartDump(actualNumOfTables);
        }

        public async Task<DumpResultSet>  execdump(MysqlDump mysqldump)
        {
            return mysqldump.executeDump();
        }

        public int NumOfTables { get; set; }


        public void onTableStartDump(string table)
        {
            Console.WriteLine("table:" + table);
            log.Info("table:"+table);
            Assert.IsNotNull(table);
            NumOfTables++;
            tables.Remove(table);
        }

        public void tableRowCount(int rowcount)
        {

        }

        public void validateOnTableStartDump(int actual)
        {
            Console.WriteLine("actual:" + actual);
            log.Info("actual:"+actual);
            Assert.AreEqual(actual, NumOfTables);
            Assert.AreEqual(0, tables.Count);
        }

        public void compressProgress(int progress)
        {

        }

        public void onCompressStart()
        {

        }

        

    }
}
