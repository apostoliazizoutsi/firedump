using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Topshelf;

namespace Firedump.service
{
    public class FiredumpService : ServiceControl
    {       
        private static readonly int MILLISECS = 3000;

        private static Thread serviceThread;
        private static bool run = true;

        private firedumpdbDataSet.schedulesDataTable schedules;
        private firedumpdbDataSetTableAdapters.schedulesTableAdapter schedulesAdapter;
        private ScheduleManager schedulemanager;
        
        public FiredumpService()
        {
        }

        public bool Start(HostControl hostControl)
        {
            run = true;
            if(serviceThread == null || !serviceThread.IsAlive)
            {
                serviceThread = new Thread(new ThreadStart(Run));
                serviceThread.Start();
            }
            
            return true;
        }


        private void Run()
        {           
            while (run)
            {
                Thread.Sleep(MILLISECS);
                try
                {
                    
                    /*on comment i have no schedule so some kind of null exception raised and the service broke
                    //CANT DEBUG/WRITELINE/LOG ON CONSOLE.WRITELINE a service!

                    schedulemanager = new ScheduleManager();
                    schedules = new firedumpdbDataSet.schedulesDataTable();
                    schedulesAdapter = new firedumpdbDataSetTableAdapters.schedulesTableAdapter();
                    schedulesAdapter.Fill(schedules);

                    //Sort schedules by date and take the nearest upcomming

                    //Set up the current day/hour
                    int day = (int)DateTime.Now.DayOfWeek;
                    int hours = DateTime.Now.Hour;
                    int minute = DateTime.Now.Minute;

                    //Check if schedule[0]date is near now with gap +-MILLISECS+1sec safety
                    //If it is continue
                    //Set the nearest in time schedule
                    schedulemanager.setSchedule(schedules[0]);

                    //Set event delegate callback
                    schedulemanager.ScheduleResult += scheduleResult;

                    //Start the schedule
                    schedulemanager.Start();
                    */
                }
                catch (Exception ex) { }
            }
        }


        private void scheduleResult(object ob)
        {
            //if success remove schedule from database
        }


        public bool Stop(HostControl hostControl)
        {
            run = false;
            //
            //schedulemanager.StopCurrentJob();
            return true;
        }

        
    }
}
