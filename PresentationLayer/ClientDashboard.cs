﻿using Shared.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class ClientDashboard : Form
    {
        private readonly IAdminBusiness adminBusiness;
        private readonly IClientBusiness clientBusiness;
        private Client client;

        public ClientDashboard(IAdminBusiness _adminBusiness,IClientBusiness _clientBusiness, Client _client)
        {
            adminBusiness=_adminBusiness;
            clientBusiness = _clientBusiness;
            client = _client;
            InitializeComponent();
        }

        private void ClientDashboard_Load(object sender, EventArgs e)
        {
            labelLoggedIn.Text += "\n" + client.firstName.ToString() + " " + client.lastName.ToString();
        }

        int count = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count < 5)
            {
                pictureBoxSlide.Image = imageList1.Images[count];
                count++;
            }
            else
            {
                count = 0;
            }
            
        }

        private void buttonExchange_Click(object sender, EventArgs e)
        {
            this.Close();
            ExchangeOffice exchangeOffice = new ExchangeOffice(adminBusiness, clientBusiness, client);
            exchangeOffice.ShowDialog(); 
        }

        private void buttonTicket_Click(object sender, EventArgs e)
        {
            this.Close();
            TicketStore ticketStore = new TicketStore(adminBusiness, clientBusiness, client);
            ticketStore.Show();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login(adminBusiness, clientBusiness);
            login.ShowDialog();
        }

        private void buttonBoughtTickets_Click(object sender, EventArgs e)
        {
            this.Close();
            BoughtTickets boughtTickets = new BoughtTickets(clientBusiness, adminBusiness, client);
            boughtTickets.Show();
        }

        private void buttonBoughtArrangements_Click(object sender, EventArgs e)
        {
            this.Close();
            BoughtArrangements boughtArrangements= new BoughtArrangements(clientBusiness, adminBusiness, client);
            boughtArrangements.Show();
        }

        private void buttonArrangements_Click(object sender, EventArgs e)
        {
            ArrangementStore arrangementStore = new ArrangementStore(adminBusiness, clientBusiness, client);
            arrangementStore.Show();
            this.Close();
        }
    }
}
