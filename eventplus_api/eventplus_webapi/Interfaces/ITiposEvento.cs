using eventplus_webapi.Domains;

namespace eventplus_webapi.Interfaces
{
    public interface ITiposEvento
    {
        void Cadastrar(TiposEvento tipoEvento);

        void Deletar(Guid id);

        List<TiposEvento> Listar();

        TiposEvento BuscarPorId(Guid id);

        void Atualizar(Guid id, TiposEvento tipoEvento);
    }
}
