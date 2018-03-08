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