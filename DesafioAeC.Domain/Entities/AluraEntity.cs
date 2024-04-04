namespace DesafioAeC.Domain.Entities
{
    public class AluraEntity : BaseEntity
    {
        public string? Titulo { get; private set; }
        public string? Professor { get; private set; }
        public string? DescricaoProfessor { get; private set; }
        public DateTime CargaHoraria { get; private set; }
        public string Descricao { get; private set; }
    }
}

