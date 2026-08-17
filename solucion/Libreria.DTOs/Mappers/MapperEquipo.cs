using Libreria.DTOs.DataTransferObjects.DTOsEquipo;
using Libreria.LogicaNegocio.CustomExceptions.GenericasExceptions;
using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.DTOs.Mappers
{
    public class MapperEquipo
    {
        public static Equipo CrearEquipo(DTOGestionEquipo dto)
        {
            switch (dto.TipoEquipo)
            {
                case "Montura":
                    return new Montura
                    {
                        EquipoId = dto.EquipoId,
                        marca = dto.Marca,
                        modelo = dto.Modelo,
                        cantidadDisponible = dto.CantidadDisponible,
                        tipoMontura = dto.TipoMontura.Value,
                        cargaUtil = dto.CargaUtil.Value,
                        esGoTo = dto.EsGoTo 
                    };

                case "Telescopio":
                    return new Telescopio
                    {
                        EquipoId = dto.EquipoId,
                        marca = dto.Marca,
                        modelo = dto.Modelo,
                        cantidadDisponible = dto.CantidadDisponible,
                        apertura = dto.Apertura.Value,
                        relacionFocal = dto.RelacionFocal,
                        distanciaFocal = dto.DistanciaFocal.Value,
                        peso = dto.Peso.Value
                    };

                case "Ocular":
                    return new Ocular
                    {
                        EquipoId = dto.EquipoId,
                        marca = dto.Marca,
                        modelo = dto.Modelo,
                        cantidadDisponible = dto.CantidadDisponible,
                        diametro = dto.Diametro.Value,
                        anguloVision = dto.AnguloVision.Value
                    };

                case "Camara":
                    return new Camara
                    {
                        EquipoId = dto.EquipoId,
                        marca = dto.Marca,
                        modelo = dto.Modelo,
                        cantidadDisponible = dto.CantidadDisponible,
                        tipoSensor = dto.TipoSensor.Value,
                        resolucion = dto.Resolucion,
                        tamañoPixel = dto.TamañoPixel.Value
                    };

                default:
                    throw new Exception("Tipo de equipo inválido");
            }
        }
        public static DTOGestionEquipo ToDto(Equipo equipo)
        {
            var dto = new DTOGestionEquipo
            {
                EquipoId = equipo.EquipoId,
                Marca = equipo.marca,
                Modelo = equipo.modelo,
                CantidadDisponible = equipo.cantidadDisponible,
                TipoEquipo = equipo.GetType().Name
            };

            if (equipo is Montura m)
            {
                dto.TipoMontura = m.tipoMontura;
                dto.CargaUtil = m.cargaUtil;
                dto.EsGoTo = m.esGoTo;
            }
            else if (equipo is Telescopio t)
            {
                dto.Apertura = t.apertura;
                dto.RelacionFocal = t.relacionFocal;
                dto.DistanciaFocal = t.distanciaFocal;
                dto.Peso = t.peso;
            }
            else if (equipo is Ocular o)
            {
                dto.Diametro = o.diametro;
                dto.AnguloVision = o.anguloVision;
            }
            else if (equipo is Camara c)
            {
                dto.TipoSensor = c.tipoSensor;
                dto.Resolucion = c.resolucion;
                dto.TamañoPixel = c.tamañoPixel;
            }

            return dto;
        }
    }
}
