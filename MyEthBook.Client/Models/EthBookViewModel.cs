using MyEthBook.Services.BookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEthBook.Client.Models
{
    public class EthBookViewModel
    {
        public List<ContactAddress> ContactAddresses;
        public int Length;
        public bool UserUnlocked;
        public bool Init;
        public string RefLink;
    }
}