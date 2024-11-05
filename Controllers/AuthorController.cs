using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CustomApi.Data;
using CustomApi.Models;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using CustomApi.Services.Interfaces;

namespace CustomApi.Controllers
{
    /// <summary>
    /// This is the AuthorController, responsible for handling author-related API requests.
    /// </summary>
    [ApiController]
    [Route("Author")]
    [SwaggerTag("Author data (AUTHOR)")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorController"/> class.
        /// </summary>
        /// <param name="authorService">The author service dependency.</param>
        /// <param name="mapper">The AutoMapper dependency for data transformation.</param>
        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves a list of all authors.
        /// </summary>
        /// <returns>A list of authors.</returns>
        [HttpGet("get")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AuthorDTO>))] 
        [ProducesResponseType(400)]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAuthors()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            var authorsDto = _mapper.Map<IEnumerable<AuthorDTO>>(authors);

            if (!ModelState.IsValid)
               return BadRequest(ModelState);

            return Ok(authorsDto);
        }

        /// <summary>
        /// Retrieves an author by their ID.
        /// </summary>
        /// <param name="id">The ID of the author to retrieve.</param>
        /// <returns>An author object if found; otherwise, a 404 response.</returns>
        [HttpGet("get/{id}")]
        [ProducesResponseType(200, Type = typeof(AuthorDTO))] 
        [ProducesResponseType(400)]
        public async Task<ActionResult<AuthorDTO>> GetAuthorById(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            var authorDto = _mapper.Map<AuthorDTO>(author);
            return Ok(authorDto);
        }

        /// <summary>
        /// Creates a new author.
        /// </summary>
        /// <param name="authorDto">The author object to create.</param>
        /// <returns>The created author object.</returns>
        [HttpPost("create")]
        public async Task<ActionResult<AuthorDTO>> CreateAuthor([FromBody] AuthorDTO authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            await _authorService.AddAuthorAsync(author);
            return CreatedAtAction(nameof(GetAuthorById), new { id = author.Id }, authorDto);
        }
    }
}
