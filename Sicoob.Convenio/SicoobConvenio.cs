/****************************************************************\
 * Biblioteca C# para APIs de Convenio Cobrança do SICOOB       *
 * Autor: Alcenir Moretto                                       *
 *        https://github.com/Alcenir/SicoobAPI/Sicoob.Cobranca  *
\****************************************************************/
namespace Sicoob.Convenio;

using Simple.API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


/// <summary>
/// Classe para comunicação com as APIs de Convênios do Sicoob
/// </summary>
public sealed class SicoobConvenio : Shared.Sicoob
{
    // Documentações
    // > APIs tipo "Swagger":
    //   https://developers.sicoob.com.br/#!/apis

    private readonly int numeroContrato;
    private ClientInfo clientApi;
    private ConfiguracaoAPI ConfigApi { get; }

    public SicoobConvenio(ConfiguracaoAPI configApi, int nroContrato, System.Security.Cryptography.X509Certificates.X509Certificate2? certificado = null)
       : base(configApi, certificado)
    {
        numeroContrato = nroContrato;
        ConfigApi = configApi;
        clientApi = new ClientInfo(ConfigApi.UrlApi);
    }

    protected override void setupClients(HttpClientHandler handler)
    {
        clientApi = new ClientInfo(ConfigApi.UrlApi, handler);
        clientApi.SetHeader("client_id", ConfigApi.ClientId);

        if (ConfigApi.Token is not null)
            clientApi.SetAuthorizationBearer(ConfigApi.Token.Token);
    }

    protected override void atualizaClients(TokenResponse token)
    {
        ConfigApi.Token = new ConfiguracaoToken()
        {
            ExpiresAtUTC = DateTime.UtcNow.AddSeconds(token.expires_in),
            Token = token.access_token
        };
        //Notificar quando o token foi atualizado
        if (UpdateTokenEvent is not null)
            UpdateTokenEvent(ConfigApi.Token); 
        
        clientApi.SetAuthorizationBearer(token.access_token);
    }

    /* Optantes */
    public async Task<IncluirOptanteResponse?> IncluirBoletos(IncluirOptanteRequest boleto)
    {
        return await ExecutaChamadaAsync(() => clientApi.PostAsync<IncluirOptanteResponse?>(ConfigApi.UrlApi + "cobranca-bancaria/v3/boletos", boleto));
    }
}
