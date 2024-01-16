using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SummonObject", menuName = "Spell/SummonObject")]
public class SummonObject : Spell
{
    [SerializeField]private GameObject summon;
    [SerializeField]private int numSummons = 1;
    [SerializeField]private int maxSummons;
    //Summons a projectile or object
    public override void Cast(SpellCaster caster, Material material)
    {
        for(int i = 0; i < numSummons; i++){
            SummonedObject newSummon = Instantiate(summon, caster.CastLocation(), Quaternion.identity).GetComponent<SummonedObject>();
            newSummon.Summon(caster, material);   
            if(newSummon.IsPermanent()){
                caster.summons.Add(newSummon);
                if(caster.summons.Count > maxSummons){
                    if(caster.summons[0]){
                        Destroy(caster.summons[0].gameObject);
                    }
                    caster.summons.Remove(caster.summons[0]);
                }
            } 
        }
        base.Cast(caster, material);
    }
}
