using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

//tableLayoutpanel1 is the main menu with calendar 
//tableLayoutpanel2 is the pin menu

namespace CalendarProject
{
    public partial class Form1 : Form
    {
        Employee currentEmployee;
        Boolean managerAction = false; // Global variable, used to reuse code and objects for diffrent events

        public Form1()
        {
            InitializeComponent();
            tableLayoutPanel2.BringToFront();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }


        private void deleteEventButton_Click(object sender, EventArgs e)
        {
            //change scene
            tableLayoutPanel1.Visible = false;
            deleteEventTableLayoutPanel.Visible = true;
            deleteEventListBox.Items.Clear();
            //run retrieveEvents, add all events to listBox
            MySqlDataReader myReader = Event.retrieveEvents(currentEmployee);
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            while (myReader.Read())
                deleteEventListBox.Items.Add((string)myReader["eventName"]);
            myReader.Close();
            conn.Close();
            Console.WriteLine("Done.");

        }

        private void deleteManagerEvent_Click(object sender, EventArgs e)
        {
            //change scene
            tableLayoutPanel1.Visible = false;
            deleteManagerEventTableLayoutPanel.Visible = true;
            deleteManagerEventListBox.Items.Clear();
            //run retrieveEvents, add all manager events to listBox
            MySqlDataReader myReader = Event.retrieveEvents(null); //pass null for current employee because manager event
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            while (myReader.Read())
                if ((int)myReader["userNum"] == currentEmployee.getID())
                    deleteManagerEventListBox.Items.Add((string)myReader["eventName"]);
            myReader.Close();
            conn.Close();
            Console.WriteLine("Done.");
        }


        private void viewEventButton_Click(object sender, EventArgs e)
        {
            //change scene
            tableLayoutPanel1.Visible = false;
            viewEventTableLayoutPanel.Visible = true;
            viewEventListBox.Items.Clear();

            //run retrieveEvents, add all events to listBox
            MySqlDataReader myReader = Event.retrieveEvents(currentEmployee);
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            while (myReader.Read())
                viewEventListBox.Items.Add((string)myReader["eventName"]);
            myReader.Close();
            conn.Close();
            Console.WriteLine("Done.");
        }

