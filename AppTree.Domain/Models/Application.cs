using System;
using System.Collections.Generic;
using System.Text;

namespace AppTree.Domain.Models
{
    public class Application
    {
        public int? Id { get; set;}
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Repository { get; set; }
    }
}
