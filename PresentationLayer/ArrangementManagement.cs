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

namespace PresentationLayer
{
    public partial class ArrangementManagement : Form
    {
        private readonly IAdminBusiness adminBusiness;
        private readonly IClientBusiness clientBusiness;
        Admin admin;

        public ArrangementManagement(IAdminBusiness _adminBusiness, IClientBusiness _clientBusiness, Admin _admin)
        {
            adminBusiness = _adminBusiness;
            clientBusiness = _clientBusiness;
            admin = _admin;
            InitializeComponent();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (textBoxArrangementID.Text == "")
            {
                MessageBox.Show("Select arrangement!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxArrangementID.Focus();
                return;
            }
            else
            {
                int arrangementID = Convert.ToInt32(textBoxArrangementID.Text);
                string result = adminBusiness.DeleteArrangement(arrangementID);
                MessageBox.Show(result, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridViewArrangemet.DataSource = adminBusiness.GetAllArrangements();

                textBoxArrangementID.Text = "";
                dateTimePickerDeparture.Text = "";
                dateTimePickerReturnDate.Text = "";
            }
        }

        private void ArrangementManagement_Load(object sender, EventArgs e)
        {
            dataGridViewArrangemet.DataSource = adminBusiness.GetAllArrangements();
        }


        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Arrangement arrangement = new Arrangement();
            arrangement.arrangementId = Convert.ToInt32(textBoxArrangementID.Text);
            arrangement.dateOfDeparture = dateTimePickerDeparture.Value;
            arrangement.returnDate = dateTimePickerReturnDate.Value;
            string result = adminBusiness.UpdateArrangement(arrangement);
            MessageBox.Show(result, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridViewArrangemet.DataSource = adminBusiness.GetAllArrangements();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            this.Close();
            InsertArrangement insertArrangement = new InsertArrangement(adminBusiness, clientBusiness, admin);
            insertArrangement.Show();
        }



        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminDashboard adminDashboard = new AdminDashboard(adminBusiness, clientBusiness, admin);
            adminDashboard.Show();
        }

        private void dataGridViewArrangemet_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataGridViewArrangemet.Rows[e.RowIndex];
                textBoxArrangementID.Text = row.Cells[0].Value.ToString();
                dateTimePickerDeparture.Value = Convert.ToDateTime(row.Cells[2].Value);
                dateTimePickerReturnDate.Value = Convert.ToDateTime(row.Cells[3].Value);

            }
        }

    }
}
