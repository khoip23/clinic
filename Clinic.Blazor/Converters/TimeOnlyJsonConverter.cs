using Newtonsoft.Json;

namespace Clinic.Blazor.Converters
{
    public class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
    {
        public override void WriteJson(JsonWriter writer, TimeOnly value, JsonSerializer serializer)
            => writer.WriteValue(value.ToString("HH:mm"));

        public override TimeOnly ReadJson(JsonReader reader, Type objectType, TimeOnly existingValue, bool hasExistingValue, JsonSerializer serializer)
            => TimeOnly.Parse((string)reader.Value!);
    }
}
