using System;

namespace Store
{
    public interface IOrderRepository
    {
        Order Create();

        Order Update(Order order);

        Order GetById(int id);

    }
}
