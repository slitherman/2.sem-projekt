using System.Runtime.Serialization.Json;
using System.Text;

namespace _2._sem_projekt_boglistesystemet.Helpers
{
    public class GenericSerialize
    {
        public static string JsonSerializer<T>(T t)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, t);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            //seeking the pointer back to the begining of the stream
            //the purpose of this is to go back to the begining of the line that has just been typed
            ms.Seek(0, SeekOrigin.Begin);
            // returning the memorystreams byte array
            ms.GetBuffer();
            ms.Close();
            return jsonString;
        }
    }
}
