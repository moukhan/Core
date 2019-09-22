using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryResturantData : IResturantData
    {
        readonly List<Resturant> resturants;
        public InMemoryResturantData()
        {
            resturants = new List<Resturant>()
            {
                new Resturant{Id = 1,Name = "Scott's Pizza", Location = "JLT", Cuisine = CuisineType.Italian},
                new Resturant{Id = 2,Name = "Dum Pukht", Location = "JLT", Cuisine = CuisineType.Indian},
                new Resturant{Id = 3,Name = "Maxicano", Location = "JLT", Cuisine = CuisineType.Mexican}
            };
        }

        public Resturant GetResturantById(int resturantId)
        {
            return resturants.SingleOrDefault(r => r.Id == resturantId);
        }

        public IEnumerable<Resturant> GetResturantsByName(string name)
        {
            return from r in resturants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Resturant Update(Resturant resturant)
        {
            Resturant res = resturants.SingleOrDefault(r => r.Id == resturant.Id);
            if (res != null)
            {
                res.Name = resturant.Name;
                res.Location = resturant.Location;
                res.Cuisine = resturant.Cuisine;
            }

            return res;

        }

        public Resturant Add(Resturant newResturant)
        {
            newResturant.Id = resturants.Max(r => r.Id) + 1;
            resturants.Add(newResturant);
            return newResturant;

        }

        public int Commit()
        {
            return 0;
        }

        public Resturant Delete(int resturantId)
        {
            Resturant res = resturants.FirstOrDefault(r => r.Id == resturantId);
            if (res != null)
            {
                resturants.Remove(res);
            }
            return res;
        }

        public int GetResturantCount()
        {
            return resturants.Count();
        }

    }
        
        
}

