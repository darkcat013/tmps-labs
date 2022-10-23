namespace CreationalPatterns.Domain.Abstract
{
    public abstract class AbstractReport
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? References { get; set; }
    }
}
