using CreationalPatterns.Domain.Entities;

namespace CreationalPatterns.Patterns.Builder
{
    public class ReportBuilder
    {
        private Report _report = new();
        public ReportBuilder SetTitle(string title)
        {
            _report.Title = title;
            return this;
        }
        public ReportBuilder SetContent(string content)
        {
            _report.Content = content;
            return this;
        }
        public ReportBuilder SetReferences(string references)
        {
            _report.References = references;
            return this;
        }
        public Report Build()
        {
            var result = _report.Clone();
            _report = new();
            return result;
        }
    }
}
