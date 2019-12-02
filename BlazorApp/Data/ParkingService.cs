using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.Net.Http;

using Newtonsoft.Json;
using ParkingData;

namespace BlazorApp.Data {

  public class ParkingDataService {

    private readonly IHttpClientFactory _httpClientFactory;

    public ParkingDataService(IHttpClientFactory httpClientFactory) {
      _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
    }

    public async Task<IReadOnlyCollection<ParkingLot>> GetLocations() {
      var httpClient = _httpClientFactory.CreateClient();
      var result = await httpClient.GetStringAsync(Global.ApiUrl + "/api/parking/locations").ConfigureAwait(false);
      return JsonConvert.DeserializeObject<IReadOnlyCollection<ParkingLot>>(result);
    }

    public async Task<IReadOnlyCollection<ParkingLog>> GetLogs() {
      var httpClient = _httpClientFactory.CreateClient();
      var result = await httpClient.GetStringAsync(Global.ApiUrl + "/api/parking/logs").ConfigureAwait(false);
      return JsonConvert.DeserializeObject<IReadOnlyCollection<ParkingLog>>(result);
    }

    public async Task<ParkingLot> GetLocation(string id) {
      if (id == "") { 
        id = "AUSTIN-01"; 
      }

      var httpClient = _httpClientFactory.CreateClient();
      var result = await httpClient.GetStringAsync(Global.ApiUrl + "/api/parking/locations/" + id).ConfigureAwait(false);
      return JsonConvert.DeserializeObject<ParkingLot>(result);
    }

    public async Task<bool> AddAction(string lotkey, string action, int value) {
      
      try {

        var data = lotkey + ";" + action + ";" + value;
        var httpClient = _httpClientFactory.CreateClient();
        var result = await httpClient.GetStringAsync(Global.ApiUrl + "/api/parking/action/" + data).ConfigureAwait(false);

        return true;

      } catch (Exception e) {
        Console.WriteLine(e);
        throw;
      }
    }

  } //-- END CLASS
} //-- END NAMESPACE
