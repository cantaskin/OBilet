using Application.Services.LocationService;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

public class GoogleLocationServiceAdapter : LocationServiceBase
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = ""; //Bunu jsondan almamız lazım

    public GoogleLocationServiceAdapter(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public override async Task<Tuple<decimal, decimal>> GetDistanceAndDurationInMinutes(string fromStationName, string toStationName)
    {
        var fromCoords = await GetCoordinatesAsync(fromStationName);
        var toCoords = await GetCoordinatesAsync(toStationName);

        var url = $"https://maps.googleapis.com/maps/api/directions/json?origin={fromCoords.lat},{fromCoords.lng}&destination={toCoords.lat},{toCoords.lng}&key={_apiKey}";

        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var doc = JsonDocument.Parse(json);

        var route = doc.RootElement.GetProperty("routes").EnumerateArray().FirstOrDefault();
        if (route.ValueKind == JsonValueKind.Undefined)
            throw new Exception("No route found between the coordinates.");

        var leg = route.GetProperty("legs").EnumerateArray().First();

        var distanceInMeters = leg.GetProperty("distance").GetProperty("value").GetInt32();
        var durationInSeconds = leg.GetProperty("duration").GetProperty("value").GetInt32();

        var distanceKm = Math.Round((decimal)distanceInMeters / 1000, 2);
        var durationMinutes = Math.Round((decimal)durationInSeconds / 60, 2);

        return Tuple.Create(distanceKm, durationMinutes);
    }


    private async Task<(double lat, double lng)> GetCoordinatesAsync(string locationName)
    {
        var url = $"https://maps.googleapis.com/maps/api/geocode/json?address={Uri.EscapeDataString(locationName)}&key={_apiKey}";
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        var doc = JsonDocument.Parse(json);

        var location = doc.RootElement
            .GetProperty("results").EnumerateArray().FirstOrDefault()
            .GetProperty("geometry").GetProperty("location");

        var lat = location.GetProperty("lat").GetDouble();
        var lng = location.GetProperty("lng").GetDouble();

        return (lat, lng);
    }

}