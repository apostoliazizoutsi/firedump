﻿using Firedump.models.configuration.dynamicconfig;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firedump.models.location
{
    class LocationLocal : Location,ILocation
    {
        public LocationCredentialsConfig config { set; get; }
        private ILocationProgressListener listener;
        bool cancelFlag = false;
        private LocationLocal() { }
        public LocationLocal(ILocationProgressListener listener)
        {
            this.listener = listener;
        }
        public void connect()
        {
            throw new NotImplementedException();
        }

        public void connect(object o)
        {
            throw new NotImplementedException();
        }

        public LocationResultSet getFile()
        {
            throw new NotImplementedException();
        }

        public LocationResultSet send()
        {
            LocationResultSet result = new LocationResultSet();
            result.path = config.locationPath;
            try
            {
                string[] path = config.sourcePath.Split('\\');
                string filename = path[path.Length - 1];
                string[] temp = filename.Split('.'); //pernei to extension apo to sourcepath kai na to kanei append sto location
                config.locationPath = config.locationPath + "." + temp[temp.Length - 1];
                temp = config.locationPath.Split('\\');
                string directorypath = "";
                for(int i=0; i<temp.Length-1; i++)
                {
                    directorypath += temp[i]+"\\";
                }
                directorypath = directorypath.Substring(0,directorypath.Length-1);
                System.IO.Directory.CreateDirectory(directorypath); //dimiourgei ta directory sto path an den iparxoun

                //COPY
                Copy();
                if(cancelFlag == true)
                {
                    result.wasSuccessful = false;
                    result.errorMessage = "Copy was cancelled";
                    return result;
                }

                //akiro afto to command File.Delete(config.locationPath); //kamia fora prokalei unothorized access exception den mporw na katalavw me poia logiki
                result.wasSuccessful = true;

                /*
                File.Move(config.sourcePath, config.locationPath+temp[temp.Length-1]);
                //Microsoft.VisualBasic.FileIO.FileSystem.MoveFile("sorceFile.ext", "destFile.ext", Microsoft.VisualBasic.FileIO.UIOption.AllDialogs);
                //to panw tha ekane move to arxeio me to klasiko move dialog twn windows
                result.wasSuccessful = true;*/
            }
            catch (Exception ex)
            {
                result.wasSuccessful = false;
                result.errorMessage = ex.Message;
            }

            return result;
        }

        private void Copy()
        {
            byte[] buffer = new byte[1024 * 1024]; // 1MB buffer

            using (FileStream source = new FileStream(config.sourcePath, FileMode.Open, FileAccess.Read))
            {
                long fileLength = source.Length;
                using (FileStream dest = new FileStream(config.locationPath, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    long totalBytes = 0;
                    int currentBlockSize = 0;

                    while ((currentBlockSize = source.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        totalBytes += currentBlockSize;
                        int percentage = Convert.ToInt32(totalBytes * 100.0 / fileLength);

                        dest.Write(buffer, 0, currentBlockSize);
                        
                        listener.setProgress(percentage);

                        if (cancelFlag == true)
                        {
                            File.Delete(config.locationPath);
                            break;
                        }
                    }
                }
            }
        }
    }
}
