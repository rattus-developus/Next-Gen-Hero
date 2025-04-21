using UnityEngine;

public class Projectile : MonoBehaviour
{
    void Awake()
    {
        UIManager.Instance.eggsOnScreen++;
        UIManager.Instance.SetEggs();
    }

    void Update()
    {
        if(UIManager.Instance.paused) return;
        
        transform.position += transform.up * 40f * Time.deltaTime;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().OnShot();
            Destroy(gameObject);
        }
        if(collision.transform.tag == "Waypoint")
        {
            collision.gameObject.GetComponent<Waypoint>().OnShot();
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        UIManager.Instance.eggsOnScreen--;
        UIManager.Instance.SetEggs();
    }
}
