namespace BlazorTrails.ComponentLibrary.Map;
public class LatLong
{
    public decimal Lat { get; set; }
    public decimal Lng { get; set; }

    public LatLong(decimal latitude, decimal longitude)
    {
        Lat = latitude;
        Lng = longitude;
    }
}
