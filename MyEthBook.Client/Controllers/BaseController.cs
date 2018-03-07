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

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            internal set
            {
                _userManager = value;
            }
        }

        internal ContractService GetContactService()
        {   
            var service = new ContractService(); 

            return service;
        }

        internal T Sync<T>(Task<T> call)
        {
            return Task.Run(() => call).Result;
        }
    }
}