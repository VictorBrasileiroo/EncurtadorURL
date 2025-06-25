using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncurtadorURL.Core.IRepositories;
using EncurtadorURL.Core.Models;
using EncurtadorURL.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace EncurtadorUrl.Infra.Repositories
{
    public class UrlRepository : IUrlRepository
    {
        private readonly AppDbContext _context;

        public UrlRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UrlModel> AddShortUrl(UrlModel url)
        {
            _context.Add(url);
            await _context.SaveChangesAsync();
            return url;
        }

        public async Task<UrlModel> GetLongUrlByCode(string code) => await _context.Urls.FirstOrDefaultAsync(e => e.UrlCurta == code);

        public async Task<UrlModel> GetShortUrlByCode(string longUrl) => await _context.Urls.FirstOrDefaultAsync(e => e.UrlLonga == longUrl);
    }
}
