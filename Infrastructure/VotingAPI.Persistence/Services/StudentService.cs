﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Dto.Request.Student;
using VotingAPI.Application.Dto.Response.Student;
using VotingAPI.Application.Exceptions;
using VotingAPI.Application.Repositories.ModelRepos;
using VotingAPI.Domain.Entities;

namespace VotingAPI.Persistence.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IStudentReadRepo _studentReadRepo;
        private readonly IStudentWriteRepo _studentWriteRepo;
        private readonly IDepartmentReadRepo _departmentReadRepo;
        private readonly IUserReadRepo _userReadRepo;

        public StudentService(
            IMapper mapper,
            IStudentReadRepo studentReadRepo,
            IStudentWriteRepo studentWriteRepo,
            IDepartmentReadRepo departmentReadRepo,
            IUserReadRepo userReadRepo
            )
        {
            _mapper = mapper;
            _studentReadRepo = studentReadRepo;
            _studentWriteRepo = studentWriteRepo;
            _departmentReadRepo = departmentReadRepo;
            _userReadRepo = userReadRepo;
        }
        public async Task<List<GetStudentResponse>> GetStudentList()
        {
            var studentListResponse = new List<GetStudentResponse>();
            var studentsDb = _studentReadRepo.GetAll()/*.Include(s => s.User).Include(s => s.Department)*/.ToList();

            HashSet<int> departmentIds = new HashSet<int>(studentsDb.Select(s => s.DepartmentId));
            HashSet<int> userIds = new HashSet<int>(studentsDb.Select(s => s.UserId));

            var departmentsQuery = _departmentReadRepo.Table.Where(x => departmentIds.Contains(x.Id)).AsNoTracking();
            var departments = departmentsQuery.ToList();
            var usersQuery = _userReadRepo.Table.Where(x => userIds.Contains(x.Id)).AsNoTracking();
            var users = usersQuery.ToList();

            foreach (var student in studentsDb)
            {
                var user = users.FirstOrDefault(u => u.Id == student.UserId);
                var studentResponse = new GetStudentResponse()
                {
                    Id = student.Id,
                    DepartmentName = departments.FirstOrDefault(d => d.Id == student.DepartmentId).Name,
                    Name = user.Name,
                    Lastname = user.LastName,
                    Email = user.UserName,
                    UserRole = user.UserRole
                };
                studentListResponse.Add(studentResponse);
            }
            //var department = await _departmentReadRepo.GetSingleAsync(x => x.Id == studentsDb.)
            //var studentListResponse = _mapper.Map<List<GetStudentResponse>>(studentsDb);
            return studentListResponse;


        }

        public async Task<GetStudentResponse> GetStudentByIdAsync(int id)
        {
            var studentDb = await _studentReadRepo.GetByIdAsync(id);
            if (studentDb == null)
                throw new DataNotFoundException(id);

            var response = _mapper.Map<GetStudentResponse>(studentDb);
            return response;
        }

        public async Task<GetStudentResponse> GetStudentByUserNameAsync(string userName)
        {
            var user = await _userReadRepo.GetSingleAsync(x => x.UserName == userName);
            if (user == null)
                return null;
            var studentDb = await _studentReadRepo.GetSingleAsync(x => x.UserId == user.Id);
            if (studentDb == null)
                return null;
            var department = await _departmentReadRepo.GetByIdAsync(studentDb.DepartmentId);
            GetStudentResponse response = new()
            {
                DepartmentName = department.Name,
                Email = userName,
                Id = user.Id,
                Lastname = user.LastName,
                Name = user.Name,
                UserRole = user.UserRole
            };
            //if (studentDb == null)
            //throw new DataNotFoundException(userName);

            //response = _mapper.Map<GetStudentResponse>(studentDb);

            return response;
        }

        //public async Task<GetStudentResponse> GetStudentByStudentNumberAsync(long studentNumber)
        //{
        //    var studentDb = await _studentReadRepo.GetSingleAsync(s => s.StudentNumber == studentNumber, false);
        //    if (studentDb == null)
        //        throw new DataNotFoundException(studentNumber);
        //    var getStudentResponse = _mapper.Map<GetStudentResponse>(studentDb);
        //    return getStudentResponse;
        //}

        public async Task AddStudentAsync(AddStudentRequest student)
        {
            var studentMapped = _mapper.Map<Student>(student);//todo : 1 Burayı anlamadım Student tipinde neden veriyoz ki
            //studentMapped.UserId = student.UserId;
            bool addedStatus = await _studentWriteRepo.AddAsync(studentMapped);
            if (!addedStatus)
                throw new DataNotAddedException();
            try
            {

                await _studentWriteRepo.SaveChangesAsync();//todo arada foreign key kaynaklı hata çözümü var ama çok fazka try catch geleceek: https://stackoverflow.com/questions/2403348/how-can-i-know-if-an-sqlexception-was-thrown-because-of-foreign-key-violation
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task UpdateStudentAsync(UpdateStudentRequest updateStudentRequest)
        {
            var student = await _studentReadRepo.GetByIdAsync(updateStudentRequest.Id);
            if (student == null)
                throw new DataNotFoundException(updateStudentRequest.Id);
            var studentMapped = _mapper.Map<Student>(updateStudentRequest);
            bool isUpdated = _studentWriteRepo.Update(studentMapped);
            if (!isUpdated)
                throw new DataNotUpdatedException();
            await _studentWriteRepo.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            bool isDeleted = await _studentWriteRepo.RemoveByIdAsync(id);
            if (!isDeleted)
                throw new DataNotDeletedException();
            await _studentWriteRepo.SaveChangesAsync();
        }
        //todo : 5 buralarda null dönmesi sonucu çok fazla throw atma yapıyorum, ben repolarda bu işlemin yapılmasını daha uygun görüyorum fakat single responsibility ilkesine ters imiş. Fakat 
        //bu şekilde de kod tekrarı yaşanıyor
    }
}
