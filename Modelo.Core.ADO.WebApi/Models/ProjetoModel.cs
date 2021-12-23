using Modelo.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Modelo.Core.ADO.WebApi.Models
{
    public class ProjetoModel
    {
        public long Id { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }

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
                    Descricao = obj.Descricao,
                    Id = obj.Id,
                    Nome = obj.Nome
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
                    Descricao = obj.Descricao,
                    Id = obj.Id,
                    Nome = obj.Nome
                };
            }

            return null;
        }
    }
}
