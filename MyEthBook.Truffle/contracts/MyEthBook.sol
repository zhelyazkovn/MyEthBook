pragma solidity ^0.4.14;

import "./strings.sol";

contract MyEthBook{
    using strings for *;
    
    struct contactAddress{
        bytes32 name;
        address addr;
    }
    address public _owner;
    uint public _unlockPrice;
    uint public _minRefCount;
    
    mapping (address => contactAddress[]) private  _ethBook;
    mapping(address => bool) private _unlockedUsers;
    mapping(address => uint) private _invitedUsersCountPerUser;
    mapping(address => uint) private _invitedAndAcceptedUsersCountPerUser;
    
    mapping(address => bytes32) private _usersReferalLinks;
    mapping(address => string) private _invitedUsersEmailsPerUser;
    mapping(address => string) private _invitedAndAcceptedUsersEmailsPerUser;
    
    modifier isOwner(){
        require(msg.sender == _owner);
        _;
    }
    
    function MyEthBook() public{
        _owner = msg.sender;
        _unlockPrice = 0.005 ether;
        _minRefCount = 2;
    }
    
    function initUser(bytes32 refLink) public returns(bool){
        if(refLink.length > 0) {
            _usersReferalLinks[msg.sender] = refLink;
            return true;
        }
        return false;
    }
    
    function unlockUser()  public payable returns (bool){
        uint val = msg.value;
        if(val >= _unlockPrice){
                _unlockedUsers[msg.sender] = true;
        }
        return _unlockedUsers[msg.sender];
    }    
    
    function inviteFriend(string email) public returns (string) { 
        _invitedUsersEmailsPerUser[msg.sender] = _invitedUsersEmailsPerUser[msg.sender].toSlice()
            .concat((email.toSlice().concat(",".toSlice())).toSlice());
        
        _invitedUsersCountPerUser[msg.sender] +=1;
        
        return _invitedUsersEmailsPerUser[msg.sender];
    }
    
    function acceptInvitation(address refOwner, bytes32 refLink, string email) public returns (bool){
        require(_usersReferalLinks[refOwner] == refLink);
        
        _invitedAndAcceptedUsersEmailsPerUser[refOwner] = _invitedAndAcceptedUsersEmailsPerUser[refOwner].toSlice()
            .concat((",".toSlice().concat(email.toSlice())).toSlice());
            
        _invitedAndAcceptedUsersCountPerUser[refOwner] += 1;
        
        if( _invitedAndAcceptedUsersCountPerUser[refOwner] >= _minRefCount){
            _unlockedUsers[refOwner] = true;
        }
        
        return true;
    }
    
    function addContact(bytes32 name,address addr) public returns (bool){
        if(_unlockedUsers[msg.sender]){
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
    
    function isUnlocked(address addr) public view returns(bool){
        return _unlockedUsers[addr];
    }
    
    function unlocked() public view returns(bool){
        return _unlockedUsers[msg.sender];
    }
    
    function getRefferals(address addr) public view returns(string){
        return _invitedAndAcceptedUsersEmailsPerUser[addr];
    }
    
    function getTotalCount() public view returns(uint count){
         count = _ethBook[msg.sender].length;
    }
    
    function getTotalInvitedCount() public view returns(uint){ 
         return _invitedUsersCountPerUser[msg.sender];
    }
    
    function getTotalInvitedAndAcceptedCount(address refOwner) public view returns(uint){
         return _invitedAndAcceptedUsersCountPerUser[refOwner];
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
    
    function transferOwner(address addr) public isOwner returns (bool){
        _owner = addr;
        return true;
    }
}