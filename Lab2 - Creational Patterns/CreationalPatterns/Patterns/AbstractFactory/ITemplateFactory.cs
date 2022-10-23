using CreationalPatterns.Domain.Abstract;

namespace CreationalPatterns.Patterns.AbstractFactory
{
    public interface ITemplateFactory
    {
        AbstractPresentation CreatePresentation();
        AbstractReport CreateReport();
    }
}
