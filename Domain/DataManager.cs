using VIATECH.Domain.Repositories.Abstract;

namespace VIATECH.Domain
{
    public class DataManager
    {
        public ITextFieldsRepository? TextFields { get; set; }
        public IServiceItemsRepository? ServiceItems { get; set; }
        public IOrderRepository? Orders { get; set; }

        public DataManager(ITextFieldsRepository textFieldsRepository, IServiceItemsRepository serviceItemsRepository, IOrderRepository orderRepository)
        {
            TextFields = textFieldsRepository;
            ServiceItems = serviceItemsRepository;
            Orders = orderRepository;
        }
    }
}
