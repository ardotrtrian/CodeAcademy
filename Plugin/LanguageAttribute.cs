using System;

namespace Plugin
{
    [AttributeUsage(AttributeTargets.Class)]
    public class LanguageAttribute : Attribute
    {
        private readonly string Language;

        public LanguageAttribute(string language)
        {
            this.Language = language;
        }
    }
    
}
