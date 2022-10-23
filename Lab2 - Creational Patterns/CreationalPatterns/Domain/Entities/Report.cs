using CreationalPatterns.Domain.Abstract;
using CreationalPatterns.Patterns.Prototype;

namespace CreationalPatterns.Domain.Entities
{
    public class Report : AbstractReport, IClone<Report>
    {
        public override string ToString()
        {
            return $"Title: {Title}\nContent: {Content}\nReferences: {References}";
        }
        public Report Clone()
        {
            return new Report
            {
                Title = Title,
                Content = Content,
                References = References
            };
        }
    }
}
