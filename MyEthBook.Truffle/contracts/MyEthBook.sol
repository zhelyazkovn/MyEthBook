pragma solidity ^0.4.14;

// Import library for string manipulation.
import "./strings.sol";

/** @title MyEthBook. */
contract MyEthBook{
    using strings for *;
    
    /**
    * Struct: contactAddress.
    * Fields: name of type bytes32 ;addr of type address.
    */
    struct contactAddress{
        bytes32 name; // keeps the name of the contact address
        address addr; // keeps the ethereum address of the contact address
    }
    
    address public _owner;
    uint public _unlockPrice;
    uint public _minRefCount;
    
    // keeps all contact addresses for all users
    mapping (address => contactAddress[]) private  _ethBook;
    
    // keeps information which users are unlocked for the features
    mapping(address => bool) private _unlockedUsers;
    
    // keeps the number of the users a user invited 
    mapping(address => uint) private _invitedUsersCountPerUser;
    
    // keeps the number of the users accepted invitation of a user
    mapping(address => uint) private _invitedAndAcceptedUsersCountPerUser;
    
    // keeps the refferal links of all users after init
    mapping(address => bytes32) private _usersReferalLinks;
    
    // keeps the email list of users a user invited
    mapping(address => string) private _invitedUsersEmailsPerUser;
    
    // keeps the email list of users accepted invitation of a user
    mapping(address => string) private _invitedAndAcceptedUsersEmailsPerUser;
    
    // modifier for ownership of the contract
    modifier isOwner(){
        require(msg.sender == _owner);
        _;
    }
    
    /**
    * Contract constructor.
    * Sets the ownership to the creator and the default values for _unlockPrice and _minRefCount.
    */
    function MyEthBook() public{
        _owner = msg.sender;
        _unlockPrice = 0.005 ether;
        _minRefCount = 2;
    }
    
    /** 
    * @dev Init user and assing referal link.
    * @param refLink - the refferal link of the user to assing.
    * @return true if refferal link is assigned and false if not.
    */
    function initUser(bytes32 refLink) public returns(bool){
        if(refLink.length > 0) {
            _usersReferalLinks[msg.sender] = refLink;
            return true;
        }
        return false;
    }
    
    /**
    * @dev Unlocks user after the unlock price is paid.
    * @return true if user paied the _unlockPrice and is unlocked and false if not.
    */
    function unlockUser()  public payable returns (bool){
        uint val = msg.value;
        if(val >= _unlockPrice){
                _unlockedUsers[msg.sender] = true;
        }
        return _unlockedUsers[msg.sender];
    }    
    
    /**
    * @dev Invites friend by email, assing the email to _invitedUsersEmailsPerUser and increase the _invitedAndAcceptedUsersCountPerUser.
    * @param email - the email of the invited user.
    * @return the list with all invited users.
    */
    function inviteFriend(string email) public returns (string) { 
        _invitedUsersEmailsPerUser[msg.sender] = _invitedUsersEmailsPerUser[msg.sender].toSlice()
            .concat((email.toSlice().concat(",".toSlice())).toSlice());
        
        _invitedUsersCountPerUser[msg.sender] +=1;
        
        return _invitedUsersEmailsPerUser[msg.sender];
    }
    
    /**
    * @dev Accepts invitation.
    * @param refOwner - the address of the refferal link.
    * @param refLink - the refferal link.
    * @param email - the email of the new user link.
    * @return true if not crash.
    */
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
    
    /**
    * @dev Add contact address.
    * @param name - new contact name.
    * @param addr - new contact address.
    * @return true if user unlocked and contact added, or false if not.
    */
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
    
    /**
    * @dev Delete contact address.
    * @param index - the index of the contact has to be deleted.
    * @return true if contact deleted, or false if not.
    */
    function deleteContact(uint index) public returns(bool){ 
        if(_ethBook[msg.sender].length > index){
            delete _ethBook[msg.sender][index];
            return true;
        }
        return false;
    }
    
    /**
    * @dev Edit contact address.
    * @param index - the index of the contact has to be edited.
    * @param name - new contact name.
    * @param addr - new contact address.
    * @return true if contact edited, or false if not.
    */
    function editContact(uint index, bytes32 name, address addr) public returns(bool){ 
        if(_ethBook[msg.sender].length > index){
            _ethBook[msg.sender][index].name = name;
            _ethBook[msg.sender][index].addr = addr;
            return true;
        }
         return false;
    }
    
    /**
    * @dev Is user unlocked.
    * @param addr - the addres to check if is unlocked.
    * @return true or false.
    */
    function isUnlocked(address addr) public view returns(bool){
        return _unlockedUsers[addr];
    }
    
    /**
    * @dev Is user unlocked, based on message sender address.
    * @return true or false.
    */
    function unlocked() public view returns(bool){
        return _unlockedUsers[msg.sender];
    }
    
    /**
    * @dev Get refferals.
    * @param addr - the addres to get the refferals for.
    * @return string with emails.
    */
    function getRefferals(address addr) public view returns(string){
        return _invitedAndAcceptedUsersEmailsPerUser[addr];
    }
    
    /**
    * @dev Get total count.
    * @return count of sender's contact addresses.
    */
    function getTotalCount() public view returns(uint count){
         count = _ethBook[msg.sender].length;
    }
    
    /**
    * @dev Get total invited count.
    * @return count of the invited users by message sender.
    */
    function getTotalInvitedCount() public view returns(uint){ 
         return _invitedUsersCountPerUser[msg.sender];
    }
    
    /**
    * @dev Get total invited and accepted count.
    * @param refOwner - the addres to get the count for.
    * @return count of the invited and accepted invitation users.
    */
    function getTotalInvitedAndAcceptedCount(address refOwner) public view returns(uint){
         return _invitedAndAcceptedUsersCountPerUser[refOwner];
    }
    
    /**
    * @dev Get my book count.
    * @param addr - the addres to get the count for.
    * @return count of contact addresses of user.
    */
    function getMyBookCount(address addr) public view returns(uint count){
         count = _ethBook[addr].length;
    }
    
    /**
    * @dev Get contact.
    * @param index - the index of the contact in the array.
    * @param addr - the address of the user to get the contact for.
    * @return name of the contact.
    * @return address of the contact.
    */
    function getContact(uint index, address addr) public view returns(bytes32, address){
        return (_ethBook[addr][index].name , _ethBook[addr][index].addr);
    }
   
    /**
    * @dev Pay price - if the contract owner decide to pay a price for any special customer.
    * @param addr - the address of the user to receive the price.
    * @param amount - the amount of the price to be send.
    */
    function payPraize(address addr, uint amount) isOwner public {
       addr.transfer(amount);
    }
 
    /**
    * @dev Change unlock price.
    * @param newPrice - the new price.
    * @return the new unlock price.
    */   
    function changeUnlockPrice(uint newPrice) public isOwner returns (uint){
        return _unlockPrice = newPrice;
    }
    
    /**
    * @dev Change minimum ref count to unlock.
    * @param newMinRefCount - the new count.
    * @return the new count.
    */  
    function changeMinRefCount(uint newMinRefCount) public isOwner returns (uint){
        return _minRefCount = newMinRefCount;
    }
    
    /**
    * @dev Transfer ownership.
    * @param addr - the address of the new owner.
    * @return true to indicate the transfer is successful.
    */ 
    function transferOwner(address addr) public isOwner returns (bool){
        _owner = addr;
        return true;
    }
}