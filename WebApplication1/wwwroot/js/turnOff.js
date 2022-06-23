function parmaction(checkboxElem, elementID, disabledtype, enabledtype) {
    if (checkboxElem.checked) {
        document.getElementById(elementID).type = enabledtype
    } else {
        document.getElementById(elementID).type = disabledtype;
    }
}
function send() {
    document.getElementById("sendbtn").textContent = "Enviado 👍"
    setTimeout(5000);
    return false;
}