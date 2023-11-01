using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Model;
using Ecommerce.Repository.Contract;
using Ecommerce.Repository.DBContext;

namespace Ecommerce.Repository.Implementation
{
    public class VentaRepository:GenericRepository<Venta>, IVentaRepository
    {
        private readonly DbecommerceContext _dbContext;

        public VentaRepository(DbecommerceContext dbContext):base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Venta> Register(Venta model)
        {
            Venta ventaGenerada =  new Venta();
            using (var transaction = this._dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (DetalleVenta dv in model.DetalleVenta) 
                    {
                        Producto producto_encontrado = this._dbContext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();

                        producto_encontrado.Cantidad -= dv.Cantidad;
                        this._dbContext.Productos.Update(producto_encontrado);
                    }
                    await this._dbContext.SaveChangesAsync();

                    await this._dbContext.Venta.AddAsync(model);
                    await this._dbContext.SaveChangesAsync();
                    ventaGenerada = model;
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }

            }
            return ventaGenerada;
        }
    }
}
