using System;
using System.Collections.Generic;
using System.Text;

namespace AppTree.Domain.Models
{
    public class Dependency
    {
        public int ParentApplicationId { get; set; }
        public int ApplicationId { get; set; }
    }
}
