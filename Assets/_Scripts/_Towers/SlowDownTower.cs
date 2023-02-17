using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownTower : MonoBehaviour
{
    public Transform effectRing;
    private Tower _tower;
    
    // Start is called before the first frame update
    void Start()
    {
        _tower = GetComponent<Tower>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (EnemyController enemy in _tower.enemiesInRange)
        {
            enemy.speedMod = .5f;
        }

        effectRing.localScale = new Vector3(_tower.range, 1, _tower.range);
    }
}