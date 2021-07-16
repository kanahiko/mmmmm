using System;
using System.Linq;
using System.Text.Json;
using CodingChallenge.Models;
using System.Text.Json.Serialization;

/// <summary>
/// Converts JSON {"code":"value"} into CodeValue object
/// </summary>
public class JSONMyConverter : JsonConverter<CodeValue>
{
    public override CodeValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        CodeValue codeValue = new CodeValue(); 
        using (var jsonDoc = JsonDocument.ParseValue(ref reader))
        {
            try
            {
                var list = jsonDoc.RootElement.EnumerateObject().ToList();
                if (list.Count != 1)
                {
                    throw new Exception("Входящий JSON не соответсвует формату \"[{\"code\":\"value\"},..]\"");
                }
                else
                {
                    int code = 0;
                    if (Int32.TryParse(list[0].Name, out code))
                    {
                        codeValue.Code = code;
                        codeValue.Value = list[0].Value.ToString();
                        return codeValue;
                    }
                    throw new Exception("Код \"list[0].Name\" не является числом");
                }
            }
            catch
            {
                throw new Exception("Входящий JSON не соответсвует формату \"[{\"code\":\"value\"},..]\"");
            }
        }
        throw new Exception("Входящий JSON не соответсвует формату \"[{\"code\":\"value\"},..]\"");
    }

    public override void Write(Utf8JsonWriter writer, CodeValue value, JsonSerializerOptions options)
    {
        writer.WriteStringValue($"\"{value.Code}\":\"{value.Value}\"");
    }
}
