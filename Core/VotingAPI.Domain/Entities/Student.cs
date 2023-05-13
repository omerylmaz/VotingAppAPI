﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities.Common;
using VotingAPI.Domain.Entities.Identity;

namespace VotingAPI.Domain.Entities
{
    [Table("Students", Schema = "dbo")]

    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long StudentId { get; set; }
        public int DepartmentId { get; set; }
        public UserRole UserRole { get; set; }
    }
    public enum UserRole
    {
        Admin,
        Student,
        Candidate
    }
}
