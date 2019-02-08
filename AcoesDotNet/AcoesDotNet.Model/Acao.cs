using System;

namespace AcoesDotNet.Model
{
    public class Acao : BaseModel
    {
        public  string CodigoDaAcao { get; set; }
        public DateTime DataCotacao { get; set; }
        public decimal Valor { get; set; }
    }
}
