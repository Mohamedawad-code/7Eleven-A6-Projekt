using _7Eleven.ViewModel;
using _7Eleven.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _7Eleven.Tests
{
    [TestClass]
    public class ProductViewModelTests
    {
        [TestMethod]
        public void CreateNewProduct_ShouldReturnProductWithCorrectValues()
        {
            // Arrange
            var viewModel = new ProductViewModel();
            string expectedName = "Croissant";
            int expectedAmount = 10;
            DateTime expectedTimeReceived = new DateTime(2026, 5, 16);
            DateTime expectedExpiringDate = new DateTime(2026, 5, 20);

            // Act
            var result = viewModel.CreateNewProduct(
                expectedName,
                expectedAmount,
                expectedTimeReceived,
                expectedExpiringDate
            );

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedName, result.Name);
            Assert.AreEqual(expectedAmount, result.Amount);
            Assert.AreEqual(expectedTimeReceived, result.TimeReceived);
            Assert.AreEqual(expectedExpiringDate, result.ExpiringDate);
        }
    }
}