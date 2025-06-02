//  Copyright (c) 2024 RickGrymes
// Licensed under the MIT License
// See LICENSE.txt for the full text of the license

using UnityEngine;
using Verse;
using RimWorld;
using JetBrains.Annotations;

namespace URMC
{
    [UsedImplicitly]
    public class CharacterAppearanceDefinition : CharacterBaseDefinition
    {
        public HairDef hairDef;
        public BeardDef beardDef;
        public TattooDef faceTattooDef;
        public TattooDef bodyTattooDef;
        public Color? hairColor;
        public Color? skinColorOverride;
        public HeadTypeDef headTypeDef;
        public BodyTypeDef bodyTypeDef;

        public override bool AppliesPreGeneration => bodyTypeDef != null;
        public override bool AppliesPostGeneration => true;

        public override void ApplyToRequest(ref PawnGenerationRequest request)
        {
            request.ForceBodyType = bodyTypeDef ?? request.ForceBodyType;
        }

        public override void ApplyToPawn(Pawn pawn)
        {
            if (hairDef != null)
                pawn.story.hairDef = hairDef;

            if (hairColor != null)
                pawn.story.HairColor = (Color)hairColor;

            if (beardDef != null)
                pawn.style.beardDef = beardDef;

            if (skinColorOverride != null)
                pawn.story.skinColorOverride = skinColorOverride;

            if (faceTattooDef != null)
                pawn.style.FaceTattoo = faceTattooDef;

            if (bodyTattooDef != null)
                pawn.style.BodyTattoo = bodyTattooDef;

            if (headTypeDef != null)
                pawn.story.headType = headTypeDef;

            if (bodyTypeDef != null)
                pawn.story.bodyType = bodyTypeDef;

            pawn.Drawer?.renderer?.SetAllGraphicsDirty();
        }
    }
}