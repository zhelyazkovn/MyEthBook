const util ={
	expectThrow: async promise => {
	try{
		let result = await promise;
		console.log(result);
	}catch(error){
		const incalidJump = error.message.search('invalid JUMP') >= 0
		const incalidOpcode = error.message.search('invalid opcode') >= 0
		const outOfGas = error.message.search('out of gas') >= 0
		const revert = error.message.search('revert') >= 0
		assert(incalidJump || incalidOpcode || outOfGas || revert, "expected throw, got'" + error + "'instead")
		return		
	}
	assert.fail('Expected throw not received')
	}
	
}

module.exports = util;

