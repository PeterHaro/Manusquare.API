namespace Manusquare.API.Models
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SemanticInput
    {
        [JsonProperty("nda")] public string Nda { get; set; }

        [JsonProperty("projectName")] public string ProjectName { get; set; }

        [JsonProperty("projectDescription")] public string ProjectDescription { get; set; }

        [JsonProperty("selectionType")] public string SelectionType { get; set; }

        [JsonProperty("supplierMaxDistance")]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public long SupplierMaxDistance { get; set; }

        [JsonProperty("servicePolicy")]
        [JsonConverter(typeof(PurpleParseStringConverter))]
        public bool ServicePolicy { get; set; }

        [JsonProperty("projectId")] public string ProjectId { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("processNames")] public List<string> ProcessNames { get; set; }

        [JsonProperty("projectAttributes")] public List<ProjectAttribute> ProjectAttributes { get; set; }

        [JsonProperty("supplierAttributes")] public List<SupplierAttribute> SupplierAttributes { get; set; }
    }

    public partial class ProjectAttribute
    {
        [JsonProperty("attributeId")] public string AttributeId { get; set; }

        [JsonProperty("processName")] public string ProcessName { get; set; }

        [JsonProperty("attributeKey")] public string AttributeKey { get; set; }

        [JsonProperty("attributeValue")] public string AttributeValue { get; set; }
    }

    public partial class SupplierAttribute
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("attributeKey")] public string AttributeKey { get; set; }

        [JsonProperty("attributeValue")] public string AttributeValue { get; set; }
    }

    public partial class SemanticInput
    {
        public static SemanticInput FromJson(string json) => JsonConvert.DeserializeObject<SemanticInput>(json, Manusquare.API.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this SemanticInput self) => JsonConvert.SerializeObject(self, Manusquare.API.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {new IsoDateTimeConverter {DateTimeStyles = DateTimeStyles.AssumeUniversal}},
        };
    }

    internal class PurpleParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(bool) || t == typeof(bool?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var value = serializer.Deserialize<string>(reader);
            if (bool.TryParse(value, out var b))
            {
                return b;
            }

            throw new Exception("Cannot unmarshal type bool");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }

            var value = (bool)untypedValue;
            var boolString = value ? "true" : "false";
            serializer.Serialize(writer, boolString);
        }

        public static readonly PurpleParseStringConverter Singleton = new PurpleParseStringConverter();
    }

    internal class FluffyParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var value = serializer.Deserialize<string>(reader);
            if (long.TryParse(value, out var l))
            {
                return l;
            }

            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }

            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
        }

        public static readonly FluffyParseStringConverter Singleton = new FluffyParseStringConverter();
    }
}