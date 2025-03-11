using Api;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Reflection.PortableExecutable;
namespace TodoApi
{
    
    //public class NDSConvertor : JsonConverter<string>
    //{



    //    private static readonly Dictionary<string, double> ставки = new()
    //    {
    //        { "БезНДС", 0 }, { "НДС18", 18 }, { "НДС10", 10 }, { "НДС0", 0 },
    //        { "НДС18_118", 18.118 }, { "НДС10_110", 10.110 }, { "НДС20", 20 },
    //        { "НДС20_120", 20.120 }, { "НДС909", 909 }, { "НДС1525", 1525 },
    //        { "НДС1667", 1667 }, { "НДС25", 25 }, { "НДС26", 26 }
    //    };

    //    public override void WriteJson(JsonWriter writer, string? value, JsonSerializer serializer)
    //    {
    //        if (value is string stringValue && ставки.TryGetValue(stringValue, out double number))
    //        {
    //            writer.WriteValue(number);
    //        }
    //        else if (value is double || value is int)
    //        {
    //            writer.WriteValue(value);
    //        }
    //        else
    //        {
    //            writer.WriteValue(0);
    //        }
    //    }

    //    public override string ReadJson(JsonReader reader, Type objectType, string? existingValue, bool hasExistingValue, JsonSerializer serializer)
    //    {
    //        if (reader.Value == null)
    //            return "БезНДС";

    //        if (reader.Value is double number)
    //        {
    //            var key = ставки.FirstOrDefault(x => x.Value == number).Key;
    //            return key ?? number.ToString();
    //        }

    //        return reader.Value.ToString() ?? "БезНДС";
    //    }


    //}


    public class BoolConvertor : JsonConverter<bool>
    {

        private static readonly Dictionary<bool, int> ставки = new()
        {
            { false, 0 }, {true, 1 }
        };

        public override void WriteJson(JsonWriter writer, bool value, JsonSerializer serializer)
        {
            if (value is bool boolValue && ставки.TryGetValue(boolValue, out int number))
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

        public override bool ReadJson(JsonReader reader, Type objectType, bool existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
                return false;

            if (reader.Value is int number)
            {
                var key = ставки.FirstOrDefault(x => x.Value == number).Key;
                return key;
            }

            return (bool)reader.Value;
        }

    }


    //public class viewConvertor : JsonConverter<string>
    //{



    //    public override void WriteJson(JsonWriter writer, string value, JsonSerializer serializer)
    //    {
    //        if (value == "ю03_Продукты" || value == "ю03_Блюда")
    //            writer.WriteValue(value);
    //        else
    //            writer.WriteValue("ю03_Продукты");
    //    }

    //    public override string ReadJson(JsonReader reader, Type objectType, string existingValue, bool hasExistingValue, JsonSerializer serializer)
    //    {
    //        return (string)reader.Value;

    //    }

    //}


}
