using System;
using System.Collections.Generic;
using System.Text;

namespace AppTree.Domain.AggregateModels.HostAggregate
{
   public class Host
    {
        public int? Id { get; }
        public string HostName { get; private set; }
        public string Domain { get; private set; }

        /// <summary>
        /// Azure
        /// OnPrem
        /// </summary>
        public string Location { get; private set; }
        public string Summary { get; private set; }
    }
}
