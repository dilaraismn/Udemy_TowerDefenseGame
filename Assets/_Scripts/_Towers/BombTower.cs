using UnityEngine;

public class BombTower : MonoBehaviour
{
    public Bomb _bomb;
    public Transform spawnPoint;
    
    private Tower _tower;
    private Transform target;
    private float bombCounter;
    
    
    void Start()
    {
       _tower = GetComponent<Tower>();
       bombCounter = _tower.fireRate;
    }

    void Update()
    {
        bombCounter -= Time.deltaTime;

        if (_tower.enemiesInRange.Count > 0)
        {
            if (bombCounter <= 0)
            {
                float minDistance = _tower.range + 1;
                foreach (EnemyController enemy in _tower.enemiesInRange)
                {
                    if (enemy != null)
                    {
                        float distance = Vector3.Distance(transform.position, enemy.transform.position);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            target = enemy.transform;
                        }
                    }
                }

                bombCounter = _tower.fireRate;
                Bomb newBomb = Instantiate(_bomb, spawnPoint.position, Quaternion.identity);
                newBomb.targetPoint = target.position;
            }
        }
    }
}
