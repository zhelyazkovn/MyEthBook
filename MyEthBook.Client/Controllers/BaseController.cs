using Microsoft.AspNet.Identity.Owin;
using MyEthBook.Services;
using Nethereum.Web3;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyEthBook.Client.Controllers
{
    public class BaseController : Controller
    {
        internal ApplicationUserManager _userManager;

        internal ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        internal ContractService GetContactService()
        {   
            string ethNodeAddress = "https://ropsten.infura.io/pRYzCwqJJrbYxkXJJjL5";// "http://127.0.0.1:7545";
            var web3 = new Web3(ethNodeAddress);
            var service = new ContractService(web3, "0x181976bb53bce865a3e7f9f2a22cb550019849bf"); //contract address //0xdd6e8a55ef29b4a4dd9a0cf3259afbd0ef4c5755

            return service;
        }

        internal T Sync<T>(Task<T> call)
        {
            return Task.Run(() => call).Result;
        }
    }
}