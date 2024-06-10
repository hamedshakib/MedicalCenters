namespace MedicalCenters.Application.Contracts.Persistence
{
    public interface IMedicalCentersUnitOfWork : IDisposable
    {
        Task Save();
    }
}
