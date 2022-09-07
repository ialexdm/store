using Store.Contractors;
using Store.Web.Contractors;


namespace Store.YandexKassa
{
    public class YandexKassaPaymentService : IPaymentService, IWebContractorService
    {
        public string UniqueCode => "YandexKassa";

        public string GetUri => "/YandexKassa/home";

        public string Title => "Cash by card";

        public Form CreateForm(Order order)
        {
            return new Form(UniqueCode, order.Id, 1, true, new Field[0]);
        }

        public OrderPayment GetPayment(Form form)
        {
            return new OrderPayment(UniqueCode, "Pay by card", new Dictionary<string, string>() );
        }

        public Form MoveNextForm(int orderId, int step, IReadOnlyDictionary<string, string> keyValuePairs)
        {
            return new Form(UniqueCode, orderId, 2, true, new Field[0]);
        }
    }
}
