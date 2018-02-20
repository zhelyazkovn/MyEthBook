using MyEthBook.Services.BookModels;
using Nethereum.Contracts;
using Nethereum.Web3;
using System.Threading.Tasks;

namespace MyEthBook.Services
{
    public class ContractService
    {
        private readonly Web3 web3;
        //private string abi = @"[{""constant"": true,""inputs"": [{""name"": ""hash"",""type"": ""string""}],""name"": ""verify"",""outputs"": [{""name"": ""dateAdded"",""type"": ""uint256""}],""payable"": false,""stateMutability"": ""view"",""type"": ""function""},{""constant"": false,""inputs"": [{""name"": ""hash"",""type"": ""string""}],""name"": ""add"",""outputs"": [{""name"": ""dateAdded"",""type"": ""uint256""}],""payable"": false,""stateMutability"": ""nonpayable"",""type"": ""function""},{""inputs"": [],""payable"": false,""stateMutability"": ""nonpayable"",""type"": ""constructor""}]";
        /* get the abi form the details button in Compile section in remix */
        private string abi = @"[{""constant"":true,""inputs"":[],""name"":""getTotalCount"",""outputs"":[{""name"":""count"",""type"":""uint256""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":true,""inputs"":[{""name"":""addr"",""type"":""address""}],""name"":""getMyBookCount"",""outputs"":[{""name"":""count"",""type"":""uint256""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":true,""inputs"":[{""name"":""index"",""type"":""uint256""},{""name"":""addr"",""type"":""address""}],""name"":""getContact"",""outputs"":[{""name"":"""",""type"":""bytes32""},{""name"":"""",""type"":""address""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":true,""inputs"":[{""name"":"""",""type"":""address""},{""name"":"""",""type"":""uint256""}],""name"":""_ethBook"",""outputs"":[{""name"":""name"",""type"":""bytes32""},{""name"":""addr"",""type"":""address""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""name"",""type"":""bytes32""},{""name"":""addr"",""type"":""address""}],""name"":""addContact"",""outputs"":[],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""addr"",""type"":""address""},{""name"":""amount"",""type"":""uint256""}],""name"":""payPraize"",""outputs"":[],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[],""payable"":false,""stateMutability"":""nonpayable"",""type"":""constructor""}]";
        private Contract contract;
        public ContractService(Web3 web3, string address)
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

        public Task<bool?> AddContact(string name,string address)
        {
            var getMyBookCountFunction = contract.GetFunction("addContact"); //0x2b0a1ced76081189d4faf7342a940a305a61d9e0
            var result = getMyBookCountFunction.CallAsync<bool?>(name,address);
            return result;
        }

        public Task<ContactAddress> GetContact(int index, string address)
        {
            var getContactFunction = contract.GetFunction("getContact"); //0x2b0a1ced76081189d4faf7342a940a305a61d9e0
            var result = getContactFunction.CallDeserializingToObjectAsync<ContactAddress>(index, address);
            return result;
        }


        //public Task<long> GetNumberOfProposals()
        //{
        //    return contract.GetFunction("numberOfProposals").CallAsync<long>();
        //}

        //public async Task<List<Proposal>> GetAllProposals()
        //{

        //    var numberOfProposals = await GetNumberOfProposals().ConfigureAwait(false);
        //    var proposals = new List<Proposal>();

        //    for (var i = 0; i < numberOfProposals; i++)
        //    {
        //        proposals.Add(await GetProposal(i).ConfigureAwait(false));
        //    }
        //    return proposals;
        //}

        //public async Task<List<Proposal>> GetLatestProposals(long total)
        //{
        //    var numberOfProposals = await GetNumberOfProposals().ConfigureAwait(false);
        //    if (total >= numberOfProposals) total = numberOfProposals - 1;
        //    var proposals = new List<Proposal>();

        //    for (var i = numberOfProposals - 1; i >= (numberOfProposals - total); i--)
        //    {
        //        proposals.Add(await GetProposal(i).ConfigureAwait(false));
        //    }
        //    return proposals;
        //}

        //public async Task<List<Proposal>> GetAllProposals(long startProposal, long lastProposal)
        //{
        //    var numberOfProposals = await GetNumberOfProposals().ConfigureAwait(false);
        //    if (lastProposal >= numberOfProposals) lastProposal = numberOfProposals - 1;
        //    var proposals = new List<Proposal>();

        //    for (var i = startProposal; i <= lastProposal; i++)
        //    {
        //        proposals.Add(await GetProposal(i).ConfigureAwait(false));
        //    }
        //    return proposals;
        //}

        //public async Task<Proposal> GetProposal(long index)
        //{
        //    var proposalsFunction = contract.GetFunction("proposals");
        //    var proposal = await proposalsFunction.CallDeserializingToObjectAsync<Proposal>(index).ConfigureAwait(false);
        //    proposal.Index = index;
        //    return proposal;
        //}

    }
}

