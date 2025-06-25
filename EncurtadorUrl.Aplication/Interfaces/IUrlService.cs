using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncurtadorUrl.Aplication.Dto;
using EncurtadorURL.Core.Models;

namespace EncurtadorUrl.Aplication.Interfaces
{
    public interface IUrlService
    {
        Task<UrlModel>EncurtarUrl(UrlDto dto);
        Task<string>RedirecionarUrl(string shortCode);
    }
}
