namespace MedicalCenters.Application.Contracts.Persistence
{
    public interface IMedicalCentersUnitOfWork : IDisposable
    {
        Task Save();

        IMedicalCenterRepository MedicalCenterRepository { get; }
        IMedicalWardRepository MedicalWardRepository { get; }
        IMedicineRepository MedicineRepository { get; }

    }
}
