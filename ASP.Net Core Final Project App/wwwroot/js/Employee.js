$.get("http://localhost:7222/api/Employee", function (data, status) {

    let code = "";
    for (let x in data) {
        function updateEmp() {
            $.get('http://localhost:7222/api/UpdateEmployee(' + data[x].employeeID + ')', function () { })
        }
        code += "<tr>"
        code += "<td>" + data[x].employeeID + "</td>"
        code += "<td>" + data[x].name + "</td>"
        code += "<td>" + data[x].manager + "</td>"
        code += "<td>" + data[x].experience + "</td>"
        code += "<td>"
        for (let y in data[x].skills)
            code += data[x].skills[y] + "  "
        code += "</td>"
        code += "<td><button" + onclick=updateEmp() + "> Request Lock</button> </td> </tr>"
    }
    $('#tbody').html(code)
})  

