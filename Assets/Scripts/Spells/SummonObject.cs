using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class SummonObject : Spell
{
    [SerializeField]private GameObject summon;

    public override void Cast(SpellCaster caster)
    {
        Instantiate(summon, caster.CastLocation(), Quaternion.identity);
        base.Cast(caster);
    }
}
