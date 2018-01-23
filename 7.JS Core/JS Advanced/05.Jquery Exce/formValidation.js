

function validate() {


    let username = $('#username');
    let email = $('#email');
    let password = $('#password');
    let confirmPassword = $('#confirm-password');
    let checkbox = $('#company');
    let companyNumber = $('#companyNumber');
    let submitBtn = $('#submit');
    let allIsValid = true;

    submitBtn.on('click', function (e) {
        e.preventDefault();

        //validirame formata
        validateForm();

    });

    checkbox.change(function() {
        if(this.checked)
        {
            $('#companyInfo').css('display', 'block');
        }
        else
            $('#companyInfo').css('display', 'none');

    });

    function validateForm() {

        allIsValid = true;

        let usernamePattern = /^[a-zA-Z0-9]{3,12}$/gm;
        let emailPattern = /^.*?[\@].*?[\.].*?$/gm;
        let passwordPattern = /^\w{5,15}$/gm;
        let confirmPasswordPattern = /^\w{5,15}$/gm;

        validateInputWithParrern(username, usernamePattern);
        validateInputWithParrern(email, emailPattern);


        if(confirmPassword.val() === password.val()) {
            validateInputWithParrern(password, passwordPattern);
            validateInputWithParrern(confirmPassword, confirmPasswordPattern);
        }else{
            confirmPassword.css("border", "solid red");
            password.css("border", "solid red");
            allIsValid = false;
        }

        if(checkbox.is(":checked"))
        {
            if(Number(companyNumber.val()) < 1000 || Number(companyNumber.val()) > 9999) {
                companyNumber.css("border", "solid red");
                allIsValid = false;
            } else {
                companyNumber.css("border", "none");
            }
        }
        else
            allIsValid = false;

        console.log(allIsValid);
        if(allIsValid === true) {
            $('#valid').css('display', 'block');
        }else{
            $('#valid').css('display', 'none');
        }


        function validateInputWithParrern(input, pattern) {

            if(pattern.test(input.val())) {
                input.css("border", "none");
            }else {
                input.css("border", "solid red");
                allIsValid = false;
            }
        }

    }

}






