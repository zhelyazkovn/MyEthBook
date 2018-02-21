// Attach AJAX "loading" event listener
$(document).on({
    ajaxStart: function () {
			$("#loadingBox").show()
		},
		ajaxStop: function () {
			$("#loadingBox").hide()
		}
	});

$(document).ready(function () {
    //todo: add this as parameter from Nethereum!!!!! - contract address and contract ABI!! OR if not possible use nethereum for reading and metamask for adding ;)
    //return contract.GetFunction("numberOfProposals").CallAsync<long>();
    //https://github.com/Nethereum/Nethereum/blob/master/src/Nethereum.Web.Sample/Services/DaoService.cs
    const documentRegistryContractAddress = '0xdd6e8a55ef29b4a4dd9a0cf3259afbd0ef4c5755';
	const documentRegistryContractABI = [{"constant": true,"inputs": [{"name": "hash","type": "string"}],"name": "verify","outputs": [{"name": "dateAdded","type": "uint256"}],"payable": false,"stateMutability": "view","type": "function"},{"constant": false,"inputs": [{"name": "hash","type": "string"}],"name": "add","outputs": [{"name": "dateAdded","type": "uint256"}],"payable": false,"stateMutability": "nonpayable","type": "function"},{"inputs": [],"payable": false,"stateMutability": "nonpayable","type": "constructor"}];
	
	$('#linkHome').click(function () {
    showView("viewHome")
});
$('#linkSubmitDocument').click(function () {
    showView("viewSubmitDocument")
});
$('#linkVerifyDocument').click(function () {
    showView("viewVerifyDocument")
});
$('#documentUploadButton').click(uploadDocument);
$('#documentVerifyButton').click(verifyDocument);


	function showView(viewName) {
		// Hide all views and show the selected view only
		$('main > section').hide();
		$('#' + viewName).show();
	}

	function showInfo(message) {
		$('#infoBox>p').html(message);
		$('#infoBox').show();
		$('#infoBox>header').click(function () {
			$('#infoBox').hide();
		});
	}

	function showError(errorMsg) {
		$('#errorBox>p').html("Error: " + errorMsg);
		$('#errorBox').show();
		$('#errorBox>header').click(function () {
			$('#errorBox').hide();
		})
	};

	function uploadDocument(){
		if($('#documentForUpload')[0].files.length == 0){
			return showError("Please select a file to upload.");
		}
		let fileReader = new FileReader();
		//fileReader.onload = function(){
		//	let documentHash = sha256(fileReader.result);
		//}
		//fileReader.readAsBinaryString($('#documentForUpload')[0].files[0]);
		
		fileReader.onload = function(){
			let documentHash = sha256(fileReader.result);
			if(typeof web3=='undefined'){
				return showError("Please install MM.");
			}
			
			let contract = web3.eth.contract(documentRegistryContractABI).at(documentRegistryContractAddress);
			contract.add(documentHash, function(err,result,r1,r2,r3){
				if(err){
					return showError("Smart contract call failed: " + err);
				}
				showInfo('Document ' + documentHash + ' <b>successfully added</b> to the registry.');
			});
		}
		fileReader.readAsBinaryString($('#documentForUpload')[0].files[0]);
	}
	
	function verifyDocument(){
		if($('#documentToVerify')[0].files.length == 0){
			return showError("Please select a file to verify.");
			}
			
			let fileReader = new FileReader();
			fileReader.onload = function(){
				let documentHash = sha256(fileReader.result);
				if(typeof web3 == 'undefined'){
					return showError("Please install MM");
				}
				let contract = web3.eth.contract(documentRegistryContractABI).at(documentRegistryContractAddress);
				contract.verify(documentHash,function(err,result){
					if(err){
						return showError("SmartContract call failed: " + err);
					}
					let contractPublishDate = result.c;
					if(contractPublishDate > 0){
						let displayDate = new Date(contractPublishDate*1000).toLocaleString();
						showInfo('Document ' + documentHash + ' is <b>valid</b>, date published: ' + displayDate);
					}
					else {
						showError('Document ' + documentHash +' is <b>invalid</b>, not found in the registry.}');
					}
				});
			}
			fileReader.readAsBinaryString($('#documentToVerify')[0].files[0]);
			
		
	}
});