﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Dto.Response.Student
{
    public class GetStudentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string DepartmentName { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }
    }
}
