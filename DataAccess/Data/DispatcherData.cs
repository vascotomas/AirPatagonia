using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;
public class DispatcherData : IDispatcherData
{
    private readonly ISqlDataAccess _db;

    public DispatcherData(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<DispatcherModel>> GetDispatchers()
    {
        var dispatchers = await _db.LoadData<DispatcherModel, dynamic>(storedProcedure: "spDispatcher_GetAll", new { });

        var documentTypes = await GetDocumentTypes();
        foreach (var  dispatcher in dispatchers)
        {
            dispatcher.DocumentType = documentTypes.FirstOrDefault(x => x.IdDocumentType == dispatcher.IdDocumentType);
        }
        return dispatchers;
    }

    public async Task<DispatcherModel?> GetDispatcher(int id)
    {
        var results = await _db.LoadData<DispatcherModel, dynamic>(
            storedProcedure: "spDispatcher_Get",
            new { IdDispatcher = id });

        return results.FirstOrDefault();
    }

    public Task InsertDispatcher(DispatcherModel dispatcher) =>
        _db.SaveData(storedProcedure: "spDispatcher_Insert",
                     new
                     {
                         dispatcher.BirthDate,
                         dispatcher.FirstName,
                         dispatcher.LastName,
                         dispatcher.Active,
                         dispatcher.DocumentType.IdDocumentType,
                         dispatcher.NoDocument
                     });

    public Task DisableDispatcher(DispatcherModel dispatcher) =>
        _db.SaveData(storedProcedure: "spDispatcher_Disable", new { dispatcher.Active, dispatcher.IdDispatcher });

    public Task<IEnumerable<DocumentType>> GetDocumentTypes() => _db.LoadData<DocumentType, dynamic>(storedProcedure: "spDocumentType_GetAll", new { });
}
