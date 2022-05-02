namespace SNR.Common;

public interface ICacheProvider
{
    TType Get<TType>(string name) where TType : class;

    void Set(string name, object value, TimeSpan expire);

    void Clear();

    void Remove(string name);

    bool Exists(string key);
}