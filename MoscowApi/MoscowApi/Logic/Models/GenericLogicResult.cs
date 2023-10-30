using System.Net;

namespace MoscowApi.Logic.Models;

public class GenericLogicResult
{
    public virtual bool Status { get; init; }
    public virtual object? Result { get; init; } = String.Empty;
    public virtual Exception? Exception { get; init; }
    public virtual HttpStatusCode HttpCode { get; init; } = HttpStatusCode.OK;
}