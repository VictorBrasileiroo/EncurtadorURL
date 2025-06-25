using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncurtadorURL.Core.Models;

namespace EncurtadorURL.Core.IRepositories
{
    public interface IUrlRepository
    {
        Task<UrlModel> GetLongUrlByCode(string code);
        Task<UrlModel> GetShortUrlByCode(string longUrl);
        Task<UrlModel> AddShortUrl(UrlModel url);
    }
}
