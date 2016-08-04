using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PCDCRSystem.Models
{
    public class ProjectControlService: IDisposable
    {
        private PCDCREntities entities;

        public ProjectControlService(PCDCREntities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<ProjectControlViewModel> Read()
        {
            return entities.ProjectControl.Select(control => new ProjectControlViewModel
            {
                ID = control.ID,
                ProID = control.ProjectID,
                projects = new ProjectViewModel()
                {
                    ProjectID = control.Projects_table.ID,
                    ProjectName = control.Projects_table.ProjectName
                },

                UserID = control.UserID,
                Users = new UserViewModel()
                {
                    UserID = control.Users_Table.ID,
                    Username = control.Users_Table.FullName
                },

                Status = control.Status,
            });
        }


        public void Create(ProjectControlViewModel control)
        {
            var entity = new ProjectControl();

            entity.ProjectID = control.ProID;
            entity.UserID = control.UserID;
            entity.Status = control.Status;
       
            entities.ProjectControl.Add(entity);
            entities.SaveChanges();

            control.ID = entity.ID;
        }

        public void Update(ProjectControlViewModel control)
        {
            var entity = new ProjectControl();

            entity.ID = control.ID;
            entity.ProjectID = control.ProID;
            entity.UserID = control.UserID;
            entity.Status = control.Status;

            entities.ProjectControl.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(ProjectControlViewModel product)
        {
            var entity = new ProjectControl();

            entity.ID = product.ID;

            entities.ProjectControl.Attach(entity);

            entities.ProjectControl.Remove(entity);

            entities.SaveChanges();
        }

        public IEnumerable<ProjectViewModel> ReadProject()
        {
            return entities.Projects_table.Select(project => new ProjectViewModel
            {
                ProjectID = project.ID,
                ProjectName = project.ProjectName


            });
        }
        public void Dispose()
        {
            entities.Dispose();
        }
    }
}