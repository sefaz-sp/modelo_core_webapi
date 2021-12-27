using Modelo.Core.Domain.Entities;

namespace Modelo.Core.ADO.WebApi.Models
{
    public class NovoProjetoModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }

    public static class NovoProjetoModelExtension
    {
        public static NovoProjetoModel ToNovoProjetoModel(this ProjetoEntity obj)
        {
            if (obj != null)
            {
                return new NovoProjetoModel
                {
                    Descricao = obj.Descricao,
                    Nome = obj.Nome
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
                    Descricao = obj.Descricao,
                    Nome = obj.Nome
                };
            }

            return null;
        }
    }
}
