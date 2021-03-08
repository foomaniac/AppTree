using System;
using System.Collections.Generic;
using System.Text;

namespace AppTree.Domain.AggregateModels.ApplicationAggregate
{
   public class Dependency
    {
        public int ParentApplicationId { get; set; }
        public Application ParentApplication { get; set; }

        public int ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}
