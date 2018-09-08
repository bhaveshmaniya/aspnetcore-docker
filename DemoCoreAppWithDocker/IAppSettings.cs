namespace DemoCoreAppWithDocker
{
    public interface IAppSettings
    {
        string EnvKey { get; set; }
    }

    public class AppSettings : IAppSettings
    {
        public string EnvKey { get ; set ; }
    }
}