namespace SNR.Common;

public class ExceptionFilterModel
{
    public int Status { get; set; }
    public string Data { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}