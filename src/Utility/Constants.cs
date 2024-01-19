using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

namespace VisibleTerraPretaParticles;

public static class Constants
{
    public const string ConfigName = "VisibleTerraPretaParticlesConfig.json";
    public static string[] DefaultBlockCodes = new string[] { "soil-high-*", "soil-compost-*" };

    public static AdvancedParticleProperties DefaultParticles = new AdvancedParticleProperties()
    {
        HsvaColor = new NatFloat[]
        {
            new NatFloat(0, 0, EnumDistribution.UNIFORM),
            new NatFloat(100, 0, EnumDistribution.UNIFORM),
            new NatFloat(40, 10, EnumDistribution.UNIFORM),
            new NatFloat(255, 0, EnumDistribution.UNIFORM)
        },
        GravityEffect = new NatFloat(-0.005f, 0, EnumDistribution.UNIFORM),
        PosOffset = new NatFloat[]
        {
            new NatFloat(0, 0.5f, EnumDistribution.UNIFORM),
            new NatFloat(0, 0.5f, EnumDistribution.UNIFORM),
            new NatFloat(0, 0.5f, EnumDistribution.UNIFORM)
        },
        Velocity = new NatFloat[]
        {
            new NatFloat(0, 0.05f, EnumDistribution.UNIFORM),
            new NatFloat(0.1f, 0.05f, EnumDistribution.UNIFORM),
            new NatFloat(0, 0.05f, EnumDistribution.UNIFORM)
        },
        WindAffectednes = 0,
        Quantity = new NatFloat(0, 1.5f, EnumDistribution.UNIFORM),
        TerrainCollision = false,
        Size = new NatFloat(0.5f, 0.05f, EnumDistribution.UNIFORM),
        SizeEvolve = new EvolvingNatFloat(EnumTransformFunction.LINEAR, 0.5f),
        ParticleModel = EnumParticleModel.Quad,
        LifeLength = new NatFloat(3, 0.5f, EnumDistribution.UNIFORM)
    };
}