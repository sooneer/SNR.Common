using System.ComponentModel.DataAnnotations;

namespace SNR.Common;

public class ValidationHelper : IValidationHelper
{
    public void Get(int id)
    {
        if (id <= 0)
        {
            throw new NotificationException("id parametresi boş olamaz");
        }
    }

    public void Save<TModel>(TModel request)
    {
        if (request == null)
        {
            throw new NotificationException("request parametresi boş olamaz");
        }

        var context = new ValidationContext(request, null, null);
        var validationResults = new List<ValidationResult>();
        bool valid = Validator.TryValidateObject(request, context, validationResults, true);
        if (!valid)
        {
            throw new NotificationException(JsonConvert.SerializeObject(validationResults.Select(k => k.ErrorMessage).ToList()));
        }
    }
}