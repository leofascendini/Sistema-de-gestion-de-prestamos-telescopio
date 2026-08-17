using Libreria.DTOs.DataTransferObjects.DTOsUsuario;
using Libreria.DTOs.Mappers;
using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.CasosUso.CUUsuario
{
    public class CUUsuarioListado : ICUUsuarioListado
    {
        private IRepositorioUsuario _repoUsuario;

        public CUUsuarioListado(
            IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public List<DTOUsuarioListado> Ejecutar()
        {
            List<Usuario> usuarios =
                _repoUsuario.FindAll();

            List<DTOUsuarioListado> retorno =
                new List<DTOUsuarioListado>();

            foreach (Usuario u in usuarios)
            {
                retorno.Add(
                    MapperUsuario
                    .FromUsuarioToDTOUsuarioListado(u));
            }

            return retorno;
        }
    }
}
