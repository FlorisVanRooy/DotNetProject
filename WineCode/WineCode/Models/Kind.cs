using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineCode.Models
{
    //druivenras (sauvignon, ..)
    public class Kind
    {
        public int KindId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
