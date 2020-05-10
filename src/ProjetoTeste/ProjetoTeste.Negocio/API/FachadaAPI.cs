using Newtonsoft.Json;
using ProjetoTeste.CrossCutting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ProjetoTeste.Negocio
{
    public class FachadaAPI : IFachadaAPI
    {
        private readonly string _urlWebService;
        private const string _CONTENTTYPE = "application/json";
        public FachadaAPI()
        {
            _urlWebService = Configuracao.UrlWebService;
        }

        private RetornoWS ExecutarRequisicao(RestRequest request)
        {
            var client = new RestClient(_urlWebService);
            IRestResponse response = client.Execute(request);
            string retornoErro = response.Content.Replace("\n", " ");

            if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.NoContent)
            {
                return new RetornoWS(0, retornoErro ?? "Sem mensagem de retorno");
            }

            return new RetornoWS(1, retornoErro);
        }
        private RestRequest MontarRequisicao(ProdutoAPI produto, string resource, Method metodo)
        {
            var request = new RestRequest(resource, metodo);
            request.AddHeader("content-type", _CONTENTTYPE);

            var produtoJSON = JsonConvert.SerializeObject(produto, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            request.AddParameter(_CONTENTTYPE, produtoJSON, ParameterType.RequestBody);
            return request;
        }

        public RetornoWS CadastrarProdutoAPI(Produto novoProduto)
        {
            var produtoAPI = new ProdutoAPI(novoProduto);
            RestRequest request = MontarRequisicao(produtoAPI, "/api/produto", Method.POST);
            return ExecutarRequisicao(request);
        }

        public RetornoWS AtualizarProdutoAPI(Produto produto, string codigoIntegracao)
        {
            var produtoAPI = new ProdutoAPI(produto, codigoIntegracao);
            RestRequest request = MontarRequisicao(produtoAPI, "/api/produto", Method.PUT);
            return ExecutarRequisicao(request);
        }
    }
}
