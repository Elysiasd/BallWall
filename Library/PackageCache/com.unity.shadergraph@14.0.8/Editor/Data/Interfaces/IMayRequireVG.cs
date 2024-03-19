namespace UnityEditor.ShaderGraph
{
    // Interface for some nodes to determine whether they need VG by ShaderStageCapability.
    // By default, we make sure that these nodes, supporting ShaderStageCapability including
    // fragment stage, should be require VG.
    // When generating node codes, ShaderGraph will maintain requirements again,so we could
    // acquire runtime ShaderStageCapability to determine actual codes needed to be generated.
    interface IMayRequireVG
    {
        bool RequiresVG(ShaderStageCapability stageCapability = ShaderStageCapability.All);
    }

    // Some nodes derived from CodeFunctionNode will use special MaterialSlot, so this would
    // be essential. But for now, VG do not need this.
    //static class MayRequireVGExtensions
    //{
    //    public static bool RequiresVG(this MaterialSlot slot, ShaderStageCapability stageCapability)
    //    {
    //        var mayRequireVG = slot as IMayRequireVG;
    //        return mayRequireVG?.RequiresVG(stageCapability) ?? false;
    //    }
    //}
}
