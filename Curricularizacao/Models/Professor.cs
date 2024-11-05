namespace Curricularizacao.Models;

public class Professor
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public List<Atividade> Atividades { get; set; } = [];
}
