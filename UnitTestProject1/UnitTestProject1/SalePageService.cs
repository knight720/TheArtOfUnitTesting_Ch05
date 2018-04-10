using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    public class SalePageService
    {
        /// <summary>
        /// UserService
        /// </summary>
        private IUserService _userService;

        /// <summary>
        /// ISalePageRepository
        /// </summary>
        private ISalePageRepository _salePageRepository;

        /// <summary>
        /// IMapper
        /// </summary>
        private IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the SalePageService class
        /// </summary>
        public SalePageService(IUserService userService, ISalePageRepository salePageRepository, IMapper mapper)
        {
            this._userService = userService;
            this._salePageRepository = salePageRepository;
            this._mapper = mapper;
        }

        /// <summary>
        /// 取得商品頁
        /// </summary>
        /// <param name="salePageId">序號</param>
        /// <returns>商品頁資料</returns>
        public SalePageDataEntity Get(long salePageId)
        {
            var data = this._salePageRepository.Get(salePageId);

            if (this._userService.IsAuthenticated(data.SalePage_SupplierId) == false)
            {
                throw new ApplicationException("Message.InvalidAccount");
            }

            var result = this._mapper.Map<SalePageDataEntity>(data);

            return result;
        }

    }
}
