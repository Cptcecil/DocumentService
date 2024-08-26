using DocumentService.Application.DTOs;
using DocumentService.Application.Interfaces;
using DocumentService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DocumentService.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document>>> GetDocuments()
        {
            var documents = await _documentService.GetAllDocumentsAsync();
            return Ok(documents);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Document>> GetDocument(int id)
        {
            var document = await _documentService.GetDocumentByIdAsync(id);
            if (document == null)
            {
                return NotFound();
            }

            return Ok(document);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Document>> CreateDocument(CreateDocumentDto createDocumentDto)
        {
            var document = await _documentService.AddDocumentAsync(createDocumentDto);
            return CreatedAtAction(nameof(GetDocument), new { id = document.Id }, document);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument(int id, CreateDocumentDto createDocumentDto)
        {
            await _documentService.UpdateDocumentAsync(id, createDocumentDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            await _documentService.DeleteDocumentAsync(id);
            return NoContent();
        }
    }
}
