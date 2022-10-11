$.get("http://localhost:7222/api/SoftLock", function (data, status) {

    let code = "";
    for (let x in data) {
        code += "<tr>"
        code += "<td>" + data[x].employeeId + "</td>"
        code += "<td>" + data[x].requestee + "</td>"
        code += "<td>" + data[x].requestMessage + "</td>"
        code += "<td>" + data[x].managerStatus + "</td>"
        code += "<td>" + data[x].requestDate + "</td>"
        code += "<td> <button id=request> ViewDetails </button> </td> </tr>"
    }
    $('#tbody').html(code)
})