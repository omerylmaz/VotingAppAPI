﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingAPI.Application.Exceptions
{
    public class AuthenticationFailedException : Exception
    {
        public AuthenticationFailedException()
            : base(ResultMessages.AuthenticationFailed) { }

        public AuthenticationFailedException(string? message) : base(message)
        {
        }
    }
}
