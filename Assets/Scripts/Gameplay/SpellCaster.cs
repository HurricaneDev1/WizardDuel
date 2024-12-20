using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellCaster : MonoBehaviour
{
    [SerializeField]private List<Spell> spellList = new List<Spell>();
    [SerializeField]private Transform castingPoint;
    [SerializeField]private SpriteRenderer sr;
    public List<SummonedObject> summons = new List<SummonedObject>();
    public List<float> cooldowns = new List<float>();
    public List<bool> heldDown = new List<bool>();
    private Spell currentSpell;
    private Material material;
    void Start(){
        if(sr){
            material = sr.material;
        }

        for(int i = 0; i < spellList.Count; i++){
            cooldowns.Add(0);
            heldDown.Add(false);
        }
    }
    void Update(){
        //Updates the cooldowns of the spells; probably a better way to do it
        for(int i = 0; i < cooldowns.Count; i ++){
            cooldowns[i] -= Time.deltaTime;
        }

        for(int i = 0; i < heldDown.Count; i ++){
            if(heldDown[i] == true && cooldowns[i] <= 0 && spellList[i].hold == true){
                spellList[i].HoldSkill(this, material);
            }
        }
    }
    public void SetSpell(int spellNum){
        currentSpell = spellList[spellNum];
    }
    public void CastSpell(InputAction.CallbackContext context){
        if(currentSpell){
            if(context.action.triggered){
                if(cooldowns[spellList.IndexOf(currentSpell)] <= 0){
                    currentSpell.Cast(this, material);
                    heldDown[spellList.IndexOf(currentSpell)] = true;
                }
            }else if(!context.action.triggered){
                heldDown[spellList.IndexOf(currentSpell)] = false;
            }
        }
    }
    //Gets the location of castingPoint
    public Vector3 CastLocation(){
        return castingPoint.position;
    }
    //Flips the direction you cast your spells
    public void FlipCastLocation(){
        castingPoint.parent.Rotate(0f,180f,0f);
    }
    //Gets the direction of the castingPoint to see which direction to shoot
    public Vector2 DirectionOfCast(){
        return castingPoint.position - transform.position;
    }
    public SummonedObject GetRandomSummon(){
        if(summons.Count > 0){
            for(int i = summons.Count - 1; i >= 0; i--){
                if(summons[i] == null){
                    summons.Remove(summons[i]);
                }
            }
            if(summons.Count > 0){
                return summons[Random.Range(0, summons.Count)];
            }else{
                return null;
            }
        }
        return null;
    }
    public void SpellCooldown(Spell spell){
        int spellSlot = spellList.IndexOf(spell);
        cooldowns[spellSlot] = spell.coolDown;
    }

    public void ResetSummons(){
     for(int i = summons.Count - 1; i >= 0; i--){
            if(summons[i] == null){
                summons.Remove(summons[i]);
            }else{
                Destroy(summons[i].gameObject);
                summons.Remove(summons[i]);
            }
        }
    }
}
