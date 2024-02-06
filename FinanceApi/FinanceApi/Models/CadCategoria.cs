using Microsoft.AspNetCore.Authentication;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FinanceApi.Models
{
    public class CadCategoria
    {
        public enum TipoCategoriaEnum
        {
            Receita = 0,
            Despesa = 1
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? NomeCategoria { get; set; }
        public TipoCategoriaEnum? TipoCategoria { get; set; } // Tipos: Receita e Despesa
        public bool AtividadeCategoria { get; set; }

    }
}
