using System.Linq;
using MultilingualWebsite.Data;
using MultilingualWebsite.Models;

namespace AspNetCoreDatabaseLocalizationDemo.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly MyAppDbContext _context;

        public LocalizationService(MyAppDbContext context)
        {
            _context = context;
        }

        public Texts GetText(string resourceKey, int languageId)
        {


            return _context.Texts.FirstOrDefault(x =>
                    x.KeyText.Trim().ToLower() == resourceKey.Trim().ToLower()
                    && x.LanguageId == languageId);
        }
    }
}