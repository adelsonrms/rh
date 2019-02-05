/*
 *  Autor   : Adelson RM Silva
 *  Data    : 12/12/2018 - 12:20
 *  ------------------------------------------------------------------------------------------
 *  Metodos genericos para execução de um request ajax via JQueries
 *  Contem o monitoramento de eventos
 */


//Inicializa um Grupo no Console
function logIniciaGrupo(nome) {
    console.group(nome);
}

//Finaliza um Grupo no Console
function logFinalizaGrupo() {
    console.groupEnd();
}

//Registra mensagems no Console
function enviaParaLog(msg, dados, tipoLog) {
    switch (tipoLog) {
        case "info":
            console.info(msg, dados);
            break;
        
        case "erro":
            console.error(msg, dados);
            break;

        case "aviso":
            console.warn(msg, dados);
            break;

        default:
            console.log(msg, dados);
            break;
    }
    
}

//Obtem a data/hora do sistema no padrao Portugue
function GetDateNow() {
    var dNow = new Date();
    var localdate = dNow.getMonth() + 1 + '/' + dNow.getDate() + '/' + dNow.getFullYear() + ' ' + dNow.getHours() + ':' + dNow.getMinutes();
    return localdate;
}

//Grava mensagens no Log
function LogEvento(evento, dados, tipoLog) {

    //if (typeof(tipoLog) == "undefined") {tipoLog = "info";}

    switch (evento) {
        case "Global.ajaxStop":
           // enviaParaLog(GetDateNow() + ' / *****************************************************************************************************************', ['FIM']);
            break;
        case "Request.success":
            enviaParaLog(GetDateNow() + ' / --------------------------------------------------------------');
            break;
        default:
    }

    enviaParaLog(GetDateNow() + ' / Evento $.' + evento + '()', dados, tipoLog);

    if (evento ==="Global.ajaxStart") {
       // enviaParaLog(GetDateNow() + ' / *****************************************************************************************************************', ['INICIO']);
    }
}

//---------------------------------------------------------------------------------
// Regista os eventos $.Ajax no escopo do documento (pagina)
//---------------------------------------------------------------------------------
function RegistrarEventosAjax() {
    var bSend = 0;
    $(document).ajaxStart(function() {
        console.clear();
        logIniciaGrupo("AJAX REQUESTS");
        LogEvento('Global.ajaxStart', ['Iniciado a execução de Ajax Request', 'INICIO']);
    });
    $(document).ajaxSend(function(event, req, options) {

        //if (bSend == 0) { logIniciaGrupo("REQUESTS - PREPARE")}
        LogEvento('Global.' + event.type,
            ['Request enviado para o servidor', options.type + ' ' + options.url, options]);
        if (bSend === 0) {
            bSend = 1;
        }
    });
    $(document).ajaxSuccess(function(event, req, options, data) {
        LogEvento('Global.' + event.type, [event, req, options, data]);
    });
    $(document).ajaxError(function(event, req, options, error) {
        LogEvento('Global.' + event.type, ['Um Request lançou um erro', options.type + ' ' + options.url, error]);
    });
    //O evento 'ajaxComplete' é invocado quando alguma requisição é finalizada
    $(document).ajaxComplete(function(event, req, options) {
        LogEvento('Global.' + event.type, ['Um Request foi finalizado', null, options.type + ' ' + options.url]);
    });
    //O evento 'ajaxStop' é invocado quando todas as requisições forem finalizadas.
    $(document).ajaxStop(function() {
        LogEvento('Global.ajaxStop', ['Todos os request foram finalizados', 'FIM']);
        logFinalizaGrupo();

    });
    LogEvento('Document.ready', ['Eventos Global Ajax - Registrados !']);
}

//Função generica para invocar qualquer solicitação Ajax, tratar o retorno nos callbacks:
function jqajax(metodo, url, parametros, callbacks) {

    var callback = callbacks.OnSuccess;
    var callbackBeforeSend = callbacks.OnBeforeSend;
    var callbackError = callbacks.OnError;

    var UrlParams;

    if (parametros.UrlParams!==null) {
        UrlParams = JSON.stringify(parametros.UrlParams);
    }

    //{ arquivo:GetArquivo(files[i]), ListaDeArquivo: formData }
    //Efetua uma chamada ajax
    var jqxhr = $.ajax(
            url,
            {
                method: metodo, // Padrão é GET
                Accept: "*/*", //CORS
                crossDomain: true, // CORS habilitado
                dataType: "json", //jsonp a requisição ja vai com o CORS habilitado
                contentType: 'application/json; charset=utf-8',

                processData: true,

                data: UrlParams, //Parametros que serão passados para a função (URL)
                global: true, //Permite que seja habilitado ou nao a execução de eventos globais ajaxStart, ajaxStop
                beforeSend:
                    function(jqXHR, settings) {
                        if (typeof callbackBeforeSend !== "undefined") {
                            LogEvento('Request.beforeSend', [jqXHR, settings]);
                            callbackBeforeSend(jqXHR, settings);
                        }
                    },
                complete:
                    function(jqXHR, settings) {
                        LogEvento('Request.complete', [jqXHR, settings]);
                    },
                success:
                    function(data, textStatus, jqXHR) {
                        //logIniciaGrupo("REQUEST - EXECUTE")
                        LogEvento('Request.success', [data, textStatus, jqXHR, parametros]);

                        //Se o callback foi informado, invoca-o passando os parametros.
                        if (typeof callback !== "undefined") {
                            callback({ data: data, contextRequest: this, params: parametros });
                        }
                    },

                error: function(jqXHR, res, status) {
                    callbackError(jqXHR, res, status);
                },

                timeout: 0, //Timeout do request. O padrão 0 indica infinito
                //Definições especificas para retornos de HTTP Status Code
                statusCode: {
                    404: function() {
                        LogEvento("Ajax.StatusCode 404 - Pagina nao encontrada", ['N/D']);
                    },
                    200: function() {
                        LogEvento("Ajax.StatusCode 200 - OK", ['N/D']);
                    }
                }
            }
        ).done(function(data, textStatus, jqXHR) {
            LogEvento('Request.done', ['Um Request foi concluído']);
        })
        .fail(function(jqXHR, textStatus, errorThrown) {
            MensagemErro(GetError(jqXHR).Message, 'SpanMensagemErro', true);
            LogEvento("Request.fail", ['Erro interceptado no Request', errorThrown, textStatus, jqXHR]);
        })
        .always(function(jqXHR, textStatus, errorThrown) {
            LogEvento("Request.always", ['Request finalizado']);
        });
}

//Registra os eventos na inicialização do documento
$(document).ready(RegistrarEventosAjax());
