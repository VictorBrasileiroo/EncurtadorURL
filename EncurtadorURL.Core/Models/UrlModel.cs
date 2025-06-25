using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncurtadorURL.Core.Models
{
    public class UrlModel
    {
        public Guid Id { get; set; }
        public string? UrlLonga { get; set; }
        public string? UrlCurta { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    }
}
