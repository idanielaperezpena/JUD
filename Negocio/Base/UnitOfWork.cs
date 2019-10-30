using Datos;
using Entidades.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UnitOfWork
    {
        private DatabaseContext _context;
        private CatalogosRepository _catsRepo;
        private ErrorLogRepository _errorRepo;
        private UsuarioRepository _usrRepo;
        private ParejaRepository _parejaRepo;
        private DeudorSolidarioRepository _deudorRepo;
        private CiudadanoRepository _ciudadanoRepo;
        private DomicilioCiudadanoRepository _domiciliociudadanoRepo;
        private DomicilioRepository _domicilioRepo;
        private SeccionElectoralRepository _seccionRepo;

        private EmailUtility _emailSender;
        private EncriptarUtility _encriptador;

        public UnitOfWork()
        {
            _context = new DatabaseContext();
        }

        public CatalogosRepository Catalogos
        {
            get
            {
                if (_catsRepo == null)
                    _catsRepo = new CatalogosRepository(_context);

                return _catsRepo;
            }
        }

        public ErrorLogRepository ErrorLog
        {
            get
            {
                if (_errorRepo == null)
                    _errorRepo = new ErrorLogRepository(_context);

                return _errorRepo;
            }
        }

        public UsuarioRepository Usuarios
        {
            get
            {
                if (_usrRepo == null)
                    _usrRepo = new UsuarioRepository(_context);

                return _usrRepo;
            }
        }


        public ParejaRepository Pareja
        {
            get
            {
                if (_parejaRepo == null)
                    _parejaRepo = new ParejaRepository(_context);

                return _parejaRepo;
            }
        }
        public DeudorSolidarioRepository DeudorSolidario
        {
            get
            {
                if (_deudorRepo == null)
                    _deudorRepo = new DeudorSolidarioRepository(_context);

                return _deudorRepo;
            }
        }

        public CiudadanoRepository Ciudadano
        {
            get
            {
                if (_ciudadanoRepo == null)
                    _ciudadanoRepo = new CiudadanoRepository(_context);

                return _ciudadanoRepo;
            }
        }

        public DomicilioCiudadanoRepository DomicilioCiudadano
        {
            get
            {
                if (_domiciliociudadanoRepo == null)
                    _domiciliociudadanoRepo = new DomicilioCiudadanoRepository(_context);

                return _domiciliociudadanoRepo;
            }
        }
        public DomicilioRepository Domicilio
        {
            get
            {
                if (_domicilioRepo == null)
                    _domicilioRepo = new DomicilioRepository(_context);

                return _domicilioRepo;
            }
        }

        public SeccionElectoralRepository SeccionElectoral
        {
            get
            {
                if (_seccionRepo == null)
                    _seccionRepo = new SeccionElectoralRepository(_context);

                return _seccionRepo;
            }
        }


        public EmailUtility EmailSender
        {
            get
            {
                if (_emailSender == null)
                    _emailSender = new SendGridEmailUtility(SettingsProvider.SendgridApiKey, SettingsProvider.EmailNombre, SettingsProvider.EmailDireccion);

                return _emailSender;
            }
        }

        public EncriptarUtility Encriptador
        {
            get
            {
                if (_encriptador == null)
                    _encriptador = new EncriptarUtility();

                return _encriptador;
            }
        }
    }
}
