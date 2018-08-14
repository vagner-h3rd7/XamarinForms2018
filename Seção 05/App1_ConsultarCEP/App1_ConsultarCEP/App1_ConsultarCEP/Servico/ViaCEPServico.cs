using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App1_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace App1_ConsultarCEP.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string Contedo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Contedo);

            if (end.cep == null) return null;

            return end;
        }
    }
}
