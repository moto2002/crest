﻿// This file is subject to the MIT License as seen in the root of this folder structure (LICENSE)

using UnityEngine;

namespace Crest
{
    /// <summary>
    /// A persistent foam simulation that moves around with a displacement LOD.
    /// </summary>
    public class SimFoam : SimBase
    {
        public override string SimName { get { return "Foam"; } }
        protected override string ShaderSim { get { return "Ocean/Shape/Sim/Foam"; } }
        protected override string ShaderRenderResultsIntoDispTexture { get { return "Ocean/Shape/Sim/Foam Add To Disps"; } }
        public override RenderTextureFormat TextureFormat { get { return RenderTextureFormat.RHalf; } }
        public static readonly int SIM_RENDER_DEPTH = -20;
        public override int Depth { get { return SIM_RENDER_DEPTH; } }

        [Range(0f, 5f)]
        public float _foamFadeRate = 0.8f;
        [Range(0f, 5f)]
        public float _WaveFoamStrength = 1.25f;
        [Range(0f, 1f)]
        public float _WaveFoamCoverage = 0.8f;
        [Range(0f, 3f)]
        public float _ShorelineFoamMaxDepth = 0.65f;
        [Range(0f, 1f)]
        public float _ShorelineFoamStrength = 0.313f;

        protected override void SetAdditionalSimParams(Material simMaterial)
        {
            base.SetAdditionalSimParams(simMaterial);

            simMaterial.SetFloat("_FoamFadeRate", _foamFadeRate);
            simMaterial.SetFloat("_WaveFoamStrength", _WaveFoamStrength);
            simMaterial.SetFloat("_WaveFoamCoverage", _WaveFoamCoverage);
            simMaterial.SetFloat("_ShorelineFoamMaxDepth", _ShorelineFoamMaxDepth);
            simMaterial.SetFloat("_ShorelineFoamStrength", _ShorelineFoamStrength);
        }
    }
}
