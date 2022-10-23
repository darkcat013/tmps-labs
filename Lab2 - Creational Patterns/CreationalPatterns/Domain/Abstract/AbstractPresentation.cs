namespace CreationalPatterns.Domain.Abstract
{
    public class AbstractPresentation
    {
        public string? Title { get; set; }
        public List<string> Slides { get; set; } = new();
    }
}
