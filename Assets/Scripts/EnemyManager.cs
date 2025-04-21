using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    public static EnemyManager Instance;
    public static float ASPECT_RATIO = 1.77777777778f;
    public int enemyCount;
    public bool randomMode;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        while(enemyCount < 10) SpawnEnemy();

        if(Input.GetKeyDown(KeyCode.J))
        {
            randomMode = !randomMode;
            UIManager.Instance.SetEnemyMode(randomMode);
        }
    }

    void SpawnEnemy()
    {
        Vector2 spawnBounds = new Vector2(Camera.main.orthographicSize * ASPECT_RATIO, Camera.main.orthographicSize) * 0.9f;
        Vector2 spawnPos = new Vector2(Random.Range(-spawnBounds.x, spawnBounds.x), Random.Range(-spawnBounds.y, spawnBounds.y));

        GameObject enemy = Instantiate(enemyPrefab);
        enemyPrefab.transform.position = spawnPos;
        enemyCount++;
    }
}
