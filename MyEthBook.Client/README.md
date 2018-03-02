// -------------------   MyEthBook  --------------------- //
// ---- Store your address book on the blockchain!  ---- //

1. Problem - keeps important and frequently used addresses in secure manner, nn blockchain, that could be easilly accessed from the DApp. Example: two and more friends participate in ICO with common budget and the one that succeeds transfer the coins to the others. Use myethbook for frequently used addresses - you don't remember the phone numbers of all your friends, do you? The final goal will be ethereum book that acts as wallet, book, and portfolio - must be combination between blockfolio + my ether wallet + address book

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


-------- Deployment and presentation workflow --------
1. Write, compile and test solidity code in remix ide
2. Go MEW in Ropsten mode -> Contracts -> Deploy Contract
3. Get the needed data from remix (Compile -> Details)
4. Sing and deploy the contract using prepared ropsten address with some test eth in there 
5. Get the contract address and keep it in the web app (both web3js and nethereum)
6. Get the ABI from the remix and add it to the web app (both web3js and nethereum)
-----------------

--------PLEASE IGNORRE!! OLD RANDOM NOTES------------
23 feb FLOW:
1. user register and we assign MM address to his account + avatar + refLink


---



nethereum for reading data - just reading because singning server side is not safe.
web3js for writing data using metamask (most secure)

New Idea 20 Feb 2018
 - use my ether waller downloaded locally - change the UI, use all features, add address storring - CANCELLED FOR NOW - too much things to work on


!!! crypto address book - ethertakt, ethcontact,!!! myethbook !!!
-what problem does it solves - keeps important and frequently used addresses in secure manner in blockchain that could be easilly accessed from the DApp. Example: two and more friends participate in ICO with common budget and the one that succeeds transfer the coins to the others. Use myethbook for frequently used addresses - you don't remember the phone numbers of all your friends, do you?
-store your most important addresses secure in the blockchain!
-pay 10$ in eth lifetime or invite 3 people to unlock your eth book! (website profit)
-pay minimum gas for adding address contact in your book
metamask - asp.net mvc core - fancy UI (ready theme) - Nethereum instead web3js - testrpc(or infura) - IPFS?(snimki na priqteli??) - test? - ropsten
-features: connect to address via MetaMask, show tokens, show erc20 tokens, show saved addresses, receive and send transactions, 2FA, top 10 users with longest contacts list receive bonus 0.1 eth.

-------------
client + wallet (meta mask or eth-lightwallet network!!! see github) -> backend c# (INFURA C# API) -> infura (connect blockchain)


DA SI IZMISLQ PROEKT v koito shte se polzvat smao test net-a ropsten na eterium
ili te da ni dadat takav proekt; Primer za proekt nqkav magazin. https://www.stateofthedapps.com/ ima primeri, drug prinmer e blog
- magazin
- blog
- crypo kitties
- tamagochi
- koteto tom ?
- register za dokumenti 

requirements:
da se chete i pishe po blockchaina
unit tests
"0xca35b7d915458ef540ade6068dfe2f44e8fa733c","putka"
"0xca35b7d915458ef540ade6068dfe2f44e8fa733c","putka2"
"0xca35b7d915458ef540ade6068dfe2f44e8fa733c","putka3"
"0xca35b7d915458ef540ade6068dfe2f44e8fa733c","putka4"


VIJ Nethereum!!! web3 v .net!!!!

very miracle club riot sea quality number clarify deputy item fortune ridge