// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//I forgot where I got these two validation methods, but I think it was geeksforgeeks.org
// Should probably be RegEx based


function onlyFloat(evt) { //returns true for 0-9 and .
              
        // Only ASCII character in that range allowed
    var ASCIICode = (evt.which) ? evt.which : evt.keyCode;

    if (ASCIICode > 31 && (ASCIICode < 48 || ASCIICode > 57) && ASCIICode != 46)
        return false;
    return true;
}


function onlyTimeSpanString(evt) {  //returns true for 0-9 and :

    // Only ASCII character in that range allowed
    var ASCIICode = (evt.which) ? evt.which : evt.keyCode;

    if (ASCIICode > 31 && (ASCIICode < 48 || ASCIICode > 57) && ASCIICode != 58)
        return false;
    return true;
}

function editEmployee(element) {
    var row = element.parentNode.parentNode.rowIndex;
    var empTable = document.getElementById("empTable");
    var empId = empTable.rows[row].cells[0].innerHTML;
    var empName = empTable.rows[row].cells[1].innerHTML;
    var empTitle = empTable.rows[row].cells[2].innerHTML;
    var empStart = empTable.rows[row].cells[3].innerHTML;
    var empRate = empTable.rows[row].cells[4].innerHTML;
    var empHours = empTable.rows[row].cells[5].innerHTML;
    var deptID = empTable.rows[row].cells[6].innerHTML;
    var deptName = empTable.rows[row].cells[7].innerHTML;

    alert(`Selected row contains the following information:\nEmployee ID: ${empId}\nEmployee Name: ${empName}\nTitle: ${empTitle}\nStart Date: ${empStart}\nRate: ${empRate}\nHours: ${empHours}\nDept ID: ${deptID}\nDept Name: ${deptName}\nThis alert should be replaced to make an edit form appear.`);

}