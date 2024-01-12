using DataAccess.Data;
using System.Runtime.CompilerServices;

namespace WebApi;

public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet(pattern: "/Dispatchers", GetDispatchers);
        app.MapGet(pattern: "/Dispatchers/{id}", GetDispatcher);
        app.MapPost(pattern: "/Dispatchers", InsertDispatchers);
        app.MapPut (pattern: "/Dispatchers", DisableDispatcher);
    }

    private static   async Task<IResult> GetDispatchers(IDispatcherData data)
    {
        try
        {
            return Results.Ok(await data.GetDispatchers());
        }
        catch ( Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    
    private static async Task<IResult> GetDispatcher(int id, IDispatcherData data)
    {
        try
        {
            var results = await data.GetDispatcher(id);
            if(results is null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertDispatchers(DispatcherModel model,IDispatcherData data)
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

    private static async Task<IResult> DisableDispatcher(DispatcherModel model, IDispatcherData data)
    {
        try
        {
            await data.DisableDispatcher(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
