namespace DIOSeries
{
    public interface iRepositorio<T>
    {
         List<T> Lista();

         T RetornaPorId(int id);

         void Insere(T entidade);
         void Exciui(int id);
         void Atualiza(int id, T entidade);
         int ProximoId();

    }
}