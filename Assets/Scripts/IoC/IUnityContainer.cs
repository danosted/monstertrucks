namespace UnityDM.IoC
{
    public interface IUnityContainer
    {
        public T Resolve<T>();
    }
}
