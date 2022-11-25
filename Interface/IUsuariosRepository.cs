namespace Project.Byte.Bank.Interface.IUsuariosRepository
{
    public interface IUsuariosRepository
    {
        IEnumerable<UsuarioKey> GetUsuario();
        UsuarioKey GetUsuariokeyByID(int usuariokeyId);
        Task InsertUsuario(UsuarioKey usuariokeyId);
        void DeleteUsuario(int usuariokeyId);
        void UpdateUsuario(UsuarioKey usuariokeyId);
        void Save();
    }
}
