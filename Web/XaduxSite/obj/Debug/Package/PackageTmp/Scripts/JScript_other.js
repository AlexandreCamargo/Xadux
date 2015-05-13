var navegador = navigator.appName.toLowerCase();
var mozilla = navegador.indexOf("netscape") + 1;

function numerico(event) {
	var tecla = mozilla ? event.which : event.keyCode;
	if ((tecla >= 48 && tecla <= 57)
		|| (tecla >= 0 && tecla <= 31)
		|| tecla == 127)
		return true;
	return false;
}

function ValidaMoeda(event) {
	var tecla = mozilla ? event.which : event.keyCode;
	if ((tecla >= 48 && tecla <= 57)
		|| (tecla >= 0 && tecla <= 31)
		|| tecla == 127
		|| tecla == 44)
		return true;
	return false;
}


function formataData(campo) {
	//Criaremos esta variável para evitar a digitação de nomes longos
	//var data = campo;

	if (campo.value.length == 2 || campo.value.length == 5) {
		campo.value += "/";
	}
}


function formataTelefone(campo) {
	switch (campo.value.length) {
		case 2:
			campo.value += " ";
			break;
		case 7:
			campo.value += "-";
			break;
	}
}

function formataCEP(campo) {
	switch (campo.value.length) {
		case 5:
			campo.value += "-";
			break;
	}
}

function formataCPF(campo) {
	switch (campo.value.length) {
		case 3:
		case 7:
			campo.value += ".";
			break;
		case 11:
			campo.value += "-";
			break;
	}
}