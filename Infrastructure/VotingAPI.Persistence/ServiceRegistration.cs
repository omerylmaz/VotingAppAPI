﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VotingAPI.Application.Abstractions;
using VotingAPI.Application.Repositories.ModelRepos;
//using VotingAPI.Domain.Entities.Identity;
using VotingAPI.Persistence.Contexts;
using VotingAPI.Persistence.Extensions;
using VotingAPI.Persistence.Repos;
using VotingAPI.Persistence.Services;

namespace VotingAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceDI(this IServiceCollection services)
        {
            services.AddDbContext<ElectionSystemDbContext>(o => o.UseNpgsql(Constants.ConnectionString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            }));
            
            //services.AddIdentity<AppUser, AppRole>(options =>
            //{
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.User.RequireUniqueEmail = true;
            //    options.Password.RequireUppercase = false;
            //    options.SignIn.RequireConfirmedEmail = true;
            //})
                //.AddRoles<AppRole>()
                //.AddEntityFrameworkStores<ElectionSystemDbContext>()
                 //.AddDefaultTokenProviders(); //todo bunu araştır
            services.AddScoped<IDepartmentReadRepo, DepartmentReadRepo>();
            services.AddScoped<ICandidateReadRepo, CandidateReadRepo>();
            //services.AddScoped<IElectionTypeReadRepo, ElectionTypeReadRepo>();
            services.AddScoped<IStudentReadRepo, StudentReadRepo>();
            services.AddScoped<IVoteReadRepo, VoteReadRepo>();
            //services.AddScoped<IVotingPeriodReadRepo, VotingPeriodReadRepo>();
            //services.AddScoped<IVotingReadRepo, VotingReadRepo>();
            services.AddScoped<IDepartmentWriteRepo, DepartmentWriteRepo>();
            services.AddScoped<ICandidateWriteRepo, CandidateWriteRepo>();
            //services.AddScoped<IElectionTypeWriteRepo, ElectionTypeWriteRepo>();
            services.AddScoped<IStudentWriteRepo, StudentWriteRepo>();
            services.AddScoped<IVoteWriteRepo, VoteWriteRepo>();
            //services.AddScoped<IVotingPeriodWriteRepo, VotingPeriodWriteRepo>();
            //services.AddScoped<IVotingWriteRepo, VotingWriteRepo>();
            services.AddScoped<IVoteReadRepo, VoteReadRepo>();
            services.AddScoped<IVoteWriteRepo, VoteWriteRepo>();
            services.AddScoped<IElectionReadRepo, ElectionReadRepo>();
            services.AddScoped<IElectionWriteRepo, ElectionWriteRepo>();
            services.AddScoped<IUserReadRepo, UserReadRepo>();
            services.AddScoped<IUserWriteRepo, UserWriteRepo>();
            services.AddScoped<IAnnouncementReadRepo, AnnouncementReadRepo>();
            services.AddScoped<IAnnouncementWriteRepo, AnnouncementWriteRepo>();
            //services.AddScoped<ITranscriptFileReadRepo, TranscriptFileReadRepo>();
            //services.AddScoped<ITranscriptFileWriteRepo, TranscriptFileWriteRepo>();
            //services.AddScoped<ICriminalRecordFileReadRepo, CriminalRecordFileReadRepo>();
            //services.AddScoped<ICriminalRecordFileWriteRepo, CriminalRecordFileWriteRepo>();
            //services.AddScoped<IProfilePhotoFileReadRepo, ProfilePhotoFileReadRepo>();
            //services.AddScoped<IProfilePhotoFileWriteRepo, ProfilePhotoFileWriteRepo>();
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IVoteService, VoteService>();
            services.AddScoped<IElectionService, ElectionService>();
            services.AddScoped<IAnnouncementService, AnnouncementService>();
            //services.AddScoped<IVotingPeriodService, VotingPeriodService>();
            //services.AddScoped<IFileReadRepo, FileReadRepo>();
            //services.AddScoped<IFileWriteRepo, FileWriteRepo>();

        }
    }
}
