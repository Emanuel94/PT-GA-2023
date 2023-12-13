using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFServiceMedico.Class;

namespace WCFServiceMedico
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceHospital" in both code and config file together.
    [ServiceContract]
    public interface IServiceHospital
    {
        [OperationContract]
        //Listado de Medicamentos
        IEnumerable<MedicamentoCLS> listarMedicamento();

        [OperationContract]
        //Listado de Forma Farmaceutica
        IEnumerable<FormaFarmaceuticaCLS> listarFormaceutica();

        [OperationContract]
        //Recuperrar Medicamento
        MedicamentoCLS recuperarMedicamento(int iiMedicamento);

        [OperationContract]
        //Agregar y editar Medicamento
        int agregarYActualizarMedicamento(MedicamentoCLS medicamento);

        [OperationContract]
        //Eliminar Medicamento
        int eliminarMeidcamento(int iidMedicamento);

        [OperationContract]
        //Eliminar Medicamento
        Articulo recuperaArticulo(int iiArticulo);

        [OperationContract]
        //Listar articulo
        IEnumerable<Articulo> listarArticulo();


    }
}
