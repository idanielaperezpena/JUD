using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Utilidades
{
    public abstract class EmailUtility
    {
        protected string _nombre;
        protected string _address;

        public EmailUtility()
        {
        }

        public EmailUtility(string nombre, string address)
        {
            _nombre = nombre;
            _address = address;
        }

        protected abstract Task<EmailResult> EnviarEmail();
        protected abstract void AgregarDestinatario(string email);
        protected abstract void ConfigurarMensaje(string asunto, string contenido);

        protected bool IsValid(string emailAddress)
        {
            try
            {
                new MailAddress(emailAddress);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public abstract void AgregarAdjunto(byte[] fileBytes, string nombreArchivo);

        public async Task<EmailResult> Enviar(string asunto, string contenido, string destinatarios)
        {
            try
            {
                foreach (var itemEmail in destinatarios.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries).Distinct())
                {
                    if (IsValid(itemEmail))
                        AgregarDestinatario(itemEmail);
                }

                ConfigurarMensaje(asunto, contenido);

                return await EnviarEmail();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new EmailResult { StatusCode = HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }
    }

    public class EmailResult
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            var _builder = new StringBuilder();

            _builder.AppendFormat("<small><b>SendEmailResult - {0}</b></small>", StatusCode);
            _builder.AppendFormat("<ul><li>{0}</li></ul>", Message);

            return _builder.ToString();
        }
    }

    #region Implementación Smtp Client
    public class SmtpEmailUtility : EmailUtility
    {
        private SmtpClient _client;
        private MailMessage _message;
        private List<System.Net.Mail.Attachment> _adjuntos;

        public SmtpEmailUtility()
        {
            _client = new SmtpClient();
            _message = new MailMessage { IsBodyHtml = true };
            _adjuntos = new List<System.Net.Mail.Attachment>();
        }

        protected override Task<EmailResult> EnviarEmail()
        {
            _client.Send(_message);

            return Task.FromResult(new EmailResult { StatusCode = HttpStatusCode.Accepted });
        }

        protected override void AgregarDestinatario(string email)
        {
            _message.To.Add(email);
        }

        protected override void ConfigurarMensaje(string asunto, string contenido)
        {
            _message.Subject = asunto;
            _message.Body = contenido;

            if (_message.Attachments != null)
                _message.Attachments.Clear();

            if (_adjuntos != null && _adjuntos.Count > 0)
                _adjuntos.ForEach(a => _message.Attachments.Add(a));
        }

        public override void AgregarAdjunto(byte[] fileBytes, string nombreArchivo)
        {
            var _adj = new System.Net.Mail.Attachment(new MemoryStream(fileBytes), nombreArchivo);
            _adjuntos.Add(_adj);
        }
    }
    #endregion

    #region Implementación SendGrid
    public class SendGridEmailUtility : EmailUtility
    {
        private SendGridClient _client;
        private SendGridMessage _message;
        private List<SendGrid.Helpers.Mail.Attachment> _adjuntos;

        public SendGridEmailUtility(string apiKey, string nombre, string email) : base(nombre, email)
        {
            _client = new SendGridClient(apiKey);
            _message = new SendGridMessage { From = new EmailAddress { Email = _address, Name = _nombre } };
            _adjuntos = new List<SendGrid.Helpers.Mail.Attachment>();
        }

        protected override async Task<EmailResult> EnviarEmail()
        {
            var _response = await _client.SendEmailAsync(_message);

            if (_response == null)
                return new SendgridEmailResult { StatusCode = HttpStatusCode.InternalServerError };

            var _body = await _response.Body.ReadAsStringAsync();

            var _resultado = _body.FromJSON<SendgridEmailResult>() ?? new SendgridEmailResult();
            _resultado.StatusCode = _response.StatusCode;

            return _resultado;
        }

        protected override void AgregarDestinatario(string email)
        {
            _message.AddTo(email);
        }

        protected override void ConfigurarMensaje(string asunto, string contenido)
        {
            _message.Subject = asunto;
            _message.HtmlContent = contenido;

            if (_message.Attachments != null)
                _message.Attachments.Clear();

            if (_adjuntos != null && _adjuntos.Count > 0)
                _message.AddAttachments(_adjuntos);
        }

        public override void AgregarAdjunto(byte[] fileBytes, string nombreArchivo)
        {
            var _adj = new SendGrid.Helpers.Mail.Attachment
            {
                Content = Convert.ToBase64String(fileBytes),
                Filename = nombreArchivo
            };

            _adjuntos.Add(_adj);
        }
    }

    public class SendgridEmailResult : EmailResult
    {
        public List<SendgridEmailError> errors { get; set; }

        public override string ToString()
        {
            var _builder = new StringBuilder();

            _builder.AppendFormat("<small><b>SendEmailResult - {0}</b></small>", StatusCode);

            if (errors != null)
            {
                _builder.Append("<ul>");
                foreach (var item in errors)
                {
                    _builder.AppendFormat("<li>{0}", item.message);

                    if (!string.IsNullOrWhiteSpace(item.field))
                        _builder.AppendFormat("<br/>{0}", item.field);
                    if (!string.IsNullOrWhiteSpace(item.help))
                        _builder.AppendFormat("<br/>{0}", item.help);

                    _builder.Append("</li>");
                }
                _builder.Append("</ul>");
            }

            return _builder.ToString();
        }
    }

    public class SendgridEmailError
    {
        public string message { get; set; }
        public string field { get; set; }
        public string help { get; set; }
    }
    #endregion
}
