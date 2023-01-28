﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VotingAPI.Persistence.Contexts;

#nullable disable

namespace VotingAPI.Persistence.Migrations
{
    [DbContext(typeof(ElectionSystemDbContext))]
    [Migration("20230128181620_update_mig_5")]
    partial class updatemig5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("VotingAPI.Domain.Entities.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("ApplicationDate")
                        .HasColumnType("date");

                    b.Property<short>("ApproveStatus")
                        .HasColumnType("smallint");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("Candidates", "dbo");
                });

            modelBuilder.Entity("VotingAPI.Domain.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Departments", "dbo");
                });

            modelBuilder.Entity("VotingAPI.Domain.Entities.ElectionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ElectionTypes", "dbo");
                });

            modelBuilder.Entity("VotingAPI.Domain.Entities.FileTypes.CriminalRecordFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<short>("ApprovedStatus")
                        .HasColumnType("smallint");

                    b.Property<int>("CandidateId")
                        .HasColumnType("integer");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Storage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId")
                        .IsUnique();

                    b.HasIndex("Path")
                        .IsUnique();

                    b.ToTable("CriminalRecordFiles", "dbo");
                });

            modelBuilder.Entity("VotingAPI.Domain.Entities.FileTypes.ProfilePhotoFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CandidateId")
                        .HasColumnType("integer");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Storage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("ProfilePhotos", "dbo");
                });

            modelBuilder.Entity("VotingAPI.Domain.Entities.FileTypes.TranscriptFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<short>("ApprovedStatus")
                        .HasColumnType("smallint");

                    b.Property<int>("CandidateId")
                        .HasColumnType("integer");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Storage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId")
                        .IsUnique();

                    b.HasIndex("Path")
                        .IsUnique();

                    b.ToTable("TranscriptFiles", "dbo");
                });

            modelBuilder.Entity("VotingAPI.Domain.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StudentNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StudentNumber")
                        .IsUnique();

                    b.ToTable("Students", "dbo");
                });

            modelBuilder.Entity("VotingAPI.Domain.Entities.Vote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CandidateId")
                        .HasColumnType("integer");

                    b.Property<int>("Students")
                        .HasColumnType("integer");

                    b.Property<int>("VoterId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("VotingDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("VotingPeriodId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId")
                        .IsUnique();

                    b.HasIndex("Students");

                    b.HasIndex("VoterId")
                        .IsUnique();

                    b.HasIndex("VotingPeriodId")
                        .IsUnique();

                    b.ToTable("Votes", "dbo");
                });

            modelBuilder.Entity("VotingAPI.Domain.Entities.Voting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("VotingPeriodId")
                        .HasColumnType("integer");

                    b.Property<int>("WinnerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("VotingPeriodId");

                    b.HasIndex("WinnerId");

                    b.ToTable("Votings", "dbo");
                });

            modelBuilder.Entity("VotingAPI.Domain.Entities.VotingPeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ElectionTypeId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("ElectionTypeId")
                        .IsUnique();

                    b.ToTable("VotingPeriods", "dbo");
                });

            modelBuilder.Entity("VotingAPI.Domain.Entities.Candidate", b =>
                {
                    b.HasOne("VotingAPI.Domain.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("VotingAPI.Domain.Entities.FileTypes.CriminalRecordFile", b =>
                {
                    b.HasOne("VotingAPI.Domain.Entities.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("VotingAPI.Domain.Entities.FileTypes.ProfilePhotoFile", b =>
                {
                    b.HasOne("VotingAPI.Domain.Entities.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("VotingAPI.Domain.Entities.FileTypes.TranscriptFile", b =>
                {
                    b.HasOne("VotingAPI.Domain.Entities.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("VotingAPI.Domain.Entities.Vote", b =>
                {
                    b.HasOne("VotingAPI.Domain.Entities.Student", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VotingAPI.Domain.Entities.Student", "Voter")
                        .WithMany()
                        .HasForeignKey("Students")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VotingAPI.Domain.Entities.VotingPeriod", "VotingPeriod")
                        .WithMany()
                        .HasForeignKey("VotingPeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Voter");

                    b.Navigation("VotingPeriod");
                });

            modelBuilder.Entity("VotingAPI.Domain.Entities.Voting", b =>
                {
                    b.HasOne("VotingAPI.Domain.Entities.VotingPeriod", "VotingPeriod")
                        .WithMany()
                        .HasForeignKey("VotingPeriodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VotingAPI.Domain.Entities.Candidate", "Winner")
                        .WithMany()
                        .HasForeignKey("WinnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VotingPeriod");

                    b.Navigation("Winner");
                });

            modelBuilder.Entity("VotingAPI.Domain.Entities.VotingPeriod", b =>
                {
                    b.HasOne("VotingAPI.Domain.Entities.ElectionType", "ElectionType")
                        .WithMany()
                        .HasForeignKey("ElectionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ElectionType");
                });
#pragma warning restore 612, 618
        }
    }
}
