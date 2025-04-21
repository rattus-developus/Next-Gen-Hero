using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float shootCooldown = 0.2f;
    float shootTimer;

    void Update()
    {
        shootTimer -= Time.deltaTime;

        if(Input.GetKey(KeyCode.Space) && shootTimer <= 0f)
        {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.transform.position = transform.position;
            projectile.transform.rotation = transform.rotation;

            shootTimer = shootCooldown;
        }

        UIManager.Instance.UpdateEggCooldown(shootTimer / shootCooldown);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Enemy") collision.gameObject.GetComponent<Enemy>().Die(true);
    }
}
