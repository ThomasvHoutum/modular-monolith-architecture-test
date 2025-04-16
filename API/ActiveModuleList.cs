using Core.Modules.Interfaces;

namespace API;

public static class ActiveModuleList
{
    // Add all active modules to this list
    public static List<IModule> Modules => new()
    {
        new WarningModule.ModuleActivator()
    };
}