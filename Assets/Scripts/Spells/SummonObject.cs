using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class SummonObject : Spell
{
    [SerializeField]private GameObject summon;

    public override void Cast(SpellCaster caster)
    {
        Projectile newSummon = Instantiate(summon, caster.CastLocation(), Quaternion.identity).GetComponent<Projectile>();
        newSummon.Summon(caster);    
        base.Cast(caster);
    }
}
