namespace SNR.Common;

public class ConfigurationManager : IConfigurationManager
{
    private readonly ConfigurationModel _configurationModel;

    public ConfigurationManager()
    {
        var _settingPath = AppDomain.CurrentDomain.BaseDirectory + "/appsettings.json";
        var _file = File.ReadAllText(_settingPath);
        _configurationModel = JsonConvert.DeserializeObject<ConfigurationModel>(_file);
    }
    public string GetConnectionString()
    {
        return _configurationModel.ConnectionStrings.SqlConnection;
    }

    public MailSetting GetMailSetting()
    {
        return _configurationModel.MailSetting;
    }
}