namespace CadastroSeries
{
    public class SeriesArmazenamento : Iarmazenamento<Series>
    {
        List<Series> ListaSeries = new List<Series>();
        public void AtualizarSerie(int id, Series series)
        {
            ListaSeries[id] = series;
        }

        public void CadastrarSerie(Series series)
        {
            ListaSeries.Add(series);
        }

        public void ExcluirSerie(int id)
        {
            ListaSeries[id].Excluir();
        }

        public int IdProximo()
        {
            return ListaSeries.Count;
        }

        public List<Series> ListarSeries()
        {
            return ListaSeries;
        }

        public Series RetornaPorId(int id)
        {
            return ListaSeries[id];
        }
    }
}