using System.Text.Json.Serialization;

namespace MedicationControlSystem.src.utils
{
    public class Utility
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum RemedyType { Default, Reference, Generics, Similar }
    }
}
