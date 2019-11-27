using Loja.Dominio;
using System.Web.Mvc;

namespace Loja.Mvc.Helpers
{
    public class AuthorizeRole : AuthorizeAttribute
    {
        public AuthorizeRole(params PerfilUsuario[] perfis)
        {
            foreach (var perfil in perfis)
            {
                Roles += perfil + ",";
            }

            Roles = Roles.TrimEnd(',');
        }
    }
}