using AutoMapper;
using MedicalCenters.Application.Contracts.Persistence;
using MedicalCenters.Application.DTOs.Medicine;
using MedicalCenters.Application.Features.Medicine.Handlers.Commands;
using MedicalCenters.Application.Features.Medicine.Requests.Commands;
using MedicalCenters.Application.Mapping.MappingProfiles;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenters.Application.UnitTests.Medicine
{

    public class CreateMedicineMappingTests
    {
        private readonly IMapper _mapper;
        private readonly CreateMedicineCommandHandler _handler;
        private readonly CreateMedicineDto _createMedicineDto;
        private readonly IMedicalCentersUnitOfWork _unitOfWork;
        public CreateMedicineMappingTests()
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
        public async Task CreateMedicineMapping_createMedicineDto_NotNull()
        {
            var data = InitMappedMedicineData();

            Assert.NotNull(data);
        }

        [Fact]
        public async Task CreateMedicineMapping_createMedicineDto_NameIsNotNull()
        {
            var data = InitMappedMedicineData();

            Assert.NotNull(data.Name);
        }

        [Fact]
        public async Task CreateMedicineMapping_createMedicineDto_TypeIdIsNotNull()
        {
            var data = InitMappedMedicineData();

            Assert.NotNull(data.TypeId);
        }
        private MedicalCenters.Domain.Entities.Medicines.Medicine? InitMappedMedicineData()
        {
            var command = new CreateMedicineCommand() { CreateMedicineDto = _createMedicineDto };
            return _mapper.Map<MedicalCenters.Domain.Entities.Medicines.Medicine>(command.CreateMedicineDto);
        }

    }
}
