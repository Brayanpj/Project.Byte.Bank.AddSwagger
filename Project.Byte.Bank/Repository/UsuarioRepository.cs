using Microsoft.EntityFrameworkCore;
using Project.Byte.Bank.Infra.Context;
using Project.Byte.Bank.Interface.IUsuariosRepository;

namespace Project.Byte.Bank.Repository
{
    public class UsuarioRepository : IUsuariosRepository
    {
        private readonly DataContext _datacontext;

        public UsuarioRepository(DataContext dataContext)
        {
            _datacontext = dataContext;
        }

        public void DeleteUsuario(int usuariokeyId)
        {
            _datacontext.Set<UsuarioKey>().ExecuteDelete();
            _datacontext.SaveChangesAsync();
        }
        public async Task GetTaskAsync<UsuarioKey>() // o retorno precisa ser nulo. 
        {

            await _datacontext.SaveChangesAsync();
        }
        public void GetUsuariokeyByID(int usuariokeyId)
        {
            _datacontext.Set<UsuarioKey>();
        }
        public async Task InsertUsuario(UsuarioKey usuariokeyId)
        {
            await _datacontext.Set<UsuarioKey>().AddAsync(usuariokeyId);
            await _datacontext.SaveChangesAsync();
        }
        public void UpdateUsuario(UsuarioKey usuariokeyId)
        {
            _datacontext.Update(usuariokeyId);
            _datacontext.SaveChangesAsync();
        }
        public void Save()
        {
            _datacontext.SaveChanges();
        }
        //UsuarioKey IUsuariosRepository.GetUsuariokeyByID(int usuariokeyId)
        //{
        //    return ((IUsuariosRepository)_usuarioRepository).GetUsuariokeyByID(usuariokeyId);
        //}
        public IEnumerable<UsuarioKey> GetUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
