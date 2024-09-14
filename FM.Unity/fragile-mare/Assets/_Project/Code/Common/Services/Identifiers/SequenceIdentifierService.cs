namespace _Project.Code.Common.Services.Identifiers
{
    public class SequenceIdentifierService : IIdentifierService
    {
        private int _currentId;
        
        public int Next()
        {
            return _currentId++;
        }
    }
}