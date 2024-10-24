    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace WineCode.Models
    {
        // red, white, vegan, ..;
        public class Category
        {
            public int CategoryId { get; set; }
            public string Name { get; set; } = string.Empty;
        }
    }
