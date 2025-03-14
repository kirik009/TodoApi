using Api;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
namespace TodoApi
{
    
    public class NDSConvertor : JsonConverter<string>
    {



        private static readonly Dictionary<string, double> ставки = new()
        {
            { "БезНДС", 0 }, { "НДС18", 18 }, { "НДС10", 10 }, { "НДС0", 0 },
            { "НДС18_118", 18.118 }, { "НДС10_110", 10.110 }, { "НДС20", 20 },
            { "НДС20_120", 20.120 }, { "НДС909", 909 }, { "НДС1525", 1525 },
            { "НДС1667", 1667 }, { "НДС25", 25 }, { "НДС26", 26 }
        };

        public override void WriteJson(JsonWriter writer, string? value, JsonSerializer serializer)
        {
            if (value is string stringValue && ставки.TryGetValue(stringValue, out double number))
            {
                writer.WriteValue(number);
            }
            else if (value is double || value is int)
            {
                writer.WriteValue(value);
            }
            else
            {
                writer.WriteValue(0);
            }
        }

        public override string ReadJson(JsonReader reader, Type objectType, string? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
                return "БезНДС";

            if (reader.Value is double number)
            {
                var key = ставки.FirstOrDefault(x => x.Value == number).Key;
                return key ?? number.ToString();
            }

            return reader.Value.ToString() ?? "БезНДС";
        }


    }


    public class SumConverter : JsonConverter
    {
        private readonly string key1;
        private readonly string key2;
        private readonly string sumKey;

        public SumConverter(string key1, string key2, string sumKey)
        {
            this.key1 = key1;
            this.key2 = key2;
            this.sumKey = sumKey;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.FromObject(value ?? new object(), serializer);

            if (jsonObject.TryGetValue(key1, out JToken? token1) &&
                jsonObject.TryGetValue(key2, out JToken? token2))
            {
                double val1 = token1.Value<double>();
                double val2 = token2.Value<double>();

                jsonObject[sumKey] = val1 + val2; // Записываем сумму в JSON
            }

            jsonObject.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);

            if (obj.TryGetValue(key1, out JToken? token1) &&
                obj.TryGetValue(key2, out JToken? token2))
            {
                double val1 = token1.Value<double>();
                double val2 = token2.Value<double>();

                obj[sumKey] = val1 + val2; // Восстанавливаем сумму при десериализации
            }

            return obj.ToObject(objectType, serializer)!;
        }

        public override bool CanConvert(Type objectType) => true;
    }
}
