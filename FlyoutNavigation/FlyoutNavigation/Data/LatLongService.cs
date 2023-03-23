using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyoutNavigation.Data
{
    public class LatLongService : ILatLongService
    {
        public async Task<(double Latitude, double Longitude)> GetLatLong()
        {
            var latLoc = 0.0;
            var longLoc = 0.0;
#if DEBUG
            // 沖縄県
            latLoc = 26.212;
            longLoc = 127.681;
            return (latLoc, longLoc);
#else
            var status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            if (status == PermissionStatus.Granted)
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromSeconds(10));
                var location = await Geolocation.GetLocationAsync(request);
                latLoc = location.Latitude;
                longLoc = location.Longitude;
            }
            return (latLoc, longLoc);
#endif
        }
    }
}
