using System;
using Vintagestory.API.Util;
using System.Linq;
using Vintagestory.API.Common;

namespace VisibleTerraPretaParticles;

public class ConfigParticles : IModConfig
{
    public bool Enabled { get; set; } = true;
    public string[] BlockCodes { get; set; } = Array.Empty<string>();
    public AdvancedParticleProperties[] Particles { get; set; } = Array.Empty<AdvancedParticleProperties>();

    public ConfigParticles(ICoreAPI api, ConfigParticles previousConfig = null)
    {
        if (previousConfig != null)
        {
            this.BlockCodes = previousConfig.BlockCodes;
            this.Particles = previousConfig.Particles;
        }

        if (api != null)
        {
            this.FillDefault();
        }
    }

    private void FillDefault()
    {
        this.Particles = new AdvancedParticleProperties[] { Constants.DefaultParticles };

        foreach (string blockCode in Constants.DefaultBlockCodes)
        {
            if (!this.BlockCodes.Contains(blockCode))
            {
                this.BlockCodes = this.BlockCodes.Append(blockCode);
            }
        }
    }
}
