using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MyEthBook.Services;
using Nethereum.Web3;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyEthBook.Client.Controllers
{
    public class HomeController : Controller
    {
        //private ApplicationUserManager _userManager;

        //public ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}

        public ActionResult Index()
        {
            ContractService contractService = GetContactService();
            long myBookCount = -1;
            //if (User.Identity.IsAuthenticated)
            //{
            //    var user = UserManager.FindById(User.Identity.GetUserId());
                
            //    myBookCount = Sync(contractService.GetMyBookCount("0xfb3d0b9d9ae0bfccf875688fbb7aaad4556eb371"));

            //    //myBookCount = Sync(contractService.GetMyBookCount(user.Address));
            //}


           // Sync(contractService.AddContact("pena", "0x440a3ced76081189d4faf7342a940a305a61d9e2"));
            return View(myBookCount);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private ContractService GetContactService()
        {
            /*   Important:
             *   write your contract in remix ide
             *   run local node - test rpc
             *   connect remix toWeb3 provider - localhost:8545 - the local one from the testrpc
             *   deploy the contract in remix (create)
             *   get the contract address
             *   get the abi form the details button in Compile section in remix and assign to the ContactService
             */
            var web3 = new Web3("http://localhost:8545");
            var service = new ContractService(web3, "0x7e383a3a1759c2f150f0fab93b94fd3cc2472486"); //contract address

            return service;
        }

        public T Sync<T>(Task<T> call)
        {
            return Task.Run(() => call).Result;
        }
    }
}