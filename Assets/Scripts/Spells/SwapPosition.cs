using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SwapPosition", menuName = "Spell/Swap Position")]
public class SwapPosition : Spell
{
    public override void Cast(SpellCaster caster, Material material)
    {
        base.Cast(caster, material);
        if(caster.GetRandomSummon() != null){
            SummonedObject summon = caster.GetRandomSummon();
            Vector3 spellCasterPos = caster.transform.position;
            caster.transform.position = summon.transform.position;
            summon.transform.position = spellCasterPos;
        }
    }
}
