using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMissle : Projectile
{
    public int move;
    private float myTime;
    new protected void Update(){
        base.Update();
        myTime += Time.deltaTime;
        transform.position = new Vector2(transform.position.x, transform.position.y + (Mathf.Cos(myTime * 15)/move));
    }

    public override void OnTriggerEnter2D(Collider2D col){
    if(col.GetComponent<Hittable>()){
            if(col.gameObject != caster.gameObject){ 
                col.GetComponent<Hittable>().GotHit();
                Destroy(gameObject);
            }
        }
    }
}
