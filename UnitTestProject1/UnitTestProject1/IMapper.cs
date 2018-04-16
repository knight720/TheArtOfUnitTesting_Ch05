namespace UnitTestProject1
{
    /// <summary>
    /// IMapper
    /// </summary>
    public interface IMapper
    {
        /// <summary>
        /// 物件轉換 Table To Entity
        /// </summary>
        /// <typeparam name="TDestination">目標類別</typeparam>
        /// <param name="source">來源</param>
        /// <returns>目標</returns>
        TDestination Map<TDestination>(object source);
    }
}