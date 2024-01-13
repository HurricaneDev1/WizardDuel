using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellCaster : MonoBehaviour
{
    [SerializeField]private Spell primarySpell;
    [SerializeField]private Spell secondarySpell;
    [SerializeField]private Transform castingPoint;
    [SerializeField]private SpriteRenderer sr;
    private Material material;
    void Start(){
        if(sr){
            material = sr.material;
        }
    }
    void Update(){
        //Updates the cooldowns of the spells; probably a better way to do it
        if(primarySpell)primarySpell.UpdateTimer();
        if(secondarySpell)secondarySpell.UpdateTimer();
    }
    //Does the effect of a spell if its off cooldown
    public void CastSpell(Spell spell){
        if(spell.CanCast()){
            spell.Cast(this, material);
        }
    }
    //Casts primary spell
    public void CastPrimary(InputAction.CallbackContext context){
        if(context.action.triggered){
             CastSpell(primarySpell);
        }
    }
    //Casts secondary spell
    public void CastSecondary(InputAction.CallbackContext context){
        if(context.action.triggered){
            CastSpell(secondarySpell);
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
    public void GotHit(){
        Destroy(gameObject);
    }
}
