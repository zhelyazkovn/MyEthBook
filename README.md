 <h1>MyEthBook</h1>
 
<p>Store your address book on the blockchain!</p>

<p>It keeps important and frequently used addresses in secure manner, on blockchain, that could be easilly accessed from the DApp. Example: two and more friends participate in ICO with common budget and the one that succeeds has to transfer the coins to the others. Use MyEthBook for frequently used addresses - you don't remember the phone numbers of all your friends, do you? The final goal will be Ethereum book that acts as wallet, book, and portfolio -> will be combination between Blockfolio + My Ether Wallet + Address Book = MyEthManager (online banking for Ethereum tokens)</p>

<h2>Project Architecture</h2>
<p>
<img style="max-width:70% !important;" width="500" src="https://raw.githubusercontent.com/zhelyazkovn/MyEthBook/master/MyEthBook.Client/img/diagram.png" />

</p>

<h2>How It Works?</h2>
<p>
<ol>
<li>Register and unlock your EthBook</li>
<li>Use it for free - Init your user to obtain referral link and invite at least 2 friends to register in MyEthBook</li>
<li>Or pay 0.005eth once for lifetime usage</li>
<li>Use MetaMask on your browser with account with minimal amount of eth for the transactions gas price. Pay minimal gas only on adding new contact - miners fee.</li>
<li>Add, Edit and Remove name-address pairs to your EthBook</li>
<li>Upload avatar - image stored in IPFS</li>
</ol>
</p>

<h3>Prerequisites</h2>
<p>
You have Internet connection and MetaMask installed.
</p>


<h2>Technical Details</h2>
<p>
<ul>
<li>ASP.NET MVC 5.2.3; .NET Framework 4.7.1</li>
<li>Nethereum - Web3 for .NET</li>
<li>Remix IDE for smart contract developing; Visual Studio 2017 for Client developing</li>
<li>MetaMask</li>
<li>IPFS</li>
<li>Unit testing with Truffle</li>
</ul>
</p>

<h2>Starting the project</h2>
<p>
<ul>
<li>Clone the project locally and open it with Visual Studio (2017 preferred)</li>
<li>Restore NuGet Packages</li>
<li>*Optional: if errors with missing project files appear just include the files in the project - they are all in the repo. (MyEthBook.Services/Utils folder and MyEthBook.Services/IPFSService.cs file stays as not included in the project for unknown reason.)</li>
<li>Set MyEthBook.Client project as startup project</li>
<li>In Visual Studio open Package Manager Console, select MyEthBook.Client project from the dropdown above and execute "Update-Database"</li>
<li>Start the project from VS with your favourite browser</li>
</ul>
</p>

<h2>Running the tests</h2>
<p>
<ul>
<li>On separate window start testrpc</li>
<li>Open new command window and navigate to /MyEthBook.Truffle/test/</li>
<li>Type truffle test and hit ENTER</li>
</ul>
</p>

<h2>Screenshots</h2>
<p>
<ul>
<li><a target="_blank" href="https://raw.githubusercontent.com/zhelyazkovn/MyEthBook/master/MyEthBook.Client/img/demo_img/home.png">[home.png]</a></li>
<li><a target="_blank"  href="https://raw.githubusercontent.com/zhelyazkovn/MyEthBook/master/MyEthBook.Client/img/demo_img/account.png">[account.png]</a></li>
<li><a target="_blank"  href="https://raw.githubusercontent.com/zhelyazkovn/MyEthBook/master/MyEthBook.Client/img/demo_img/book.png">[book.png]</a></li>
<li><a target="_blank"  href="https://raw.githubusercontent.com/zhelyazkovn/MyEthBook/master/MyEthBook.Client/img/demo_img/reg.png">[reg.png]</a></li>
<li><a target="_blank"  href="https://raw.githubusercontent.com/zhelyazkovn/MyEthBook/master/MyEthBook.Client/img/demo_img/edit.png">[edit.png]</a></li>
</ul>
</p>

<h2>Contract Address</h2>
<p>
<ol>
<li>https://ropsten.etherscan.io/address/0x9c3431612364eb8f6fe7ad91d205f014bf0349aa</li>
</ol>
</p>

<h2>Authors</h2>
<p>
<ul>
<li>Nikolay Zhelyazkov - zhelyazkovn@gmail.com</li>
</ul>
</p>

<h2>Acknowledgments</h2>
<p>
<ul>
<li>Special thanks to SofUni team!</li>
</ul>
</p>

<h2>License</h2>
<p>
<ul>
<li>MIT</li>
</ul>
</p>