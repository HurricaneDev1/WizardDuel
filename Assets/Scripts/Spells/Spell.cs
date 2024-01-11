using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Spell : ScriptableObject
{
    public float coolDown;
    private float cooldownTimer;
    public virtual void Cast(SpellCaster caster){
        cooldownTimer = coolDown;
    }

    public void UpdateTimer(){
        cooldownTimer -= Time.deltaTime;
    }

    public bool CanCast(){
        return (cooldownTimer <= 0);
    }
}
