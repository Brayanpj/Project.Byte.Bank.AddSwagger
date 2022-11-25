using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pro.Infra.Dtos;
using Project.Byte.Bank.Infra.Context;
using Project.Byte.Bank.Interface.IUsuariosRepository;

namespace Project.Byte.Bank.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUsuariosRepository _usuariosRepository;
        public UsuarioController(DataContext context, IMapper mapper, IUsuariosRepository usuariosRepository)
        {
            _context = context;
            _mapper = mapper;
            _usuariosRepository = usuariosRepository;
        }

        /// <summary>
        /// Adiciona um usuario ao banco de dados
        /// </summary>
        /// <param name="usuarioDto">Objeto com os campos necessários para criação de um filme</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AdicionaUsuario([FromBody] CreateUsuarioDto usuarioDto)
        {
            var _usuario = _mapper.Map<UsuarioKey>(usuarioDto);
            await _usuariosRepository.InsertUsuario(_usuario);
            return CreatedAtAction(nameof(RecuperaUsuarioPorId), new { id = _usuario.Id }, _usuario);
        }

        /// <summary>
        /// Recupera uma lista de usuario do banco de dados
        /// </summary>
        /// <param name="skip">Número de usuarios que serão pulados</param>
        /// <param name="take">Número de usuarios que serão recuperados</param>
        /// <returns>Informações de usuarios buscados</returns>
        /// <response code="200">Com a lista de usuarios presentes na base de dados</response>
        [HttpGet]
        public IEnumerable<UsuarioKey> RecuperaUsuario(int skip = 0, int take = 4)
        {

            return _context.UsuarioKey.Skip(skip).Take(take);
        }

        /// <summary>
        /// Recupera um usuario no banco de dados usando seu id
        /// </summary>
        /// <param name="id">Id do usuario a ser recuperado no banco</param>
        /// <returns>Informações do usuario buscado</returns>
        /// <response code="200">Caso o id seja existente na base de dados</response>
        /// <response code="404">Caso o id seja inexistente na base de dados</response>
        [HttpGet("{id}")]
        public IActionResult RecuperaUsuarioPorId(int id)
        {
            var usuario = _context.UsuarioKey.FirstOrDefault(_usuario => _usuario.Id == id); // Observação o Usuariokey = 
            if (usuario != null)
            {
                ReadUsuarioDto RecuperaUsuarioPorId = _mapper.Map<ReadUsuarioDto>(usuario); // Ele mapeia a entidade para a resposta, _mapper.Map<ReadUsuarioDto>. 
                return Ok(RecuperaUsuarioPorId); // Se UsuarioKey, não tiver as entidades o "_mapper.Map". Não vai conseguir mapear nada. 
            }
            return NotFound();
        }

        /// <summary>
        /// Atualiza um usuario no banco de dados usando seu id
        /// </summary>
        /// <param name="id">Id do filme a ser atualizado no banco</param>
        /// <param name="usuarioDto">Objeto com os campos necessários para atualização de um filme</param>
        /// <returns>Sem conteúdo de retorno</returns>
        /// <response code="204">Caso o id seja existente na base de dados e o usuario tenha sido atualizado</response>
        /// <response code="404">Caso o id seja inexistente na base de dados</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AtualizaUsuario(int id, [FromBody] UpdateUsuarioDto usuarioDto)
        {
            var usuario = _context.UsuarioKey.Where(usuario => usuario.Id == id);
            if (usuario != null)
            {
                _mapper.Map(usuarioDto, usuario);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

        /// <summary>
        /// Deleta um usuario do banco de dados usando seu id
        /// </summary>
        /// <param name="id">Id do filme a ser removido do banco</param>
        /// <returns>Sem conteúdo de retorno</returns>
        /// <response code="204">Caso o id seja existente na base de dados e o usuario tenha sido removido</response>
        /// <response code="404">Caso o id seja inexistente na base de dados</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletaUsuario(int id)
        {
            var usuario = _context.UsuarioKey.FirstOrDefault(_usuario => _usuario.Id == id);
            if (usuario != null)
            {
                _context.Remove(usuario);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

    }
}
