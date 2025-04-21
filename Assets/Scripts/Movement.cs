using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    [SerializeField] bool useMouse = true;
    [SerializeField] float acceleration;
    [SerializeField] float lookSpeed;
    float velocity;

    void Update()
    {
        if(UIManager.Instance.paused) return;

        //Allow changing of control scheme
        if(Input.GetKeyDown(KeyCode.M))
        {
            velocity = 0f;
            useMouse = !useMouse;
            UIManager.Instance.SetHeroMode(useMouse);
        }
        
        Look();
        if(useMouse) MoveWithMouse();
        else MoveWithKeyboard();
    }

    void Look()
    {
        if(Input.GetKey(KeyCode.A)) transform.Rotate(Vector3.forward * lookSpeed * Time.deltaTime);
        if(Input.GetKey(KeyCode.D)) transform.Rotate(Vector3.forward * -lookSpeed * Time.deltaTime);
    }

    void MoveWithMouse()
    {
        //Use Vector2 to truncate position vector3
        Vector2 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = newPos;
    }

    void MoveWithKeyboard()
    {
        if(Input.GetKey(KeyCode.W)) velocity += acceleration * Time.deltaTime;
        if(Input.GetKey(KeyCode.S)) velocity -= acceleration * Time.deltaTime;
        
        //Move while ensuring player doesn't leave screen
        Vector2 moveBounds = new Vector2(Camera.main.orthographicSize * EnemyManager.ASPECT_RATIO, Camera.main.orthographicSize) * 0.985f;
        Vector2 nextPos = transform.position + transform.up * velocity;
        if(Mathf.Abs(nextPos.x) < moveBounds.x &&  Mathf.Abs(nextPos.y) < moveBounds.y) transform.position = nextPos;
    }
}
