﻿using Microsoft.AspNet.Identity;
using MyEthBook.Client.Models;
using MyEthBook.Services;
using MyEthBook.Services.BookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyEthBook.Client.Controllers
{
    public class EthBookController : BaseController
    {
        // GET: EthBook
        public async Task<ActionResult> Index()
        {
            ContractService contractService = GetContactService();
            long myBookCount = -1;
            EthBookViewModel vm = new EthBookViewModel();
            if (User.Identity.IsAuthenticated)
            {
                var user = UserManager.FindById(User.Identity.GetUserId());

                //myBookCount = Sync(contractService.GetMyBookCount("0xf17f52151ebef6c7334fad080c5704d77216b732"));
                myBookCount = Sync(contractService.GetMyBookCount(user.Address));

                vm.ContactAddresses = new List<ContactAddress>();
                for (int i = 0; i < myBookCount; i++)
                {
                    //ContactAddress ca = await contractService.GetContact(i, "0xf17f52151ebef6c7334fad080c5704d77216b732");
                    ContactAddress ca = await contractService.GetContact(i, user.Address);
                    vm.ContactAddresses.Add(ca);
                }

                //myBookCount = Sync(contractService.GetMyBookCount(user.Address));
            }


            //Sync(contractService.AddContact("pena", "0x440a3ced76081189d4faf7342a940a305a61d9e2"));
            return  View(vm);
        }
    }
}