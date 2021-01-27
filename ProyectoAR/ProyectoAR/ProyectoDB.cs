using System;
using SQLite;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAR
{
    public class ProyectoDB
    {
        readonly SQLiteAsyncConnection _database;

        public ProyectoDB(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            
            // Creacion de las tablas en la base de datos
            _database.CreateTableAsync<Pedido>().Wait();
            _database.CreateTableAsync<Venta>().Wait();
            _database.CreateTableAsync<Producto>().Wait();
        }

        // Tabla: Pedido
        public Task<List<Pedido>> GetPedidosAsync()
        {
            return _database.Table<Pedido>().ToListAsync();
        }

        public Task<Pedido> GetPedidoAsync(int id)
        {
            return _database.Table<Pedido>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> InsertPedidoAsync(Pedido pedido)
        {
            if(pedido.ID != 0)
            {
                return _database.UpdateAsync(pedido);
            } else
            {
                return _database.InsertAsync(pedido);
            }
        }

        

        public Task<int> DeletePedidoAsync(Pedido pedido)
        {
            return _database.DeleteAsync(pedido);
        }

        // Tabla: Venta
        public Task<List<Venta>> GetVentasAsync()
        {
            return _database.Table<Venta>().ToListAsync();
        }

        public Task<Venta> GetVentaAsync(int id)
        {
            return _database.Table<Venta>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> InsertVentaAsync(Venta venta)
        {
            if(venta.ID != 0)
            {
                return _database.UpdateAsync(venta);
            } else
            {
                return _database.InsertAsync(venta);
            }
        }

        public Task<int> InsertNuevaVenta(Venta venta)
        {
            return _database.InsertAsync(venta);
        }

        public Task<int> DeleteVentaAsync(Venta venta)
        {
            return _database.DeleteAsync(venta);
        }

        // Tabla Producto
        public Task<List<Producto>> GetProductosAsync()
        {
            return _database.Table<Producto>().ToListAsync();
        }

        public Task<Producto> GetProductoAsync(int id)
        {
            return _database.Table<Producto>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> InsertProductoAsync(Producto producto)
        {
            if(producto.ID != 0)
            {
                return _database.UpdateAsync(producto);
            } else
            {
                return _database.InsertAsync(producto);
            }
        }

        public Task<int> DeleteProductoAsync(Producto producto)
        {
            return _database.DeleteAsync(producto);
        }

    }
}
