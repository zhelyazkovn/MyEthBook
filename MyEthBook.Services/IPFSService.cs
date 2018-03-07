using Ipfs.Api;
using MyEthBook.Services.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEthBook.Services
{
    public class IPFSService
    {
        private IpfsClient IpfsClient;

        public IPFSService()
        {
            IpfsClient = new IpfsClient(IPFSData.Host);
        }

        public IpfsClient GetIpfsClient()
        {
            return IpfsClient;
        }
    }
}
