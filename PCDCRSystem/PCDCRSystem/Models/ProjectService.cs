using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PCDCRSystem.Models
{
    public class ProjectService :IDisposable
    {
        private PCDCREntities entities;

        public ProjectService(PCDCREntities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<ProjectViewModel> Read()
        {
            return entities.Projects_table.Select(project => new ProjectViewModel
            {
                ProjectID = project.ID,
                ProjectName = project.ProjectName,
                Status = project.ProjectStatus,
                StartDate=project.StartDate.HasValue ? project.StartDate.Value: default(DateTime),
                EndDate=project.EndDate.HasValue ? project.StartDate.Value : default(DateTime),
                 ProgrameID=project.ProgrameID,
                Programe = new ProgramsViewModel()
                {
                    ProgramID = project.Programs_Table.ID,
                    ProgramName = project.Programs_Table.ProgramName
                },
             
            });
        }
             public void Create(ProjectViewModel product)
        {
            var entity = new Projects_table();

            entity.ProjectName = product.ProjectName;
            entity.StartDate = (DateTime)product.StartDate.Date;
            entity.EndDate = (DateTime)product.EndDate.Date;
            entity.ProjectStatus = product.Status;
            entity.ProgrameID = product.ProgrameID;

            if (entity.ProgrameID == null)
            {
                entity.ProgrameID = 1;
            }

            if (product.Programe != null)
            {
                entity.ProgrameID = product.Programe.ProgramID;
            }

            entities.Projects_table.Add(entity);
            entities.SaveChanges();

            product.ProjectID = entity.ID;
        }

        public void Update(ProjectViewModel product)
        {
            var entity = new Projects_table();

            entity.ID = product.ProjectID;
            entity.ProjectName = product.ProjectName;
            entity.StartDate = (DateTime)product.StartDate.Date;
            entity.EndDate = (DateTime)product.EndDate.Date;
            entity.ProjectStatus = product.Status;
            entity.ProgrameID = product.ProgrameID;

            

            entities.Projects_table.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(ProjectViewModel product)
        {
            var entity = new Projects_table();

            entity.ID = product.ProjectID;

            entities.Projects_table.Attach(entity);

            entities.Projects_table.Remove(entity);
      
            entities.SaveChanges();
        }
        public IEnumerable<ProgramsViewModel> ReadPrograms()
        {
            return entities.Programs_Table.Select(product => new ProgramsViewModel
            {
                ProgramID = product.ID,
                ProgramName = product.ProgramName


            });
        }
        public void Dispose()
        {
            entities.Dispose();
        }
    }
}