using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace PCDCRSystem.Models
{
    public class ActivitiesCategoryService :IDisposable
    {
        private PCDCREntities entities;

        public ActivitiesCategoryService(PCDCREntities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<ActivitiesCategoryViewModel> Read()
        {
            return entities.ActivitiesCategory_Table.Select(db => new ActivitiesCategoryViewModel
            {
                ActivitiesCategoryID = db.ID,
                ActivitiesCategoryName = db.ActivitiesCategoryName,
              




            });
        }


        public void Create(ActivitiesCategoryViewModel db)
        {
            var entity = new ActivitiesCategory_Table();

            entity.ActivitiesCategoryName = db.ActivitiesCategoryName;



            entities.ActivitiesCategory_Table.Add(entity);
            entities.SaveChanges();

            db.ActivitiesCategoryID = entity.ID;
        }

        public void Update(ActivitiesCategoryViewModel db)
        {
            var entity = new ActivitiesCategory_Table();

            entity.ID = db.ActivitiesCategoryID;
            entity.ActivitiesCategoryName = db.ActivitiesCategoryName;
          


            entities.ActivitiesCategory_Table.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(ActivitiesCategoryViewModel db)
        {
            var entity = new ActivitiesCategory_Table();

            entity.ID = db.ActivitiesCategoryID;

            entities.ActivitiesCategory_Table.Attach(entity);

            entities.ActivitiesCategory_Table.Remove(entity);

            entities.SaveChanges();
        }
        public void Dispose()
        {
            entities.Dispose();
        }

       
    }
}