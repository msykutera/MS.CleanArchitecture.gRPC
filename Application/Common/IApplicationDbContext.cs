using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Common;

public interface IApplicationDbContext
{
    DbSet<License> Licenses { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
