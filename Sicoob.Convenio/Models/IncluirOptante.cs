using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sicoob.Convenio.Models;

public class IncluirOptanteRequest
{
    public Optante optante { get; set; }
    public long transacao { get; set; }
}

public class IncluirOptanteResponse
{
    public string mensagem { get; set; }
    public int codigo { get; set; }
    public string autenticacao { get; set; }
}

public class Optante
{
    public string convenio { get; set; }

    public string identificadorClienteEmpresa { get; set; }

    public string identificadorClienteBanco { get; set; }

    public int dataOpcao { get; set; }

    public int codigoMovimento { get; set; }   

}