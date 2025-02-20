using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public float speed = 1f;  // Tốc độ di chuyển
    public float range = 2f;  // Biên độ dao động (khoảng cách di chuyển)

    private float startX;  // Vị trí ban đầu của nhân vật

    void Start()
    {
        startX = transform.position.x;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * speed) * range;
        transform.position = new Vector3(startX + offset, transform.position.y, transform.position.z);
    }
}
