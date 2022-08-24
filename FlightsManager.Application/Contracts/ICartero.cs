using FlightsManager.Domain.Models.MailModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsManager.Application.Contracts
{
    public interface ICartero
    {
        void Enviar(CorreoElectronico correo);
    }
}
