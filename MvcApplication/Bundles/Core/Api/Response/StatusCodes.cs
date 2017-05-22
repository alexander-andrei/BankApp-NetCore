namespace MvcApplication.Bundles.Core.Api.Response
{
    public class StatusCodes
    {
        private const int Success = 200;
        private const int Fail = 401;

        public int GetStatusCode(bool status)
        {
            return (status) ? Success : Fail;
        }
    }
}