﻿using Ardalis.Specification;

namespace Virtable.Core.SharedKernel;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
