using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [Range(0,1)]public float probChance;
    
    [SerializeField] ObjectPooler op;


    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.tag == "Bullet")
        {
            op.SetFalse(this.gameObject, this.gameObject.tag);
        }


    }
}