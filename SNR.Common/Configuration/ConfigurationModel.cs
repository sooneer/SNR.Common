namespace SNR.Common;

public class ConfigurationModel
{
    public ConnectionStrings ConnectionStrings { get; set; }
    public string UploadPath { get; set; }
    public MailSetting MailSetting { get; set; }
}

public class ConnectionStrings
{
    public string SqlConnection { get; set; }
}