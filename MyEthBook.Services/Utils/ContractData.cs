using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEthBook.Services.Utils
{
    public struct ContractData
    {
        //Not stored in app settings in web.config because of abi format in xml document specifics
        public static string ABI {
            get
            {
                return @"[{""constant"":true, ""inputs"":[],""name"":""unlocked"",""outputs"":[{""name"":"""",""type"":""bool""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":true,""inputs"":[],""name"":""_owner"",""outputs"":[{""name"":"""",""type"":""address""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":true,""inputs"":[],""name"":""_unlockPrice"",""outputs"":[{""name"":"""",""type"":""uint256""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":true,""inputs"":[{""name"":""index"",""type"":""uint256""},{""name"":""addr"",""type"":""address""}],""name"":""getContact"",""outputs"":[{""name"":"""",""type"":""bytes32""},{""name"":"""",""type"":""address""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":true,""inputs"":[{""name"":""addr"",""type"":""address""}],""name"":""isUnlocked"",""outputs"":[{""name"":"""",""type"":""bool""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":true,""inputs"":[{""name"":""addr"",""type"":""address""}],""name"":""getMyBookCount"",""outputs"":[{""name"":""count"",""type"":""uint256""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":true,""inputs"":[],""name"":""getTotalCount"",""outputs"":[{""name"":""count"",""type"":""uint256""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":true,""inputs"":[],""name"":""getTotalInvitedCount"",""outputs"":[{""name"":"""",""type"":""uint256""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":true,""inputs"":[{""name"":""refOwner"",""type"":""address""}],""name"":""getTotalInvitedAndAcceptedCount"",""outputs"":[{""name"":"""",""type"":""uint256""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":true,""inputs"":[],""name"":""_minRefCount"",""outputs"":[{""name"":"""",""type"":""uint256""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":true,""inputs"":[{""name"":""addr"",""type"":""address""}],""name"":""getRefferals"",""outputs"":[{""name"":"""",""type"":""string""}],""payable"":false,""stateMutability"":""view"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""newPrice"",""type"":""uint256""}],""name"":""changeUnlockPrice"",""outputs"":[{""name"":"""",""type"":""uint256""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""newMinRefCount"",""type"":""uint256""}],""name"":""changeMinRefCount"",""outputs"":[{""name"":"""",""type"":""uint256""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""refLink"",""type"":""bytes32""}],""name"":""initUser"",""outputs"":[{""name"":"""",""type"":""bool""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""email"",""type"":""string""}],""name"":""inviteFriend"",""outputs"":[{""name"":"""",""type"":""string""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":false,""inputs"":[],""name"":""unlockUser"",""outputs"":[{""name"":"""",""type"":""bool""}],""payable"":true,""stateMutability"":""payable"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""addr"",""type"":""address""}],""name"":""transferOwner"",""outputs"":[{""name"":"""",""type"":""bool""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""refOwner"",""type"":""address""},{""name"":""refLink"",""type"":""bytes32""},{""name"":""email"",""type"":""string""}],""name"":""acceptInvitation"",""outputs"":[{""name"":"""",""type"":""bool""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""name"",""type"":""bytes32""},{""name"":""addr"",""type"":""address""}],""name"":""addContact"",""outputs"":[{""name"":"""",""type"":""bool""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""addr"",""type"":""address""},{""name"":""amount"",""type"":""uint256""}],""name"":""payPraize"",""outputs"":[],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[],""payable"":false,""stateMutability"":""nonpayable"",""type"":""constructor""},{""constant"":false,""inputs"":[{""name"":""index"",""type"":""uint256""}],""name"":""deleteContact"",""outputs"":[{""name"":"""",""type"":""bool""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""},{""constant"":false,""inputs"":[{""name"":""index"",""type"":""uint256""},{""name"":""name"",""type"":""bytes32""},{""name"":""addr"",""type"":""address""}],""name"":""editContact"",""outputs"":[{""name"":"""",""type"":""bool""}],""payable"":false,""stateMutability"":""nonpayable"",""type"":""function""}]";
            }
        }

        public static string Address
        {
            get
            {
                return "0x9c3431612364Eb8f6Fe7AD91D205F014BF0349aA";
            }
        }

        public static string EthNode
        {
            get
            {
                return "https://ropsten.infura.io/pRYzCwqJJrbYxkXJJjL5";
            }
        }
    }
}
