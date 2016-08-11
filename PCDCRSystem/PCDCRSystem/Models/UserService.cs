using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PCDCRSystem.Models
{
    public class UserService
    {
        private PCDCREntities entities;

        public UserService(PCDCREntities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<UserViewModel> Read()
        {
            return entities.Users_Table.Select(user => new UserViewModel
            {
                UserID = user.ID,
                FullName = user.FullName,
                Username = user.UserName,
                Password = user.Password,
                UserType = user.UserType,
                UserPhone = user.UserPhone,
                UserAddress = user.UserAddress,
              //  userstatus = user.Status,
                
              
            });
        }
        public void Create(UserViewModel user)
        {
            var entity = new Users_Table();

            entity.FullName = user.FullName;
            entity.UserName = user.Username;
            entity.Password = user.Password;
            entity.UserType = user.UserType;
            entity.UserPhone = user.UserPhone;
            entity.UserAddress = user.UserAddress;
            entity.Status = user.userstatus;
           entities.Users_Table.Add(entity);
            entities.SaveChanges();

            user.UserID = entity.ID;
        }

        public void Update(UserViewModel user)
        {
            var entity = new Users_Table();

            entity.ID = user.UserID;
            entity.FullName = user.FullName;
            entity.UserName = user.Username;
            entity.Password = user.Password;
            entity.UserType = user.UserType;
            entity.UserPhone = user.UserPhone;
            entity.UserAddress = user.UserAddress;
            entity.Status = user.userstatus;



            entities.Users_Table.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(UserViewModel user)
        {
            var entity = new Users_Table();

            entity.ID = user.UserID;

            entities.Users_Table.Attach(entity);

            entities.Users_Table.Remove(entity);

            entities.SaveChanges();
        }
     
        public void Dispose()
        {
            entities.Dispose();
        }

    }
}