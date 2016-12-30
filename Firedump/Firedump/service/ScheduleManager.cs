using Firedump.models.configuration.dynamicconfig;
using Firedump.models.dump;
using Firedump.models.location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.service
{
    public class ScheduleManager
    {

        private MySqlDumpAdapter mysqldumpAdapter;
        private LocationAdapterManager locationAdapterManager;
        private DumpResultSet result;
        private firedumpdbDataSet.schedulesRow schedulesRow;
        private firedumpdbDataSet.mysql_serversRow server;


        public ScheduleManager()
        {
        }

        internal void StopCurrentJob()
        {
            //cancel mysql dump process
            //cancel location/upload process
        }

        internal void setSchedule(firedumpdbDataSet.schedulesRow schedulesRow)
        {
            this.schedulesRow = schedulesRow;
        }

       
        internal void Start()
        {
            List<string> tables = utils.StringUtils.extractTableListFromString(schedulesRow.tables);
            string database = schedulesRow.database;
            firedumpdbDataSetTableAdapters.mysql_serversTableAdapter serveradapter = new firedumpdbDataSetTableAdapters.mysql_serversTableAdapter();
            firedumpdbDataSet.mysql_serversDataTable servertable = new firedumpdbDataSet.mysql_serversDataTable();
            serveradapter.FillById(servertable, schedulesRow.server_id);

            if (servertable?.Count > 0)
                server = servertable[0];
            else
                return;

            DumpCredentialsConfig dumpConfig = new DumpCredentialsConfig();
            dumpConfig.database = database;
            dumpConfig.username = server.username;
            dumpConfig.password = server.password;
            dumpConfig.host = server.host;
            dumpConfig.port = (int)server.port;
            if (tables.Count > 0)
                dumpConfig.excludeTables = tables.ToArray();

            mysqldumpAdapter = new MySqlDumpAdapter();
            mysqldumpAdapter.Cancelled += OnCancelled;
            mysqldumpAdapter.Completed += OnCompleted;         
            mysqldumpAdapter.startDump(dumpConfig);
            
        }


        private void OnCompleted(DumpResultSet resultSet)
        {
            if(resultSet != null)
            {
                if(resultSet.wasSuccessful)
                {

                    List<int> locations = new List<int>();
                    //get schedule_save_location data table by schedule ID
                    firedumpdbDataSetTableAdapters.schedule_save_locationsTableAdapter savelocAdapter = new firedumpdbDataSetTableAdapters.schedule_save_locationsTableAdapter();
                    firedumpdbDataSet.schedule_save_locationsDataTable saveloctable = new firedumpdbDataSet.schedule_save_locationsDataTable();
                    savelocAdapter.FillByScheduleId(saveloctable,schedulesRow.id);

                    if(saveloctable.Count > 0)
                    {
                        //now get backuplocations by backuplocationID
                        firedumpdbDataSetTableAdapters.backup_locationsTableAdapter backupAdapter = new firedumpdbDataSetTableAdapters.backup_locationsTableAdapter();
                        firedumpdbDataSet.backup_locationsDataTable backuptable = new firedumpdbDataSet.backup_locationsDataTable();
                        for (int i = 0; i < saveloctable.Count; i++)
                        {
                            firedumpdbDataSet.backup_locationsDataTable  temp = backupAdapter.GetDataByID(saveloctable[i].backup_location_id);
                            backuptable.Addbackup_locationsRow(temp[0]);
                        }

                        foreach(firedumpdbDataSet.backup_locationsRow backrow in backuptable)
                        {
                            locations.Add((int)backrow.id);
                        }

                        locationAdapterManager = new LocationAdapterManager(locations,resultSet.fileAbsPath);
                        locationAdapterManager.SaveInit += onSaveInitHandler;
                        locationAdapterManager.InnerSaveInit += onInnerSaveInitHandler;
                        locationAdapterManager.LocationProgress += onLocationProgressHandler;
                        locationAdapterManager.SaveProgress += setSaveProgressHandler;
                        locationAdapterManager.SaveComplete += onSaveCompleteHandler;
                        locationAdapterManager.SaveError += onSaveErrorHandler;
                        locationAdapterManager.setProgress();

                        locationAdapterManager.startSave();
                    }
                    
                }
            }

        }



        private void onSaveErrorHandler(string message)
        {
            
        }

        private void onSaveCompleteHandler(List<LocationResultSet> results)
        {
            
        }

        private void setSaveProgressHandler(int progress, int speed)
        {
           
        }

        private void onLocationProgressHandler(int progress, int speed)
        {
            
        }

        private void onInnerSaveInitHandler(string location_name, int location_type)
        {
           
        }

        private void onSaveInitHandler(int maxprogress)
        {
            
        }

        private void OnCancelled()
        {

        }

        
    }
}
