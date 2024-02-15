using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : ScriptableObject
{
    public float coolDown;
    public bool hold;
    public virtual void Cast(SkillUser user){
        user.SkillCooldown(this); 
    }

    public virtual void EndCast(){
        
    }

    public virtual void HoldSkill(SkillUser user){
        Cast(user);
    }
}
