using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spell : ScriptableObject
{
    public float coolDown;
    protected SpellCaster spellCaster; 
    public virtual void Cast(SpellCaster caster, Material material){
        spellCaster = caster;
        caster.SpellCooldown(this);
    }

    public virtual void EndCast(){
        
    }
}
