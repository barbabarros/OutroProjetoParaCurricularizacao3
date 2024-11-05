namespace Curricularizacao.Models;

public class Atividade
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public List<Professor> Professores { get; set; } = new List<Professor>();
    public List<int> ProfessorIds { get; set; } = new List<int>();
}
