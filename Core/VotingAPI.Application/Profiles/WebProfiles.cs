﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Application.Dto.General;
using VotingAPI.Application.Dto.Request.Announcement;
using VotingAPI.Application.Dto.Request.Department;
using VotingAPI.Application.Dto.Request.Election;
using VotingAPI.Application.Dto.Request.Student;
using VotingAPI.Application.Dto.Request.User;
using VotingAPI.Application.Dto.Request.Votes;
using VotingAPI.Application.Dto.Request.VotingPeriod;
using VotingAPI.Application.Dto.Response.Announcement;
using VotingAPI.Application.Dto.Response.Candidate;
using VotingAPI.Application.Dto.Response.Department;
using VotingAPI.Application.Dto.Response.Election;
using VotingAPI.Application.Dto.Response.ProfilePhoto;
using VotingAPI.Application.Dto.Response.Student;
using VotingAPI.Application.Dto.Response.User;
using VotingAPI.Application.Dto.Response.VotingPeriod;
using VotingAPI.Domain.Entities;
//using VotingAPI.Domain.Entities.FileTypes;
using C = VotingAPI.Domain.Entities.Common;

namespace VotingAPI.Application.Profiles
{
    public class WebProfiles : Profile
    {
        public WebProfiles()
        {
            //CreateMap<C.File, AddFileResponse>();
            //CreateMap<AddStudentRequest, AppUser>()
            //.ForMember(x => x.);
            //CreateMap<AppUser, AddStudentRequest>()
            //    .ForMember(s => s.UserId, x => x.MapFrom(t => t.Id));

            CreateMap<AddStudentRequest, Student>();
                //.ForPath(dest => dest.User.UserName, opt => opt.MapFrom(src => src.UserName));
            CreateMap<Student, AddStudentResponse>();
            //CreateMap<Student, GetStudentListResponse>();
            CreateMap<Student, GetStudentResponse>();

            CreateMap<CreateUserRequest, User>();
            CreateMap<User, GetUserResponse>();

            CreateMap<Candidate, GetCandidateResponse>();


            //.ForMember(c => c.StudentNumber, g => g.MapFrom(x => x.Student.StudentNumber))
            //.ForMember(c => c.Name, g => g.MapFrom(x => x.Student.Name));
            //CreateMap<CreateUserRequest, AppUser>()
            //    .ForMember(c => c.UserName, g => g.MapFrom(x => x.Email));
            //CreateMap<AppUser, GetUserResponse>();

            CreateMap<GetDepartmentRequest, Department>();
            CreateMap<AddDepartmentRequest, Department>();
            CreateMap<Department, GetDepartmentResponse>();
            CreateMap<UpdateDepartmentRequest, Department>();
            CreateMap<UpdateStudentRequest, Student>();
            CreateMap<VoteDto, Vote>().ReverseMap();
            //    .ForMember(x => x.VoterId, y => y.MapFrom(z => z.UserId));
            //.ForMember(x => x.VotingPeriodId, y => y.MapFrom(z => z.VotingPeriodId))
            //.ForMember(x => x.CandidateId, y => y.MapFrom(z => z.CandidateId));

            CreateMap<CreateDepartmentElectionRequest, Election>();
            CreateMap<Election, GetDepartmentElectionResponse>();
            CreateMap<Candidate, CandidateDto>();

            CreateMap<AddAnnouncementRequest, Announcement>().ReverseMap();
            CreateMap<Announcement, GetAnnouncementResponse>();
            //CreateMap<VotingPeriod, GetVotingPeriodResponse>()
            //    .ForMember(x => x.ElectionTypeName, y => y.MapFrom(z => z.ElectionType.TypeName));

            //CreateMap<AddVotingPeriodRequest, VotingPeriod>();


            //todo burayı barışa sor her modelde mapper kullanmaya gerek var mı?
        }
    }
}
