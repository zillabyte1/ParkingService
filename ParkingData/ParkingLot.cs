using System;

namespace ParkingData
{

  public class ParkingLot
  {
    public string LotKey { get; set; }

    public int MaxSpaces { get; set; }

    public int Occupied { get; set; }

    public int Available => (int)(MaxSpaces - Occupied);

    public double PercentValue {
      get {
        double rtn = 0;
        try {
          rtn = (double) Math.Abs(Occupied) / (double) Math.Abs(MaxSpaces);
        }  catch {
          rtn = 0;
        }
        return rtn;
      }
    }

    public string PercentFilled
    {
      get
      {
        string rtn = "0%";
        try
        {
          rtn = String.Format("{0:P0}", this.PercentValue);
        }
        catch
        {
          rtn = "0%";
        }
        return rtn;
      }
    }

    //public double PercentValue => (double)(Occupied / MaxSpaces);

    //public string PercentFilled => String.Format("{0:P0}.", this.PercentValue);

    public DateTime LastUpdated { get; set; }


  }


}
