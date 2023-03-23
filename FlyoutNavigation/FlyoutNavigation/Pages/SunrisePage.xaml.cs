using FlyoutNavigation.Data;

namespace FlyoutNavigation.Pages;

// This page displays sunrise and sunset times for locations on Earth. The data is provided by the Sunrise Sunset web service.
// https://sunrise-sunset.org/api
public partial class SunrisePage : ContentPage
{
    ILatLongService LatLongService { get; set; }
    public SunrisePage()
    {
        InitializeComponent();
        LatLongService = new LatLongService();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        activityWaiting.IsRunning = true;
        var sunriseSunsetData = await GetSunriseSunsetData();
        InitializeUI(sunriseSunsetData.Item1, sunriseSunsetData.Item2, sunriseSunsetData.Item3);
        activityWaiting.IsRunning = false;
    }

    async Task<(DateTime, DateTime, TimeSpan)> GetSunriseSunsetData()
    {

        var latLongData = await LatLongService.GetLatLong();
        var sunData = await new SunriseService().GetSunriseSunsetTimes(latLongData.Latitude, latLongData.Longitude);

        var riseTime = sunData.Sunrise.ToLocalTime();
        var setTime = sunData.Sunset.ToLocalTime();
        var span = setTime.TimeOfDay - riseTime.TimeOfDay;
        return (riseTime, setTime, span);
    }

    void InitializeUI(DateTime riseTime, DateTime setTime, TimeSpan span)
    {
        lblDate.Text = DateTime.Today.ToString("D");
        lblSunrise.Text = riseTime.ToString("h:mm tt");
        lblDaylight.Text = $"{span.Hours} hours, {span.Minutes} minutes";
        lblSunset.Text = setTime.ToString("h:mm tt");
    }
}