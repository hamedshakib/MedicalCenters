using AutoMapper;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Features.Medicine.Commands;
using MedicalCenters.Application.Mapping.MappingProfiles;
using MedicalCenters.Application.Responses;
using NSubstitute;
using System.Runtime.CompilerServices;

namespace MedicalCenters.Application.UnitTests.Medicine
{
    public class CreateMedicineCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly CreateMedicineCommandHandler _handler;
        private readonly MedicineDto _MedicineDto;
        private readonly IMedicalCentersUnitOfWork _unitOfWork;

        public CreateMedicineCommandHandlerTests()
        {
            _MedicineDto = new MedicineDto()
            {
                Name = "Medicine test",
                TypeId = 1
            };

            _unitOfWork = Substitute.For<IMedicalCentersUnitOfWork>();

            var mapConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<AutoMapperProfile>();
            });

            _mapper = mapConfig.CreateMapper();
            _handler = new CreateMedicineCommandHandler(_unitOfWork, _mapper);
        }


        [Fact]
        public async Task CreateMedicine_MedicineRepository_IsCalled()
        {
            var result = (BaseValuedCommandResponse)await InitResult();
            _unitOfWork.MedicineRepository.Received();
        }

        [Fact]
        public async Task CreateMedicine_HandlerResult_IsValidTyped()
        {
            var result = (BaseValuedCommandResponse)await InitResult();
            Assert.IsType<BaseValuedCommandResponse>(result);
        }

        [Fact]
        public async Task CreateMedicine_HandlerResultIsSuccess_IsTrue()
        {
            var result = (BaseValuedCommandResponse)await InitResult();
            Assert.True(result.IsSuccess);
        }

        private async Task<object> InitResult()
        {
            var command = new CreateMedicineCommand() { MedicineDto = _MedicineDto };
            var data = _mapper.Map<MedicalCenters.Domain.Entities.Medicines.Medicine>(command.MedicineDto);
            data.Id = 1;
            _unitOfWork.MedicineRepository.Add(Arg.Any<MedicalCenters.Domain.Entities.Medicines.Medicine>())
                .Returns(data);

            return await _handler.Handle(command, CancellationToken.None);
        }
    }
}
