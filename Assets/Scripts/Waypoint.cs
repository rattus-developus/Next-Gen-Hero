using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] float health = 100f;
    Vector2 originalPos;

    void Awake()
    {
        originalPos = transform.position;
    }

    void Update()
    {
        if(health <= 0f)
        {
            Relocate();
        }
    }

    public void OnShot()
    {
        health -= 25f;

        Color newColor = GetComponent<SpriteRenderer>().color;
        newColor.a -= 0.25f;
        GetComponent<SpriteRenderer>().color = newColor;
    }

    public void Relocate()
    {
        Vector2 randomization = new Vector2(Random.Range(-15f, 15f), Random.Range(-15f, 15f));
        transform.position = originalPos + randomization;
        health = 100f;

        Color newColor = GetComponent<SpriteRenderer>().color;
        newColor.a = 1f;
        GetComponent<SpriteRenderer>().color = newColor;
    }
}
