using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using apiRESTCheckBdTADS.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace apiRESTCheckBdTADS.Controllers
{
    public class CheckBdController : ApiController
    {
        // Definicion del endpoint

        // Definicion del metodo
        [HttpGet]
        [Route("check/checkbs/mysqlconnectioncheckbd")]
        public clsApiStatus mySqlConnectionCheck(){

            clsApiStatus objRespuesta = new clsApiStatus();
            JObject jsonResp = new JObject();

            //Creacion del objeto, sobre el modelo clsCheckBD
            clsCheckBd objCheckBD = new clsCheckBd();
            // Ejecucion del metodo dechequeo de BD
            objCheckBD.checkBd();
            // Analizar lso atributos y configurar el objeto de salida
            if (objCheckBD.ban == 1)
            {
                objRespuesta.statusExec = true;
                // Configuracion del objeto Json 
                jsonResp.Add("msgData", "Conexion exitosa");
            }
            else
            {
                objRespuesta.statusExec = false;
                // Configuracion del objeto Json 
                jsonResp.Add("msgData", "Conexion fallida");

            }

            objRespuesta.ban = objCheckBD.ban;
            objRespuesta.msg = objCheckBD.statusMsg;
            objRespuesta.datos = jsonResp;
            // Envio de respuesta al cliente
            return objRespuesta;



        }

    }
}
