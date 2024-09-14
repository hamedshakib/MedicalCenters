using AutoMapper;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Features.Medicine.Commands;
using MedicalCenters.Application.Mapping.MappingProfiles;
using MedicalCenters.Domain.Abstractions;
using NSubstitute;

namespace MedicalCenters.Application.UnitTests.Medicine
{

    public class CreateMedicineMappingTests
    {
        private readonly IMapper _mapper;
        private readonly CreateMedicineCommandHandler _handler;
        private readonly MedicineDto _MedicineDto;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMedicineRepository _medicineRepository;

        public CreateMedicineMappingTests()
        {
            _MedicineDto = new MedicineDto()
            {
                Name = "Medicine test",
                TypeId = 1
            };

            _medicineRepository = Substitute.For<IMedicineRepository>();
            _unitOfWork = Substitute.For<IUnitOfWork>();

            var mapConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<AutoMapperProfile>();
            });

            _mapper = mapConfig.CreateMapper();
            _handler = new CreateMedicineCommandHandler(_medicineRepository, _unitOfWork, _mapper);
        }
        [Fact]
        public Task CreateMedicineMapping_MedicineDto_NotNull()
        {
            var data = _InitMappedMedicineData();

            Assert.NotNull(data);
            return Task.CompletedTask;
        }

        [Fact]
        public Task CreateMedicineMapping_MedicineDto_NameIsNotNull()
        {
            var data = _InitMappedMedicineData();

            Assert.NotNull(data.Name);
            return Task.CompletedTask;
        }

        [Fact]
        public Task CreateMedicineMapping_MedicineDto_TypeIdIsNotNull()
        {
            var data = _InitMappedMedicineData();

            Assert.NotNull(data.TypeId);
            return Task.CompletedTask;
        }
        private Domain.Entities.Medicines.Medicine? _InitMappedMedicineData()
        {
            var command = new CreateMedicineCommand() { MedicineDto = _MedicineDto };
            return _mapper.Map<Domain.Entities.Medicines.Medicine>(command.MedicineDto);
        }

    }
}
