namespace AppTree.Domain.AggregateModels.ApplicationAggregate
{
    public class Dependency
    {
        public int ParentApplicationId { get; set; }
        public Application ParentApplication { get;  }

        public int ApplicationId { get; set; }
        public Application Application { get; }

        public Dependency(int parentApplicationId, int applicationId)
        {
            ParentApplicationId = parentApplicationId;
            ApplicationId = applicationId;
        }


    }
}
