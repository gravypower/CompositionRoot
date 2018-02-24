using CompositionRoot.Kernel;

namespace CompositionRoot.Plugin.Japanese
{
    public class HelloInJapanese: IPlugin
    {
        private readonly IPerson _person;
        private readonly ILanguage _language;

        public HelloInJapanese(IPerson person, ILanguage language)
        {
            _person = person;
            _language = language;
        }

        public string SayHello()
        {
            return $"{_language.Hello} {_person.Name}";
        }
    }
}
