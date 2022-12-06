function login() {
    let data = new Object();
    data.Email = $("#inputName").val();
    data.Password = $("#inputPassword").val();

    console.log(data)

    $.ajax({
        type: 'post',
        url: '/Auth/Login',
        data: data
    }).done((result) => {
        console.log("ok", result);
        if (result == '/Dashboard/Employee' || result == '/Dashboard/Manager' || result == '/Dashboard/Admin') {
            /*alert("Successed to Login");
            sessionStorage.setItem("token", result.token);
            console.log(result.token);*/
            localStorage.setItem('LoginRes', JSON.stringify(result));
            window.location.href = result;
            $("#inputName").val(null);
        }
        else {
            alert("Failed to Login");
            $("#inputName").val(null);
            $("#inputPassword").val(null);
        }
    }).fail((result) => {
        console.log(result);
        alert("Failed to Login");
    })
   /* $.ajax({
        url: `/Auth/Login`,
        method: "POST",
        data: JSON.stringify(data),
        dataType: "json",
        headers: {
            'Content-Type': 'application/json'
        },
    }).done((result) => {
        console.log("ok", result);
        sessionStorage.setItem("token", result.token);
   
        console.log(result.token);
        if (result == '/Dashboard/Employee' || result == '/Dashboard/Manager' || result == '/Dashboard/Admin') {
            //alert("Successed to Login");
            localStorage.setItem('LoginRes', JSON.stringify(result));
            window.location.href = result;
            $("#inputName").val(null);
        }
        else {
            alert("Failed to Login");
            $("#inputName").val(null);
            $("#inputPassword").val(null);
        }
    }).fail((result) => {
        console.log(result);
        alert("Failed to Login");
    })*/
    
   
}