

function validate() {

    //Vzimme si vsichki poleta ot formata
    let username = $('#username');
    let email = $('#email');
    let password = $('#password');
    let confirmPassword = $('#confirm-password');
    let checkbox = $('#company');
    let companyNumber = $('#companyNumber');
    let submitBtn = $('#submit');
    let allIsValid = true;

    //Kato kliknem Submit validirame formata
    submitBtn.on('click', function (e) {
      
        e.preventDefault();
        //validirame formata
        validateForm();

    });

    //pokaji Company Information ili go skrii
    checkbox.change(function() {
        this.checked
            ? $('#companyInfo').css('display', 'block')
            : $('#companyInfo').css('display', 'none');
    });

    function validateForm() {

        allIsValid = true;

        //pravim si regexite
        let usernamePattern = /^[a-zA-Z0-9]{3,20}$/gm;
        let emailPattern = /^.*@.*\..*$/g;
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
            let companyNumber = $("#companyNumber").val();
            if (!companyNumber.match(/^[1-9][0-9]{3}$/)){
                $("#companyNumber").css('border-color', 'red');
                allIsValid = false;
            }
            else{
                $("#companyNumber").css('border', 'none');
            }
        }
        else
            allIsValid = false;

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






