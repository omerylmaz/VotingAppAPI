﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities.Common;

namespace VotingAPI.Domain.Entities
{
    [Table("Candidates", Schema = "dbo")]
    public class Candidate : BaseEntity
    {
        public ApproveStatus ApproveStatus { get; set; }

        public long StudentId { get; set; }
        public Student Student { get; set; }

        public int ElectionId { get; set; }
        public Election Election { get; set; }
    }
    public enum ApproveStatus
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3
    }
}
