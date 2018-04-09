namespace UnitTestProject1
{
    public interface IMapper
    {
        TDestination Map<TDestination>(object source);
    }
}