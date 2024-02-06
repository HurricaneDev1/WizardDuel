using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHittable : Hittable
{
    private bool currentlyDead;
    private SpellCaster caster;
    private ScreenWrap wrap;
    void Start(){
        caster = GetComponent<SpellCaster>();
        wrap = GetComponent<ScreenWrap>();
    }
     public override void GotHit(){
        Instantiate(particle, transform.position, Quaternion.identity);
        wrap.activated = false;
        transform.position = new Vector2(-400,-400);
        
        currentlyDead = true;
        PlayerManager.I.AllPlayersAlive();
    }

    public bool IsDead(){
        return currentlyDead;
    }

    public void Reset(Vector3 resetPosition){
        wrap.activated = true;
        transform.position = resetPosition;
        currentlyDead = false;
        caster.ResetSummons();
    }
}
