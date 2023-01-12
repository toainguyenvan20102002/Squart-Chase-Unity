using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    List<EnemyFollowPath> listEnemys = new List<EnemyFollowPath>();
    public GameObject enemyPrefab;
    public GameObject ghostPrefab;

    public int minDistanceToPlayer = 30;
    public int distanceBetweenEnemy = 10;
    public int maxCountEnemys = 15;

    private void Start()
    {
        if(instance == null) instance = this;
    }

    public void GenerateEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab);
        enemy.GetComponent<EnemyFollowPath>().DistanceIndex = minDistanceToPlayer + listEnemys.Count * distanceBetweenEnemy;

        listEnemys.Add(enemy.GetComponent<EnemyFollowPath>());
    }

    public void RemoveEnemy(EnemyFollowPath enemy)
    {
        listEnemys.Remove(enemy);
    }

    private void Update()
    {
        if (listEnemys.Count > 0 && listEnemys[0] != null) listEnemys[0].GetComponent<EnemyAttack>().Attack();
    }

    public GameObject GetLastEnemy()
    {
        if(listEnemys.Count <= 0) return null;
        return listEnemys[listEnemys.Count - 1].gameObject;
    }

    public void GenerateGhost(Vector2 position)
    {
        Instantiate(ghostPrefab, position, Quaternion.identity);
    }
}
