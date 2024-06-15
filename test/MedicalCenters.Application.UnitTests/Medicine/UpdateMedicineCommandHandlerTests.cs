using AutoMapper;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Features.Medicine.Commands;
using MedicalCenters.Application.Mapping.MappingProfiles;
using MedicalCenters.Application.Responses;
using MedicalCenters.Domain.Contracts;
using MedicalCenters.Domain.Entities.Medicines;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace MedicalCenters.Application.UnitTests.Medicine
{
    public class UpdateMedicineCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly UpdateMedicineCommandHandler _handler;
        private readonly MedicineDto _MedicineDto;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMedicineRepository _medicineRepository;

        public UpdateMedicineCommandHandlerTests()
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
            _handler = new UpdateMedicineCommandHandler(_medicineRepository, _unitOfWork, _mapper);
        }


        [Fact]
        public async Task UpdateMedicine_MedicineRepository_IsCalled()
        {
            int medicineId = 1;
            var result = (BaseResponse)await InitResult(medicineId);
            _medicineRepository.Received();

        }

        [Fact]
        public async Task UpdateMedicine_HandlerResult_IsValidTyped()
        {
            int medicineId = 1;
            var result = (BaseResponse)await InitResult(medicineId);
            Assert.IsType<BaseResponse>(result);
        }

        [Fact]
        public async Task UpdateMedicine_HandlerResultIsSuccess_IsTrue()
        {
            int medicineId = 1;
            var result = (BaseResponse)await InitResult(medicineId);
            Assert.True(result.IsSuccess);
        }

        private async Task<object> InitResult(int medicineId)
        {
            var command = new UpdateMedicineCommand() {  Id = medicineId, MedicineDto = _MedicineDto };

            var data = _mapper.Map<MedicalCenters.Domain.Entities.Medicines.Medicine>(command.MedicineDto);
            data.Id = medicineId;
            data.TypeId = 2;

            _mapper.Map(command.MedicineDto, data);


            _medicineRepository.Get(medicineId)
                .Returns(data);


            _medicineRepository.Update(data).Returns(Task.CompletedTask);
            _unitOfWork.SaveChangesAsync(CancellationToken.None).Returns(true);

            return await _handler.Handle(command, CancellationToken.None);
        }
    }
}
