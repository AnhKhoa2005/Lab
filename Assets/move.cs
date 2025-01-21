using UnityEngine;

public class move : MonoBehaviour
{
    bool IsSpinning;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsSpinning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSpinning)
        {
            this.transform.Rotate(0, 0, 90);
        }
    }
}
