using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.Buses.Constants;
using Application.Features.BusServices.Constants;
using Application.Features.Personels.Constants;
using Application.Features.Seats.Constants;
using Application.Features.Stations.Constants;
using Application.Features.Tickets.Constants;
using Application.Features.Campaigns.Constants;
using Application.Features.BusServiceStations.Constants;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion

        
        #region Buses CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BusesOperationClaims.Admin },
                new() { Id = ++lastId, Name = BusesOperationClaims.Read },
                new() { Id = ++lastId, Name = BusesOperationClaims.Write },
                new() { Id = ++lastId, Name = BusesOperationClaims.Create },
                new() { Id = ++lastId, Name = BusesOperationClaims.Update },
                new() { Id = ++lastId, Name = BusesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region BusServices CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BusServicesOperationClaims.Admin },
                new() { Id = ++lastId, Name = BusServicesOperationClaims.Read },
                new() { Id = ++lastId, Name = BusServicesOperationClaims.Write },
                new() { Id = ++lastId, Name = BusServicesOperationClaims.Create },
                new() { Id = ++lastId, Name = BusServicesOperationClaims.Update },
                new() { Id = ++lastId, Name = BusServicesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Personels CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PersonelsOperationClaims.Admin },
                new() { Id = ++lastId, Name = PersonelsOperationClaims.Read },
                new() { Id = ++lastId, Name = PersonelsOperationClaims.Write },
                new() { Id = ++lastId, Name = PersonelsOperationClaims.Create },
                new() { Id = ++lastId, Name = PersonelsOperationClaims.Update },
                new() { Id = ++lastId, Name = PersonelsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Seats CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = SeatsOperationClaims.Admin },
                new() { Id = ++lastId, Name = SeatsOperationClaims.Read },
                new() { Id = ++lastId, Name = SeatsOperationClaims.Write },
                new() { Id = ++lastId, Name = SeatsOperationClaims.Create },
                new() { Id = ++lastId, Name = SeatsOperationClaims.Update },
                new() { Id = ++lastId, Name = SeatsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Stations CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = StationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = StationsOperationClaims.Read },
                new() { Id = ++lastId, Name = StationsOperationClaims.Write },
                new() { Id = ++lastId, Name = StationsOperationClaims.Create },
                new() { Id = ++lastId, Name = StationsOperationClaims.Update },
                new() { Id = ++lastId, Name = StationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Tickets CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = TicketsOperationClaims.Admin },
                new() { Id = ++lastId, Name = TicketsOperationClaims.Read },
                new() { Id = ++lastId, Name = TicketsOperationClaims.Write },
                new() { Id = ++lastId, Name = TicketsOperationClaims.Create },
                new() { Id = ++lastId, Name = TicketsOperationClaims.Update },
                new() { Id = ++lastId, Name = TicketsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Campaigns CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CampaignsOperationClaims.Admin },
                new() { Id = ++lastId, Name = CampaignsOperationClaims.Read },
                new() { Id = ++lastId, Name = CampaignsOperationClaims.Write },
                new() { Id = ++lastId, Name = CampaignsOperationClaims.Create },
                new() { Id = ++lastId, Name = CampaignsOperationClaims.Update },
                new() { Id = ++lastId, Name = CampaignsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region BusServiceStations CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BusServiceStationsOperationClaims.Admin },
                new() { Id = ++lastId, Name = BusServiceStationsOperationClaims.Read },
                new() { Id = ++lastId, Name = BusServiceStationsOperationClaims.Write },
                new() { Id = ++lastId, Name = BusServiceStationsOperationClaims.Create },
                new() { Id = ++lastId, Name = BusServiceStationsOperationClaims.Update },
                new() { Id = ++lastId, Name = BusServiceStationsOperationClaims.Delete },
            ]
        );
        #endregion
        
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
