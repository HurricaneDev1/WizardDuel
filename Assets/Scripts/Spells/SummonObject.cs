using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class SummonObject : Spell
{
    [SerializeField]private GameObject summon;
    //Summons a projectile or object
    public override void Cast(SpellCaster caster, Material material)
    {
        Projectile newSummon = Instantiate(summon, caster.CastLocation(), Quaternion.identity).GetComponent<Projectile>();
        newSummon.Summon(caster, material);    
        base.Cast(caster, material);
    }
}
