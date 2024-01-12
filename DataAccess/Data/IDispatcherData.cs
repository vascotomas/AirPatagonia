using DataAccess.Models;

namespace DataAccess.Data;
public interface IDispatcherData
{
    Task DisableDispatcher(DispatcherModel dispatcher);
    Task<DispatcherModel?> GetDispatcher(int id);
    Task<IEnumerable<DispatcherModel>> GetDispatchers();
    Task InsertDispatcher(DispatcherModel dispatcher);
    Task<IEnumerable<DocumentType>> GetDocumentTypes();
}