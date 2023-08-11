using System;
using System.IO;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Config;
using Vintagestory.API.MathTools;
using Vintagestory.API.Util;

[assembly: ModInfo(name: "Visible Terra Preta Particles", modID: "vtpp", Side = "Client")]

namespace VisibleTerraPretaParticles;

public class Core : ModSystem
{
    public SettingsFile<ParticleSettings> ParticleSettings { get; set; } = new(Path.Combine(GamePaths.ModConfig, "VisibleTerraPretaParticlesConfig.json"));

    public AdvancedParticleProperties[] Particles => ParticleSettings.Settings.Particles;

    public override void AssetsFinalize(ICoreAPI api)
    {
        base.AssetsFinalize(api);

        foreach (Block block in api.World.Blocks)
        {
            if (!block.WildCardMatch("soil-high-*"))
            {
                continue;
            }

            block.ParticleProperties ??= Array.Empty<AdvancedParticleProperties>();
            block.ParticleProperties = block.ParticleProperties.Append(Particles);
        }

        api.World.Logger.Event("started '{0}' mod", Mod.Info.Name);
    }
}