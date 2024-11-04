using ApplicationLayer.Contracts;
using ApplicationLayer.Dtos;
using DomainLayer.Entities;
using InfrastructureLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Services
{
    public class StudentService : IStudent
    {
        private readonly StudentDbContext studentDbContext;

        public StudentService(StudentDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;
        }

        public async Task<ServiceResponse> AddASync(Student student)
        {
            var check = await studentDbContext.Students.FirstOrDefaultAsync(_ => _.FirstName.ToLower() == student.FirstName.ToLower ());
            if (check != null) 
                return new ServiceResponse(false, "User already existed");
            studentDbContext.Students.Add(student);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Added");
        }

        public async Task<ServiceResponse> DeleteASync(int id)
        {
           var student = await studentDbContext.Students.FindAsync(id);
            if (student == null)
                return new ServiceResponse(false, "User not found");
            studentDbContext.Students.Remove(student);
            await SaveChangesAsync();
            return new ServiceResponse(true, "Deleted");
        }

        public async Task<List<Student>> GetStudent() => await studentDbContext.Students.AsNoTracking().ToListAsync();


        public async Task<Student> GetById(int id) => await studentDbContext.Students.FindAsync(id);


        public async Task<ServiceResponse> UpdateASync(Student student)
        {
            studentDbContext.Update(student);
            await SaveChangesAsync();
            return new ServiceResponse(true, "UpDated");
        }
        private async Task SaveChangesAsync() => await studentDbContext.SaveChangesAsync();

    }

}
