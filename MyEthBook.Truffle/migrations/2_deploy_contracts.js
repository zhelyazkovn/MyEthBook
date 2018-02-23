var MyEthBook = artifacts.require("./MyEthBook.sol");

module.exports = function(deployer) {
  deployer.deploy(MyEthBook);
};
