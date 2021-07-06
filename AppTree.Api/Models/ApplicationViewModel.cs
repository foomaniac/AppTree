using System;
using System.Collections.Generic;

namespace AppTree.Api.Models
{
    public class ApplicationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Repository { get; set; }
        public string Type { get; set; }

        public ICollection<ApplicationDependencyModel> Dependencies {get; set;}
    }

    public class ApplicationDependencyModel
    {
        public int ParentApplicationId { get; set; }
        public int ApplicationId { get; set; }
        public string Name { get; set; }              
        public string Type { get; set; }
    }
}
