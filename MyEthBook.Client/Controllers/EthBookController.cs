using Microsoft.AspNet.Identity;
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

                myBookCount = Sync(contractService.GetMyBookCount(user.Address));

                vm.ContactAddresses = new List<ContactAddress>();
                for (int i = 0; i < myBookCount; i++)
                {
                    ContactAddress ca = await contractService.GetContact(i, user.Address);
                    vm.ContactAddresses.Add(ca);
                }

                vm.UserUnlocked = user.Unlocked.HasValue ? user.Unlocked.Value : false;
                if (!user.Unlocked.HasValue || (user.Unlocked.HasValue && !user.Unlocked.Value))
                {
                    if (contractService != null)
                    {
                        Task<bool> task = contractService.IsUnlocked(user.Address);
                        bool unlocked = Sync(task);
                        if (unlocked)
                        {
                            user.Unlocked = true;
                            vm.UserUnlocked = true;
                            await UserManager.UpdateAsync(user);
                        }
                    }
                }

                vm.RefLink = user.RefLink;
                vm.Init = user.Init.HasValue ? user.Init.Value : false;
            }

            return  View(vm);
        }
    }
}