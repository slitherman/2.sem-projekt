using _2._sem_projekt_boglistesystemet.Helpers;
using _2._sem_projekt_boglistesystemet.Interfaces;
using _2._sem_projekt_boglistesystemet.Models;

namespace _2._sem_projekt_boglistesystemet.Services
{
    public class BoghandelService : GenericService<Boghandler>, IBoghandler
    {
        public BookstoreDbContext Context { get; set; }
        public BoghandelService b { get; set; }
        public string FileName = "BoghandelJson.json";

       /// <summary>
       /// ???
       /// </summary>
       /// <returns></returns>
        public async Task<IEnumerable<Books>> ReturnReferenceList()

        {
  
            var a = await b.GetItemsAsync();
            GenericDeserialize.JsonDeserialize<Books>(FileName);
            return (IEnumerable<Books>)a;
           
        }
    }
}
