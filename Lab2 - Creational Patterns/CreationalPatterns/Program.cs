using CreationalPatterns.Patterns.Builder;
using CreationalPatterns.Patterns.FactoryMethod;
using CreationalPatterns.Patterns.Singleton;

namespace CreationalPatterns
{
    public class Program
    {
        static void Main(string[] args)
        {
            var singleton = Singleton.GetInstance();
            Console.WriteLine($"Available presentations and reports template: {string.Join(',', singleton.TemplateOrigins)}");
            Console.WriteLine();

            var utmFactory = new UTM_TemplateFactory();
            Console.WriteLine(utmFactory.CreatePresentation());
            Console.WriteLine();

            var asemFactory = new ASEM_TemplateFactory();
            Console.WriteLine(asemFactory.CreateReport());
            Console.WriteLine();

            var report = new ReportBuilder()
                .SetTitle("Custom report")
                .SetContent("Report Content")
                .SetReferences("www.google.com")
                .Build();

            Console.WriteLine(report);
        }
    }
}