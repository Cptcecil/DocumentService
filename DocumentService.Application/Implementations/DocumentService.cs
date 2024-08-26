using DocumentService.Application.DTOs;
using DocumentService.Application.Interfaces;
using DocumentService.Domain.Entities;
using DocumentService.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentService.Application.Implementations
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<IEnumerable<Document>> GetAllDocumentsAsync()
        {
            return await _documentRepository.GetAllAsync();
        }

        public async Task<Document> GetDocumentByIdAsync(int id)
        {
            return await _documentRepository.GetByIdAsync(id);
        }

        public async Task<Document> AddDocumentAsync(CreateDocumentDto documentDto)
        {
            var document = new Document { 
                Name = documentDto.Name,
                CreatedBy = documentDto.CreatedBy,
                ExternalId = Guid.NewGuid(),
                StoragePath = documentDto.StoragePath,
                Size = documentDto.Size
            };

            return await _documentRepository.AddAsync(document);
        }

        public async Task UpdateDocumentAsync(int id, CreateDocumentDto documentDto)
        {
            var document = await _documentRepository.GetByIdAsync(id);

            document.Name = documentDto.Name;
            document.StoragePath = documentDto.StoragePath;
            document.Size = documentDto.Size;

            await _documentRepository.UpdateAsync(document);
        }

        public async Task DeleteDocumentAsync(int id)
        {
            await _documentRepository.DeleteAsync(id);
        }
    }
}
