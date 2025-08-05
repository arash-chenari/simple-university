﻿using SimpleUniversity.Application.Students.Contracts;
using SimpleUniversity.Domain;
using System.Net.Http.Headers;

namespace SimpleUniversity.Persistence.EF.Students
{
    public class EFStudentRepository : IStudentRepository
    {
        private readonly EFDbContext _dbContext;

        public EFStudentRepository(EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Student student)
        {
            _dbContext.Students.Add(student);
        }

        public List<GetStudentDto> GetAll()
        {
            return _dbContext.Students
                     .Select(s => new GetStudentDto
                     {
                         BirthDate = s.BirthDate,
                         Code = s.Code,
                         FirstName = s.FirstName,
                         LastName = s.LastName,
                         FatherName = s.FatherName,
                         Gender = s.Gender,
                         NationalCode = s.NationalCode,
                         Id = s.Id,
                         ContactInfo = new ContactInfo
                         {
                             Address = s.ContactInfo.Address,
                             Phone = s.ContactInfo.Phone
                         }
                     }).ToList();
        }
    }
}
