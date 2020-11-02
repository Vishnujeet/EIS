using EIS.ViewModel.Screen;
using Moq;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EIS.Common;
using EIS.Service;
using EIS.Utils;
using EIS.TestUtils;
using EIS.ViewModel;

namespace EIS.UnitTest
{
    [TestFixture]
    public class TestEmployeeInfoViewModel
    {
        private Mock<IDataContextProvider> mockDataContextProvider;
        private Mock<IViewActivator> mockViewActivator;
        private Mock<IEISService> mockIEISService;
        private MenuToolsViewModel vm;

        [SetUp]
        public void SetUp()
        {
            mockDataContextProvider = Container.Instance.RegisterMock<IDataContextProvider>();
            mockViewActivator = new Mock<IViewActivator>();
            mockIEISService = Container.Instance.RegisterMock<IEISService>();
            vm = new MenuToolsViewModel();
        }

        [Test]
        public void TestLoadEmpCommand()
        {
            var mockEmployeeInfo=new Mock<IEmployeeInfoViewModel>();
            mockIEISService.Setup(x => x.GetEmployees()).Returns(Task.FromResult(new EmployeeData()));
            mockDataContextProvider.SetupGet(x => x.MainScreenViewModel.EmployeeInfoViewModel)
                .Returns(mockEmployeeInfo.Object);
            mockEmployeeInfo.SetupGet(x => x.ListOfEmployees).Returns(new List<EmployeeInfo>());
            vm.LoadEmployeeData.Execute(null);
            mockIEISService.Verify(x=>x.GetEmployees(),Times.Once);
        }
    }
}
