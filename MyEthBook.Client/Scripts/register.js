$(document).ready(function () {
    'use strict';

    if (typeof web3 == 'undefined') {
        alert("Please Install MetaMask if you want to use the DApp.");
    }
    console.log(web3.eth.accounts[0]);
    $("#mmaddress").val(web3.eth.accounts[0]);

    $("#form-submit").on('click', function () {
        let refLink = getUrlParameter("reflink");
        let contactForm = $("#contact");

        const documentRegistryContractAddress = '0x9c3431612364Eb8f6Fe7AD91D205F014BF0349aA';
        const documentRegistryContractABI =
            [{ "constant": true, "inputs": [], "name": "unlocked", "outputs": [{ "name": "", "type": "bool" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": true, "inputs": [], "name": "_owner", "outputs": [{ "name": "", "type": "address" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": true, "inputs": [], "name": "_unlockPrice", "outputs": [{ "name": "", "type": "uint256" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": true, "inputs": [{ "name": "index", "type": "uint256" }, { "name": "addr", "type": "address" }], "name": "getContact", "outputs": [{ "name": "", "type": "bytes32" }, { "name": "", "type": "address" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": true, "inputs": [{ "name": "addr", "type": "address" }], "name": "isUnlocked", "outputs": [{ "name": "", "type": "bool" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": true, "inputs": [{ "name": "addr", "type": "address" }], "name": "getMyBookCount", "outputs": [{ "name": "count", "type": "uint256" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": true, "inputs": [], "name": "getTotalCount", "outputs": [{ "name": "count", "type": "uint256" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": true, "inputs": [], "name": "getTotalInvitedCount", "outputs": [{ "name": "", "type": "uint256" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": true, "inputs": [{ "name": "refOwner", "type": "address" }], "name": "getTotalInvitedAndAcceptedCount", "outputs": [{ "name": "", "type": "uint256" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": true, "inputs": [], "name": "_minRefCount", "outputs": [{ "name": "", "type": "uint256" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": true, "inputs": [{ "name": "addr", "type": "address" }], "name": "getRefferals", "outputs": [{ "name": "", "type": "string" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": false, "inputs": [{ "name": "newPrice", "type": "uint256" }], "name": "changeUnlockPrice", "outputs": [{ "name": "", "type": "uint256" }], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": false, "inputs": [{ "name": "newMinRefCount", "type": "uint256" }], "name": "changeMinRefCount", "outputs": [{ "name": "", "type": "uint256" }], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": false, "inputs": [{ "name": "refLink", "type": "bytes32" }], "name": "initUser", "outputs": [{ "name": "", "type": "bool" }], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": false, "inputs": [{ "name": "email", "type": "string" }], "name": "inviteFriend", "outputs": [{ "name": "", "type": "string" }], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": false, "inputs": [], "name": "unlockUser", "outputs": [{ "name": "", "type": "bool" }], "payable": true, "stateMutability": "payable", "type": "function" }, { "constant": false, "inputs": [{ "name": "addr", "type": "address" }], "name": "transferOwner", "outputs": [{ "name": "", "type": "bool" }], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": false, "inputs": [{ "name": "refOwner", "type": "address" }, { "name": "refLink", "type": "bytes32" }, { "name": "email", "type": "string" }], "name": "acceptInvitation", "outputs": [{ "name": "", "type": "bool" }], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": false, "inputs": [{ "name": "name", "type": "bytes32" }, { "name": "addr", "type": "address" }], "name": "addContact", "outputs": [{ "name": "", "type": "bool" }], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": false, "inputs": [{ "name": "addr", "type": "address" }, { "name": "amount", "type": "uint256" }], "name": "payPraize", "outputs": [], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "inputs": [], "payable": false, "stateMutability": "nonpayable", "type": "constructor" }, { "constant": false, "inputs": [{ "name": "index", "type": "uint256" }], "name": "deleteContact", "outputs": [{ "name": "", "type": "bool" }], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": false, "inputs": [{ "name": "index", "type": "uint256" }, { "name": "name", "type": "bytes32" }, { "name": "addr", "type": "address" }], "name": "editContact", "outputs": [{ "name": "", "type": "bool" }], "payable": false, "stateMutability": "nonpayable", "type": "function" }];
        let contract = web3.eth.contract(documentRegistryContractABI).at(documentRegistryContractAddress);

        let refOwnerAddress = '';
        // debugger;
        let error = false;
        //ajax call to get ref owner address
        $.ajax({
            url: "/manage/GetOwnerAddress",
            method: "POST",
            data: {
                refLink: refLink, // Second add quotes on the value.
            },
            cache: false,
            success: function (res) {
                //debugger;
                console.log(res);
                refOwnerAddress = res.addr;

                ////accept invitation
                let email = $('#Email').val();
                let result = contract.acceptInvitation.call(refOwnerAddress, refLink, email, function (err, result, r1, r2, r3) {
                    if (err) {
                        error = true;
                        alert(err);
                    }
                    // debugger;
                    console.log(result);
                });
                // debugger;

                if (!error) {
                    let txHash = contract.acceptInvitation(refOwnerAddress, refLink, email, function (err, result, r1, r2, r3) {

                        // debugger;
                        if (err) {
                            console.log("ERROR");
                        }
                        console.log(err);
                        console.log(result);
                        console.log(r1);
                        console.log(r2);
                        console.log(r3);
                        console.log("invitation accepted");
                        if (result) {
                            contactForm.submit();
                        }
                    });
                }
            },
            error: function (err) {
                alert(err);
            }
        });
    })
});

var getUrlParameter = function getUrlParameter(sParam) {
    var sPageURL = decodeURIComponent(window.location.search.substring(1)),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : sParameterName[1];
        }
    }
};