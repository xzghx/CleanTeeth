namespace CleanTeeth.Api.Utilities
{
    public static class HttpContextExtensions
    {
        public static void InsertPaginationInfoInHeader(this HttpContext context, int totalAmountOfRecords)
        {
            context.InsertPaginationInfoInHeader(totalAmountOfRecords);
        }

    }
}
