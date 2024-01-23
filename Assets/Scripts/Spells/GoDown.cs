using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GoDown", menuName = "Spell/GoDown")]
public class GoDown : Spell
{
    public int downForce;
    public override void Cast(SpellCaster caster, Material material){
        caster.GetComponent<Rigidbody2D>().AddForce(Vector2.down * downForce, ForceMode2D.Impulse);
    }
}
