
function IsEmpty(id)
{
    var txt = document.getElementById(id);
    if (txt.value == "") { txt.focus(); alert('Empty input not allowed.'); return false;}
    return true;
}

function IsValidemail(id)
{
    var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    var txt = document.getElementById(id);
    if (txt.value.match(mailformat))
    {  
        return true;  
    }  
    else  
    {  
        alert("You have entered an invalid email address!");  
        txt.focus();  
        return false;  
    }  
}

var specialKeys = new Array();
specialKeys.push(8); //Backspace

function IsNumeric(e) {
    var keyCode = e.which ? e.which : e.keyCode
    var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
    //alert('Invalid input.');
    return ret;
}

//IsNumeric function is used as '##       onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"   ##' on inline coding.

function ConvertNumerToPrice(id)
{
        var p = parseFloat(document.getElementById(id).value);
        p = p.toFixed(2);
        document.getElementById(id).value = p;
}


function IsPrice(id) {
    var textVal = document.getElementById(id).value;
    //textVal = textVal.toFixed(2);
    //var regex = /^(\$|)([1-9]\d{0,2}(\,\d{3})*|([1-9]\d*))(\.\d{2})?$/;
    var regex = /^(\$|)([0-9]\d{0,2}(\,\d{3})*|([0-9]\d*))(\.\d*)?$/;
    var passed = textVal.match(regex);
    if (textVal == 0 || textVal == "") { textVal = 0; return true; }
    if (passed == null) {
        alert("Enter price only. For example: 523.36");
        document.getElementById(id).focus();
        
        return false;
    }
    else { return true;}
}

function IsDecimal(event, id) {
    if (event.charCode >= 48 && event.charCode <= 57 || event.charCode <= 46) {
        var str = document.getElementById(id).value;
        var n = str.indexOf(".");
        if (n != -1) {
            if (event.charCode == 46) { return false; }
            else { return true; }
        }

        return true;
    }
    return false;
}

function IsInteger(event) {
    return event.charCode >= 48 && event.charCode <= 57;
}