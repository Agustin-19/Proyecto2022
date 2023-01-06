using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private DataBase2022Context context = new DataBase2022Context();
        private GenericRepository<Cliente>? clienteRepository;
        private GenericRepository<Producto>? productoRepository;
        private GenericRepository<Venta>? ventaRepository;
        private GenericRepository<VentaDetalle>? ventaDetalleRepository;
        private GenericRepository<Localidad>? localidadRepository;
        


        public GenericRepository<Cliente> ClienteRepository
        {
            get
            {

                if (this.clienteRepository == null)
                {
                    this.clienteRepository = new GenericRepository<Cliente>(context);
                }
                return clienteRepository;
            }
        }
        public GenericRepository<Producto> ProductoRepository
        {
            get
            {

                if (this.productoRepository == null)
                {
                    this.productoRepository = new GenericRepository<Producto>(context);
                }
                return productoRepository;
            }
        }
        public GenericRepository<Venta> VentaRepository
        {
            get
            {

                if (this.ventaRepository == null)
                {
                    this.ventaRepository = new GenericRepository<Venta>(context);
                }
                return ventaRepository;
            }
        }

        public GenericRepository<VentaDetalle> VentaDetalleRepository
        {
            get
            {

                if (this.ventaDetalleRepository == null)
                {
                    this.ventaDetalleRepository = new GenericRepository<VentaDetalle>(context);
                }
                return ventaDetalleRepository;
            }
        }
        public GenericRepository<Localidad> LocalidadRepository
        {
            get
            {

                if (this.localidadRepository == null)
                {
                    this.localidadRepository = new GenericRepository<Localidad>(context);
                }
                return localidadRepository;
            }
        }


        public void Save()
        {
            context.SaveChanges();
            context.ChangeTracker.Clear();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
