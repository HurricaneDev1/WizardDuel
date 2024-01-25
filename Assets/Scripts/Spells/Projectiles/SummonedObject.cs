using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonedObject : MonoBehaviour
{
    protected SpellCaster caster;
    protected Rigidbody2D rb;
    [SerializeField]private float lifeSpan;
    private SpriteRenderer sr;
    [SerializeField]private bool permanent;
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    protected void Update(){
        //Kills the projectile off after a bit
        lifeSpan -= Time.deltaTime;
        if(lifeSpan <= 0){
            Destroy(gameObject);
        }
    }
    //Creates the projectile, changes its direction, speed and appearance based on the caster
    public virtual void Summon(SpellCaster newCaster, Material material){
        sr.material = material;
        sr.flipX = newCaster.GetComponentInChildren<SpriteRenderer>().flipX;
        caster = newCaster;
    }

    public bool IsPermanent(){
        return permanent;
    }
}
