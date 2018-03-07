const MyEthBook = artifacts.require("./MyEthBook.sol");
const expectThrow = require("./util").expectThrow;


contract('MyEthBook',function(accounts){
	let myEthBook;
	const _owner = accounts[0];
	const user1 = accounts[1];
    const user2 = accounts[2];
    const user3 = accounts[3];
    const user4 = accounts[4];
	const _unlockPrice = '0.005';
	const _minRefCount = 2;
	const _hashedEmail = 'af175530712c5d456b3e0c870dfc4e61';//MD5 on test@abv.bg
	const _hashedEmailExpectedInvitationresult = 'af175530712c5d456b3e0c870dfc4e61,';//MD5 on test@abv.bg with ','
	

beforeEach('creating MyEthBook', async function () {
	myEthBook = await MyEthBook.new({
		from:_owner
	});
})

it("should set owner correctly", async function(){
	let owner = await myEthBook._owner.call();
	assert.strictEqual(owner,_owner,"The expected owner is not set");
})

it("should set _unlockPrice correctly", async function(){
	let unlockPriceTmp = await myEthBook._unlockPrice.call();
	let unlockPrice = web3.fromWei(unlockPriceTmp.toNumber(), "ether" );
	
	assert.strictEqual(unlockPrice,_unlockPrice,"The expected _unlockPrice is not set");
})

it("should set _minRefCount correctly", async function(){
	let minRefCountTmp = await myEthBook._minRefCount.call();
	let minRefCount = minRefCountTmp.toNumber();
	
	assert.strictEqual(minRefCount,_minRefCount,"The expected _minRefCount is not set");
})

it("should init user", async function(){
	let result = await myEthBook.initUser.call('teststring');
	
	assert.strictEqual(true,result,"The user is not init");
})

it("should not init user", async function(){
	let result = await myEthBook.initUser.call('');
	
	assert.strictEqual(true,result,"The user is not init");
})

it("should not unlock user", async function(){
	let result = await myEthBook.unlockUser.call();
	
	assert.strictEqual(false,result,"The user is unlocked, but shouldn't be");
})

it("should not add contact", async function(){
	let result = await myEthBook.addContact.call("kolio","0xf41ea18d2cfdd6b79d1569478e56562076d2f907");
	
	assert.strictEqual(false,result,"The contact is added, but shouldn't be");
})

it("should be able invite friend", async function(){
	let result = await myEthBook.inviteFriend.call(_hashedEmail);
	
	assert.strictEqual(_hashedEmailExpectedInvitationresult,result,"The user is not able to invite, but should be");
})

it("should save correct email on invitation", async function(){
	let result = await myEthBook.inviteFriend.call(_hashedEmail);
	
	assert.notEqual(_hashedEmail,result,"The user is not able to invite, but should be");
})

it("should change unlock price", async function(){
	let newValInWei = '10000000000000000'; // 0.01ether
	let newValInEth = '0.01';
	let changeResult = await myEthBook.changeUnlockPrice.call(newValInWei); 
	
	let unlockPriceTmp = await myEthBook._unlockPrice.call();
	
	let unlockPrice = web3.fromWei(unlockPriceTmp.toNumber(), "ether" );
	
	assert.notEqual(unlockPrice,newValInEth,"Should change unlock price, but it didn't");	
})

it("should change _minRefCount", async function(){
	let newVal = 5;
	var result = await myEthBook.changeMinRefCount.call(newVal);
	
	let minRefCountTmp2 = await myEthBook._minRefCount.call();
	let minRefCount2 = result.toNumber();
	
	
	assert.strictEqual(minRefCount2,newVal,"The expected _minRefCount is not set");
})

it("should unlock user", async function(){
	 let options = {
				from: user1, 
				value: '5000000000000000', 
				gas: 100000
            };
	await myEthBook.unlockUser(options);
	
	var result = await myEthBook.isUnlocked(user1);
	
	assert.strictEqual(result,true,"User should be unlocked");
})

it("should add address and return count", async function(){
	let options = {
		from: user1, 
		value: '5000000000000000', 
		gas: 100000
	};
	await myEthBook.unlockUser(options);


	let options2 = {
		from: user1
	};
	await myEthBook.addContact('pena','0xca35b7d915458ef540ade6068dfe2f44e8fa733c',options2);

	var result = await myEthBook.getMyBookCount(user1);

	assert.strictEqual(JSON.parse(result),1,"should add address and return count");
})

it("should not be equal - count must be 2", async function(){
	 let options = {
				from: user1, 
				value: '5000000000000000', 
				gas: 100000
            };
	await myEthBook.unlockUser(options);
	
	
	 let options2 = {
				from: user1
            };
	await myEthBook.addContact('Pena','0xca35b7d915458ef540ade6068dfe2f44e8fa733c',options2);
	await myEthBook.addContact('Pena1','0xca35b7d915458ef540ade6068dfe2f44e8fa7331',options2);
	
	var result = await myEthBook.getMyBookCount(user1);
	
	assert.notEqual(JSON.parse(result),1,"should not be equal - count must be 2");
})
});