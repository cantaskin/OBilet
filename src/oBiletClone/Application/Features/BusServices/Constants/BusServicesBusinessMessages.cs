namespace Application.Features.BusServices.Constants;

public static class BusServicesBusinessMessages
{
    public const string SectionName = "BusService";

    public const string BusServiceNotExists = "BusServiceNotExists";

    public const string NoBusServiceCreated = "NoBusServiceCreated";

    public const string BeAValidStartTime = "BeAValidStartTime";

    public const string BusServiceStationsShouldGreaterThanOne = "BusServiceStationsShouldGreaterThanOne";

    public const string BusServiceStartTimeShouldBeBeforeFinishTime = "BusServiceStartTimeShouldBeBeforeFinishTime";
}