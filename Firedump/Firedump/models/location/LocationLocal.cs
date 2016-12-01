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
                File.Move(config.sourcePath, config.locationPath);
                result.wasSuccessful = true;
            }
            catch (Exception ex)
            {
                result.wasSuccessful = false;
                result.errorMessage = ex.Message;
            }

            return result;
        }

        public void setListener(ICallBack callback)
        {
            throw new NotImplementedException();
        }
    }
}