using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServiceMedico.Class;
using WCFServiceMedico.Models;

namespace WCFServiceMedico
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceHospital" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceHospital.svc or ServiceHospital.svc.cs at the Solution Explorer and start debugging.
    public class ServiceHospital : IServiceHospital
    {

        public IEnumerable<FormaFarmaceuticaCLS> listarFormaceutica()
        {
            IEnumerable<FormaFarmaceuticaCLS> listaFarmaceutica = new List<FormaFarmaceuticaCLS>();

            try
            {
                using (var db = new MedicoDB())
                {
                    listaFarmaceutica = db.Medicamentoes
                        .Where(p => p.BHABILITADO ==1)
                        .Select(p => new FormaFarmaceuticaCLS
                        {
                            iidFormafarmaceutica = (int)p.IIDFORMAFARMACEUTICA,
                            Nombre = p.NOMBRE,

                        }).ToList();
                    return listaFarmaceutica;
                }
            }
            catch (Exception ex)
            {
                listaFarmaceutica = null;
                return listaFarmaceutica;
            }

        }


        public IEnumerable<MedicamentoCLS> listarMedicamento()
        {
            IEnumerable<MedicamentoCLS> listarMedicamento = new List<MedicamentoCLS>();
            try
            {
                using (var db = new MedicoDB())
                {
                    listarMedicamento = (from medicamento in db.Medicamentoes
                                         join formaFarmaceutica in db.Medicamentoes
                                         on medicamento.IIDFORMAFARMACEUTICA equals
                                         formaFarmaceutica.IIDFORMAFARMACEUTICA
                                         select new MedicamentoCLS
                                         {
                                             IIdMedicamento = medicamento.IIDMEDICAMENTO,
                                             nombre = medicamento.NOMBRE,
                                             Precio = (decimal)medicamento.PRECIO,
                                             nombreFormaFarmaceutica = formaFarmaceutica.NOMBRE,
                                             concentracion = medicamento.CONCENTRACION,
                                             presentacion = medicamento.PRESENTACION,
                                             habilitado = (int)medicamento.BHABILITADO,
                                             stock = (int)medicamento.STOCK

                                         }).ToList();
                }
            }
            catch (Exception)
            {
                listarMedicamento = null;
                throw;
            }
            return listarMedicamento;
        }


        public MedicamentoCLS recuperarMedicamento(int iiMedicamento)
        {
            MedicamentoCLS medicamento = new MedicamentoCLS();
            try
            {
                using (var db = new MedicoDB())
                {
                    Medicamento oMedicamento = db.Medicamentoes.Where(p => p.IIDMEDICAMENTO == iiMedicamento).First();
                    medicamento.IIdMedicamento = oMedicamento.IIDMEDICAMENTO;
                    medicamento.nombre = oMedicamento.NOMBRE;
                    medicamento.iidFormaFarmaceutica = (int)oMedicamento.IIDFORMAFARMACEUTICA;
                    medicamento.Precio = (decimal)oMedicamento.PRECIO;
                    medicamento.stock = (int)oMedicamento.STOCK;
                    medicamento.concentracion = oMedicamento.CONCENTRACION;
                    medicamento.presentacion = oMedicamento.PRESENTACION;

                }
            }
            catch (Exception)
            {
                medicamento = null;

            }
            return medicamento;
        }

        public int agregarYActualizarMedicamento(MedicamentoCLS medicamento)
        {
            int result = 0;
            try
            {
                using (var db = new MedicoDB())
                {


                    if (medicamento.IIdMedicamento == 0)
                    {
                        Medicamento omedicamento = new Medicamento();
                        omedicamento.IIDMEDICAMENTO = medicamento.IIdMedicamento;
                        omedicamento.NOMBRE = medicamento.nombre;
                        omedicamento.PRECIO = medicamento.Precio;
                        omedicamento.STOCK = medicamento.stock;
                        omedicamento.IIDFORMAFARMACEUTICA = medicamento.iidFormaFarmaceutica;
                        omedicamento.CONCENTRACION = medicamento.concentracion;
                        omedicamento.PRESENTACION = medicamento.presentacion;
                        omedicamento.BHABILITADO = 1;
                        db.Medicamentoes.Add(omedicamento);
                        db.SaveChanges();
                        result = 1;
                    }
                    else
                    {
                        Medicamento oMedicamento = db.Medicamentoes.Where(p => p.IIDMEDICAMENTO == medicamento.IIdMedicamento).First();
                            oMedicamento.IIDMEDICAMENTO = medicamento.IIdMedicamento;
                            oMedicamento.NOMBRE = medicamento.nombre;
                            oMedicamento.PRECIO = medicamento.Precio;
                            oMedicamento.STOCK = medicamento.stock;
                            oMedicamento.IIDFORMAFARMACEUTICA = medicamento.iidFormaFarmaceutica;
                            oMedicamento.CONCENTRACION = medicamento.concentracion;
                            oMedicamento.PRESENTACION = medicamento.presentacion;

                        db.SaveChanges();
                        result = 1;
                    }
                }
            }
            catch (Exception)
            {

                result = 0;
            }
            return result;
        }
        public int eliminarMeidcamento(int iidMedicamento)
        {
            int result = 0;
            try
            {
                using (var db = new MedicoDB())
                {
                    Medicamento oMedicamento = db.Medicamentoes.Where(m => m.IIDMEDICAMENTO == iidMedicamento).First();
                    oMedicamento.BHABILITADO = 0;
                    db.SaveChanges();
                    result = 1;
                }

            }
            catch (Exception ex)
            {
                result = 0;
                throw;
            }
            return result;

        }



        public Articulo recuperaArticulo(int iiArticulo)
        {
            Articulo articulo = new Articulo();
            try
            {

                using (var dbPTGA = new PruebaTecnicaGAEntities())
                {
                    Articulo oArticulo = dbPTGA.Articulo.Where(a => a.IdArticulo == iiArticulo).First();

                    articulo.IdArticulo = oArticulo.IdArticulo;
                    articulo.Descripcion = oArticulo.Descripcion;
                    articulo.Sku = oArticulo.Sku;
                    articulo.IdMarca = oArticulo.IdMarca;
                }

            }
            catch (Exception)
            {
                articulo = null;

            }
            return articulo;
        }

        public IEnumerable<Articulo> listarArticulo()
        {
            IEnumerable<Articulo> articulo =new List<Articulo>();
            try
            {

                using (var dbPTGA = new PruebaTecnicaGAEntities())
                {
                    /*
                    Articulo oArticulo = dbPTGA.Articulo.Where(a => a.IdArticulo == iiArticulo).First();

                    articulo.IdArticulo = oArticulo.IdArticulo;
                    articulo.Descripcion = oArticulo.Descripcion;
                    articulo.Sku = oArticulo.Sku;
                    articulo.IdMarca = oArticulo.IdMarca;
                    */
                }

            }
            catch (Exception)
            {
                articulo = null;

            }
            return articulo;
        }

    }
}
