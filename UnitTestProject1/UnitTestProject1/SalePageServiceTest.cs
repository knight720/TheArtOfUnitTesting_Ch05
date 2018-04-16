using System;
using NSubstitute;
using Xunit;

namespace UnitTestProject1
{
    public class SalePageServiceTest
    {
        /// <summary>
        /// 5.2 動態建立假物件
        /// </summary>
        [Fact(DisplayName = "Page 08 動態建立假物件")]
        public void SalePage_Not_Null()
        {
            //// Arrange
            int supplierId = 8;
            long salePageId = 88;

            IUserService userService = Substitute.For<IUserService>();
            ISalePageRepository salePageRepository = Substitute.For<ISalePageRepository>();
            IMapper mapper = Substitute.For<IMapper>();

            userService.IsAuthenticated(Arg.Any<int>()).Returns(true);
            // Make Fail By Return Null
            //mapper.Map<SalePageDataEntity>(Arg.Any<SalePage>()).Returns((SalePageDataEntity) null);

            var target = new SalePageService(userService, salePageRepository, mapper);

            //// Act
            var actual = target.Get(salePageId);

            //// Assert
            Assert.NotNull(actual);
        }

        /// <summary>
        /// 5.3 模擬回傳值
        /// Page 11 模擬回傳值
        /// </summary>
        [Fact(DisplayName = "Page 11 模擬回傳值")]
        public void IsAuthenticated_Throw_ApplicationException()
        {
            //// Arrange
            int supplierId = 11;
            long salePageId = 1111;

            ISalePageRepository salePageRepository = Substitute.For<ISalePageRepository>();
            //// 從一個假物件回傳值
            salePageRepository.Get(salePageId).Returns(new SalePage(supplierId));

            IMapper mapper = Substitute.For<IMapper>();
            //// 參數匹配器
            mapper.Map<SalePageDataEntity>(Arg.Any<SalePage>()).Returns(new SalePageDataEntity());

            IUserService userService = Substitute.For<IUserService>();
            //// 模擬拋出例外 1
            userService.When(x => x.IsAuthenticated(Arg.Any<int>())).Do(x => { throw new ApplicationException("訊息.無效的會員"); });
            //// 模擬拋出例外 2
            //userService.IsAuthenticated(Arg.Any<int>()).Returns(x => { throw new ApplicationException("訊息.無效的會員"); });

            var target = new SalePageService(userService, salePageRepository, mapper);

            //// Act
            Action act = () => target.Get(salePageId);

            //// Assert
            // Make Fail By Change Exception Type
            Assert.Throws<ApplicationException>(act);
        }

        /// <summary>
        /// 5.3 模擬回傳值
        /// Page 12 同時使用模擬物件和虛設常式物件
        /// </summary>
        [Fact(DisplayName = "Page 12 同時使用模擬物件和虛設常式物件")]
        public void IsAuthenticated_SupplierId_Should_Be_Equal()
        {
            //// Arrange
            int supplierId = 12;
            long salePageId = 1212;

            ISalePageRepository stubSalePageRepository = Substitute.For<ISalePageRepository>();
            //// 5.3 Simulating Fake Values
            stubSalePageRepository.Get(Arg.Any<long>()).Returns(new SalePage(supplierId));

            IUserService mockUserService = Substitute.For<IUserService>();
            mockUserService.IsAuthenticated(Arg.Any<int>()).Returns(true);

            IMapper stubMapper = Substitute.For<IMapper>();

            var target = new SalePageService(mockUserService, stubSalePageRepository, stubMapper);

            //// Act
            target.Get(salePageId);

            //// Assert
            // Make Fail By Change SalePage()
            mockUserService.Received().IsAuthenticated(Arg.Is<int>(s => s.Equals(supplierId)));
        }

        /// <summary>
        /// 5.3 模擬回傳值
        /// Page 13 驗證物件是帶著某些屬性的情況
        /// </summary>
        [Fact(DisplayName = "Page 13 驗證物件是帶著某些屬性的情況")]
        public void Map_SupplierId_Should_Be_Equal()
        {
            //// Arrange
            int supplierId = 13;
            long salePageId = 1313;

            ISalePageRepository stubSalePageRepository = Substitute.For<ISalePageRepository>();
            stubSalePageRepository.Get(Arg.Any<long>()).Returns(new SalePage(supplierId));

            IUserService stubUserService = Substitute.For<IUserService>();
            stubUserService.IsAuthenticated(Arg.Any<int>()).Returns(true);

            IMapper mockMapper = Substitute.For<IMapper>();

            var target = new SalePageService(stubUserService, stubSalePageRepository, mockMapper);

            //// Act
            target.Get(salePageId);

            //// Assert
            // Make Fail By Change SalePageRepository.Get().Returns();
            mockMapper.Received().Map<SalePageDataEntity>(Arg.Is<SalePage>(s => s.SalePage_SupplierId == supplierId));
        }
    }
}