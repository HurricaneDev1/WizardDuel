using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private SpellCaster caster;
    private Rigidbody2D rb;
    [SerializeField]private int speed;
    [SerializeField]private float lifeSpan;
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Update(){
        lifeSpan -= Time.deltaTime;
        if(lifeSpan <= 0){
            Destroy(gameObject);
        }
    }
    public void Summon(SpellCaster newCaster){
        caster = newCaster;
        rb.AddForce(caster.DirectionOfCast() * speed, ForceMode2D.Impulse);
    }

    public void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Wall"){
            Destroy(gameObject);
        }else if(col.GetComponent<SpellCaster>()){
            SpellCaster colCast = col.GetComponent<SpellCaster>();
            if(colCast != caster){
                colCast.GotHit();
                Destroy(gameObject);
            }
        }
    }
}
