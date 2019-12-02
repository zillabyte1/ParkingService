using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

using System.Data.SqlClient;

using ParkingData;

namespace ParkingService.Controllers
{

  [ApiController]
  [Route("[controller]")]
  public class ParkingController : ControllerBase
  {
    private readonly ILogger<ParkingController> _logger;

    public ParkingController(ILogger<ParkingController> logger) {
      _logger = logger;
    }

    #region Actions

    [HttpGet("/api/parking/action/{data}")]
    public bool AddAction(string data) {
      ParkingLot rec = new ParkingLot();
      string CS = Global.DBConnStr;
      string[] args = data.Split(';'); ;

      string lotkey = args[0];
      string actiontype = args[1];
      int actionvalue = int.Parse(args[2]);
      string SQL = "";

      if (actiontype == "reset") {

        SQL = "UPDATE ParkingLot SET Occupied = (@actionvalue)" +
              ", LastUpdated = getdate()" +
              " WHERE LotKey = @lotkey;";

      } else if (actiontype == "set") {

        SQL = "UPDATE ParkingLot SET MaxSpaces = (@actionvalue)" +
              ", LastUpdated = getdate()" +
              " WHERE LotKey = @lotkey;";

      } else {

        SQL = "UPDATE ParkingLot SET Occupied = Occupied + (@actionvalue)" +
              ", LastUpdated = getdate()" +
              " WHERE LotKey = @lotkey;";
      }

      SQL += "INSERT INTO ParkingLog (" +
           " LotKey,ActionType,ActionValue" +
           " ) VALUES (" +
           "@lotkey" +
           ",@actiontype" +
           ",@actionvalue" +
           ");";


      using (SqlConnection Connection = new SqlConnection(CS)) {
        using (SqlCommand cmd = Connection.CreateCommand()) {

          cmd.CommandText = SQL;
          cmd.Parameters.AddWithValue("@actionvalue", actionvalue);
          cmd.Parameters.AddWithValue("@lotkey", lotkey);
          cmd.Parameters.AddWithValue("@actiontype", actiontype);

          Connection.Open();

          cmd.ExecuteNonQuery();
        }

      }
      return true;
    }

    #endregion


    #region ParkingLot

    [HttpGet("/api/parking/locations/{id}")]
    public ParkingLot Lot(string id) {

      ParkingLot rec = new ParkingLot();
      string CS = Global.DBConnStr;
      using (SqlConnection con = new SqlConnection(CS)) {
        SqlCommand cmd = new SqlCommand("SELECT * FROM ParkingLot WHERE LotKey='" + id + "'", con);
        cmd.CommandType = CommandType.Text;
        con.Open();

        SqlDataReader rdr = cmd.ExecuteReader();
        if (rdr.Read()) {
          rec.LotKey = rdr["LotKey"].ToString();
          rec.MaxSpaces = Convert.ToInt32(rdr["MaxSpaces"]);
          rec.Occupied = Convert.ToInt32(rdr["Occupied"]);
          rec.LastUpdated = Convert.ToDateTime(rdr["LastUpdated"]);
        }
      }

      return rec;
    }

    [HttpGet("/api/parking/locations")]
    public IEnumerable<ParkingLot> ListParkingLots() {

      List<ParkingLot> lst = new List<ParkingLot>();
      string CS = Global.DBConnStr;
      using (SqlConnection con = new SqlConnection(CS)) {
        SqlCommand cmd = new SqlCommand("SELECT * FROM ParkingLot", con);
        cmd.CommandType = CommandType.Text;
        con.Open();

        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read()) {
          var rec = new ParkingLot();

          rec.LotKey = rdr["LotKey"].ToString();
          rec.MaxSpaces = Convert.ToInt32(rdr["MaxSpaces"]);
          rec.Occupied = Convert.ToInt32(rdr["Occupied"]);
          rec.LastUpdated = Convert.ToDateTime(rdr["LastUpdated"]);
          lst.Add(rec);
        }
      }
      return lst;
    }

    #endregion

    #region ParkingLog

    [HttpGet("/api/parking/logs")]
    public IEnumerable<ParkingLog> ListParkingLogs() {

      List<ParkingLog> lst = new List<ParkingLog>();
      string CS = Global.DBConnStr;
      using (SqlConnection con = new SqlConnection(CS)) {
        SqlCommand cmd = new SqlCommand("SELECT Top 100* FROM ParkingLog", con);
        cmd.CommandType = CommandType.Text;
        con.Open();

        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read()) {
          var rec = new ParkingLog();

          rec.LogId = Convert.ToInt32(rdr["LogId"]);
          rec.LotKey = rdr["LotKey"].ToString();
          rec.ActionType = rdr["ActionType"].ToString();
          rec.ActionValue = Convert.ToInt32(rdr["ActionValue"]);
          rec.DateCreated = Convert.ToDateTime(rdr["DateCreated"]);
          lst.Add(rec);
        }
      }
      return lst;
    }

    #endregion

  }
}
