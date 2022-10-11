$(document).ready(
    function () {
        $('#submit').click(function () {

            var Username = $("#uname").val();
            var Password = $("#psw").val();
         
            console.log(Username);
            $.ajax({
                url: 'http://localhost:7222/api/User/authenticate',
                dataType: "json",
                type: "GET",
                contentType: "application/json",
                data: 'username=' + Username + '&password=' + Password,
                processData: false,
                success: function (data, textStatus, jQxhr) {
                    
                    console.log(data)
                    if (data.roles == "Manager") {
                        
                        window.location.replace('EmployeePage')
                    }
                    else {
                       
                        window.location.replace('SoftLockPage')
                    }


                },
                error: function (jqXhr, textStatus, errorThrown) {
                    console.log('error in login')
                }
            });



        })

    }
);