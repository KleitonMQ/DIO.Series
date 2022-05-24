namespace DIOSeries
{
    public class SerieRepositorio : iRepositorio<Series>
    {
        private List<Series> listaSerie = new List<Series>();
        public void Atualiza(int id, Series objeto)
        {
            listaSerie[id] = objeto;
        }

        public void Exciui(int id)
        {
            listaSerie[id].Exciuir();
        }

        public void Insere(Series objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Series> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Series RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}