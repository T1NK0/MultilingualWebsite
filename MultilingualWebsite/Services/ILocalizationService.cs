using MultilingualWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreDatabaseLocalizationDemo.Services
{
    public interface ILocalizationService
    {
        Texts GetText(string resourceKey, int languageId);
    }
}