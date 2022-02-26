using System;
using System.Collections.Generic;

namespace MultilingualWebsite.Models
{
    public partial class Language
    {
        public Language()
        {
            Texts = new HashSet<Texts>();
        }

        public int Id { get; set; }
        public string LanguageName { get; set; }
        public string Culture { get; set; }

        public virtual ICollection<Texts> Texts { get; set; }
    }
}
