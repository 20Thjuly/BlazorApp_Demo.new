using eShop.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.OrderConfirmationScreen
{
    public interface IViewOrderConfirmationUseCase
    {
        Order? Execute(string uniqueId);
    }
}
