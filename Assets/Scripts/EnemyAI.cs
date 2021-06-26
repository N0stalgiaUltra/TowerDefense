using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    Transform[] _waypoints;
    [SerializeField]float _MoveSpeed = 2f;
    [SerializeField]int _WaypointIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = _waypoints[_WaypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position,_waypoints[_WaypointIndex].transform.position, _MoveSpeed * Time.deltaTime);

        if(this.transform.position == _waypoints[_WaypointIndex].transform.position)
            _WaypointIndex++;
        
        if(_WaypointIndex == _waypoints.Length)
            Debug.Log("Fim do caminho");
    }

}
