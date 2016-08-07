using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace PCDCRSystem.Models
{
    public class ActivityPeopleCategorySerivce
    {
        private PCDCREntities entities;

        public ActivityPeopleCategorySerivce(PCDCREntities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<ActivityPeopleCategoryViewModel> Read()
        {
            return entities.ActivityPeopleCategory_Table.Select(db => new ActivityPeopleCategoryViewModel
            {
                ActivityPeopleCategoryID = db.ID,
                ActivityPeopleCategoryName = db.PeopleCategoryName,





            });
        }


        public void Create(ActivityPeopleCategoryViewModel db)
        {
            var entity = new ActivityPeopleCategory_Table();

            entity.PeopleCategoryName = db.ActivityPeopleCategoryName;



            entities.ActivityPeopleCategory_Table.Add(entity);
            entities.SaveChanges();

            db.ActivityPeopleCategoryID = entity.ID;
        }

        public void Update(ActivityPeopleCategoryViewModel db)
        {
            var entity = new ActivityPeopleCategory_Table();

            entity.ID = db.ActivityPeopleCategoryID;
            entity.PeopleCategoryName = db.ActivityPeopleCategoryName;



            entities.ActivityPeopleCategory_Table.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(ActivityPeopleCategoryViewModel db)
        {
            var entity = new ActivityPeopleCategory_Table();

            entity.ID = db.ActivityPeopleCategoryID;

            entities.ActivityPeopleCategory_Table.Attach(entity);

            entities.ActivityPeopleCategory_Table.Remove(entity);

            entities.SaveChanges();
        }
        public void Dispose()
        {
            entities.Dispose();
        }
    }
}