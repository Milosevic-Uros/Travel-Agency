﻿using BusinessLayer;
using Shared.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PresentationLayer
{
    public partial class InsertClient : Form
    {
        private readonly IAdminBusiness adminBusiness;
        private readonly IClientBusiness clientBusiness;
        Admin admin;
        public InsertClient(IAdminBusiness _adminBusiness, IClientBusiness _clientBusiness, Admin _admin)
        {
            adminBusiness= _adminBusiness;
            adminBusiness = _adminBusiness;
            clientBusiness = _clientBusiness;
            admin = _admin;
            InitializeComponent();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "" ||
               textBoxLastName.Text == "" ||
               textBoxIdNum.Text == "" ||
               textBoxPhoneNum.Text == "" ||
               textBoxEmail.Text == "" ||
               textBoxPassword.Text == "" ||
               textBoxJMBG.Text == "" ||
               textBoxAddress.Text == "" ||
               textBoxPassportNum.Text == "")
            {
                MessageBox.Show("Fill in all required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxName.Focus();
            }

            else if (!Regex.Match(textBoxName.Text, "^[A-Z][a-z]*$").Success)
            {
                MessageBox.Show("The name field is not filled in correctly!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxName.Focus();
            }

            else if (!Regex.Match(textBoxLastName.Text, "^[A-Z][a-z]*$").Success)
            {
                MessageBox.Show("The surname field is not filled in correctly!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxLastName.Focus();
            }

            else if (!Regex.Match(textBoxIdNum.Text, "^\\d{9}$").Success)
            {
                MessageBox.Show("The ID number field is not filled in correctly!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxIdNum.Focus();
            }
            else if (!Regex.Match(textBoxPhoneNum.Text, @"^([0][6]\d{1}[0-9]\d{2,3}\d{3,4}$)?").Success)
            {
                MessageBox.Show("The phone number field is not filled in correctly!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPhoneNum.Focus();
            }

            else if (!Regex.Match(textBoxEmail.Text, "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$").Success)
            {
                MessageBox.Show("The email field is not filled in correctly!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxEmail.Focus();
            }

            else if (!Regex.Match(textBoxPassword.Text, "^[a-zA-Z][a-zA-Z0-9]{5,15}").Success)
            {
                MessageBox.Show("The password field is not filled in correctly! The length of the password must be between 10 and 20 characters!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Focus();
            }

            else if (!Regex.Match(textBoxJMBG.Text, "^^(0[1-9]|[12][0-9]|3[01])(0[1-9]|1[012])[0-9]{9}$").Success)
            {
                MessageBox.Show("13 characters required for JMBG field!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxJMBG.Focus();
            }

            else if (!Regex.Match(textBoxPassportNum.Text, "^\\d{9}$").Success)
            {
                MessageBox.Show("The passport number field is not filled in correctly!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassportNum.Focus();
            }
            else 
            {
                Client client = new Client();
                client.firstName = textBoxName.Text;
                client.lastName = textBoxLastName.Text;
                client.idNumber = textBoxIdNum.Text;
                client.phoneNumber = textBoxPhoneNum.Text;
                client.email = textBoxEmail.Text;
                client.password = textBoxPassword.Text;
                client.uniqueIdNumber = textBoxJMBG.Text;
                client.address = textBoxAddress.Text;
                client.passportNumber = textBoxPassportNum.Text;

                string result = adminBusiness.InsertClient(client);
                MessageBox.Show(result, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);


                textBoxName.Text = "";
                textBoxLastName.Text = "";
                textBoxIdNum.Text = "";
                textBoxPhoneNum.Text = "";
                textBoxAddress.Text = "";
                textBoxEmail.Text = "";
                textBoxJMBG.Text = "";
                textBoxPassportNum.Text = "";
                textBoxPassword.Text = "";

            }
                

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
            ClientManagement clientManagement = new ClientManagement(adminBusiness, clientBusiness, admin);
            clientManagement.Show();
        }
    }
}
