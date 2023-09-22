namespace eventplus_webapi.Utils
{
    /// <summary>
    /// Classe estática responsável por criptografar as senhas usando o BCrypt
    /// </summary>
    public static class Criptografia
    {
        /// <summary>
        /// Método que transforma a senha em uma HASH
        /// </summary>
        /// <param name="senha">Senha que será transformada</param>
        /// <returns>retorna a HASH</returns>
        public static string GerarHash(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        /// <summary>
        /// Método responsável por comparar a hash passada pelo form com a hash ja cadastrada no banco
        /// </summary>
        /// <param name="senhaForm">Senha passada no formulário</param>
        /// <param name="senhaBanco">Senha cadastrada no banco</param>
        /// <returns>Retorna um true ou false dependendo se as senhas forem comparadas</returns>
        public static bool CompararHash(string senhaForm, string senhaBanco)
        {
            return BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);
        }
    }
}
