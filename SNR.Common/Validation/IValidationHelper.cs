namespace Common
{
    public interface IValidationHelper
    {
        void Get(int id);

        void Save<TModel>(TModel request);
    }
}