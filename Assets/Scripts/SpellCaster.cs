using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpellCaster : MonoBehaviour
{
    [SerializeField]private Spell primarySpell;
   // private Spell secondarySpell;
    [SerializeField]private Transform castingPoint;
    void Update(){
        if(primarySpell)primarySpell.UpdateTimer();
    }
    public void CastSpell(InputAction.CallbackContext context){
        if(context.action.triggered){
            if(primarySpell.CanCast()){
                primarySpell.Cast(this);
            }
        }
    }

    public Vector3 CastLocation(){
        return castingPoint.position;
    }

    public void FlipCastLocation(){
        transform.Rotate(0f,180f,0f);
    }
}
