namespace AppTree.Models
{
    public class CreateApplicationViewModel
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Repository { get; set; }
        public int ApplicationTypeId { get; set; }
    }
}
