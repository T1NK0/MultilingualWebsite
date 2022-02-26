using System;
using System.Collections.Generic;

namespace MultilingualWebsite.Models
{
    public partial class Texts
    {
        public int Id { get; set; }
        public int? LanguageId { get; set; }
        public string KeyText { get; set; }
        public string KeyValue { get; set; }

        public virtual Language Language { get; set; }
        public string Value { get; internal set; }
    }
}
