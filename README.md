// -------------------   MyEthBook  --------------------- //
// ---- Store your address book on the blockchain!  ---- //

1. Problem - keeps important and frequently used addresses in secure manner, in blockchain, that could be easilly accessed from the DApp. Example: two and more friends participate in ICO with common budget and the one that succeeds transfer the coins to the others. Use myethbook for frequently used addresses - you don't remember the phone numbers of all your friends, do you? The final goal will be ethereum book that acts as wallet, book, and portfolio - must be combination between blockfolio + my ether wallet + address book = MyEthManager


2. Register and unlock your ethbook

2.1. Use it for free - invite 3 friends to use myethbook

2.2. Or Pay 5$ in ethereum lifetime

2.3. Use MetaMask on your browser with account with minimal amount of eth for the transactions gas price. Pay minimal gas only on adding new contact - miners fee.

2.4. Version 1: Add/Edit/Remove addresses, assing images to a contact (optional).

2.5. Version 2: Generate wallet, send and receive tokens, list tokens.

2.6. Version 3: List


3. Technical Details

3.1. ASP.NET MVC

3.2. Nethereum - web3 for .net // src: https://github.com/Nethereum/Nethereum/blob/master/src/Nethereum.Web.Sample/Controllers/HomeController.cs

3.3. Remix IDE for smart contract creation

3.4. TestRPC locall node

3.5. MetaMask

3.6. User sign in - store referal link, list of contacts (optional), bookEnabled = true/false (payed or invited friends);

3.15 Store images on IPFS - optional

4. Additional Random Notes
while developing use remix and deploy contracts there + ganache = work locally because it is faster
when doing demo user ropsten+infura
write the cotract in remix
open myethwallet in rposten network
create wallet and use faucet to send some ethers
deploy the cotract, use the byte code from remix
open MM and join ropsten
import account with the private key from myethwallet above
network? how to connect to ropsten and my contract?
get the contract address when deployed in ropsten



