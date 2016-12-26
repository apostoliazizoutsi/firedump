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
        private List<firedumpdbDataSet.schedulesRow> scheduleRowList;
        
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
            //on comment i have no schedule so some kind of null exception raised and the service broke
            //CANT DEBUG/WRITELINE/LOG ON CONSOLE.WRITELINE a service!
            try
            {
                
                schedules = new firedumpdbDataSet.schedulesDataTable();
                schedulesAdapter = new firedumpdbDataSetTableAdapters.schedulesTableAdapter();
                schedulesAdapter.Fill(schedules);

                scheduleRowList = new List<firedumpdbDataSet.schedulesRow>();
                //copy schedules to List<>scheduleRowList
                foreach (firedumpdbDataSet.schedulesRow row in schedules)
                {
                    scheduleRowList.Add(row);
                }
            }catch(Exception ex)
            {
                File.AppendAllText(@"errorlog.txt",ex.ToString());
            }

            //Sort scheduleRowList by date and take the nearest upcomming
            //malon panw anti gia Fill ena FillByDate query pou tha ta fernei etima me date order

            while (run)
            {
                Thread.Sleep(MILLISECS);
                try
                {                                    
                    //Set up the current day/hour
                    int day = (int)DateTime.Now.DayOfWeek;
                    int hours = DateTime.Now.Hour;
                    int minute = DateTime.Now.Minute;

                    //Check if scheduleRowList[0]date is near now with gap +-MILLISECS+5sec safety
                    //If it is and scheduleRowlist.Count > 0 continue
                    //Set the nearest in time schedule
                    if(scheduleRowList.Count > 0)
                    {
                        schedulemanager = new ScheduleManager();
                        schedulemanager.setSchedule(scheduleRowList[0]);

                        //Set event delegate callback
                        schedulemanager.ScheduleResult += scheduleResult;

                        //Start the schedule
                        schedulemanager.Start();
                        //needs to wait
                    }
                    
                }
                catch (Exception ex) {
                    //write ex message to file
                    File.AppendAllText(@"errorlog.txt",ex.ToString());
                }
            }
        }


        private void scheduleResult(object ob)
        {
            //if success remove schedule from scheduleRowList
            /*
            if (scheduleRowList.Count > 0)
            {
                scheduleRowList.Remove(row);
            }
            */
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
