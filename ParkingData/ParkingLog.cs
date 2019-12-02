using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingData
{
  public class ParkingLog
  {
    public int LogId { get; set; }

    public string LotKey { get; set; }

    public string ActionType { get; set; }

    public int ActionValue { get; set; }

    public DateTime DateCreated { get; set; }

  }
}
