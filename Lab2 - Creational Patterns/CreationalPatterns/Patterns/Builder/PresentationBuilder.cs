using CreationalPatterns.Domain.Entities;

namespace CreationalPatterns.Patterns.Builder
{
    public class PresentationBuilder
    {
        private Presentation _presentation = new();
        public PresentationBuilder SetTitle(string title)
        {
            _presentation.Title = title;
            return this;
        }
        public PresentationBuilder AddSlide(string text)
        {
            _presentation.Slides.Add(text);
            return this;
        }
        public Presentation Build()
        {
            var result = _presentation.Clone();
            _presentation = new();
            return result;
        }
    }
}
