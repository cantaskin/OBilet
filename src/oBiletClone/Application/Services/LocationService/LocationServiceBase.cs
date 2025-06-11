using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.LocationService;
public abstract class LocationServiceBase
{
    public abstract Task<Tuple<decimal,decimal>> GetDistanceAndDurationInMinutes(string fromStationName, string toStationName);

}
