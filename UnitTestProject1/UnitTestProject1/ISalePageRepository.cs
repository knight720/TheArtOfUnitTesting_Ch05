using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    /// <summary>
    /// SalePageRepository interface
    /// </summary>
    public interface ISalePageRepository
    {
        /// <summary>
        /// 取得商品頁資料
        /// </summary>
        /// <param name="id">商品頁序號</param>
        /// <returns>SalePage</returns>
        SalePage Get(long id);
        
    }
}