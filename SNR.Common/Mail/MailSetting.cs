namespace SNR.Common;

public class MailSetting
{
    public string From { get; set; }
    public string PassWord { get; set; }
    public bool IsBodyHtml { get; set; }
    public int Port { get; set; }
    public string Host { get; set; }
    public bool EnableSsl { get; set; }
    public string To { get; set; }
    public string FromFullName { get; set; }
}