using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMissle : Projectile
{
    public int move;
    public bool inverse;
    new protected void Update(){
        base.Update();
        transform.position = new Vector2(transform.position.x, transform.position.y +( inverse == true ? (Mathf.Sin(Time.time * 10)/move) : (Mathf.Sin(-Time.time * 10)/move)));
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
