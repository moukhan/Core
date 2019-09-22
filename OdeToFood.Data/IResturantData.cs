using OdeToFood.Core;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public interface IResturantData
    {
        IEnumerable<Resturant> GetResturantsByName(string name);
        Resturant GetResturantById(int resturantId);
        Resturant Delete(int resturantId);
        Resturant Update(Resturant updatedResturant);

        Resturant Add(Resturant newResturant);
        int GetResturantCount();
        int Commit();


    }
        
        
}

