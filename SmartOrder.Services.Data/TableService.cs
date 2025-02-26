using Microsoft.EntityFrameworkCore;
using SmartOrder.Data.Models;
using SmartOrder.Data.Repository.Interfaces;
using SmartOrder.Services.Data.Interfaces;
using SmartOrder.Web.ViewModels.Table;
using System.Collections.Immutable;

namespace SmartOrder.Services.Data
{
    public class TableService : BaseService, ITableService
    {
        private readonly IRepository<Table, Guid> tableRepository;

        public TableService(IRepository<Table, Guid> tableRepository)
        {
            this.tableRepository = tableRepository;
        }

        public async Task<IEnumerable<TableViewModel>> GetAllTablesAsync(string venueId)
        {
            IEnumerable<Table> tables = await tableRepository
                .GetAllAttached()
                .Include(t => t.Venue)
                .Where(t => t.VenueId.ToString() == venueId)
                .OrderBy(t => t.TableNumber)
                .ToListAsync();

            return tables.Select(t => new TableViewModel
            {
                Id = t.Id.ToString(),
                VenueId = t.VenueId.ToString(),
                VenueName = t.Venue.Name,
                TableNumber = t.TableNumber,
                Token = t.Token
            });
        }

        public async Task<bool> AddTableAsync(TableViewModel tableViewModel)
        {
            Guid venueGuid = Guid.Empty;
            if (!IsGuidValid(tableViewModel.VenueId, ref venueGuid))
            {
                return false;
            }

            Table table = new Table
            {
                Id = Guid.NewGuid(),
                VenueId = venueGuid,
                TableNumber = tableViewModel.TableNumber,
                Token = Guid.NewGuid().ToString()
            };
            await tableRepository.AddAsync(table);
            return true;
        }

        public async Task<bool> DeleteTableAsync(Guid tableId)
        {
            Table table = await tableRepository.GetByIdAsync(tableId);
            if (table == null)
            {
                return false;
            }

            await tableRepository.DeleteAsync(table);
            return true;
        }

        public async Task<Guid?> GetVenueIdByTableTokenAsync(string token)
        {
            Table table = await tableRepository.FirstOrDefaultAsync(t => t.Token == token);
            return table?.VenueId;
        }

        public async Task<Guid> GetTableIdByTokenAsync(string token)
        {
            Table? table = await this.tableRepository
                .GetAllAttached()
                .FirstOrDefaultAsync(t => t.Token == token);

            return table!.Id;
        }

        public async Task<string> GetTokenByTableIdAsync(Guid tableId)
        {
            Table? table = await this.tableRepository
                .GetAllAttached()
                .FirstOrDefaultAsync(t => t.Id == tableId);

            return table!.Token;
        }
    }
}
