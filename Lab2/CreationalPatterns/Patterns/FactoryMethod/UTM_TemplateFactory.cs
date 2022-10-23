using CreationalPatterns.Patterns.AbstractFactory;
using CreationalPatterns.Domain.Abstract;
using CreationalPatterns.Domain.Entities;

namespace CreationalPatterns.Patterns.FactoryMethod
{
    public class UTM_TemplateFactory : ITemplateFactory
    {
        public AbstractPresentation CreatePresentation()
        {
            var presentation = new Presentation()
            {
                Title = "UTM presentation, Name Surname Group",
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
            var report = new Report() { 
                Title = "UTM report\n Report for discipline\n Name Surname Group",
                Content = "Report contents",
                References = "References"
            };

            return report;
        }
    }
}
