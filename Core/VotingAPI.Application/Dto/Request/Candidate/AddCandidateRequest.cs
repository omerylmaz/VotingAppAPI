﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Dto.Request.Candidate
{
    public class AddCandidateRequest
    {
        public string UserName { get; set; }
        public string Description { get; set; }
    }
}
