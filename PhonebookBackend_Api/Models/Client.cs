using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhonebookBackend_Api.Models
{
    public class Client
    {
        public long clientID { get; set; }
        public string clientName { get; set; }
        public string clientSurname { get; set; }
        public string clientIdNumber { get; set; }
        public string clientTelephone { get; set; }
        public string clientEmail { get; set; }
        public string clientAddress { get; set; }
    }
}