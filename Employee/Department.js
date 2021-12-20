$(document).ready(function () {
    getDepartmentList();
});
var saveDepartment = function () {
    var DptName = $("#txtDptName").val();
    var EmpName = $("#txtEmpName").val();
    var EmpsSalary = $("#txtEmpSalary").val();
    var EmpContact = $("#txtEmpContact").val();
    var EmpCity = $("#txtCity").val();
    var model = {
        DptName : DptName,
        EmpName : EmpName,
        EmpsSalary : EmpsSalary,
        EmpContact : EmpContact,
        EmpCity : EmpCity,

    }
    $.ajax({
        url: "/Department/saveDepartment",
        method: "Post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (responce) {
            alert("succesfully");
        }
    })
};
var getDepartmentList = function () {
    $.ajax({
        url: "/Department/GetDepartmentList/",
        method: "Post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tblDepartment tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.id + "</td><td>" + elementValue.DptName + "</td><td>" + elementValue.EmpName + "</td><td>" + elementValue.EmpContact + "</td><td>" + elementValue.EmpsSalary + "</td><td>" + elementValue.EmpCity + "</td></tr>";
            });
            $("#tblDepartment tbody" ).append(html);
        }
    });
}