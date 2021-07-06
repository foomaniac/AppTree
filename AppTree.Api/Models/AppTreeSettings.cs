using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTree.Api.Models
{
    public class AppTreeSettings
    {
        public const string ConnectionString = "ConnectionStrings";
        public string AppTreeContext { get; set; }
    }
}
