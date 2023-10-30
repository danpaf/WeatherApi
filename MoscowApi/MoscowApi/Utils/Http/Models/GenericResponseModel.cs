using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using MoscowApi.Logic.Models;

namespace MoscowApi.Utils.Http.Models;

public class GenericResponseModel : ObjectResult
{
    public GenericResponseModel(bool status, dynamic? response, int statusCode) : base(
        JsonSerializer.Serialize(
            new
            {
                Status = status,
                Response = response is string ? new { Message = response } : (object?)response
            },
            new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic), }
        ))
    {
        StatusCode = statusCode;
    }

    public static GenericResponseModel FromLogicResult(GenericLogicResult result)
    {
        return new GenericResponseModel(result.Status, result.Result, (int)result.HttpCode);
    }
}
