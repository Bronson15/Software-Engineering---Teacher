﻿using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TeacherGUI
{

    public partial class Login_Screen : Form
    {
        
        //serverAddress = "127.0.0.0";
        //port = "8888";
        
        public Login_Screen()
        {
            InitializeComponent();
        }

        //loginButton
        private void button1_Click(object sender, EventArgs e)
        {
            databaseController.dbConnect();
            databaseController.sqlQuery = "SELECT * FROM teacher WHERE login_id = @username && pass = @pass;";
            MySqlCommand cmd = new MySqlCommand(databaseController.sqlQuery, databaseController.conn);


            string passwordHash = Hash.passwordHash(passwordTextBox.Text);
            cmd.Parameters.AddWithValue("@username", usernameTextBox.Text);
            cmd.Parameters.AddWithValue("@pass", passwordHash);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                databaseController.conn.Close();
                Hide();
                new TeacherHome().Show();
            }
            else
            {
                MessageBox.Show("Either your username or password was incorrect. Please try again.");
                databaseController.conn.Close();
            }
        }

        private void Login_Screen_Load(object sender, EventArgs e)
        {
            /*g.clientSocket.Connect("10.40.43.43", 61600);
            g.serverStream.Read(g.inStream, 0, (int)g.clientSocket.ReceiveBufferSize);
            string returndata = Encoding.ASCII.GetString(g.inStream);
            if (returndata == ";")
            {
                Console.WriteLine("hello");
            }*/

            //Username textbox
            usernameTextBox.Enter += new EventHandler(username_Enter);
            usernameTextBox.Leave += new EventHandler(username_Leave);
            username_SetText();

            //Password textbox
            passwordTextBox.Enter += new EventHandler(password_Enter);
            passwordTextBox.Leave += new EventHandler(password_Leave);
            password_SetText();

            this.AcceptButton = button1;
        }


        //adminButton
        private void button2_Click(object sender, EventArgs e)
        {
            new AdminScreen().Show();
            Hide();
        }

        //Username
        protected void username_SetText()
        {
            this.usernameTextBox.Text = "Username";
            usernameTextBox.ForeColor = Color.Gray;
        }

        private void username_Enter(object sender, EventArgs e)
        {
            if (usernameTextBox.ForeColor == Color.Black)
                return;
            usernameTextBox.Text = "";
            usernameTextBox.ForeColor = Color.Black;
        }
        private void username_Leave(object sender, EventArgs e)
        {
            if (usernameTextBox.Text.Trim() == "")
                username_SetText();
        }

        //Password
        protected void password_SetText()
        {
            this.passwordTextBox.Text = "Password";
            passwordTextBox.ForeColor = Color.Gray;
        }

        private void password_Enter(object sender, EventArgs e)
        {
            if (passwordTextBox.ForeColor == Color.Black)
                return;
            passwordTextBox.Text = "";
            passwordTextBox.ForeColor = Color.Black;
        }
        private void password_Leave(object sender, EventArgs e)
        {
            if (passwordTextBox.Text.Trim() == "")
                password_SetText();
        }
    }
}
