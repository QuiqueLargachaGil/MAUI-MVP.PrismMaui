namespace MVP.PrismMaui.Infrastructure.Mappers.Base
{
    public abstract class BaseMapper<TSource, TDestination> where TSource : class where TDestination : class
    {
        public TDestination Map(TSource source)
        {
            if (source is null) return null;

            return MapImpl(source);
        }

        protected abstract TDestination MapImpl(TSource source);
    }
}
