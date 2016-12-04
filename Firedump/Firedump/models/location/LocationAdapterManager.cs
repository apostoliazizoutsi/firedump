﻿using Firedump.models.configuration.dynamicconfig;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Firedump.models.location
{
    class LocationAdapterManager : ILocationListener 
    {
        private ILocationManagerListener listener;
        private List<int> locations;
        private List<LocationResultSet> results;
        private firedumpdbDataSetTableAdapters.backup_locationsTableAdapter backup_adapter = new firedumpdbDataSetTableAdapters.backup_locationsTableAdapter(); //malon tha xreiastei adapter pou tha einai join pinakwn tha doume
        private int currentProgress = 0;
        private string sourcePath;
        private LocationAdapterManager() { }
        public LocationAdapterManager(ILocationManagerListener listener, List<int> locations, string sourcePath)
        {
            this.listener = listener;
            this.locations = locations;
            this.sourcePath = sourcePath;
            init();
        }
        private void init()
        {
            results = new List<LocationResultSet>();
            listener.onSaveInit(locations.Count * 100); //set to max progress px gia 2 locations 200
        }
        private void setupForNewSave()
        {
            currentProgress += 100;
            if (locations.Count > 0)
            {
                locations.RemoveAt(0);
            }

            if (locations.Count > 0) //teliki sinthiki tou adapter
            {
                startSave();
            }
            else
            {
                try
                {
                    File.Delete(sourcePath);
                }
                catch(Exception e){ }
                listener.onSaveComplete(results);
            }
        }

        public void startSave() //thelei douleia afti
        {
            if(locations.Count == 0)
            {
                listener.onSaveError("Save started with no locations");
                return;
            }
            LocationCredentialsConfig config;
            DataTable data = backup_adapter.GetDataByID(locations[0]);
            if (data.Rows.Count == 0)
            {
                onSaveError("Location not found in the database");
                return;
            }
            long type = (Int64)data.Rows[0]["service_type"];
            LocationAdapter adapter = new LocationAdapter(this);
            switch (type) //edw gemizei to config apo to database prepei na kanei diaforetiko query gia kathe diaforetiko type kai na gemisei to config prin to settarei ston adapter
            {              
                case 0: //file system
                    config = new LocationCredentialsConfig();
                    config.sourcePath = sourcePath;
                    config.locationPath = (string)data.Rows[0]["path"];
                    adapter.setLocalLocation(config);
                    break;
                case 1: //FTP
                    config = new LocationCredentialsConfig();
                    //EDW SETUP TO CONFIG
                    adapter.setFtpLocation(config);
                    break;
                case 2: //Dropbox
                    config = new LocationCredentialsConfig();
                    //EDW SETUP TO CONFIG
                    adapter.setCloudBoxLocation(config);
                    break;
                case 3: //Google drive
                    config = new LocationCredentialsConfig();
                    //EDW SETUP TO CONFIG
                    adapter.setCloudDriveLocation(config);
                    break;
                default:
                    onSaveError("Location type unknown");
                    return;
            }

            listener.onInnerSaveInit((string)data.Rows[0]["name"]);

            Task managersendtask = new Task(adapter.sendFile);
            managersendtask.Start();
        }
       
        public void onSaveComplete(LocationResultSet result)
        {
            results.Add(result);
            setupForNewSave();
        }

        public void onSaveError(string message)
        {
            LocationResultSet result = new LocationResultSet();
            result.wasSuccessful = false;
            result.errorMessage = message;
            results.Add(result);
            setupForNewSave();
        }

        public void onSaveInit()
        {
            throw new NotImplementedException();
        }

        public void setSaveProgress(int progress)
        {
            listener.setSaveProgress(currentProgress+progress);
        }
    }
}
