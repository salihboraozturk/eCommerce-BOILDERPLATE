using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace eCommerceProject.Localization
{
    public static class eCommerceProjectLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(eCommerceProjectConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(eCommerceProjectLocalizationConfigurer).GetAssembly(),
                        "eCommerceProject.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
