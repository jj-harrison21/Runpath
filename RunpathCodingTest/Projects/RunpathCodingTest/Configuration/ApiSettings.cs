using System.Configuration;

namespace RunpathCodingTest.Configuration
{
    public class ApiSettings : ConfigurationSection
    {
        public static ApiSettings Settings { get; } = ConfigurationManager.GetSection("ApiSettings") as ApiSettings;

        [ConfigurationProperty("BaseUrl", IsRequired = true)]
        public string BaseUrl => (string)this["BaseUrl"];

        [ConfigurationProperty("AlbumUrl", IsRequired = true)]
        public string AlbumUrl => (string)this["AlbumUrl"];

        [ConfigurationProperty("PhotoUrl", IsRequired = true)]
        public string PhotoUrl => (string)this["PhotoUrl"];
    }
}
