using System;
using System.Collections.Generic;
using System.Text;

namespace Plugin
{
    [Language("Finnish")]
    public class FinnishTranslator : TranslatorBase
    {
        public override string Translate()
        {
            return "Hei Maailma";
        }
    }
}
