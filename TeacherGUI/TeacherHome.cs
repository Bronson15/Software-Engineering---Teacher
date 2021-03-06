﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeacherGUI
{

    

    public partial class TeacherHome : Form
    {
        



        public TeacherHome()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Login_Screen().Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        //Redesign so that the teacher selects the class they currently want to stream and then start said streaming on click
        //use this to send the course that the teacher selects to the Server and wait to receive the port number that the udp stream will come in on
        /*g.outStream = Encoding.ASCII.GetBytes(usernameTextBox.Text + "#" + passwordTextBox.Text);
            g.serverStream.Write(g.outStream, 0, g.outStream.Length);
            g.serverStream.Flush();
        */
        //Change udpListener port to the current class port as received on the TCP connection
        private void CurrentClass_Click(object sender, EventArgs e)
        {
            Form form; 
            try
            {
                form= new Form1(int.Parse(selectedClass.Text));
            }
            catch(Exception ea)
            {
                form = new Form1(1234);
            }
            form.Show();
            Hide();
        }

        private void HistoricData_Click(object sender, EventArgs e)
        {
            new Historic_Data().Show();
            Hide();
        }

        private void TeacherHome_Load(object sender, EventArgs e)
        {

        }
    }
}
