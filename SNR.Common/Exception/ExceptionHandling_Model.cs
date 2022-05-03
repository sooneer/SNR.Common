namespace SNR.Common;

public class ExceptionHandling_Model
{
    public bool Success { get; set; }
    public string Message { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}