using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] float moveSpeed = 2f;
    int currentWaypointIndex = 0;

    void Start()
    {
        if(EnemyManager.Instance.randomMode) SetNewTarget();
    }

    void Update()
    {
        if(health <= 0f)
        {
            Die(false);
        }

        Move();
    }

    public void OnShot()
    {
        health -= 25f;

        Color newColor = GetComponent<SpriteRenderer>().color;
        newColor.a *= 0.8f;
        GetComponent<SpriteRenderer>().color = newColor;

        Color newAccent = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
        newAccent.a *= 0.8f;
        transform.GetChild(0).GetComponent<SpriteRenderer>().color = newAccent;
    }

    public void Die(bool byTouch)
    {
        EnemyManager.Instance.enemyCount--;

        if(byTouch) UIManager.Instance.touchKills++;
        else UIManager.Instance.eggKills++;

        UIManager.Instance.SetKills();

        Destroy(gameObject);
    }

    void Move()
    {
        Vector2 chasePos = WaypointManager.Instance.waypoints[currentWaypointIndex].position;

        transform.position = Vector2.MoveTowards(transform.position, chasePos, moveSpeed * Time.deltaTime);
        if(Vector2.Distance(transform.position, chasePos) < 0.25f) SetNewTarget();
    }

    void SetNewTarget()
    {
        if(EnemyManager.Instance.randomMode)
        {
            currentWaypointIndex = Random.Range(0, WaypointManager.Instance.waypoints.Count);
        }
        else
        {
            if(currentWaypointIndex == WaypointManager.Instance.waypoints.Count - 1) currentWaypointIndex = 0;
            else currentWaypointIndex++;
        }
    }
}
