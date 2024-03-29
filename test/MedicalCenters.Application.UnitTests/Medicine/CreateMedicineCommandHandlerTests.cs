﻿using AutoMapper;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs.Medicine;
using MedicalCenters.Application.Features.Medicine.Handlers.Commands;
using MedicalCenters.Application.Features.Medicine.Requests.Commands;
using MedicalCenters.Application.Mapping.MappingProfiles;
using MedicalCenters.Application.Responses;
using NSubstitute;

namespace MedicalCenters.Application.UnitTests.Medicine
{
    public class CreateMedicineCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly CreateMedicineCommandHandler _handler;
        private readonly CreateMedicineDto _createMedicineDto;
        private readonly IMedicalCentersUnitOfWork _unitOfWork;

        public CreateMedicineCommandHandlerTests()
        {
            _createMedicineDto = new CreateMedicineDto()
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
            var command = new CreateMedicineCommand() { CreateMedicineDto = _createMedicineDto };
            var data = _mapper.Map<MedicalCenters.Domain.Entities.Medicines.Medicine>(command.CreateMedicineDto);
            data.Id = 1;
            _unitOfWork.MedicineRepository.Add(Arg.Any<MedicalCenters.Domain.Entities.Medicines.Medicine>())
                .Returns(data);

            return await _handler.Handle(command, CancellationToken.None);
        }
    }
}
