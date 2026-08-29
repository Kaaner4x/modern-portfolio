using System;
using ModernPortfolio.Models;
using ModernPortfolio.Repositories.@abstract;

namespace ModernPortfolio.Repositories.concrete;

public class AboutRepository : GenericRepository<About>, IAboutRepository
{
    public AboutRepository(IConfiguration configuration) : base(configuration, "About")
    {
    }
}
