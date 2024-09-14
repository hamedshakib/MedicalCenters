using AutoMapper;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Features.Medicine.Commands;
using MedicalCenters.Application.Mapping.MappingProfiles;
using MedicalCenters.Application.Responses;
using MedicalCenters.Domain.Contracts;
using MedicalCenters.Domain.Entities.Medicines;
using NSubstitute;
using System.Runtime.CompilerServices;

namespace MedicalCenters.Application.UnitTests.Medicine
{
    public class CreateMedicineCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly CreateMedicineCommandHandler _handler;
        private readonly MedicineDto _MedicineDto;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMedicineRepository _medicineRepository;

        public CreateMedicineCommandHandlerTests()
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
        public async Task CreateMedicine_MedicineRepository_IsCalled()
        {
            var result = (BaseValuedCommandResponse<int>)await InitResult();
            _medicineRepository.Received();
        }

        [Fact]
        public async Task CreateMedicine_HandlerResult_IsValidTyped()
        {
            var result = (BaseValuedCommandResponse<int>)await InitResult();
            Assert.IsType<BaseValuedCommandResponse<int>>(result);
        }

        [Fact]
        public async Task CreateMedicine_HandlerResultIsSuccess_IsTrue()
        {
            var result = (BaseValuedCommandResponse<int>)await InitResult();
            Assert.True(result.IsSuccess);
        }

        private async Task<object> InitResult()
        {
            var command = new CreateMedicineCommand() { MedicineDto = _MedicineDto };
            var data = _mapper.Map<Domain.Entities.Medicines.Medicine>(command.MedicineDto);
            data.Id = 1;
            _medicineRepository.AddAsync(Arg.Any<Domain.Entities.Medicines.Medicine>())
                .Returns(data);

            return await _handler.Handle(command, CancellationToken.None);
        }
    }
}
