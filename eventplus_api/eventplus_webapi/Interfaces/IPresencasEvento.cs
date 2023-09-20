using eventplus_webapi.Domains;

namespace eventplus_webapi.Interfaces
{
    public interface IPresencasEvento
    {
        void Cadastrar(PresencasEvento presencasEvento);

        List<PresencasEvento> Listar();

        void Atualizar(Guid id, PresencasEvento presencasEvento);

        void Deletar(Guid id);

        List<PresencasEvento> ListarMinhas();
    }
}
