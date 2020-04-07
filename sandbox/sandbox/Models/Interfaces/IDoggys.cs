using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sandbox.Models.Interfaces
{
    // TODO DI: create a folder and interface
    public interface IDoggys
    {
        // C
        ///TODO DI: change it
        Task CreateAnimal(Dogs dog);

        //R
        Task<Dogs> GetDog(int id);

        Task<List<Dogs>> GetDogs();
        // U
        Task<Dogs> UpdateDog(int id, Dogs dog);
        // D
        Task<Dogs> DeleteDog(int id);
    }
}
