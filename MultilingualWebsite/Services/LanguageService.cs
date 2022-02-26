using System.Collections.Generic;
using System.Linq;
using MultilingualWebsite.Data;
using MultilingualWebsite.Models;

namespace AspNetCoreDatabaseLocalizationDemo.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly MyAppDbContext _context;

        public LanguageService(MyAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Language> GetLanguages()
        {
            return _context.Languages.ToList();
        }

        public Language GetLanguageByCulture(string culture)
        {
            return _context.Languages.FirstOrDefault(x =>
                x.Culture.Trim().ToLower() == culture.Trim().ToLower());
        }
    }
}