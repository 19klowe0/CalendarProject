using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CalendarProject
{
    class Event
    {
        int eventNum;
        string eventName;
        string description;
        DateTime startTime;
        DateTime endTime;
        Boolean managerEvent;

        public Event(int evNum, string evName, string desc, DateTime start, DateTime end, Boolean man)
        {
            eventNum = evNum;
            eventName = evName;
            description = desc;
            startTime = start;
            endTime = end;
            managerEvent = man;
        }

        public void saveEvent()
        {
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM teammmlevent;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                MySqlDataReader myReader = cmd.ExecuteReader();
                if (myReader.Read())
                {
                    eventNum = (int)myReader["eventNum"];
                    eventName = (string)myReader["eventName"];
                    description = (string)myReader["description"];
                    startTime = (DateTime)myReader["startTime"];
                    endTime = (DateTime)myReader["endTime"];

                    //No boolean type in MySQL, so if the int is 0 store false, else store true.
                    int tempManager = (int)myReader["managerEvent"];
                    if (tempManager == 0)
                        managerEvent = false;
                    else
                        managerEvent = true;
                }
                myReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            Console.WriteLine("Done.");
        }

        ~Event()
        {
            Console.WriteLine("event #" + eventNum + " - " + eventName + " has been destroyed");

        }

        public String getEventName()
        {
            return eventName;
        }

        public String getEventDescription()
        {
            return description;
        }

        public DateTime getStartTime()
        {
            return startTime;
        }

        public DateTime getEndTime()
        {
            return endTime;
        }

        //retrieve all events from specified user - pass null to retrieve manager events
        public static MySqlDataReader retrieveEvents(Employee currentEmployee)
        {
            MySqlDataReader myReader = null;

            //connect to MySQL, select all applicable events
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "";
                int id = -1;
                if (currentEmployee == null) //manager events only
                    sql = "SELECT * FROM teammmlevent WHERE managerEvent <> 0";
                else //user events and manager events
                {
                    sql = "SELECT * FROM teammmlevent WHERE (userNum = @currEmp OR managerEvent <> 0)";
                    id = currentEmployee.getID();
                }
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                if (id != -1)
                    cmd.Parameters.AddWithValue("@currEmp", id);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                myReader = cmd.ExecuteReader();
                return myReader;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return myReader;

        }

        //delete an event from MySQL - pass null to currentEmployee if manager event
        public static void deleteEvent(string name, Employee currentEmployee)
        {
            //connect to MySQL, delete proper event
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "";
                int id = -1;
                //currentEmployee = null if manager event
                if (currentEmployee == null) //manager event
                    sql = "DELETE from teammmlevent WHERE managerEvent != 0 AND eventName = @evName";
                else //normal event
                {
                    sql = "DELETE FROM teammmlevent WHERE userNum = @currEmp AND eventName = @evName";
                    id = currentEmployee.getID();
                }
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                if (id != -1) //only if not manager event
                    cmd.Parameters.AddWithValue("@currEmp", id);
                cmd.Parameters.AddWithValue("@evName", name);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                MySqlDataReader myReader = cmd.ExecuteReader();
                myReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }
    }
}