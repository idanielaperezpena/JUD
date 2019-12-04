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
        private CreditoInicialRepository _creditoinicial;
        private CIDictamenJuridicoRepository _ciDictamenJuridico;
        private CIDictamenSocialRepository _ciDictamenSocial;
        private CIDictamenTecnicoRepository _ciDictamenTecnico;
        private CIDictamenFinancieroRepository _ciDictamenFinanciero;
        private CCDictamenJuridicoRepository _ccDictamenJuridico;
        private CCDictamenSocialRepository _ccDictamenSocial;
        private CCDictamenTecnicoRepository _ccDictamenTecnico;
        private CCDictamenFinancieroRepository _ccDictamenFinanciero;
        private CSDictamenJuridicoRepository _csDictamenJuridico;
        private CSDictamenSocialRepository _csDictamenSocial;
        private CSDictamenTecnicoRepository _csDictamenTecnico;
        private CSDictamenFinancieroRepository _csDictamenFinanciero;
        private MCDictamenJuridicoRepository _mcDictamenJuridico;
        private MCDictamenSocialRepository _mcDictamenSocial;
        private MCDictamenTecnicoRepository _mcDictamenTecnico;
        private MCDictamenFinancieroRepository _mcDictamenFinanciero;
        private PrincipalRepository _principal;
        private CreditoComplementarioRepository _creditocomplementario;
        private CreditoSustentabilidadRepositoy _creditoSustentabilidad;
        private ModificacionesCreditoRepository _modificacionesCredito;
        private UnidadTerritorialRepository _unidadTerritorial;

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

        public CreditoInicialRepository CreditoInicial
        {
            get
            {
                if (_creditoinicial == null)
                    _creditoinicial = new CreditoInicialRepository(_context);

                return _creditoinicial;
            }
        }

        public CreditoComplementarioRepository CreditoComplementario
        {
            get
            {
                if (_creditocomplementario == null)
                    _creditocomplementario = new CreditoComplementarioRepository(_context);

                return _creditocomplementario;
            }
        }

        public PrincipalRepository Principal
        {
            get
            {
                if (_principal == null)
                    _principal = new PrincipalRepository(_context);

                return _principal;
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

        public CIDictamenJuridicoRepository CiDictamenJuridico
        {
            get
            {
                if (_ciDictamenJuridico == null)
                    _ciDictamenJuridico = new CIDictamenJuridicoRepository(_context);
                return _ciDictamenJuridico;
                
            }
           
        }
        public CIDictamenSocialRepository CiDictamenSocial
        {
            get
            {
                if (_ciDictamenSocial == null)
                    _ciDictamenSocial = new CIDictamenSocialRepository(_context);
                return _ciDictamenSocial;

            }

        }
        public CIDictamenTecnicoRepository CiDictamenTecnico
        {
            get
            {
                if (_ciDictamenTecnico == null)
                    _ciDictamenTecnico = new CIDictamenTecnicoRepository(_context);
                return _ciDictamenTecnico;

            }

        }
        public CIDictamenFinancieroRepository CiDictamenFinanciero
        {
            get
            {
                if (_ciDictamenFinanciero == null)
                    _ciDictamenFinanciero = new CIDictamenFinancieroRepository(_context);
                return _ciDictamenFinanciero;

            }

        }

        public CCDictamenJuridicoRepository CcDictamenJuridico
        {
            get
            {
                if (_ccDictamenJuridico == null)
                    _ccDictamenJuridico = new CCDictamenJuridicoRepository(_context);
                return _ccDictamenJuridico;
                
            }
           
        }
        public CCDictamenSocialRepository CcDictamenSocial
        {
            get
            {
                if (_ccDictamenSocial == null)
                    _ccDictamenSocial = new CCDictamenSocialRepository(_context);
                return _ccDictamenSocial;

            }

        }
        public CCDictamenTecnicoRepository CcDictamenTecnico
        {
            get
            {
                if (_ccDictamenTecnico == null)
                    _ccDictamenTecnico = new CCDictamenTecnicoRepository(_context);
                return _ccDictamenTecnico;

            }

        }
        public CCDictamenFinancieroRepository CcDictamenFinanciero
        {
            get
            {
                if (_ccDictamenFinanciero == null)
                    _ccDictamenFinanciero = new CCDictamenFinancieroRepository(_context);
                return _ccDictamenFinanciero;

            }

        }

        public CSDictamenJuridicoRepository CsDictamenJuridico
        {
            get
            {
                if (_csDictamenJuridico == null)
                    _csDictamenJuridico = new CSDictamenJuridicoRepository(_context);
                return _csDictamenJuridico;

            }

        }
        public CSDictamenSocialRepository CsDictamenSocial
        {
            get
            {
                if (_csDictamenSocial == null)
                    _csDictamenSocial = new CSDictamenSocialRepository(_context);
                return _csDictamenSocial;

            }

        }
        public CSDictamenTecnicoRepository CsDictamenTecnico
        {
            get
            {
                if (_csDictamenTecnico == null)
                    _csDictamenTecnico = new CSDictamenTecnicoRepository(_context);
                return _csDictamenTecnico;

            }

        }
        public CSDictamenFinancieroRepository CsDictamenFinanciero
        {
            get
            {
                if (_csDictamenFinanciero == null)
                    _csDictamenFinanciero = new CSDictamenFinancieroRepository(_context);
                return _csDictamenFinanciero;

            }

        }
        public MCDictamenJuridicoRepository McDictamenJuridico
        {
            get
            {
                if (_mcDictamenJuridico == null)
                    _mcDictamenJuridico = new MCDictamenJuridicoRepository(_context);
                return _mcDictamenJuridico;

            }

        }
        public MCDictamenSocialRepository McDictamenSocial
        {
            get
            {
                if (_mcDictamenSocial == null)
                    _mcDictamenSocial = new MCDictamenSocialRepository(_context);
                return _mcDictamenSocial;

            }

        }
        public MCDictamenTecnicoRepository McDictamenTecnico
        {
            get
            {
                if (_mcDictamenTecnico == null)
                    _mcDictamenTecnico = new MCDictamenTecnicoRepository(_context);
                return _mcDictamenTecnico;

            }

        }
        public MCDictamenFinancieroRepository McDictamenFinanciero
        {
            get
            {
                if (_mcDictamenFinanciero == null)
                    _mcDictamenFinanciero = new MCDictamenFinancieroRepository(_context);
                return _mcDictamenFinanciero;

            }

        }

        public CreditoSustentabilidadRepositoy CreditoSustentabilidad
        {
            get
            {
                if (_creditoSustentabilidad==null)
                     _creditoSustentabilidad = new CreditoSustentabilidadRepositoy(_context);
                return _creditoSustentabilidad;


            }
        }

        public ModificacionesCreditoRepository ModificacionesCredito
        {
            get
            {
                if (_modificacionesCredito == null)
                    _modificacionesCredito = new ModificacionesCreditoRepository(_context);
                return _modificacionesCredito;
            }
        }

        public UnidadTerritorialRepository UnidadTerritorial
        {
            get
            {
                if (_unidadTerritorial == null)
                    _unidadTerritorial = new UnidadTerritorialRepository(_context);
                return _unidadTerritorial;
            }
        }
    }
}
