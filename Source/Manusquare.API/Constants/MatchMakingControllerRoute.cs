namespace Manusquare.API.Constants
{
    public class MatchmakingControllerRoute
    {
        public const string GetAllSuppliers = ControllerName.Matchmaking + nameof(GetAllSuppliers);
        public const string GetAllBuyers = ControllerName.Matchmaking + nameof(GetAllBuyers);
        public const string GetAllTransactionalData = ControllerName.Matchmaking + nameof(GetAllTransactionalData);
        public const string GetAllOffers = ControllerName.Matchmaking + nameof(GetAllOffers);
        public const string GetOfferForOrder = ControllerName.Matchmaking + nameof(GetOfferForOrder);
        public const string GetMatch = ControllerName.Matchmaking + nameof(GetMatch);
    }
}