using Modelo.Core.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Modelo.Core.ADO.Infra.Util
{
    public class SafeReader
    {
        private readonly SqlDataReader _reader;

        public SafeReader(SqlDataReader reader)
        {
            _reader = reader;
        }
        
        public T Get<T>(string campo, T valorPadrao, bool propagaErro = false)
        {
            if (_reader[campo] != null)
            {
                try
                {
                    return (T)_reader[campo];
                }
                catch(Exception e)
                {
                    if (propagaErro)
                        throw new TipoInvalidoException($"Falha na conversão de valor do campo {_reader[campo]} em {typeof(T)}: {e.Message} ");                    
                }
            }

            return valorPadrao;
        }
    }
}
