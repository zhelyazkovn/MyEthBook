using Ipfs.Api;
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

        public async Task<ActionResult> Index()
        {
            ContractService contractService =  GetContactService();
            string imageSrc = "";
            //string imageSrc = "QmdDF4RyGeSXSwoSNQXFqWZDgw2mTaDgWimJcRpAo3GWv5";
            //string avatar = "avatar55.jpg";
            //var ipfs = new IpfsClient("http://localhost:5001/ipfs/QmPhnvn747LqwPYMJmQVorMaGbMSgA7mRRoyyZYz3DoZRQ/");
            //var file = await ipfs.FileSystem.ReadFileAsync("QmdDF4RyGeSXSwoSNQXFqWZDgw2mTaDgWimJcRpAo3GWv5");
            //    https://ipfs.io/ipfs/
            //if (User.Identity.IsAuthenticated)
            //{
            //    var user = UserManager.FindById(User.Identity.GetUserId());

            //    myBookCount = Sync(contractService.GetMyBookCount("0xfb3d0b9d9ae0bfccf875688fbb7aaad4556eb371"));

            //    //myBookCount = Sync(contractService.GetMyBookCount(user.Address));
            //}


            // Sync(contractService.AddContact("pena", "0x440a3ced76081189d4faf7342a940a305a61d9e2"));
            //var ipfs = new IpfsClient("http://localhost:5001/ipfs/QmPhnvn747LqwPYMJmQVorMaGbMSgA7mRRoyyZYz3DoZRQ/");// ("http://ipv4.fiddler:5001");

            //const string filename = "QmXarR6rgkQ2fDSHjSY5nM2kuCXKYGViky5nohtwgF65Ec/about";
            //string text = await ipfs.FileSystem.ReadAllTextAsync(filename);
            //ipfs.FileSystem.AddAsync(, "kur");
            return View((object)imageSrc);

        }


        //
        // POST: /Manage/Index
        [HttpPost]
        public async Task<ActionResult> Index(HttpPostedFileBase avatar)
        {
            string myBookCount = "";
            //if (avatar == null)
            //{
            //    avatar = Request.Files["avatar"];
            //}
            
            //var ipfs = new IpfsClient("http://localhost:5001/ipfs/QmPhnvn747LqwPYMJmQVorMaGbMSgA7mRRoyyZYz3DoZRQ/");
            //var file = await ipfs.FileSystem.AddAsync(avatar.InputStream, avatar.FileName);

            //var userId = User.Identity.GetUserId();

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
            var service = new ContractService(web3, "0x9c3431612364Eb8f6Fe7AD91D205F014BF0349aA"); //contract address //0x7e383a3a1759c2f150f0fab93b94fd3cc2472486

            return service;
        }

        public T Sync<T>(Task<T> call)
        {
            return Task.Run(() => call).Result;
        }
    }
}