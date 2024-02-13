using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : Projectile
{
    [SerializeField]private float fallSpeed = 5;
    public override void Summon(SpellCaster newCaster, Material material)
    {
        base.Summon(newCaster, material);
        transform.position = new Vector2(Random.Range(-14, 15), 7.5f);
    }
    protected void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - fallSpeed);
    }
}
