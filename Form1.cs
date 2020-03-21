﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using AUT.ServiceReference1;
using System.Threading;

namespace AUT
{
    public partial class Form1 : Form
    {
        AuthorizationClient client = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new AuthorizationClient();

            Thread ServerStatus = new Thread(CheckServerStatus);
            ServerStatus.IsBackground = true;
            ServerStatus.Start();
        }

        private void CheckServerStatus()
        {
            while(true)
            {
                bool status = true;
                
                //Если сервер работает
                while (status)
                {
                    try
                    {
                        client.ServerStatus();
                        Thread.Sleep(50);
                    }
                    catch
                    {
                        status = false;
                        MessageBox.Show("Сервер недоступен. Нажмите ОК для переподключения...");
                    }
                }

                //Если сервер не работает
                while (!status)
                {
                    try
                    {
                        client.ServerStatus();
                        status = true;
                        MessageBox.Show("Подключение восстановлено");

                    }
                    catch
                    {
                        MessageBox.Show("Сервер недоступен. Нажмите ОК для переподключения...");
                        Thread.Sleep(50);
                    }
                }
            }
            
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            if(tbLogin.TextLength < 1 || tbPassword.TextLength < 1)
            {
                MessageBox.Show("Одно из полей для ввода пусто!!!");
                return;
            }
            try
            {
                var result = client.Authorization(tbLogin.Text, tbPassword.Text);
                if (result)
                    MessageBox.Show("Удачно");
                else
                    MessageBox.Show("Неудачно");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Не удаётся подключиться к серверу");
            }

        }

        

        private void tbLogin_TextChanged(object sender, EventArgs e)
        {
            if(tbLogin.Text.Length == 0)
            {
                StatusLogin.Text = null;
            }
            var result = client.AvailabilityLogin(tbLogin.Text);
            if(result)
            {
                StatusLogin.ForeColor = Color.Green;
                StatusLogin.Text = "Ник доступен";
                //btConnect.Enabled = true;
            }
            else
            {
                StatusLogin.ForeColor = Color.Red;
                StatusLogin.Text = "Ник занят";
                //btConnect.Enabled = false;
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Close();
        }
    }
}
