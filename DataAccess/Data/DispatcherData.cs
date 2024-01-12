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

    public Task<IEnumerable<DispatcherModel>> GetDispatchers() =>
        _db.LoadData<DispatcherModel, dynamic>(storedProcedure: "dbo.spDispatcher_GetAll", new { });

    public async Task<DispatcherModel?> GetDispatcher(int id)
    {
        var results = await _db.LoadData<DispatcherModel, dynamic>(
            storedProcedure: "dbo.spDispatcher_Get",
            new { IdDispatcher = id });

        return results.FirstOrDefault();
    }

    public Task InsertDispatcher(DispatcherModel dispatcher) =>
        _db.SaveData(storedProcedure: "dbo.spDispatcher_Insert",
                     new
                     {
                         dispatcher.BirthDate,
                         dispatcher.FirstName,
                         dispatcher.LastName,
                         dispatcher.IsActive,
                         dispatcher.DocumentType.IdDocumentType,
                         dispatcher.NoDocument
                     });

    public Task DisableDispatcher(DispatcherModel dispatcher) =>
        _db.SaveData(storedProcedure: "dbo.spDispatcher_Disable", new { dispatcher.IsActive, dispatcher.IdDispatcher });
}
