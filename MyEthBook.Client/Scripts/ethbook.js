$(document).ready(function () {
    "use strict";

    // Web3 and MetaMask check
    if (typeof web3 == 'undefined') {
        alert("Please Install MetaMask if you want to use the DApp.");
    }

    $("#mmaddress").val(web3.eth.accounts[0]);

    var addr = web3.eth.accounts[0];
    $("#mmaddress").val(addr);

    console.log(addr);


    contract.isUnlocked(addr, function (err, result, r1, r2, r3) {
        console.log(err);
        console.log(result);
    });

    //delete address
    $(".delete-address-contact").on("click", function () {
        let index = $(this).attr('data-index');
        let error = false;
        let result = contract.deleteContact.call(index, function (err, result, r1, r2, r3) {
            if (err) {
                error = true;
                alert(err);
            }
            console.log(result);
        });

        if (!error) {
            let txHash = contract.deleteContact(index, function (err, result, r1, r2, r3) {
                if (err) {
                    console.log("ERROR");
                }
                console.log(err);
                console.log(result);
                console.log("deleted");
                if (result) {
                    $('#result-check').attr('href', 'https://ropsten.etherscan.io/tx/' + result);
                    $('#result-check').text('Check Transaction');
                    $('#result-check').css('color', 'white');
                }
            });
        }
    })

    //edit address
    $(".edit-address-contact").on("click", function () {
        let index = $(this).attr('data-index');

        let popUpForm = $("#edit-address-popup-form");
        let editName = popUpForm.find("#edit-name-text");
        let editAddress = popUpForm.find("#edit-address-text");
        $('#edit-index-text').val(index);

        let addrName = $(this).parent().parent().find('.ca-name').text();
        editName.val(addrName);

        let addrAddr = $(this).parent().parent().find('.ca-addr').text();
        editAddress.val(addrAddr);
    })

    $("#save-edit-addr").on("click", function () {
        let popUpForm = $(this).parent();
        let newName = popUpForm.find("#edit-name-text").val();
        let NewAddress = popUpForm.find("#edit-address-text").val();
        let index = popUpForm.find("#edit-index-text").val();;

        let error = false;
        let result = contract.editContact.call(index, newName, NewAddress, function (err, result, r1, r2, r3) {
            if (err) {
                error = true;
                alert(err);
            }
            console.log(result);
        });

        if (!error) {
            let txHash = contract.editContact(index, newName, NewAddress, function (err, result, r1, r2, r3) {
                if (err) {
                    console.log("ERROR");
                }
                console.log(err);
                console.log(result);
                console.log("edited");
                if (result) {
                    $('#trans-result-check').attr('href', 'https://ropsten.etherscan.io/tx/' + result);
                    $('#trans-result-check').text('Check Transaction');
                    $('#trans-result-check').css('color', 'white');
                }
            });
        }
    });

    //unlock user
    $("#unlock-account").on("click", function () {
        let error = false;
        let result = contract.unlockUser.call(function (err, result, r1, r2, r3) {
            if (err) {
                error = true;
                alert('err');
            }
        });

        if (!error) {
            contract.unlockUser({
                gas: 300000,
                from: web3.eth.coinbase,
                value: web3.toWei(0.005, 'ether')
            }, function (err, result, r1, r2, r3) {
                console.log(err);
                console.log(result);
                console.log(r1);
                console.log(r2);
                console.log(r3);
                console.log("ADDED");

                if (result) {
                    $('#result-check-unlock').attr('href', 'https://ropsten.etherscan.io/tx/' + result);
                    $('#result-check-unlock').text('Check Transaction');
                    $('#result-check-unlock').css('color', 'white');
                }
            });
        }
    });

    //add address contact
    $("#add-addr").on("click", function () {
        if (!$("#name").val() || !$("#address").val()) {
            alert('Please check your inputs.');
        }
        else {
            let name = $("#name").val();
            let address = $("#address").val();

            //good practice: first do "call" and then sendTransaction in order to "test the waters", because transactions are expensive
            let result = contract.addContact.call(name, address, function (err, result, r1, r2, r3) {
                if (err) {
                    alert('err');
                }
            });

            let txHash = contract.addContact(name, address, function (err, result, r1, r2, r3) {
                if (err) {
                    console.log("ERROR");
                }
                console.log(err);
                console.log(result);
                console.log("added");
                if (result) {
                    $('#result-check').attr('href', 'https://ropsten.etherscan.io/tx/' + result);
                    $('#result-check').text('Check Transaction');
                    $('#result-check').css('color', 'white');
                }
            });
        }
    });

    //declare the popup
    $('.open-popup-link').magnificPopup({
        type: 'inline',
        midClick: true // Allow opening popup on middle mouse click. Always set it to true if you don't provide alternative source in href.
    });

    //init
    $("#init-user").on("click", function () {
        let refLink = $("#refLink").val();
        //good practice: first do "call" and then sendTransaction in order to "test the waters", because transactions are expensive
        let result = contract.initUser.call(refLink, function (err, result, r1, r2, r3) {
            if (err) {
                alert('err');
            }
        });

        let txHash = contract.initUser(refLink, function (err, result, r1, r2, r3) {
            if (err) {
                console.log("ERROR");
            }
            console.log(err);
            console.log(result);
            if (result) {
                $('#result-check-unlock').attr('href', 'https://ropsten.etherscan.io/tx/' + result);
                $('#result-check-unlock').text('Check Transaction');
                $('#result-check-unlock').css('color', 'white');

                //ajax call to update init
                $.ajax({
                    url: "/manage/inituser",
                    cache: false,
                    success: function (res) {
                        console.log("init done");
                    }
                });
            }
        });
    });
});