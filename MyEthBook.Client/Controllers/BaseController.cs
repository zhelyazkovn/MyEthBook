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
            /*   Important:
             *   write your contract in remix ide
             *   run local node - test rpc
             *   connect remix toWeb3 provider - localhost:8545 - the local one from the testrpc
             *   deploy the contract in remix (create)
             *   get the contract address
             *   get the abi form the details button in Compile section in remix and assign to the ContactService
             */
            var web3 = new Web3("http://localhost:8545");
            var service = new ContractService(web3, "0x1a7420bbbb541a91a318dab606060d359f63556c"); //contract address

            return service;
        }

        internal T Sync<T>(Task<T> call)
        {
            return Task.Run(() => call).Result;
        }
    }
}