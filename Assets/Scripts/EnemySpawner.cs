using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Randomizar as chances de n inimigos de spawnarem
    //repassar um array de 10 objetos 
    //ao fim de cada round, renova o array
    
    public GameObject[] enemies;
    public GameObject a;

    float[] probability;
    float[] cumulative;



    // Update is called once per frame
    void Update()
    {
        MakeCumulative();
        RandomEnemy();
    }
    void MakeCumulative()
    {
        float current = 0;
        int itemCount = probability.Length;

        for (int i = 0; i <= itemCount; i++)
        {
            current += probability[i];
            cumulative[i] = current;    
        }

        if(current > 1.0f)
            Debug.Log("Probabilities exceed 100%");

    }

    GameObject RandomEnemy()
    {
        float rnd = Random.Range(0, 1.0f);
        int item = cumulative.Length;

        for (int i = 0; i < item; i++)
        {
            if(rnd <= cumulative[i])
            {
               Debug.Log(enemies[i]);
            }
        }

        return null;
    }
}
