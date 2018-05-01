using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace AdoDotNetCompare
{
    internal class TestClass
    {
        public int SqlDataReaderNamed()
        {
            var result = new List<Order>();
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=.\mssql2016;Initial Catalog=Northwind;Integrated Security=True";
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 100 * FROM Orders", cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    result.Add(new Order
                    {
                        OrderID = Convert.ToInt32(dr["OrderID"]),
                        CustomerID = dr["CustomerID"]?.ToString() ?? string.Empty,
                        EmployeeID = Convert.ToInt32(dr["EmployeeID"]),
                        OrderDate = DateTime.Parse(dr["OrderDate"]?.ToString() ?? string.Empty),
                        RequiredDate = DateTime.Parse(dr["RequiredDate"]?.ToString() ?? string.Empty),
                        ShippedDate = DateTime.Parse(dr["ShippedDate"]?.ToString() ?? string.Empty),
                        ShipVia = Convert.ToInt32(dr["ShipVia"]),
                        Freight = Convert.ToInt32(dr["Freight"]),
                        ShipName = dr["ShipName"]?.ToString() ?? string.Empty,
                        ShipAddress = dr["ShipAddress"]?.ToString() ?? string.Empty,
                        ShipCity = dr["ShipCity"]?.ToString() ?? string.Empty,
                        ShipRegion = dr["ShipRegion"]?.ToString() ?? string.Empty,
                        ShipPostalCode = dr["ShipPostalCode"]?.ToString() ?? string.Empty,
                        ShipCountry = dr["ShipCountry"]?.ToString() ?? string.Empty,
                    });
                }
                cn.Close();
            }

            return result.Count;
        }

        public int SqlDataReaderIndex()
        {
            var result = new List<Order>();
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=.\mssql2016;Initial Catalog=Northwind;Integrated Security=True";
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 100 * FROM Orders", cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var item = new Order();
                    item.OrderID = dr.GetInt32(0);
                    item.CustomerID = dr.IsDBNull(1) ? string.Empty : dr.GetString(1);
                    item.EmployeeID = Convert.ToInt32(dr.GetValue(2));
                    item.OrderDate = dr.GetDateTime(3);
                    item.RequiredDate = dr.GetDateTime(4);
                    item.ShippedDate = dr.GetDateTime(5);
                    item.ShipVia = dr.IsDBNull(6) ? (int?)null : dr.GetInt32(6);
                    item.Freight = dr.IsDBNull(7) ? (decimal?)null : dr.GetDecimal(7);
                    item.ShipName = dr.GetValue(8)?.ToString() ?? string.Empty;
                    item.ShipAddress = dr.GetValue(9)?.ToString() ?? string.Empty;
                    item.ShipCity = dr.IsDBNull(10) ? string.Empty : dr.GetString(10);
                    item.ShipRegion = dr.IsDBNull(11) ? string.Empty : dr.GetString(11);
                    item.ShipPostalCode = dr.IsDBNull(12) ? string.Empty : dr.GetString(12);
                    item.ShipCountry = dr.IsDBNull(13) ? string.Empty : dr.GetString(13);
                    result.Add(item);
                }
                cn.Close();
            }

            return result.Count;
        }

        public int SqlDataReaderIndexSequential()
        {
            var result = new List<Order>();
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=.\mssql2016;Initial Catalog=Northwind;Integrated Security=True";
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 100 * FROM Orders", cn);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                while (dr.Read())
                {
                    result.Add(new Order
                    {
                        OrderID = dr.GetInt32(0),
                        CustomerID = dr.IsDBNull(1) ? string.Empty : dr.GetString(1),
                        EmployeeID = Convert.ToInt32(dr.GetValue(2)),
                        OrderDate = dr.GetDateTime(3),
                        RequiredDate = dr.GetDateTime(4),
                        ShippedDate = dr.GetDateTime(5),
                        ShipVia = dr.IsDBNull(6) ? (int?)null : dr.GetInt32(6),
                        Freight = dr.IsDBNull(7) ? (decimal?)null : dr.GetDecimal(7),
                        ShipName = dr.GetValue(8)?.ToString() ?? string.Empty,
                        ShipAddress = dr.GetValue(9)?.ToString() ?? string.Empty,
                        ShipCity = dr.IsDBNull(10) ? string.Empty : dr.GetString(10),
                        ShipRegion = dr.IsDBNull(11) ? string.Empty : dr.GetString(11),
                        ShipPostalCode = dr.IsDBNull(12) ? string.Empty : dr.GetString(12),
                        ShipCountry = dr.IsDBNull(13) ? string.Empty : dr.GetString(13),
                    });
                }
                cn.Close();
            }

            return result.Count;
        }


        public int SqlDataReaderNamedSequential()
        {
            var result = new List<Order>();
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=.\mssql2016;Initial Catalog=Northwind;Integrated Security=True";
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 100 * FROM Orders", cn);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SequentialAccess);

                while (dr.Read())
                {
                    result.Add(new Order
                    {
                        OrderID = Convert.ToInt32(dr["OrderID"]),
                        CustomerID = dr["CustomerID"]?.ToString() ?? string.Empty,
                        EmployeeID = Convert.ToInt32(dr["EmployeeID"]),
                        OrderDate = DateTime.Parse(dr["OrderDate"]?.ToString() ?? string.Empty),
                        RequiredDate = DateTime.Parse(dr["RequiredDate"]?.ToString() ?? string.Empty),
                        ShippedDate = DateTime.Parse(dr["ShippedDate"]?.ToString() ?? string.Empty),
                        ShipVia = Convert.ToInt32(dr["ShipVia"]),
                        Freight = Convert.ToDecimal(dr["Freight"]),
                        ShipName = dr["ShipName"]?.ToString() ?? string.Empty,
                        ShipAddress = dr["ShipAddress"]?.ToString() ?? string.Empty,
                        ShipCity = dr["ShipCity"]?.ToString() ?? string.Empty,
                        ShipRegion = dr["ShipRegion"]?.ToString() ?? string.Empty,
                        ShipPostalCode = dr["ShipPostalCode"]?.ToString() ?? string.Empty,
                        ShipCountry = dr["ShipCountry"]?.ToString() ?? string.Empty,
                    });
                }
                cn.Close();
            }

            return result.Count;
        }

        public int Fill()
        {
            
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=.\mssql2016;Initial Catalog=Northwind;Integrated Security=True";
                SqlDataAdapter da1 = new SqlDataAdapter("SELECT TOP 100 * FROM Orders", cn);
                da1.Fill(dt);
            }

            var result = ToList(dt);
            return result.Count;
        }

        public int TableLoad()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=.\mssql2016;Initial Catalog=Northwind;Integrated Security=True";
                SqlCommand cmd = new SqlCommand("SELECT TOP 100 * FROM Orders", cn);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                cn.Close();
            }

            var result = ToList(dt);
            return result.Count;
        }

        public int TableLoadSequential()
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=.\mssql2016;Initial Catalog=Northwind;Integrated Security=True";
                SqlCommand cmd = new SqlCommand("SELECT TOP 100 * FROM Orders", cn);

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SequentialAccess);
                dt.Load(dr);
                cn.Close();
            }

            var result = ToList(dt);
            return result.Count;
        }

        public int Dapper()
        {
            string Connection = @"Data Source=.\mssql2016;Initial Catalog=Northwind;Integrated Security=True";
            List<Order> result = new List<Order>();
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                result = conn.Query<Order>(@"SELECT TOP 100 * FROM Orders").ToList();
            }

            return result.Count;
        }

        private List<Order> ToList(DataTable dt)
        {
            var result = (from DataRow dr in dt.Rows
                            select new Order
                            {
                                OrderID = Convert.ToInt32(dr["OrderID"]),
                                CustomerID = dr["CustomerID"]?.ToString() ?? string.Empty,
                                EmployeeID = Convert.ToInt32(dr["EmployeeID"]),
                                OrderDate = DateTime.Parse(dr["OrderDate"]?.ToString() ?? string.Empty),
                                RequiredDate = DateTime.Parse(dr["RequiredDate"]?.ToString() ?? string.Empty),
                                ShippedDate = DateTime.Parse(dr["ShippedDate"]?.ToString() ?? string.Empty),
                                ShipVia = Convert.ToInt32(dr["ShipVia"]),
                                Freight = Convert.ToDecimal(dr["Freight"]),
                                ShipName = dr["ShipName"]?.ToString() ?? string.Empty,
                                ShipAddress = dr["ShipAddress"]?.ToString() ?? string.Empty,
                                ShipCity = dr["ShipCity"]?.ToString() ?? string.Empty,
                                ShipRegion = dr["ShipRegion"]?.ToString() ?? string.Empty,
                                ShipPostalCode = dr["ShipPostalCode"]?.ToString() ?? string.Empty,
                                ShipCountry = dr["ShipCountry"]?.ToString() ?? string.Empty,
                            }).ToList();
            return result;
        }
    }
}