// Funções Ajax
function callback_OnSuccess(retorno) {
    logIniciaGrupo('CALLBACK - SUCESS : ' + retorno.contextRequest.type + ' ' + retorno.contextRequest.url);
    //Trata retorno da Requisição aqui

    if (retorno.params.tipo ==='user') {
        $('.nomeUsuario').html(retorno.data.GivenName);
    }
    else {
        if (retorno.params.tipo === 'photo') {
            document.getElementById('imgUsuario').setAttribute("src", retorno.data.imageBase64);
        }
    }

    
    logFinalizaGrupo();
}

function callback_OnBeforeSend(id) {
    //Mostra um icone de progresso
    //mostrarLoadingPorLinha(id, 'progress.gif');
}
//Erro Generico
function callback_OnError(jqXHR, res, status) {
    if (typeof (jqXHR.responseJSON) != 'undefined') {
        enviaParaLog('Ocorreu um erro ao processar a solicitação \n Detalhe : ' + jqXHR.responseJSON.mensagem, jqXHR.responseJSON, "erro")
    }
    else {
        enviaParaLog('Ocorreu um erro ao processar a solicitação \n Detalhe : ' + jqXHR.responseText, jqXHR, "erro")
    }
}


function message(mensagem, estilo, valor) {
    var $span_msg = $(".mensagem");
    $span_msg.html(mensagem);
    if (typeof (estilo) != 'undefined' && typeof (valor) != 'undefined') {
        $span_msg.css(estilo, valor);
    }
}
function mostrarLoadingGenerico(icone) {
    message("<div class='container'><div class='row'><div class='col-sm-1'><img width=30 src='/CodeWeb/img/" + icone + ".svg' /></div><div class='col-sm-11'><p>Aguarde....</p></div></div></div>")
}

//Rotina de Execução
//metodo : POST, GET, etc...
//url : url que será invocada...
//parametros : objeto contendo : {id,FormData}
function ExecuteAjax(metodo, url, parametros) {
    //Callbacks de Retorno do eventos
    var callbacks = {
        OnSuccess: callback_OnSuccess,
        OnBeforeSend: callback_OnBeforeSend,
        OnError: callback_OnError
    };
    //Executa
    jqajax(metodo, url, parametros, callbacks);
};

    //AppId = "ac6aad15-111e-4f79-a816-64c85dba0736";
    //AppSecret = "pzmLMTIM8_%hjiyXH6615^_";
    //Scopes = "https://graph.microsoft.com/.default";
    //Grant_Type = "client_credentials";
    //TenanId = "352d9a60-80fa-4908-aeed-390dd3d65bbc";


function ConsultarPerfil() {
    ExecuteAjax('POST', '/Auth/GetUserInfo', {tipo:'user'});
}

function ConsultarFoto() {
    ExecuteAjax('POST', '/Auth/GetPhoto', { tipo: 'photo' });
}