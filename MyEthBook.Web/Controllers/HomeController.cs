using MyEthBook.Services;
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyEthBook.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var service = GetContactService();
            //var proposals = Sync(service.GetLatestProposals(5));
            //var proposalsViewModel = new ProposalViewModelMapper().MapFromModel(proposals);
            //return View(proposalsViewModel);

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private ContractService GetContactService()
        {
            var web3 = new Web3("https://eth2.augur.net");
            var service = new ContractService(web3, "0x1c5d91a56d1aeae82d855c408a8a8b753612a4cb");
            return service;
        }

        public T Sync<T>(Task<T> call)
        {
            return Task.Run(() => call).Result;
        }
    }
}