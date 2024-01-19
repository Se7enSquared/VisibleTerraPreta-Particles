using System;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.MathTools;
using Vintagestory.API.Util;

[assembly: ModInfo(name: "Visible Terra Preta Particles", modID: "vtpp", Side = "Client")]

namespace VisibleTerraPretaParticles;

public class Core : ModSystem
{
    public static ConfigParticles ConfigParticles { get; set; }

    public override void AssetsFinalize(ICoreAPI api)
    {
        ConfigParticles = ModConfig.ReadConfig<ConfigParticles>(api as ICoreClientAPI, Constants.ConfigName);

        foreach (Block block in api.World.Blocks)
        {
            if (block.WildCardMatch(ConfigParticles.BlockCodes))
            {
                block.ParticleProperties ??= Array.Empty<AdvancedParticleProperties>();
                block.ParticleProperties = block.ParticleProperties.Append(ConfigParticles.Particles);
            }
        }

        api.World.Logger.Event("started '{0}' mod", Mod.Info.Name);
    }
}