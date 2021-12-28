using Modelo.Core.Domain.Entities;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Modelo.Core.ADO.WebApi.Models
{
    public class ProjetoModel
    {
        public long cd_projeto { get; set; }

        public string nm_projeto { get; set; }
        public string ds_projeto { get; set; }

        public StringContent ToJson()
        {
            return new StringContent(JsonSerializer.Serialize(this), Encoding.UTF8, "application/json");
        }              
    }

    public static class ProjetoModelExtension
    {
        public static ProjetoModel ToModel(this ProjetoEntity obj)
        {
            if (obj != null)
            {
                return new ProjetoModel
                {
                    ds_projeto = obj.ds_projeto,
                    cd_projeto = obj.cd_projeto,
                    nm_projeto = obj.nm_projeto
                };
            }

            return null;
        }

        public static ProjetoEntity ToEntity(this ProjetoModel obj)
        {
            if (obj != null)
            {
                return new ProjetoEntity
                {
                    ds_projeto = obj.ds_projeto,
                    cd_projeto = obj.cd_projeto,
                    nm_projeto = obj.nm_projeto
                };
            }

            return null;
        }
    }
}
