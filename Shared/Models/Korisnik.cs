﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Korisnik
    {
        public int korisnikId { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string brLicneKarte { get; set; }
        public string jmbg { get; set; }
        public string brojpasosa { get; set; }
        public string brojTelefona { get; set; }
        public string adresa { get; set; }
        public string email { get; set; }
        public string sifra { get; set; }

    }
}
