function addOptions(box,optionText, optionValue) {
    let newOPT = new Option(optionText, optionValue);
    const combobox = document.getElementById(box);
    combobox.appendChild(newOPT);
}
addOptions("combobox","Ok", 0);
addOptions("combobox","Ok & Cancel", 1);
addOptions("combobox","Abortar & Repetir & Ignorar", 2);
addOptions("combobox","Sim & Não & Cancelar", 3);
addOptions("combobox","Sim & Não", 4);
addOptions("combobox","Repetir & Cancelar", 5);
addOptions("combobox", "Cancelar & Repetir & Continuar", 6)

addOptions("icobox", "Nenhum", 0);
addOptions("icobox", "Critico", 16);
addOptions("icobox", "Questão", 32);
addOptions("icobox", "Exclamação", 48);
addOptions("icobox", "Aviso", 48);
addOptions("icobox", "Asteristico", 64);
addOptions("icobox", "Informação", 64);