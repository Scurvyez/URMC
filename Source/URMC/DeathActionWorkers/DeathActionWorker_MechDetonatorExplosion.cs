﻿using RimWorld;
using Verse.AI.Group;
using Verse;

namespace URMC
{
    public class DeathActionWorker_MechDetonatorExplosion : DeathActionWorker
    {
        public override RulePackDef DeathRules => RulePackDefOf.Transition_DiedExplosive;
        public override bool DangerousInMelee => true;
        
        public override void PawnDied(Corpse corpse, Lord prevLord)
        {
            if (corpse.InnerPawn.TryGetComp(out CompMechDetonator comp))
            {
                GenExplosion.DoExplosion(
                    radius: comp.Props.radius, 
                    damAmount: comp.Props.damage, 
                    center: corpse.Position, 
                    map: corpse.Map, 
                    damType: DamageDefOf.Flame, 
                    instigator: corpse.InnerPawn);
            }
        }
    }
}
