using AutoMapper;
using MedicalCenters.Application.DTOs;
using MedicalCenters.Application.Features.Medicine.Commands;
using MedicalCenters.Application.Mapping.MappingProfiles;
using MedicalCenters.Application.Responses;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalCenters.Domain.Abstractions;

namespace MedicalCenters.Application.UnitTests.Medicine
{
    public class DeleteMedicineCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly DeleteMedicineCommandHandler _handler;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMedicineRepository _medicineRepository;

        public DeleteMedicineCommandHandlerTests()
        {
            _medicineRepository = Substitute.For<IMedicineRepository>();
            _unitOfWork = Substitute.For<IUnitOfWork>();

            var mapConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<AutoMapperProfile>();
            });

            _mapper = mapConfig.CreateMapper();
            _handler = new DeleteMedicineCommandHandler(_medicineRepository, _unitOfWork, _mapper);
        }

        [Theory]
        [InlineData(1)]
        public async Task CreateMedicine_MedicineRepository_IsCalled(int medicine)
        {
            var result = (BaseResponse)await _InitResult(medicine);
            _medicineRepository.Received();
        }

        
        private async Task<object> _InitResult(int medicineId)
        {
            var command = new DeleteMedicineCommand() { Id = medicineId };

            _medicineRepository.ExistAsync(medicineId).Returns(true);

            _medicineRepository.DeleteAsync(command.Id)
                .Returns(Task.CompletedTask);

            return await _handler.Handle(command, CancellationToken.None);
        }
    }
}
