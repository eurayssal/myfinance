using Microsoft.AspNetCore.Authentication;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FinanceApi.Models
{
    public class CadCategoria
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? NomeCategoria { get; set; }
        public string TipoCategoria { get; set; } // Tipos: Receita e Despesa
        public bool AtividadeCategoria { get; set; }

    }
}
