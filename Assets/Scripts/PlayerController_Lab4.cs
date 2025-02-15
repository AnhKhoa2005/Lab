using UnityEngine;

public class PlayerController_Lab4 : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Bài 1
        if (Input.GetKeyDown(KeyCode.W)) Debug.Log("Get key down W");
        if (Input.GetKey(KeyCode.W)) Debug.Log("Get key W");
        if (Input.GetKeyUp(KeyCode.W)) Debug.Log("Get key up W");
        if (Input.GetMouseButton(1)) Debug.Log("Get Mouse Right");
        if (Input.GetMouseButton(0)) Debug.Log("Get Mouse Left");
        //Bài 2
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rb.linearVelocity = movement.normalized * speed;
        Flip();
    }

    void Flip()
    {
        if (movement.x > 0)
        {
            sprite.flipX = false;
        }
        else if (movement.x < 0)
        {
            sprite.flipX = true;
        }
    }
}
