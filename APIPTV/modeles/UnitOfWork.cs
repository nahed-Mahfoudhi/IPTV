using APIPTV.modeles;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;



namespace APIPTV.DAL
{
 
        public class UnitOfWork : IDisposable
        {
            private TRANSFERDB_TESTEntities3 context = new TRANSFERDB_TESTEntities3();

        private GenericRepository<IMPH_IMPORT_HEADER> iMPH_IMPORT_HEADERRepository;
        private GenericRepository<IORA_ORDER_ACTIONPOINT> iORA_ORDER_ACTIONPOINTRepository;
        private GenericRepository<IAPO_ACTIONPOINT_OPENINGHOUR> iAPO_ACTIONPOINT_OPENINGHOURRepository;
        public GenericRepository<IMPH_IMPORT_HEADER> IMPH_IMPORT_HEADERRepository
        {
                get
                {
                    return this.iMPH_IMPORT_HEADERRepository ?? new GenericRepository<IMPH_IMPORT_HEADER>(context);
                }
         }


        public GenericRepository<IORA_ORDER_ACTIONPOINT> IORA_ORDER_ACTIONPOINTRepository
        {
            get
            {
                return this.iORA_ORDER_ACTIONPOINTRepository ?? new GenericRepository<IORA_ORDER_ACTIONPOINT>(context);
            }
        }

 
        public GenericRepository<IAPO_ACTIONPOINT_OPENINGHOUR> IAPO_ACTIONPOINT_OPENINGHOURRepository
        {
            get
            {
                return this.iAPO_ACTIONPOINT_OPENINGHOURRepository ?? new GenericRepository<IAPO_ACTIONPOINT_OPENINGHOUR>(context);
            }
        }

 
        public void Save()
            {
                context.SaveChanges();
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