using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.DTOs.DataTransferObjects.DTOsPrestamo
{
    public class DTOPrestamoListado
    {
            public int PrestamoId { get; set; }
            public string Usuario { get; set; }
            public string Telescopio { get; set; }
            public string Montura { get; set; }
            public string Camara { get; set; }
            public string Ocular { get; set; }

            public DateTime FechaInicio { get; set; }
            public DateTime FechaFin { get; set; }
            public string Estado { get; set; }
            public bool EstaAtrasado { get; set; }
    }
    }


