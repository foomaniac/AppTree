using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTree.Api.Models
{
    public class ApplicationData
    {
        public int Id { get; set; }
        public string Name { get;  set; }
        public string Summary { get; set; }
        public string Repository { get; set; }
        public string Type { get; set; }
    }
}
