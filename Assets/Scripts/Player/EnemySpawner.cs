using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemyPrefab;
    
    [SerializeField] private float interval = 5f;
    [SerializeField] private float distance = 40f;
    [SerializeField] private float distanceVariation = 5f;
    
    [SerializeField] private float groupSpacing = 8f;
    [SerializeField] private int groupSize = 5;
    [SerializeField] private int groupSizeVariation = 2;
    
    private float spawnTimer = 0f;
    private Vector2 oldPos;
    
    void Update()
    {
        spawnTimer += Time.deltaTime;
        
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        if (spawnTimer < interval || (oldPos - playerPos).magnitude < 2) return;
        SpawnEnemies(playerPos);
        spawnTimer = 0f;
        oldPos = playerPos;
    }

    private void SpawnEnemies(Vector2 playerPos)
    {
        int size = groupSize + Random.Range(-groupSizeVariation, groupSizeVariation);
        for (int i = 0; i < size; i++)
        {
            Vector2 spawnDir = (playerPos - oldPos).normalized;
            float spawnDist = distance + Random.Range(-distanceVariation, distanceVariation);
            Vector2 spawnPos = playerPos + spawnDir * spawnDist + Random.insideUnitCircle.normalized * (groupSpacing);
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }
}
