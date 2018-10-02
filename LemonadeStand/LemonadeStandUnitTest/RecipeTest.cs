using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonadeStand;

namespace LemonadeStandUnitTest
{
    [TestClass]
    public class RecipeTest
    {
        [TestMethod]
        public void Add_NotAnIngredient_QuantitiesAllZero()
        {
            //Arrange
            Recipe recipe = new Recipe();
            PrivateObject obj = new PrivateObject(recipe);
            int[] expectedResult = obj.ingredients;

            //Act
            obj.Add("Hello World!");
            int[] result = obj.ingredients()

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
