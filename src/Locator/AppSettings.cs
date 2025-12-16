namespace Locator;

public class AppSettings
{
    public MongoDbSetting MongoDbSettings { get; set; } = null!;
    public Feature Features { get; set; } = null!;

}

public class MongoDbSetting
{
    public string Host { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;

}


public class Feature
{
    public Iplocation IpLocation { get; set; }
}

public class Iplocation
{
    public Providers Providers { get; set; }
}

public class Providers
{
    public string IpGeoLocation { get; set; }
}
