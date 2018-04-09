namespace UnitTestProject1
{
    /// <summary>
    /// IUserService
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 是否通過驗證
        /// </summary>
        /// <param name="supplierId">廠商序號</param>
        /// <returns>boolean</returns>
        bool IsAuthenticated(int supplierId);
    }
}