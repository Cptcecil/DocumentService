using DocumentService.Application.DTOs;
using DocumentService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentService.Application.Interfaces
{
    public interface IDocumentService
    {
        Task<IEnumerable<Document>> GetAllDocumentsAsync();
        Task<Document> GetDocumentByIdAsync(int id);
        Task<Document> AddDocumentAsync(CreateDocumentDto document);
        Task UpdateDocumentAsync(int i, CreateDocumentDto document);
        Task DeleteDocumentAsync(int id);
    }
}
