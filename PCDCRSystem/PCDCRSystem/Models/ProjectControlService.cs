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

        public IEnumerable<ProjectControlViewModel> Readproject()
        {
            return entities.ProjectControl_table.Select(control => new ProjectControlViewModel
            {
                ID = control.ID,
                ProID = control.ProjectID,
                UserID = control.UserID,

             

                projects = new ProjectforeignKeyViewModel()
                {
                    ProjectID = control.Projects_table.ID,
                    ProjectName = control.Projects_table.ProjectName
                },

                Users = new userforeignKeyViewModel()
                {
                    UserID = control.Users_Table.ID,
                    FullName = control.Users_Table.FullName
                },

                Status = control.Status,
            });
        }
        public IEnumerable<ViewUserProjectControlViewModel> ReadprojectForUser()
        {
            return entities.ProjectControl_table.Select(control => new ViewUserProjectControlViewModel
            {
                ID = control.ID,
                UserProjectID = control.ProjectID,
                MYUserID = control.UserID,
                UserProjectName = control.Projects_table.ProjectName,
                ProjecStartDate = control.Projects_table.StartDate.HasValue ? control.Projects_table.StartDate.Value : default(DateTime),
                ProjecEndDate = control.Projects_table.EndDate.HasValue ? control.Projects_table.EndDate.Value : default(DateTime),
                ProjecStatus = control.Status,
                ProjectProgram = control.Projects_table.Programs_Table.ProgramName,


            });

        }

        public void Createproject(ProjectControlViewModel control)
        {
            var entity = new ProjectControl_table();

            entity.ProjectID = control.ProID;
            entity.UserID = control.UserID;
            entity.Status = control.Status;
       
            entities.ProjectControl_table.Add(entity);
            entities.SaveChanges();

            control.ID = entity.ID;
        }

        public void Updateproject(ProjectControlViewModel control)
        {
            var entity = new ProjectControl_table();

            entity.ID = control.ID;
           entity.ProjectID = control.ProID;
            entity.UserID = control.UserID;
            entity.Status = control.Status;

            entities.ProjectControl_table.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroyproject(ProjectControlViewModel product)
        {
            var entity = new ProjectControl_table();

            entity.ID = product.ID;

            entities.ProjectControl_table.Attach(entity);

            entities.ProjectControl_table.Remove(entity);

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



        public IEnumerable<UserViewModel> GetUseres()
        {
            return entities.Users_Table.Select(user => new UserViewModel
            {
                UserID = user.ID,
                FullName = user.FullName,
              


            });
        }

        public IEnumerable<ViewUserProjectControlViewModel> ReadUserProject()
        {
            return entities.ProjectControl_table.Select(control => new ViewUserProjectControlViewModel
            {
                ID = control.ID,
            UserProjectID= control.ProjectID,
                MYUserID = control.UserID,









                ProjecStatus = control.Status,
            });
        }
        public void Dispose()
        {
            entities.Dispose();
        }
    }
}