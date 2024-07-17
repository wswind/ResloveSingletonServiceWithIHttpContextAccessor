namespace WebApplication1
{
    public class TestService
    {
        public TestService()
        {
            guid = Guid.NewGuid();
        }

        private Guid guid { get; }

        public Guid GetGuid()
        {
            return guid;
        }
    }
}
