using Modelo.Core.Domain.Entities;

namespace Modelo.Core.ADO.WebApi.Models
{
    public class NovoProjetoModel
    {
        public string nm_projeto { get; set; }
        public string ds_projeto { get; set; }
    }

    public static class NovoProjetoModelExtension
    {
        public static NovoProjetoModel ToNovoProjetoModel(this ProjetoEntity obj)
        {
            if (obj != null)
            {
                return new NovoProjetoModel
                {
                    ds_projeto = obj.ds_projeto,
                    nm_projeto = obj.nm_projeto
                };
            }

            return null;
        }

        public static ProjetoEntity ToEntity(this NovoProjetoModel obj)
        {
            if (obj != null)
            {
                return new ProjetoEntity
                {
                    ds_projeto = obj.ds_projeto,
                    nm_projeto = obj.nm_projeto
                };
            }

            return null;
        }
    }
}
