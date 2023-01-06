using Data.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Data.Interfaces
{
    public interface IUnitOfWork
    {

        GenericRepository<Cliente> ClienteRepository { get; }
        GenericRepository<Producto> ProductoRepository { get; }
        GenericRepository<Venta> VentaRepository { get; }
        GenericRepository<VentaDetalle> VentaDetalleRepository { get; }
        GenericRepository<Localidad> LocalidadRepository { get; }

        public void Save();
        void Dispose();
    }
}
