using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PCDCRSystem.Models
{
    public class CorporationService :IDisposable
    {
        private PCDCREntities entities;

        public CorporationService(PCDCREntities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<CorporationViewModel> Read()
        {
            return entities.Corporation_Table.Select(Corp => new CorporationViewModel
            {
                CorporationID = Corp.ID,
                CorporationName = Corp.CorporationName,
                CorporationPhone = Corp.CorporationPhone,
                CorporationAdderss = Corp.CorporationAddress




            });
        }


        public void Create(CorporationViewModel Corp)
        {
            var entity = new Corporation_Table();

            entity.CorporationName = Corp.CorporationName;
            entity.CorporationAddress = Corp.CorporationAdderss;
            entity.CorporationPhone = Corp.CorporationPhone;



            entities.Corporation_Table.Add(entity);
            entities.SaveChanges();

            Corp.CorporationID = entity.ID;
        }

        public void Update(CorporationViewModel Corp)
        {
            var entity = new Corporation_Table();

            entity.ID = Corp.CorporationID;
            entity.CorporationName = Corp.CorporationName;
            entity.CorporationPhone = Corp.CorporationPhone;
            entity.CorporationAddress = Corp.CorporationAdderss;


            entities.Corporation_Table.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(CorporationViewModel city)
        {
            var entity = new Corporation_Table();

            entity.ID = city.CorporationID;

            entities.Corporation_Table.Attach(entity);

            entities.Corporation_Table.Remove(entity);

            entities.SaveChanges();
        }
        public void Dispose()
        {
            entities.Dispose();
        }
    }
}