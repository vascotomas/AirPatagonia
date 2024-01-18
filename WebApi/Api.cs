using DataAccess.Data;
using HashidsNet;
using System.Runtime.CompilerServices;

namespace WebApi;

public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet(pattern: "/Dispatchers", GetDispatchers);
        app.MapGet(pattern: "/Dispatchers/{id}", GetDispatcher);
        app.MapPost(pattern: "/Dispatchers", InsertDispatchers);
        app.MapPut(pattern: "/Dispatchers", DisableDispatcher);
    }

    private static async Task<IResult> GetDispatchers(IDispatcherData data)
    {
        try
        {
            return Results.Ok(await data.GetDispatchers());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetDispatcher(string id, IDispatcherData data, IHashids hashids)
    {
        try
        {
            var rawId = hashids.Decode(id);
            if(rawId.Length == 0)
                return Results.NotFound();
        
            var results = await data.GetDispatcher(rawId[0]);
            if (results is null) return Results.NotFound();

            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertDispatchers(DispatcherModel model, IDispatcherData data)
    {
        try
        {
            await data.InsertDispatcher(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DisableDispatcher(bool status, int id, IDispatcherData data)
    {
        try
        {
            await data.DisableDispatcher(status, id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
