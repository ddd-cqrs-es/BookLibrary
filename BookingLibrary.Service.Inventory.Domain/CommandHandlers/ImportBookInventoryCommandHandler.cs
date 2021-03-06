using System;
using BookingLibrary.Domain.Core.Commands;
using BookingLibrary.Domain.Core.DataAccessor;

namespace BookingLibrary.Service.Inventory.Domain
{
    public class ImportBookInventoryCommandHandler : ICommandHandler<ImportBookInventoryCommand>
    {
        private IDomainRepository _domainRepository = null;

        public ImportBookInventoryCommandHandler(IDomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }

        public void Dispose()
        {
            _domainRepository = null;
        }

        public void Execute(ImportBookInventoryCommand command)
        {
            if(command.BookInventoryIds == null || command.BookInventoryIds.Count == 0){
                return;
            }

            foreach(var id in command.BookInventoryIds)
            {
                var bookInventory = new BookInventory(id, command.BookId, "Bulk Imported");
                _domainRepository.Save(bookInventory, -1, command.CommandUniqueId);
            }
        }
    }
}