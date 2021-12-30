using Lgpd.Mascarador.Config;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace modelo.projetos
{
    public class Projetos
    {
        public long cd_projeto { get; set; }
        [AtributoSensivel]
        public string nm_projeto { get; set; }
        public string ds_projeto { get; set; }
        public Projetos(int id, string nome, string descricao)
        {
            cd_projeto = id;
            nm_projeto = nome;
            ds_projeto = descricao;
        }

        public Projetos()
        {

        }

        public StringContent ToJson()
        {
            return new StringContent(JsonConvert.SerializeObject(this), Encoding.UTF8, "application/json");
        }

        public Projetos ToModel(string ProjetoJson)
        {
            return JsonConvert.DeserializeObject<Projetos>(ProjetoJson);
        }

        public IEnumerable<Projetos> ToList(string ProjetoJson)
        {
            return JsonConvert.DeserializeObject<IEnumerable<Projetos>>(ProjetoJson);
        }
    }
}
