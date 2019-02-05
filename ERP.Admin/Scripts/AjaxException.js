/*
||-----------------------------------------------------------------------------------
|| DATA CRIAÇÃO:                    2015-03-26
|| CRIADO POR:                      Vitor Luiz Rubio
|| DESCRIÇÃO  :                     Funções de comportamento e validação da Gui
||----------------------------------------------------------------------------------
|| DEPENDENCIAS:
||  Essa biblioteca depende de jQuery 1.11.x e bootstrap 3.0
||
||----------------------------------------------------------------------------------
|| MANUTENÇÃO DO CÓDIGO (DATA - AUTOR - DESCRIÇÃO)
||
||----------------------------------------------------------------------------------
*/

///Formata uma mensagem e coloca no controle de de id igual a place. 
//Se place for null procura por lbMNsg para ser o place
//a classe formata a mensagem como sendo de erro, alerta, sucesso ou informação
function Mensagem(msg, place, classe, forceAlert) {
    if ((place === null) || (place === "")) {
        place = "#lblMsg";
    }

    //ARMS, 18/12/2018 - Tenta determinar o tipo de seletor na ordem > tag : id (com #) : class (com .)
    var $lbl
    $lbl = $(place);
    if ($lbl.length == 0) { $lbl = $('#' + place); }
    if ($lbl.length == 0) { $lbl = $('.' + place); }

    if (($lbl != null) && ($lbl.get(0) != null)) {

        //classe anterior: "col-sm-12 alert  alert-danger"

        //primeiro remove a classe depois a adiciona, para garantir que não está adicionando duas vezes a mesma classe
        //$(place).removeClass(classe).addClass(classe);     

        $lbl.attr("class", classe);
        $lbl.show();
        $lbl.html(msg);
    }
    else {
        if (forceAlert) {
            alert(msg);
        }
    }
}


///mensagem formatada como erro
function MensagemErro(msg, place, forceAlert) {
    Mensagem(msg, place, "col-sm-12 alert alert-danger", forceAlert);
}

///mensagem formatada como aviso
function MensagemAlerta(msg, place, forceAlert) {
    Mensagem(msg, place, "col-sm-12 alert alert-warning", forceAlert);
}

///mensagem formatada como sucesso
function MensagemSucesso(msg, place, forceAlert) {
    Mensagem(msg, place, "col-sm-12 alert alert-success", forceAlert);
}

///mensagem formatada como informacao
function MensagemInfo(msg, place, forceAlert) {
    Mensagem(msg, place, "col-sm-12 alert alert-info", forceAlert);
}

///Extrai uma mensagem de erro de um erro http 500 
//causado por uma exception e formata de forma que possa ser apresentado via JSON
function GetError(jqXHR) {
    var padrao =
    {
        Message: "Ocorreu um erro interno durante sua requisição.",
        StackTrace: ""
    };

    if ((jqXHR === null) || (jqXHR === undefined) || (jqXHR == null) || (jqXHR == undefined))
        return padrao;

    if ((jqXHR.responseText === null) || (jqXHR.responseText === undefined) || (jqXHR.responseText == null) || (jqXHR.responseText == undefined))
        return padrao;

    try {
        padrao = JSON.parse(jqXHR.responseText);
    }
    catch (err) {
        padrao.Message = jqXHR.responseText;
    }

    return padrao;

}