namespace SNR.Common;

public interface IConfigurationManager
{
    string GetConnectionString();

    MailSetting GetMailSetting();

    string Get(string key);
}