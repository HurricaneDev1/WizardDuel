using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script for things that need to get hit; tried doing it with interfaces but it didn't really work
public class Hittable : MonoBehaviour
{
    public void GotHit(){
        Destroy(gameObject);
    }
}