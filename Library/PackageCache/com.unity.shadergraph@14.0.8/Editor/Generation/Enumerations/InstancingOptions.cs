using System;

namespace UnityEditor.ShaderGraph
{
    [GenerationAPI]
    internal enum InstancingOptions
    {
        RenderingLayer,
        NoLightProbe,
        NoLodFade,
        Procedural
    }

    [GenerationAPI]
    internal static class InstancingOptionsExtensions
    {
        public static string ToShaderString(this InstancingOptions options)
        {
            switch (options)
            {
                case InstancingOptions.RenderingLayer:
                    return "renderinglayer";
                case InstancingOptions.NoLightProbe:
                    return "nolightprobe";
                case InstancingOptions.NoLodFade:
                    return "nolodfade";
                case InstancingOptions.Procedural:
                    return "procedural : setup";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
