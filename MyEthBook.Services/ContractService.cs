using MyEthBook.Services.BookModels;
using MyEthBook.Services.Utils;
using Nethereum.Contracts;
using Nethereum.Web3;
using System.Threading.Tasks;

namespace MyEthBook.Services
{
    public class ContractService
    {
        private readonly Web3 web3;

        private Contract contract;

        public ContractService()
        {
            string ethNodeAddress = ContractData.EthNode;
            this.web3 = new Web3(ethNodeAddress);
            this.contract = web3.Eth.GetContract(ContractData.ABI, ContractData.Address);
        }

        public ContractService(Web3 web3, string address, string abi)
        {
            this.web3 = web3;
            this.contract = web3.Eth.GetContract(abi, address);
        }

        public Task<long> GetMyBookCount(string address)
        {
            var getMyBookCountFunction = contract.GetFunction("getMyBookCount");
            var count = getMyBookCountFunction.CallAsync<long>(address);
            return count;
        }

        public Task<int> GetTotalInvitedAndAcceptedCount(string address)
        {
            var getTotalInvitedAndAcceptedCountFunc = contract.GetFunction("getTotalInvitedAndAcceptedCount");
            var count = getTotalInvitedAndAcceptedCountFunc.CallAsync<int>(address);
            return count;
        }

        public Task<int> GetTotalInvitedCount(string address)
        {
            var getTotalInvitedCount = contract.GetFunction("getTotalInvitedCount");
            var count = getTotalInvitedCount.CallAsync<int>();
            return count;
        }

        public Task<bool?> AddContact(string name,string address)
        {
            var getMyBookCountFunction = contract.GetFunction("addContact"); 
            var result = getMyBookCountFunction.CallAsync<bool?>(name,address);
            return result;
        }

        public Task<ContactAddress> GetContact(int index, string address)
        {
            var getContactFunction = contract.GetFunction("getContact"); 
            var result = getContactFunction.CallDeserializingToObjectAsync<ContactAddress>(index, address);
            return result;
        }

        public Task<bool> IsUnlocked(string address)
        {
            var isUnlockedFunction = contract.GetFunction("isUnlocked"); 
            var result = isUnlockedFunction.CallAsync<bool>(address);
            return result;
        }
    }
}

