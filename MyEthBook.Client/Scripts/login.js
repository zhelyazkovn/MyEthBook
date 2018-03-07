$(document).ready(function () {
    'use strict';

    if (typeof web3 == 'undefined') {
        alert("Please Install MetaMask if you want to use the DApp.");
    }
    console.log(web3.eth.accounts[0]);
    $("#mmaddress").val(web3.eth.accounts[0]);


    console.log(typeof web3);
});