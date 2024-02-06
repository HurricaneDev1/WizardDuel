using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spell : ScriptableObject
{
    public float coolDown;
    public bool hold;
    public virtual void Cast(SpellCaster caster, Material material){
        caster.SpellCooldown(this); 
    }

    public virtual void EndCast(){
        
    }

    public virtual void HoldSkill(SpellCaster caster, Material material){
        Cast(caster, material);
    }
}
