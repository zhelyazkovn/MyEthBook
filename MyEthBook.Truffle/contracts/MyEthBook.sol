pragma solidity ^0.4.14;

import "./strings.sol";

contract MyEthBook3{
    using strings for *;
    
    struct contactAddress{
        bytes32 name;
        address addr;
    }
    address public _owner;
    uint public _unlockPrice;
    uint public _minRefCount;
    
    mapping (address => contactAddress[]) private  _ethBook;
    mapping(address => bool) private unlockedUsers;
    mapping(address => uint) private invitedUsersCountPerUser;
    mapping(address => uint) private invitedAndAcceptedUsersCountPerUser;
    
    mapping(address => bytes32) private usersReferalLinks;
    mapping(address => string) private invitedUsersEmailsPerUser;
    mapping(address => string) private invitedAndAcceptedUsersEmailsPerUser;
    
    modifier isOwner(){
        require(msg.sender == _owner);
        _;
    }
    function MyEthBook3() public{
        _owner = msg.sender;
        _unlockPrice = 0.005 ether;
        _minRefCount = 2;
    }
    
    function initUser(bytes32 refLink) public returns(bool){
        if(refLink.length > 0) {
            usersReferalLinks[msg.sender] = refLink;
            return true;
        }
        return false;
    }
    
    function unlockUser()  public payable returns (bool){
        uint val = msg.value;
        if(val >= _unlockPrice){
                unlockedUsers[msg.sender] = true;
        }
        return unlockedUsers[msg.sender];
    }    
    
    function inviteFriend(string email) public returns (string) { 
        invitedUsersEmailsPerUser[msg.sender] = invitedUsersEmailsPerUser[msg.sender].toSlice()
            .concat((email.toSlice().concat(",".toSlice())).toSlice());
        
        invitedUsersCountPerUser[msg.sender] +=1;
        
        return invitedUsersEmailsPerUser[msg.sender];
    }
    
    function acceptInvitation(address refOwner, bytes32 refLink, string email) public returns (bool){
        require(usersReferalLinks[refOwner] == refLink);
        
        invitedAndAcceptedUsersEmailsPerUser[refOwner] = invitedAndAcceptedUsersEmailsPerUser[refOwner].toSlice()
            .concat((",".toSlice().concat(email.toSlice())).toSlice());
            
        invitedAndAcceptedUsersCountPerUser[refOwner] += 1;
        
        if( invitedAndAcceptedUsersCountPerUser[refOwner] >= _minRefCount){
            unlockedUsers[refOwner] = true;
        }
        
        return true;
    }
    
    function addContact(bytes32 name,address addr) public returns (bool){
        if(unlockedUsers[msg.sender]){
            _ethBook[msg.sender].push(contactAddress( 
            {
                name: name,
                addr: addr
            }));
            return true;
        }
        return false;
    }
    
    function deleteContact(uint index) public returns(bool){ 
        if(_ethBook[msg.sender].length > index){
            delete _ethBook[msg.sender][index];
            return true;
        }
        return false;
    }
    
    function editContact(uint index, bytes32 name, address addr) public returns(bool){ 
        if(_ethBook[msg.sender].length > index){
            _ethBook[msg.sender][index].name = name;
            _ethBook[msg.sender][index].addr = addr;
            return true;
        }
         return false;
    }
    
    function getRefferals(address addr) public view returns(string){
        return invitedAndAcceptedUsersEmailsPerUser[addr];
    }
    
    function getTotalCount() public view returns(uint count){
         count = _ethBook[msg.sender].length;
    }
    
    function getTotalInvitedCount() public view returns(uint){ 
         return invitedUsersCountPerUser[msg.sender];
    }
    
    function getTotalInvitedAndAcceptedCount(address refOwner) public view returns(uint){
         return invitedAndAcceptedUsersCountPerUser[refOwner];
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
    
    function changeUnlockPrice(uint newPrice) public isOwner returns (uint){
        return _unlockPrice = newPrice;
    }
    
    function changeMinRefCount(uint newMinRefCount) public isOwner returns (uint){
        return _minRefCount = newMinRefCount;
    }
}