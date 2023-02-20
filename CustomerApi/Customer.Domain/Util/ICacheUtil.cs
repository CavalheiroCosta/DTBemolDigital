namespace Customer.Domain.Util
{
    public interface ICacheUtil
    {
        T GetValue<T>(string key) where T : class;
        void SetValue<T>(string key, T value);
    }
}
