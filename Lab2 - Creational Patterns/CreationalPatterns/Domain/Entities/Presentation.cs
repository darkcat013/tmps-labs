using CreationalPatterns.Domain.Abstract;
using CreationalPatterns.Patterns.Prototype;

namespace CreationalPatterns.Domain.Entities
{
    public class Presentation : AbstractPresentation, IClone<Presentation>
    {
        public override string ToString()
        {
            return $"Title: {Title}\nSlides:\n\t{string.Join("\n\t", Slides)}";
        }
        public Presentation Clone()
        {
            return new Presentation
            {
                Title = Title,
                Slides = Slides,
            };
        }
    }
}
