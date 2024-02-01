using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : SummonedObject
{
    [SerializeField]protected int speed;
    public override void Summon(SpellCaster newCaster, Material material)
    {
        base.Summon(newCaster, material);
        rb.AddForce(caster.DirectionOfCast() * speed, ForceMode2D.Impulse);
    }
    //When the projectile hits something it dissapears and maybe destroys the thing
    public virtual void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Wall"){
            Destroy(gameObject);
        }else if(col.GetComponent<Hittable>()){
            if(col.gameObject != caster.gameObject){ 
                col.GetComponent<Hittable>().GotHit();
                Destroy(gameObject);
            }
        }
    }
}
