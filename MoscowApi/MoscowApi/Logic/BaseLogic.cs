namespace MoscowApi.Logic;

public abstract class BaseLogic
{
    
    protected readonly IServiceScope Scope;

    public BaseLogic(IServiceScopeFactory scopeFactory)
    {
        Scope = scopeFactory.CreateScope();
    }
}