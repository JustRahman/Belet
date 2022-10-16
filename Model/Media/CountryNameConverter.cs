using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belet.Model.Media
{
    internal class CountryNameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CountryName) || t == typeof(CountryName?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Japan":
                    return CountryName.Japan;
                case "Russia":
                    return CountryName.Russia;
                case "Turkey":
                    return CountryName.Turkey;
                case "USA":
                    return CountryName.Usa;
            }
            throw new Exception("Cannot unmarshal type CountryName");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CountryName)untypedValue;
            switch (value)
            {
                case CountryName.Japan:
                    serializer.Serialize(writer, "Japan");
                    return;
                case CountryName.Russia:
                    serializer.Serialize(writer, "Russia");
                    return;
                case CountryName.Turkey:
                    serializer.Serialize(writer, "Turkey");
                    return;
                case CountryName.Usa:
                    serializer.Serialize(writer, "USA");
                    return;
            }
            throw new Exception("Cannot marshal type CountryName");
        }

        public static readonly CountryNameConverter Singleton = new CountryNameConverter();
    }
}
