using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEndRound : MonoBehaviour
{
    [SerializeField]private SpriteRenderer sr;
    private SpellCaster connectedPlayer;
    [SerializeField]private GameObject circle;
    int numCircles;
    private int overlapNum = 2;
    public void SpawnIn(Material newMaterial, GameObject player){
        sr.material = newMaterial;
        TurnOn(false);
    }

    public void TurnOn(bool on){
        gameObject.SetActive(on);
    }

    public void GainPoint(){
        StartCoroutine(LightUp());
    }

    private IEnumerator LightUp(){
        GetComponent<SpriteRenderer>().color = Color.white;
        sr.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        Instantiate(circle, OverlapCalc(new Vector3(transform.position.x + ((numCircles * 0.6f) - 1.4f),transform.position.y + 0.5f, 0)), Quaternion.identity).transform.SetParent(transform);
        numCircles ++;
        yield return new WaitForSeconds(0.79f);
        GetComponent<SpriteRenderer>().color = new Color32(134, 134, 134, 255);
        sr.color = new Color32(134, 134, 134, 255);
    } 

    public Vector3 OverlapCalc(Vector3 overlap){
        return HowManyLevels(overlap);    
    }   

    public Vector2 HowManyLevels(Vector3 overlap){
        Vector3 finalCalc = overlap;
        if(overlap.x > transform.position.x + overlapNum){
            finalCalc.x = overlap.x - ((overlapNum * 2) - 0.4f);
            finalCalc.y = overlap.y - 0.55f;
            if(finalCalc.x > transform.position.x + overlapNum){
                return HowManyLevels(finalCalc);
            }
        }
        return finalCalc;
    }
}
