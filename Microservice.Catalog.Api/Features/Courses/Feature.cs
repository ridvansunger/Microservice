namespace Microservice.Catalog.Api.Features
{
    public class Feature
    {
        public int Duration { get; set; }
        public float Rating { get; set; }
        public string EducatorFullName { get; set; } = default!;
    }
}
