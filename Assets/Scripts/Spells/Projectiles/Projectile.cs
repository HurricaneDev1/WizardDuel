using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private SpellCaster caster;
    private Rigidbody2D rb;
    [SerializeField]private int speed;
    [SerializeField]private float lifeSpan;
    private SpriteRenderer sr;
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Update(){
        //Kills the projectile off after a bit
        lifeSpan -= Time.deltaTime;
        if(lifeSpan <= 0){
            Destroy(gameObject);
        }
    }
    //Creates the projectile, changes its direction, speed and appearance based on the caster
    public void Summon(SpellCaster newCaster, Material material){
        sr.material = material;
        sr.flipX = newCaster.GetComponentInChildren<SpriteRenderer>().flipX;
        caster = newCaster;
        rb.AddForce(caster.DirectionOfCast() * speed, ForceMode2D.Impulse);
    }
    //When the projectile hits something it dissapears and maybe destroys the thing
    public void OnTriggerEnter2D(Collider2D col){
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
