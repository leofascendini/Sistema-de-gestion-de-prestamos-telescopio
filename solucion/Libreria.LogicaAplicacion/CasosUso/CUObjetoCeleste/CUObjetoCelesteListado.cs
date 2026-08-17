using Libreria.LogicaAplicacion.ICasosUso.ICUObjetoCeleste;
using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.IRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.CasosUso.CUObjetoCeleste
{
    public class CUObjetoCelesteListado : ICUObjetoCelesteListado
    {
            private IRepositorioObjetoCeleste _repoObjeto;

            public CUObjetoCelesteListado(IRepositorioObjetoCeleste repoObjeto)
            {
                _repoObjeto = repoObjeto;
            }

            public List<ObjetoCeleste> Listar()
            {
                return _repoObjeto.FindAll();
            }
        }
    }

