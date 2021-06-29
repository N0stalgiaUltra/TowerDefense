using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool{
        public string tag;
        public int size;
        public GameObject prefab;

    }
    #region Singleton
      public static ObjectPooler Instance;
        private void Awake() {
            Instance = this;
        }
    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDicionario;
    void Start()
    {
        poolDicionario = new Dictionary<string, Queue<GameObject>>();
        
        foreach(Pool p in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < p.size; i++)
            {
                GameObject a = Instantiate(p.prefab);
                a.SetActive(false);
                objectPool.Enqueue(a);
            }

            poolDicionario.Add(p.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag)
    {
        if(!poolDicionario.ContainsKey(tag))
        {
            Debug.LogWarning("não tem chave na fila");
            return null;
        }

        if(poolDicionario.Count != 0)
        {
            GameObject o = poolDicionario[tag].Dequeue();
            o.SetActive(true);
            return o;
        }
        else{

            Debug.LogWarning("Fim da Fila");
            return null;
        }
    }

    public void SetFalse(GameObject go, string tag)
    {
        if(go != null)
        {
            Debug.Log("sumiu");            
            go.SetActive(false);
            poolDicionario[tag].Enqueue(go);
        }
        else
        {
            Debug.Log("não sumiu");
            return;
        
        }
    }
}
