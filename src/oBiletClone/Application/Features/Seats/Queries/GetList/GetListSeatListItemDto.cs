using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Seats.Queries.GetList;

public class GetListSeatListItemDto : IDto
{
    public int BusId { get; set; }
    public int LocalSeatId { get; set; }

    //Neighbour Seat But Local Type Yani BusInsideSeatId
    public int? LeftSeatId { get; set; }
    public int? RightSeatId { get; set; }
    public int? TopSeatId { get; set; }
    public int? BottomSeatId { get; set; }

}