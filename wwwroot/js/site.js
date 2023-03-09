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