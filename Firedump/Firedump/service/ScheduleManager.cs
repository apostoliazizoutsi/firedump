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
    class ScheduleManager
    {
        public delegate void scheduleResult(object ob);
        public event scheduleResult ScheduleResult;

        private MySqlDumpAdapter mysqldumpAdapter;
        private LocationAdapterManager locationAdapterManager;
        private DumpResultSet result;
        private firedumpdbDataSet.schedulesRow schedulesRow;


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

        internal DumpResultSet StartDump()
        {
            mysqldumpAdapter = new MySqlDumpAdapter();
            DumpCredentialsConfig config = new DumpCredentialsConfig();
            //set config info
            return mysqldumpAdapter.startDumpSync(config);
            //return null;
        }

        internal List<LocationResultSet>  StartSaveLocations(List<int> locations, string sourcePath)
        {
            locationAdapterManager = new LocationAdapterManager(locations, sourcePath);
            locationAdapterManager.startSave();

            return null;
        }

    }
}
