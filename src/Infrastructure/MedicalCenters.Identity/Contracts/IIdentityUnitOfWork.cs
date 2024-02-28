namespace MedicalCenters.Identity.Contracts
{
    public interface IIdentityUnitOfWork : IDisposable
    {
        Task Save();

        IAuthenticationRepository AuthenticationRepository { get; }
        IAuthorizationRepository AuthorizationRepository { get; }
    }
}
