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

        }

        private void addManagerEvent_Click(object sender, EventArgs e)
        {

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
    }
}