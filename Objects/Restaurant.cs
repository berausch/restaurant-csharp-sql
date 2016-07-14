using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace FoodList
{
  public class Restaurant
  {
    private int _id;
    private string _name;
    private string _phone;
    private string _location;
    private int _cuisineId;

    public Restaurant(string Name, string Phone, string Location, int CuisineId, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _phone = Phone;
      _location = Location;
      _cuisineId = CuisineId;
    }

    public override bool Equals(System.Object otherRestaurant)
    {
      if(!(otherRestaurant is Restaurant))
      {
        return false;
      }
      else
      {
        Restaurant newRestaurant = (Restaurant) otherRestaurant;
        bool idEquality = this.GetId() == newRestaurant.GetId();
        bool nameEquality = this.GetName() == newRestaurant.GetName();
        bool phoneEquality = this.GetPhone() == newRestaurant.GetPhone();
        bool locationEquality = this.GetLocation() == newRestaurant.GetLocation();
        bool cuisineIdEquality = this.GetCuisineId() == newRestaurant.GetCuisineId();
        return (idEquality && nameEquality && phoneEquality && locationEquality);
      }
    }
    public int GetCuisineId()
    {
      return _cuisineId;
    }

    public void SetCuisineId(int newCuisineId)
    {
      _cuisineId = newCuisineId;
    }
    public int GetId()
    {
      return _id;
    }

    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    public string GetPhone()
    {
      return _phone;
    }
    public void SetPhone(string newPhone)
    {
      _phone = newPhone;
    }
    public string GetLocation()
    {
      return _location;
    }
    public void SetLocation(string newLocation)
    {
      _location = newLocation;
    }
    public static List<Restaurant> GetAll()
    {
      List<Restaurant> allRestaurants = new List<Restaurant>{};

      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM restaurant;", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int restaurantId = rdr.GetInt32(0);
        string restaurantName = rdr.GetString(1);
        string restaurantPhone = rdr.GetString(2);
        string restaurantLocation = rdr.GetString(3);
        int restaurantCuisineId = rdr.GetInt32(4);
        Restaurant newRestaurant = new Restaurant(restaurantName, restaurantPhone, restaurantLocation, restaurantCuisineId, restaurantId);
        allRestaurants.Add(newRestaurant);
      }
      if ( rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        rdr.Close();
      }
      return allRestaurants;
    }
  }
}
