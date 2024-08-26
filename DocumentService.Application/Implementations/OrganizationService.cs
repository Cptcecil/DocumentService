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
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public async Task<IEnumerable<Organization>> GetAllOrganizationsAsync()
        {
            return await _organizationRepository.GetAllAsync();
        }

        public async Task<Organization> GetOrganizationByIdAsync(int id)
        {
            return await _organizationRepository.GetByIdAsync(id);
        }

        public async Task AddOrganizationAsync(Organization organization)
        {
            await _organizationRepository.AddAsync(organization);
        }

        public async Task UpdateOrganizationAsync(Organization organization)
        {
            await _organizationRepository.UpdateAsync(organization);
        }

        public async Task DeleteOrganizationAsync(int id)
        {
            await _organizationRepository.DeleteAsync(id);
        }
    }
}
