﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingAPI.Domain.Entities.Common;

namespace VotingAPI.Application.Repositories
{
    public interface IWriteRepo<T> : IRepo<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        bool Remove(T entity);
        Task<bool> RemoveByIdAsync(int id);
        bool RemoveRange(List<T> entities);
        bool Update(T entity);
        void UpdateRange(List<T> entities);
        Task<int> SaveChangesAsync();
    }
}
