using System;

namespace Plugin
{
    [AttributeUsage(AttributeTargets.Class)]
    public class LanguageAttribute : Attribute
    {
        public string Language;

        public LanguageAttribute(string language)
        {
            this.Language = language;
        }
    }
    
}
