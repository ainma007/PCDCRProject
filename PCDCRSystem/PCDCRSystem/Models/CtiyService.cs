using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PCDCRSystem.Models
{
    public class CtiyService :IDisposable
    {
        private PCDCREntities entities;

        public CtiyService(PCDCREntities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<CtiyViewModel> Read()
        {
            return entities.City_Table.Select(city => new CtiyViewModel
            {
                CityID = city.ID,
                CityName = city.CityName,
                ProvinceID = city.ProvinceID,

                Province = new ProvinceViewModel()
                {
                    ProvinceID = city.Province_Table.ID,
                    ProvinceName = city.Province_Table.ProvinceName
                },

               
            });
        }


        public void Create(CtiyViewModel city)
        {
            var entity = new City_Table();

            entity.CityName = city.CityName;
            entity.ProvinceID = city.ProvinceID;
            

            entities.City_Table.Add(entity);
            entities.SaveChanges();

            city.CityID = entity.ID;
        }

        public void Update(CtiyViewModel city)
        {
            var entity = new City_Table();

            entity.ID = city.CityID;
            entity.CityName = city.CityName;
            entity.ProvinceID = city.ProvinceID;
     

            entities.City_Table.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(CtiyViewModel city)
        {
            var entity = new City_Table();

            entity.ID = city.CityID;

            entities.City_Table.Attach(entity);

            entities.City_Table.Remove(entity);

            entities.SaveChanges();
        }

        public IEnumerable<ProvinceViewModel> ReadProvince()
        {
            return entities.Province_Table.Select(province => new ProvinceViewModel
            {
                ProvinceID = province.ID,
                ProvinceName = province.ProvinceName


            });
        }

     
        public void Dispose()
        {
            entities.Dispose();
        }
    }
}