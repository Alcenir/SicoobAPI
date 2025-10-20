using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Sicoob.Cobranca.Models.Shared;

namespace Sicoob.Cobranca.Models.v3;

public class AlterarWebhookRequest
{
    public string url { get; set; }
    public string email { get; set; }
}

public class IncluirWebhookRequest : AlterarBoletoRequest
{
    [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
    public int codigoTipoMovimento { get; set; }
    [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
    public int codigoPeriodoMovimento { get; set; }
}