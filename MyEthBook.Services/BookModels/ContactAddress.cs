using Nethereum.ABI.FunctionEncoding.Attributes;

namespace MyEthBook.Services.BookModels
{
    [FunctionOutput]
    public class ContactAddress
    {
        [Parameter("bytes32", "name", 1)]
        public string Name { get; set; }

        [Parameter("address", "addr", 1)]
        public string Address { get; set; }
    }
}
