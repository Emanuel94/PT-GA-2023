using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IdentityModel.Selectors;
using System.ServiceModel;

namespace WCFServiceMedico.Security
{
    public class Autenticacion : UserNamePasswordValidator
    {
        public Autenticacion()
        {
        }

        public override void Validate(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException("El usuario no puede ser vacio");
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("El password no puede ser vacio.");
            }
            // usuario: Ema94 password: 1234
            if (!(userName.ToLower().Equals("ema94")  && password.ToLower().Equals("1234")) )
            {
                throw new FaultException("Usuario o contraseña inconrrecta");
            }

        }
    }
}