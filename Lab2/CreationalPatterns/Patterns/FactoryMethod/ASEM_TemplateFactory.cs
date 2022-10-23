using CreationalPatterns.Patterns.AbstractFactory;
using CreationalPatterns.Domain.Abstract;
using CreationalPatterns.Domain.Entities;

namespace CreationalPatterns.Patterns.FactoryMethod
{
    public class ASEM_TemplateFactory : ITemplateFactory
    {
        public AbstractPresentation CreatePresentation()
        {
            var presentation = new Presentation()
            {
                Title = "ASEM presentation\nName Surname Group",
                Slides = new()
                {
                    "Contents",
                    "Subchapter",
                    "Subchapter"
                }
            };
            return presentation;
        }

        public AbstractReport CreateReport()
        {
            var report = new Report()
            {
                Title = "ASEM report\nReport topic\nName Surname Group",
                Content = "Content",
                References = "References"
            };

            return report;
        }
    }
}
