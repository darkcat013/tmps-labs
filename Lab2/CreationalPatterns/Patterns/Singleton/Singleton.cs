namespace CreationalPatterns.Patterns.Singleton
{
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
}
