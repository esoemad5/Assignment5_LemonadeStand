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

        [TestMethod]
        public void Add_Lemon_1AtElement0()
        {
            //Arrange
            Recipe recipe = new Recipe();
            int expectedResult = 1;

            //Act
            recipe.Add("LeMon");
            int result = recipe.Quantities[0];

            //Assert
            Assert.AreEqual(result, expectedResult);

        }

        [TestMethod]
        public void Remove_Lemon_1AtElement0()
        {
            //Arrange
            Recipe recipe = new Recipe();
            PrivateObject obj = new PrivateObject(recipe);
            int[] testArray = new int[] { 2, 0, 0 };
            obj.SetField("quantities", testArray);
            int expectedResult = 1;
            

            //Act
            recipe.Remove("LeMon");
            /* PrivateObject is for manipulating private fields of and object (call it object A).
             * Changing a field in PrivateObject will change that same field in object A!!!!!
             * IF YOU DIE IN THE MATRIX, YOU DIE IN REAL LIFE!!!!!!!!!!!!!!!!!
             */
            int result = recipe.Quantities[0];

            //Assert
            Assert.AreEqual(result, expectedResult);

        }

    }
}
