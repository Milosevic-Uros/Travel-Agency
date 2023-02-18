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
        private IClientBusiness clientBusiness;
        private Client client;

        public ClientDashboard(IClientBusiness _clientBusiness, Client _client)
        {
            clientBusiness = _clientBusiness;
            client = _client;
            InitializeComponent();
        }

        private void ClientDashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
