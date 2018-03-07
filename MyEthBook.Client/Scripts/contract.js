var contract;

let createContract = function (addr,abi) {
    contract = web3.eth.contract(abi).at(addr);
}
