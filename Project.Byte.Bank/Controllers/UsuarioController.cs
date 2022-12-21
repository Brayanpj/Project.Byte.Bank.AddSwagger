using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Byte.Bank.Infra.Context;
using Project.Byte.Bank.Interface.IUsuariosRepository;

namespace Project.Byte.Bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUsuariosRepository _usuariosRepository;
        private readonly UsuarioKey _usuarioKey;
        public UsuarioController(DataContext context, IMapper mapper, IUsuariosRepository usuariosRepository)
        {
            _context = context;
            _mapper = mapper;
            _usuariosRepository = usuariosRepository;
        }
        /// <summary>
        /// Adiciona um usuario ao banco de dados
        /// </summary>
        /// <param name="usuarioDto">Objeto com os campos necessários para criação de um usuario</param>
        /// <returns>IActionResult</returns>
        /// <response /code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionaUsuario([FromBody] CreateUsuarioDto usuarioDto)
        {
            UsuarioKey _usuarioDto = _mapper.Map<UsuarioKey>(usuarioDto); // Essa linha de código está com erro 500.  FormatException: Input string was not in a correct format.

            _context.UsuarioKey.Add(_usuarioDto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaUsuarioPorId), new { id = _usuarioDto.Id }, _usuarioDto);
        }
        /// <summary>
        /// Recupera uma lista de usuario do banco de dados
        /// </summary>
        /// <param name="skip">Número de usuarios que serão pulados</param>
        /// <param name="take">Número de usuarios que serão recuperados</param>
        /// <returns>Informações de usuarios buscados</returns>
        /// <response code="200">Com a lista de usuarios presentes na base de dados</response>
        [HttpGet]
        public IEnumerable<UsuarioKey> RecuperaUsuario(int skip = 0, int take = 10)
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult RecuperaUsuarioPorId(int id)
        {
            UsuarioKey _usuarioKey = _context.UsuarioKey.FirstOrDefault(UsuarioDto => UsuarioDto.Id == id); // Observação o Usuariokey = 
            if (_usuarioKey != null)
            {
                UsuarioDto RecuperaUsuarioPorId = _mapper.Map<UsuarioDto>(_usuarioKey); // Ele mapeia a entidade para a resposta, _mapper.Map<ReadUsuarioDto>. 
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
        public IActionResult AtualizaUsuario(int id, [FromBody] UpdateUsuarioDto _usuarioDto)
        {
            UsuarioKey usuario = _context.UsuarioKey.FirstOrDefault(usuario => usuario.Id == id);
            if (usuario != null)
            {
                _mapper.Map(_usuarioDto, usuario);
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
            UsuarioKey _usuario = _context.UsuarioKey.FirstOrDefault(_usuarioDto => _usuarioDto.Id == id);
            if (_usuario != null)
            {
                _context.Remove(_usuario);
                _context.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }

    }
}
