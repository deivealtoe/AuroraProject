namespace AuroraProject.Dominio;

public class Produto
{
    public virtual int Id { get; protected set; }
    public virtual string Titulo { get; protected set; }

    protected Produto() { }

    public Produto(string titulo)
    {
        SetTitulo(titulo);
    }

    public virtual void SetTitulo(string titulo)
    {
        if (titulo.Length > 150)
        {
            throw new ArgumentException("Tamanho do título deve ser menor ou igual a 150 caracteres");
        }
        
        Titulo = titulo;
    }
}
