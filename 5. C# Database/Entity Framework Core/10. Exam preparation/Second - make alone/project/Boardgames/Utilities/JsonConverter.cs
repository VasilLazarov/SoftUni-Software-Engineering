using Newtonsoft.Json;

namespace Boardgames.Utilities
{
    public static class JsonConverter
    {

        public static string Serialize<T>(
            T dataTransferObjects,
            bool indent)
        {
            var serializerSettings = new JsonSerializerSettings();
            if (indent)
            {
                serializerSettings.Formatting = Formatting.Indented;
            }

            string result = JsonConvert.SerializeObject(dataTransferObjects, serializerSettings);

            return result;
        }

        public static T Deserialize<T>(
            string jsonString)
            where T : class
        {
            var objectsDtos = JsonConvert
                .DeserializeObject<T>(jsonString);

            return objectsDtos;
        }
    }
}
