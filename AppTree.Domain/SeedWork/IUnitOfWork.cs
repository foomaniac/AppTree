﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace AppTree.Domain.Seedwork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
