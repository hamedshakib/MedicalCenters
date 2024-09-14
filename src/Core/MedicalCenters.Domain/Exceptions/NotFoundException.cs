namespace MedicalCenters.Application.Exceptions
{
    public class NotFoundException(string _notFoundObjectType, string _id) : ApplicationException
    {
        public string NotFound_ObjectType { get; private set; } = _notFoundObjectType;
        public string Id { get; private set; } = _id;
    }
}