        private void addEventButton_Click(object sender, EventArgs e)
        {
            managerAction = false;
            tableLayoutPanel3.Visible = true;
            tableLayoutPanel1.Visible = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1Pin_Click(object sender, EventArgs e)
        {
            if (label2.Text == "Pin")
                label2.Text = "1";
            else if (label2.Text.Length <= 3)
                label2.Text = label2.Text + "1";
        }

        private void button2Pin_Click(object sender, EventArgs e)
        {
            if (label2.Text == "Pin")
                label2.Text = "2";
            else if (label2.Text.Length <= 3)
                label2.Text = label2.Text + "2";
        }

        private void button3Pin_Click(object sender, EventArgs e)
        {
            if (label2.Text == "Pin")
                label2.Text = "3";
            else if (label2.Text.Length <= 3)
                label2.Text = label2.Text + "3";
        }

        private void button4Pin_Click(object sender, EventArgs e)
        {
            if (label2.Text == "Pin")
                label2.Text = "4";
            else if (label2.Text.Length <= 3)
                label2.Text = label2.Text + "4";
        }

        private void button5Pin_Click(object sender, EventArgs e)
        {
            if (label2.Text == "Pin")
                label2.Text = "5";
            else if (label2.Text.Length <= 3)
                label2.Text = label2.Text + "5";
        }

        private void button6Pin_Click(object sender, EventArgs e)
        {
            if (label2.Text == "Pin")
                label2.Text = "6";
            else if (label2.Text.Length <= 3)
                label2.Text = label2.Text + "6";
        }

        private void button7Pin_Click(object sender, EventArgs e)
        {
            if (label2.Text == "Pin")
                label2.Text = "7";
            else if (label2.Text.Length <= 3)
                label2.Text = label2.Text + "7";
        }

        private void button8Pin_Click(object sender, EventArgs e)
        {
            if (label2.Text == "Pin")
                label2.Text = "8";
            else if (label2.Text.Length <= 3)
                label2.Text = label2.Text + "8";
        }

        private void button9Pin_Click(object sender, EventArgs e)
        {
            if (label2.Text == "Pin")
                label2.Text = "9";
            else if (label2.Text.Length <= 3)
                label2.Text = label2.Text + "9";
        }

        private void button0Pin_Click(object sender, EventArgs e)
        {
            if (label2.Text == "Pin")
                label2.Text = "0";
            else if (label2.Text.Length <= 3)
                label2.Text = label2.Text + "0";
        }

        private void buttonDeletePin_Click(object sender, EventArgs e)
        {
            if (label2.Text.Length == 1)
                label2.Text = "Pin";
            else if (label2.Text.Length > 0)
                label2.Text = label2.Text.Substring(0, label2.Text.Length - 1);
        }

        private void buttonClearPin_Click(object sender, EventArgs e)
        {
            label2.Text = "Pin";
        }

        private void buttonProcessPin_Click(object sender, EventArgs e) //process button!!
        {
            // -1 means they are manager in managerID
            // 0 means they are not manager 
            int pin = 0;
            if (label2.Text.Equals("Pin"))
            {
                //label1.Text = "Please Input a Pin!";
            }
            else
                pin = int.Parse(label2.Text);

            currentEmployee = new Employee(pin);
            if (currentEmployee.getID() == 0) //password doesn't match any ID
            {
                //this is the code for when it goes wrong!!!!

                errorTableLayoutPanel.Visible = true;
                tableLayoutPanel2.Visible = false;
                errorLabel.Text = "You enter the wrong pin try again";
                label2.Text = "Pin";

            }
            else if (currentEmployee.getManagerID() != 0)//is a manager 
            {
                managerTableLayoutPanel.Visible = true;
                tableLayoutPanel2.Visible = false;
                tableLayoutPanel1.Visible = true;
                label2.Text = "Pin";

            }
            else
            {
                tableLayoutPanel2.Visible = false;
                tableLayoutPanel1.Visible = true;
                label2.Text = "Pin";
            }


        }

        private void buttonCancelPin_Click(object sender, EventArgs e)
        {
            //not correct yet just to get to main menu
            tableLayoutPanel2.Visible = false;
            tableLayoutPanel1.Visible = true;
        }

        private void errorButton_Click(object sender, EventArgs e)
        {
            errorTableLayoutPanel.Visible = false;
            tableLayoutPanel2.Visible = true;
        }

        private void viewEventSubmitButton_Click(object sender, EventArgs e)
        {
            //submit only works if item is selected
            if (viewEventListBox.SelectedIndex >= 0)
            {
                //change scene
                viewEventTableLayoutPanel.Visible = false;
                viewEvent2TableLayoutPanel.Visible = true;
                //run retrieveEvents, get name, description, start and end time of selected event
                MySqlDataReader myReader = Event.retrieveEvents(currentEmployee);
                while (myReader.Read())
                {
                    if ((string)myReader["eventName"] == (string)viewEventListBox.SelectedItem)
                    {
                        viewEventLabelName.Text = "Event name: " + (string)myReader["eventName"];
                        viewEventLabelDesc.Text = "Description: " + (string)myReader["description"];
                        viewEventLabelStart.Text = "Start time: " + myReader["startTime"].ToString();
                        viewEventLabelEnd.Text = "End time: " + myReader["endTime"].ToString();
                    }
                }
                myReader.Close();
            }
        }

        private void viewEventBackButton_Click(object sender, EventArgs e)
        {
            //return to menu from page 1
            viewEventTableLayoutPanel.Visible = false;
            tableLayoutPanel1.Visible = true;
        }

        private void viewAnotherEventButton_Click(object sender, EventArgs e)
        {
            //restart viewEvent
            viewEvent2TableLayoutPanel.Visible = false;
            viewEventTableLayoutPanel.Visible = true;
            viewEventListBox.SelectedIndex = -1;
        }

        private void viewEventReturnMenuButton_Click(object sender, EventArgs e)
        {
            //return to menu from end page
            viewEvent2TableLayoutPanel.Visible = false;
            tableLayoutPanel1.Visible = true;
        }

        private void deleteEventBackButton_Click(object sender, EventArgs e)
        {
            //return to menu from page 1
            deleteEventTableLayoutPanel.Visible = false;
            tableLayoutPanel1.Visible = true;
        }

        private void deleteEventSubmitButton_Click(object sender, EventArgs e)
        {
            //submit only works if item is selected
            if (deleteEventListBox.SelectedIndex >= 0)
            {
                //run deleteEvent with selected event
                string name = (string)deleteEventListBox.SelectedItem;
                Event.deleteEvent(name, currentEmployee);
                //change scene
                deleteEventTableLayoutPanel.Visible = false;
                deleteEvent2TableLayoutPanel.Visible = true;
            }
        }

        private void deleteEventReturnMenuButton_Click(object sender, EventArgs e)
        {
            //return to menu from end page
            deleteEvent2TableLayoutPanel.Visible = false;
            tableLayoutPanel1.Visible = true;
        }

        private void deleteAnotherEventButton_Click(object sender, EventArgs e)
        {
            //restart deleteEvent
            deleteEvent2TableLayoutPanel.Visible = false;
            deleteEventTableLayoutPanel.Visible = true;
            deleteEventListBox.SelectedIndex = -1;
        }

        private void deleteManagerEventSubmitButton_Click(object sender, EventArgs e)
        {
            //submit only works if item is selected
            if (deleteManagerEventListBox.SelectedIndex >= 0)
            {
                //run deleteEvent on selected event
                string name = (string)deleteManagerEventListBox.SelectedItem;
                Event.deleteEvent(name, null); //pass null for current employee because manager event
                //change scene
                deleteManagerEventTableLayoutPanel.Visible = false;
                deleteManagerEvent2TableLayoutPanel.Visible = true;
            }
        }

        private void deleteManagerEventBackButton_Click(object sender, EventArgs e)
        {
            //return to menu from page 1
            deleteManagerEventTableLayoutPanel.Visible = false;
            tableLayoutPanel1.Visible = true;
        }

        private void deleteAnotherManagerEventButton_Click(object sender, EventArgs e)
        {
            //restart deleteManagerEvent
            deleteManagerEvent2TableLayoutPanel.Visible = false;
            deleteManagerEventTableLayoutPanel.Visible = true;
            deleteManagerEventListBox.SelectedIndex = -1;
        }

        private void deleteManagerEventReturnMenuButton_Click(object sender, EventArgs e)
        {
            //return to menu from end
            deleteManagerEvent2TableLayoutPanel.Visible = false;
            tableLayoutPanel1.Visible = true;
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void editEventButton_Click(object sender, EventArgs e)
        {

        }

        //private void monthlyListButton_Click(object sender, EventArgs e)
        //{

        //}

        //private void button4_Click(object sender, EventArgs e)
        //{

        //}

        //private void button3_Click(object sender, EventArgs e)
        //{

        //}



        //private void button2_Click(object sender, EventArgs e)
        //{

        //}

        //private void button7_Click(object sender, EventArgs e)
        //{

        //}

        //private void button8_Click(object sender, EventArgs e)
        //{

        //}

        //private void button9_Click(object sender, EventArgs e)
        //{

        //}

        //private void monthlyReturn_Click(object sender, EventArgs e)
        //{

        //}

        //private void jan_Click(object sender, EventArgs e)
        //{

        //}

        //private void feb_Click(object sender, EventArgs e)
        //{

        //}

        //private void mar_Click(object sender, EventArgs e)
        //{

        //}

        //private void apr_Click(object sender, EventArgs e)
        //{

        //}

        //private void may_Click(object sender, EventArgs e)
        //{

        //}

        //private void jun_Click(object sender, EventArgs e)
        //{

        //}

        //private void jul_Click(object sender, EventArgs e)
        //{

        //}

        //private void aug_Click(object sender, EventArgs e)
        //{

        //}

        //private void sep_Click(object sender, EventArgs e)
        //{

        //}

        //private void oct_Click(object sender, EventArgs e)
        //{

        //}

        //private void nov_Click(object sender, EventArgs e)
        //{

        //}

        //private void dec_Click(object sender, EventArgs e)
        //{

        //}

        //private void button1_Click(object sender, EventArgs e)
        //{

        //}

        //private void button6_Click(object sender, EventArgs e)
        //{

        //}

        //private void addManagerEvent_Click(object sender, EventArgs e)
        //{

        //}

        //private void button5_Click(object sender, EventArgs e)
        //{

        //}

        //beginning of toby 

        private void viewEventListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addManagerEvent_Click(object sender, EventArgs e)
        {
            managerAction = false;
            if (currentEmployee.getManagerID() != 0)
            {
                managerAction = true;
                tableLayoutPanel3.Visible = true;
                tableLayoutPanel1.Visible = false;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
            else
            {
                tableLayoutPanel8.Visible = true;
                tableLayoutPanel1.Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime startTime = new DateTime(int.Parse(textBox4.Text), int.Parse(textBox5.Text), int.Parse(textBox3.Text), int.Parse(textBox1.Text), 00, 00);
            DateTime endTime = new DateTime(int.Parse(textBox4.Text), int.Parse(textBox5.Text), int.Parse(textBox3.Text), int.Parse(textBox2.Text), 00, 00);
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM teammmlevent WHERE startTime = @startTime";

                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@startTime", startTime);
                MySqlDataReader myReader = cmd.ExecuteReader();
                if (myReader.Read())
                {
                    Console.WriteLine("overlap error");
                    tableLayoutPanel3.Visible = false;
                    tableLayoutPanel6.Visible = true;

                }
                else
                {
                    tableLayoutPanel7.Visible = true;
                    tableLayoutPanel3.Visible = false;
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

        private void button2_Click(object sender, EventArgs e)
        {
            tableLayoutPanel3.Visible = true;
            tableLayoutPanel6.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = true;
            tableLayoutPanel7.Visible = false;
            String addEventName = textBox6.Text;
            String addEventDes = textBox7.Text;
            int managerAdd = 0;
            if (managerAction == true)
            {
                managerAdd = 1;// allows use of the same code and gui for adding manager and non manager events.
            }
            DateTime startTime = new DateTime(int.Parse(textBox4.Text), int.Parse(textBox5.Text), int.Parse(textBox3.Text), int.Parse(textBox1.Text), 00, 00);
            DateTime endTime = new DateTime(int.Parse(textBox4.Text), int.Parse(textBox5.Text), int.Parse(textBox3.Text), int.Parse(textBox2.Text), 00, 00);

            if (addEventName.Length >= 1)
            {

                string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
                MySqlConnection conn = new MySqlConnection(connStr);
                try
                {
                    conn.Open();
                    int transactionNum = 0;
                    string sql = "SELECT MAX(eventNum) FROM teammmlevent;";
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                    MySqlDataReader myReader = cmd.ExecuteReader();
                    if (myReader.Read())
                    {
                        transactionNum = Int32.Parse(myReader[0].ToString());
                        Console.WriteLine("eventNum number" + (transactionNum + 1));
                    }
                    myReader.Close();
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Close();

                    conn.Open();
                    sql = "INSERT INTO teammmlevent (eventNum, eventName, description, startTime, endTime, managerEvent, userNum)" +
                        " VALUES (@eNum, @eName, @des, @sTi, @eTi, @MaE, @uNum)";

                    cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@eNum", (transactionNum + 1));// wip
                    cmd.Parameters.AddWithValue("@eName", addEventName);
                    cmd.Parameters.AddWithValue("@des", addEventDes);
                    cmd.Parameters.AddWithValue("@sTi", startTime);
                    cmd.Parameters.AddWithValue("@eTi", endTime);
                    cmd.Parameters.AddWithValue("@MaE", managerAdd);
                    cmd.Parameters.AddWithValue("@uNum", currentEmployee.getID());
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                conn.Close();
                Console.WriteLine("Done.");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            tableLayoutPanel3.Visible = true;
            tableLayoutPanel7.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = true;
            tableLayoutPanel8.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = true;
            tableLayoutPanel3.Visible = false;
        }

        private void monthlyListButton_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = false;
            tableLayoutPanel9.Visible = true;
        }

        private void aug_Click(object sender, EventArgs e)
        {
            monthlyListBox.Items.Clear();
            int month = 08;
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM teammmlevent WHERE userNum = @id AND MONTH(startTime) = @month;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", currentEmployee.getID());
                cmd.Parameters.AddWithValue("@month", month);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {

                    monthlyListBox.Items.Add((string)myReader["eventName"] + ": " + (string)myReader["description"]);
                    tableLayoutPanel10.Visible = true;
                    tableLayoutPanel9.Visible = false;
                }
                myReader.Close();
                if (monthlyListBox.Items.Count <= 0)
                {
                    tableLayoutPanel11.Visible = true;
                    tableLayoutPanel9.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }

        private void jan_Click(object sender, EventArgs e)
        {
            monthlyListBox.Items.Clear();
            int month = 01;
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM teammmlevent WHERE userNum = @id AND MONTH(startTime) = @month;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", currentEmployee.getID());
                cmd.Parameters.AddWithValue("@month", month);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    monthlyListBox.Items.Add((string)myReader["eventName"] + ": " + (string)myReader["description"]);
                    tableLayoutPanel10.Visible = true;
                    tableLayoutPanel9.Visible = false;
                }
                myReader.Close();
                if (monthlyListBox.Items.Count <= 0)
                {
                    tableLayoutPanel11.Visible = true;
                    tableLayoutPanel9.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();

        }

        private void monthlyReturn_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = true;
            tableLayoutPanel9.Visible = false;
        }

        private void apr_Click(object sender, EventArgs e)
        {
            monthlyListBox.Items.Clear();
            int month = 04;
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM teammmlevent WHERE userNum = @id AND MONTH(startTime) = @month;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", currentEmployee.getID());
                cmd.Parameters.AddWithValue("@month", month);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {

                    monthlyListBox.Items.Add((string)myReader["eventName"] + ": " + (string)myReader["description"]);
                    tableLayoutPanel10.Visible = true;
                    tableLayoutPanel9.Visible = false;
                }
                myReader.Close();
                if (monthlyListBox.Items.Count <= 0)
                {
                    tableLayoutPanel11.Visible = true;
                    tableLayoutPanel9.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Visible = true;
            tableLayoutPanel10.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tableLayoutPanel9.Visible = true;
            tableLayoutPanel10.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tableLayoutPanel9.Visible = true;
            tableLayoutPanel11.Visible = false;
        }

        private void feb_Click(object sender, EventArgs e)
        {
            monthlyListBox.Items.Clear();
            int month = 02;
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM teammmlevent WHERE userNum = @id AND MONTH(startTime) = @month;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", currentEmployee.getID());
                cmd.Parameters.AddWithValue("@month", month);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    monthlyListBox.Items.Add((string)myReader["eventName"] + ": " + (string)myReader["description"]);
                    tableLayoutPanel10.Visible = true;
                    tableLayoutPanel9.Visible = false;
                }
                myReader.Close();
                if (monthlyListBox.Items.Count <= 0)
                {
                    tableLayoutPanel11.Visible = true;
                    tableLayoutPanel9.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }

        private void mar_Click(object sender, EventArgs e)
        {
            monthlyListBox.Items.Clear();
            int month = 03;
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM teammmlevent WHERE userNum = @id AND MONTH(startTime) = @month;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", currentEmployee.getID());
                cmd.Parameters.AddWithValue("@month", month);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    monthlyListBox.Items.Add((string)myReader["eventName"] + ": " + (string)myReader["description"]);
                    tableLayoutPanel10.Visible = true;
                    tableLayoutPanel9.Visible = false;
                }
                myReader.Close();
                if (monthlyListBox.Items.Count <= 0)
                {
                    tableLayoutPanel11.Visible = true;
                    tableLayoutPanel9.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }

        private void may_Click(object sender, EventArgs e)
        {
            monthlyListBox.Items.Clear();
            int month = 05;
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM teammmlevent WHERE userNum = @id AND MONTH(startTime) = @month;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", currentEmployee.getID());
                cmd.Parameters.AddWithValue("@month", month);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    monthlyListBox.Items.Add((string)myReader["eventName"] + ": " + (string)myReader["description"]);
                    tableLayoutPanel10.Visible = true;
                    tableLayoutPanel9.Visible = false;
                }
                myReader.Close();
                if (monthlyListBox.Items.Count <= 0)
                {
                    tableLayoutPanel11.Visible = true;
                    tableLayoutPanel9.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }

        private void jun_Click(object sender, EventArgs e)
        {
            monthlyListBox.Items.Clear();
            int month = 06;
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM teammmlevent WHERE userNum = @id AND MONTH(startTime) = @month;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", currentEmployee.getID());
                cmd.Parameters.AddWithValue("@month", month);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    monthlyListBox.Items.Add((string)myReader["eventName"] + ": " + (string)myReader["description"]);
                    tableLayoutPanel10.Visible = true;
                    tableLayoutPanel9.Visible = false;
                }
                myReader.Close();
                if (monthlyListBox.Items.Count <= 0)
                {
                    tableLayoutPanel11.Visible = true;
                    tableLayoutPanel9.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }

        private void jul_Click(object sender, EventArgs e)
        {
            monthlyListBox.Items.Clear();
            int month = 07;
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM teammmlevent WHERE userNum = @id AND MONTH(startTime) = @month;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", currentEmployee.getID());
                cmd.Parameters.AddWithValue("@month", month);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    monthlyListBox.Items.Add((string)myReader["eventName"] + ": " + (string)myReader["description"]);
                    tableLayoutPanel10.Visible = true;
                    tableLayoutPanel9.Visible = false;
                }
                myReader.Close();
                if (monthlyListBox.Items.Count <= 0)
                {
                    tableLayoutPanel11.Visible = true;
                    tableLayoutPanel9.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }

        private void sep_Click(object sender, EventArgs e)
        {
            monthlyListBox.Items.Clear();
            int month = 09;
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM teammmlevent WHERE userNum = @id AND MONTH(startTime) = @month;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", currentEmployee.getID());
                cmd.Parameters.AddWithValue("@month", month);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    monthlyListBox.Items.Add((string)myReader["eventName"] + ": " + (string)myReader["description"]);
                    tableLayoutPanel10.Visible = true;
                    tableLayoutPanel9.Visible = false;
                }
                myReader.Close();
                if (monthlyListBox.Items.Count <= 0)
                {
                    tableLayoutPanel11.Visible = true;
                    tableLayoutPanel9.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }

        private void oct_Click(object sender, EventArgs e)
        {
            monthlyListBox.Items.Clear();
            int month = 10;
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM teammmlevent WHERE userNum = @id AND MONTH(startTime) = @month;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", currentEmployee.getID());
                cmd.Parameters.AddWithValue("@month", month);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    monthlyListBox.Items.Add((string)myReader["eventName"] + ": " + (string)myReader["description"]);
                    tableLayoutPanel10.Visible = true;
                    tableLayoutPanel9.Visible = false;
                }
                myReader.Close();
                if (monthlyListBox.Items.Count <= 0)
                {
                    tableLayoutPanel11.Visible = true;
                    tableLayoutPanel9.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }

        private void nov_Click(object sender, EventArgs e)
        {
            monthlyListBox.Items.Clear();
            int month = 11;
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM teammmlevent WHERE userNum = @id AND MONTH(startTime) = @month;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", currentEmployee.getID());
                cmd.Parameters.AddWithValue("@month", month);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    monthlyListBox.Items.Add((string)myReader["eventName"] + ": " + (string)myReader["description"]);
                    tableLayoutPanel10.Visible = true;
                    tableLayoutPanel9.Visible = false;
                }
                myReader.Close();
                if (monthlyListBox.Items.Count <= 0)
                {
                    tableLayoutPanel11.Visible = true;
                    tableLayoutPanel9.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }

        private void dec_Click(object sender, EventArgs e)
        {
            monthlyListBox.Items.Clear();
            int month = 12;
            string connStr = "server=157.89.28.130;user=ChangK;database=csc340;port=3306;password=Wallace#409;";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT * FROM teammmlevent WHERE userNum = @id AND MONTH(startTime) = @month;";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", currentEmployee.getID());
                cmd.Parameters.AddWithValue("@month", month);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter(cmd);
                MySqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    monthlyListBox.Items.Add((string)myReader["eventName"] + ": " + (string)myReader["description"]);
                    tableLayoutPanel10.Visible = true;
                    tableLayoutPanel9.Visible = false;
                }
                myReader.Close();
                if (monthlyListBox.Items.Count <= 0)
                {
                    tableLayoutPanel11.Visible = true;
                    tableLayoutPanel9.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        }
    }
}