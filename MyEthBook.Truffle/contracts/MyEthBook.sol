pragma solidity^0.4.18;
contract MyEthBook{
    struct contactAddress{
        bytes32 name;
        address addr;
    }
    address private _owner;
    mapping (address => contactAddress[]) public  _ethBook;
    modifier isOwner(){
        require(msg.sender == _owner);
        _;
    }
    function MyEthBook() public{
        _owner = msg.sender;
    }
    function addContact(bytes32 name,address addr) public{
        //todo: check if this contact already exists and replace instead of adding it twice
        _ethBook[msg.sender].push(contactAddress(
            {
                name: name,
                addr: addr
            }));
    }
    
    function getTotalCount() public view returns(uint count){
         count = _ethBook[msg.sender].length;
    }
    
    function getMyBookCount(address addr) public view returns(uint count){
         count = _ethBook[addr].length;
    }
    
    function getContact(uint index, address addr) public view returns(bytes32, address){
        return (_ethBook[addr][index].name , _ethBook[addr][index].addr);
    }
   
   function payPraize(address addr, uint amount) isOwner public {
       addr.transfer(amount);
   }
}