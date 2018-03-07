$(document).ready(function () {
    'use strict';

    if (typeof web3 == 'undefined') {
        alert("Please Install MetaMask if you want to use the DApp.");
    }
    let account = web3.eth.accounts[0];
    let contactForm = $("#form-ivitation");

    let error = false;

    //check accepted count
    let result = contract.getTotalInvitedCount.call(function (err, result, r1, r2, r3) {
        if (err) {
            error = true;
            console.log(err)
        }
        console.log(result);
    });

    if (!error) {
        let txHash = contract.getTotalInvitedCount(function (err, r, r1, r2, r3) {
            if (err) {
                console.log("ERROR");
            }
            console.log(r);
            console.log("invitation accepted");
            if (r) {
                $("#invited-count").html(r.toString(10));
            }
        });
    }

    // invite friend
    error = false;
    $("#send-invitation-btn").on('click', function () {
        let email = $('#Email').val();

        let result = contract.inviteFriend.call(email, function (err, result, r1, r2, r3) {
            if (err) {
                error = true;
                alert(err);
            }
            console.log(result);
        });

        if (!error) {
            let txHash = contract.inviteFriend(email, function (err, r, r1, r2, r3) {
                if (err) {
                    console.log("ERROR");
                }

                console.log(err);
                console.log(r);
                console.log("invitation accepted");
                if (r) {
                    contactForm.submit();
                }
            });
        }
    });
});