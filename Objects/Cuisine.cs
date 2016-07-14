using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace FoodList
{
  public class Cuisine
  {
    private int _id;
    private string _foodKind;

    public Cuisine(string FoodKind, int Id = 0)
    {
      _id = Id;
      _foodKind = FoodKind;
    }

    public override bool Equals(System.Object otherCuisine)
    {
      if (!(otherCuisine is Cuisine))
      {
        return false;
      }
      else
      {
        Cuisine newCuisine = (Cuisine) otherCuisine;
        bool idEquality = this.GetId() == newCuisine.GetId();
        bool foodKindEquality =  this.GetFoodKind() == newCuisine.GetFoodKind();
        return (idEquality && foodKindEquality);
      }
    }
    public int GetId()
    {
      return _id;
    }
    public string GetFoodKind()
    {
      return _foodKind;
    }
    public void SetFoodKind(string newFoodKind)
    {
      _foodKind = newFoodKind;
    }
    public static List<Cuisine> GetAll()
    {
      List<Cuisine> allCuisines = new List<Cuisine>{};

      SqlConnection conn = DB.Connection();
      SqlDataReader rdr = null;
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM cuisine;", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int cuisineId = rdr.GetInt32(0);
        string cuisineFoodKind = rdr.GetString(1);
        Cuisine newCuisine = new Cuisine(cuisineFoodKind, cuisineId);
        allCuisines.Add(newCuisine);
      }

      if (rdr != null)
      {
        rdr.Close();
      }
      if(conn!= null)
      {
        conn.Close();
      }

      return allCuisines;
    }
  }
}
