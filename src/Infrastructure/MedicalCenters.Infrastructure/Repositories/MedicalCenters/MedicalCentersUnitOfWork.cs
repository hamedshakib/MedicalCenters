using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Infrastructure.DBContexts;

namespace MedicalCenters.Persistence.Repositories.MedicalCenters
{
    public class MedicalCentersUnitOfWork : IMedicalCentersUnitOfWork
    {
        private readonly MedicalCentersDBContext _dBContext;

        public MedicalCentersUnitOfWork(MedicalCentersDBContext dBContext)
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
