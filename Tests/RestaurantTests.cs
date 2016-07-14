using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace FoodList
{
  public class RestaurantTest : IDisposable
  {
    public RestaurantTest()
    {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=foodlist_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_RestaurantEmptyAtFirst()
    {
      //Arrange, Act
      int result = Restaurant.GetAll().Count;

      //Assert
      Assert.Equal(0, result);
    }
    public void Dispose()
    {
      // Restaurant.DeleteAll();
      // Cuisine.DeleteAll();
    }
    [Fact]
    public void Test_Equal_ReturnsTrueIfDescriptionsAreTheSame()
    {
      //Arrange, Act
      Restaurant firstRestaurant = new Restaurant("Chili's", "555-123-4567", "Downtown", 1);
      Restaurant secondRestaurant = new Restaurant("Chili's", "555-123-4567", "Downtown", 1);

      //Assert
      Assert.Equal(firstRestaurant, secondRestaurant);
    }
  }
}
