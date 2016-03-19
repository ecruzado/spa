using Consilium.DAO;
using Consilium.Entity;
using Consilium.Entity.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Consilium.Logica
{
    public class MetodologiaLogica : Singleton<MetodologiaLogica>
    {
        private MetodologiaData metodologiaData = new MetodologiaData();

        public List<ItemNodo> ListByColegioAndArea(int colegioId,int areaId)
        {
            return metodologiaData.ListByColegioAndArea(colegioId, areaId);
        }
        
        #region criterio

        public List<Metodologia> ListCriterioByColegioAndArea(int colegioId, int areaId) 
        {
            return metodologiaData.ListCriterioByColegioAndArea(colegioId, areaId);
        }

        public int CrearCriterio(Metodologia metodologia) 
        {
            return metodologiaData.CrearCriterio(metodologia);
        }

        public int ActualizarCriterio(Metodologia metodologia) 
        {
            return metodologiaData.ActualizarCriterio(metodologia);
        }

        public int DeleteCriterio(Metodologia metodologia) 
        {
            return metodologiaData.DeleteCriterio(metodologia);
        }
        
        public int ActualizarCriterioOrden(int criterioId, bool arriba)
        {
            return metodologiaData.ActualizarCriterioOrden(criterioId, arriba);
        }

        #endregion
        
        public List<Metodologia> ListMetecnicaByCriterio(int criterio) 
        {
            return metodologiaData.ListMetecnicaByCriterio(criterio);
        }

        public int CrearMetecnica(Metodologia metodologia) 
        {
            return metodologiaData.CrearMetecnica(metodologia);
        }

        public int ActualizarMetecnica(Metodologia metodologia) 
        {
            return metodologiaData.ActualizarMetecnica(metodologia);
        }

        public int DeleteMetecnica(Metodologia metodologia)
        {
            return metodologiaData.DeleteMetecnica(metodologia);
        }

        public int ActualizarMetecnicaOrden(int metecnicaId, bool arriba)
        {
            return metodologiaData.ActualizarMetecnicaOrden(metecnicaId, arriba);
        }
    }
}
