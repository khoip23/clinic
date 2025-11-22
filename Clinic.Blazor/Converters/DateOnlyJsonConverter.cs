using Newtonsoft.Json;

namespace Clinic.Blazor.Components.Helpers
{
    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        public override void WriteJson(JsonWriter writer, DateOnly value, JsonSerializer serializer)
            => writer.WriteValue(value.ToString("yyyy-MM-dd"));

        public override DateOnly ReadJson(JsonReader reader, Type objectType, DateOnly existingValue, bool hasExistingValue, JsonSerializer serializer)
            => DateOnly.Parse((string)reader.Value!);
    }
}
