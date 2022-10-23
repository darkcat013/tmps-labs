# Creational Design Patterns

## Author: Viorel Noroc

----

## Objectives

* Get familiar with the Creational DPs;
* Choose a specific domain;
* Implement at least 3 CDPs for the specific domain;

## Used Design Patterns

* Singleton
* Prototype
* Builder
* Factory Method
* Abstract Factory

## Implementation

### Singleton

This laboratory work uses a classic implementation of the singleton and in this cases it stores some display values.

```cs
public class Singleton
    {
        private Singleton() { }

        public List<string> TemplateOrigins { get; private set; }

        private static Singleton? _instance;
        public static Singleton GetInstance()
        {
            _instance ??= new()
            {
                TemplateOrigins = new List<string>
                {
                    "UTM", "ASEM"
                },
            };
            return _instance;
        }
    }
```

```cs
static void Main(string[] args)
{
    var singleton = Singleton.GetInstance();
    Console.WriteLine($"Available presentations and reports template: {string.Join(',', singleton.TemplateOrigins)}");
    Console.WriteLine();
    ...

```

### Prototype

This is a generic implementation of the Prototype pattern. The entities implement this interface to provide their specific methods of clonning.

```cs
public interface IClone<T>
    {
        T Clone();
    }
```

```cs
public Presentation Clone()
        {
            return new Presentation
            {
                Title = Title,
                Slides = Slides,
            };
        }
```

```cs
public Report Clone()
        {
            return new Report
            {
                Title = Title,
                Content = Content,
                References = References
            };
        }
```

### Builder

2 builders were created for this project to build a presentation and a report.

```cs
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
```

Example

```cs
var report = new ReportBuilder()
                .SetTitle("Custom report")
                .SetContent("Report Content")
                .SetReferences("www.google.com")
                .Build();
```

### Abstract Factory

The abstract factory in this project provides the templates for the origins specified in the singleton.

```cs
public interface ITemplateFactory
    {
        AbstractPresentation CreatePresentation();
        AbstractReport CreateReport();
    }
```

### Factory Method

The factories in this project create some default objects.

```cs
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
```

```cs
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
```

## Conclusions

This laboratory work was an interesting and useful one because I solidified my already existing knowledge on Creational Design Patterns and I got to implement some patterns I did not know about. The only thing that I did not like about this laboratory work is that I spent more time thinking about a use case for these patterns than to actually write the code and the report.

The expected output of Program.cs

```text
Available presentations and reports template: UTM,ASEM

Title: UTM presentation, Name Surname Group
Slides:
        Contents
        Subchapter
        Subchapter

Title: ASEM report
Report topic
Name Surname Group
Content: Content
References: References

Title: Custom report
Content: Report Content
References: www.google.com
```