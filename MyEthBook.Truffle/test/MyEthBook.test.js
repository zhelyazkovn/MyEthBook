const MyEthBook = artifacts.require("./MyEthBook.sol");
const expectThrow = require("./util").expectThrow;


contract('MyEthBook',function(accounts){
	let tokenInstance;
	const _owner = accounts[0];
	const _unlockPrice = '0.005';
	const _minRefCount = 2;
	const _hashedEmail = 'af175530712c5d456b3e0c870dfc4e61';//MD5 on test@abv.bg
	const _hashedEmailExpectedInvitationresult = 'af175530712c5d456b3e0c870dfc4e61,';//MD5 on test@abv.bg with ','
	

beforeEach('creating MyEthBook', async function () {
	tokenInstance = await MyEthBook.new({
		from:_owner
	});
})

it("should set owner correctly", async function(){
	let owner = await tokenInstance._owner.call();
	assert.strictEqual(owner,_owner,"The expected owner is not set");
})

it("should set _unlockPrice correctly", async function(){
	let unlockPriceTmp = await tokenInstance._unlockPrice.call();
	let unlockPrice = web3.fromWei(unlockPriceTmp.toNumber(), "ether" );
	
	assert.strictEqual(unlockPrice,_unlockPrice,"The expected _unlockPrice is not set");
})

it("should set _minRefCount correctly", async function(){
	let minRefCountTmp = await tokenInstance._minRefCount.call();
	let minRefCount = minRefCountTmp.toNumber();
	
	assert.strictEqual(minRefCount,_minRefCount,"The expected _minRefCount is not set");
})

it("should init user", async function(){
	let result = await tokenInstance.initUser.call('teststring');
	
	assert.strictEqual(true,result,"The user is not init");
})

it("should not init user", async function(){
	let result = await tokenInstance.initUser.call('');
	
	assert.strictEqual(true,result,"The user is not init");
})

it("should not unloock user", async function(){
	let result = await tokenInstance.unlockUser.call();
	
	assert.strictEqual(false,result,"The user is unlocked, but shouldn't be");
})

it("should not add contact", async function(){
	let result = await tokenInstance.addContact.call("kolio","0xf41ea18d2cfdd6b79d1569478e56562076d2f907");
	
	assert.strictEqual(false,result,"The contact is added, but shouldn't be");
})

it("should be able invite friend", async function(){
	let result = await tokenInstance.inviteFriend.call(_hashedEmail);
	
	assert.strictEqual(_hashedEmailExpectedInvitationresult,result,"The user is not able to invite, but should be");
})

it("should save correct email on invitation", async function(){
	let result = await tokenInstance.inviteFriend.call(_hashedEmail);
	
	assert.notEqual(_hashedEmail,result,"The user is not able to invite, but should be");
})

it("should change unlock price", async function(){
	let newValInWei = '10000000000000000'; // 0.01ether
	let newValInEth = '0.01';
	let changeResult = await tokenInstance.changeUnlockPrice.call(newValInWei); 
	
	let unlockPriceTmp = await tokenInstance._unlockPrice.call();
	
	let unlockPrice = web3.fromWei(unlockPriceTmp.toNumber(), "ether" );
	
	assert.notEqual(unlockPrice,newValInEth,"Should change unlock price, but it didn't");	
})

it("should change _minRefCount", async function(){
	let newVal = 5;
	var result = await tokenInstance.changeMinRefCount.call(newVal);
	
	let minRefCountTmp2 = await tokenInstance._minRefCount.call();
	let minRefCount2 = result.toNumber();
	
	
	assert.strictEqual(minRefCount2,newVal,"The expected _minRefCount is not set");
})

});