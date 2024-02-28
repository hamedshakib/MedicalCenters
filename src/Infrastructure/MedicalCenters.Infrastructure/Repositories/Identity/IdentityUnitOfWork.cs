using MedicalCenters.Identity.Contracts;
using MedicalCenters.Persistence.DBContexts;

namespace MedicalCenters.Persistence.Repositories.Identity
{
    internal class IdentityUnitOfWork : IIdentityUnitOfWork
    {
        private readonly IdentityDBContext _dBContext;

        private IAuthenticationRepository _athenticationRepository;
        public IAuthenticationRepository AuthenticationRepository => _athenticationRepository ??= new AthenticationRepository(_dBContext);

        private IAuthorizationRepository _authorizationRepository;
        public IAuthorizationRepository AuthorizationRepository => _authorizationRepository ??= new AuthorizationRepository(_dBContext);


        public IdentityUnitOfWork(IdentityDBContext dBContext)
        {
            _dBContext = dBContext;
        }
        public async Task Save()
        {
            //long UserId = 
            await _dBContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _dBContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
