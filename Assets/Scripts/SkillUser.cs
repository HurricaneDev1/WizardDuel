using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SkillUser : MonoBehaviour
{
    [SerializeField]private List<Skill> skillList = new List<Skill>();
    [SerializeField]private Transform attackPoint;
    public List<float> cooldowns = new List<float>();
    public List<bool> heldDown = new List<bool>();
    private Skill currentSkill;
    void Start(){
        for(int i = 0; i < skillList.Count; i++){
            cooldowns.Add(0);
            heldDown.Add(false);
        }
    }
    void Update(){
        for(int i = 0; i < heldDown.Count; i ++){
            cooldowns[i] -= Time.deltaTime;
            if(heldDown[i] == true && cooldowns[i] <= 0 && skillList[i].hold == true){
                skillList[i].HoldSkill(this);
            }
        }
    }
    public void SetSkill(int skillNum){
        currentSkill = skillList[skillNum];
    }
    public void CastSkill(InputAction.CallbackContext context){
        if(currentSkill){
            if(context.action.triggered){
                if(cooldowns[skillList.IndexOf(currentSkill)] <= 0){
                    currentSkill.Cast(this);
                    heldDown[skillList.IndexOf(currentSkill)] = true;
                }
            }else if(!context.action.triggered){
                heldDown[skillList.IndexOf(currentSkill)] = false;
            }
        }
    }
    public void SkillCooldown(Skill skill){
        int skillSlot = skillList.IndexOf(skill);
        cooldowns[skillSlot] = skill.coolDown;
    }
}
