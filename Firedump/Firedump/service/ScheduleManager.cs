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


        public ScheduleManager()
        {
            mysqldumpAdapter = new MySqlDumpAdapter();
        }

        internal void StopCurrentJob()
        {
            //cancel mysql dump process
            //cancel location/upload process
        }

        internal void setSchedule(firedumpdbDataSet.schedulesRow schedulesRow)
        {
            
        }

        internal void Start()
        {
            
        }
    }
}
