using eventplus_webapi.Domains;

namespace eventplus_webapi.Interfaces
{
    public interface IEvento
    {
        void Cadastrar(Evento evento);

        void Deletar(Guid id);

        List<Evento> Listar();

        Evento BuscarPorId(Guid id);

        void Atualizar(Guid id, Evento evento);
    }
}
