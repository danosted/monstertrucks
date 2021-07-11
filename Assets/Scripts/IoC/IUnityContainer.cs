namespace Assets.Code.IoC
{
    public interface IUnityContainer
    {
        public T Resolve<T>();
    }
}
