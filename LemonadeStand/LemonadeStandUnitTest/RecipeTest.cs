using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonadeStand;

namespace LemonadeStandUnitTest
{
    [TestClass]
    public class RecipeTest
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Add_NotAnIngredient_ThrowAnException()
        {
            //Arrange
            Recipe recipe = new Recipe();

            //Act
            recipe.Add("Hello World!");

        }
    }
}
