
using Microsoft.EntityFrameworkCore;

namespace ClientesApi.DataModel
{
    public class CustomerdbContext : DbContext
    {

        public CustomerdbContext(DbContextOptions<CustomerdbContext> options) : base(options) 
        {
            


        }


    }
}
