using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace FoodList
{
  public class CuisineTest : IDisposable
  {
    public CuisineTest()
    {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=foodlist_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_CuisineEmptyAtFirst()
    {
      //Arrange, Act
      int result = Cuisine.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }
    public void Dispose()
    {
      // Task.DeleteAll();
      // Category.DeleteAll();
    }
    [Fact]
    public void Test_Equal_ReturnsTrueForSameName()
    {
      //Arrange, Act
      Cuisine firstCuisine = new Cuisine("Thai");
      Cuisine secondCuisine = new Cuisine("Thai");

      //Assert
      Assert.Equal(firstCuisine, secondCuisine);
    }
  }
}
