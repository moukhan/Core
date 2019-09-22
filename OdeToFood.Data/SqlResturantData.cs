using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class SqlResturantData : IResturantData
    {
        readonly List<Resturant> resturants;

        private readonly OdeToFoodDBContext db;

        public SqlResturantData(OdeToFoodDBContext odeToFoodDBContext)
        {
            db = odeToFoodDBContext;
        }

        public Resturant GetResturantById(int resturantId)
        {
            return db.Resturants.Find(resturantId);
        }

        public IEnumerable<Resturant> GetResturantsByName(string name)
        {
            return from r in db.Resturants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name )
                   orderby r.Name
                   select r;
        }

        public Resturant Update(Resturant resturant)
        {
            var entity = db.Resturants.Attach(resturant);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return resturant;

        }

        public Resturant Add(Resturant newResturant)
        {
            db.Add(newResturant);
            return newResturant;

        }

        public Resturant Delete(int resturantId)
        {
            var res = GetResturantById(resturantId);
            if (res != null)
            {
                db.Remove(res);
            }
            return res;
        }
        public int GetResturantCount()
        {
            return db.Resturants.Count();
        }
        public int Commit()
        {
            return db.SaveChanges();
        }
    }
        
        
}

