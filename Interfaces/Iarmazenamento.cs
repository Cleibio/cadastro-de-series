namespace CadastroSeries
{
    public interface Iarmazenamento<T>
    {
        void ExcluirSerie(int id);
        void CadastrarSerie(T entidade);
        List<T> ListarSeries();
        void AtualizarSerie(int id, T entidade);
        T RetornaPorId(int id);
        int IdProximo();
    }
}