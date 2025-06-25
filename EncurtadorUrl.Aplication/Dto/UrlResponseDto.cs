using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncurtadorUrl.Aplication.Dto
{
    public class UrlResponseDto
    {
        public string UrlOriginal { get; set; }
        public string UrlEncurtada { get; set; }
        public string CodigoCurto { get; set; }
    }
}
