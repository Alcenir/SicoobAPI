namespace Sicoob.Cobranca.Models.v3;

using System;
using Newtonsoft.Json;
using Sicoob.Cobranca.Models.Shared;

public class ConsultaWebhookRequest
{
    [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
    public long? idWebhook { get; set; }
    [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
    public int? codigoTipoMovimento { get; set; }
}

public class ConsultaWebhookResponse
{
    public DadosWebhook[]? resultado { get; set; }
}

public class IncluirWebhooksResponse
{
    public DadosWebhook? resultado { get; set; }
}

public class DadosWebhook
{
    public long idWebhook { get; set; }
    public string url { get; set; }
    public string email { get; set; }
    public int codigoTipoMovimento { get; set; }
    public string descricaoTipoMovimento { get; set; }
    public int codigoPeriodoMovimento { get; set; }
    public string descricaoPeriodoMovimento { get; set; }
    public int codigoSituacao { get; set; }
    public string descricaoSituacao { get; set; }
    public DateTime dataHoraCadastro { get; set; }
    public DateTime dataHoraUltimaAlteracao { get; set; }
    public DateTime dataHoraInativacao { get; set; }
    public string descricaoMotivoInativacao { get; set; }
}