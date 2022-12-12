using System.Runtime.Serialization.Json;
using System.Text;

namespace _2._sem_projekt_boglistesystemet.Helpers
{
    public class GenericDeserialize
    {
        public static T JsonDeserialize<T>(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(ms);
            ms.Close();
            return obj;
        }
    }
}
