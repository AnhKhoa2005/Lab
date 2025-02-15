using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLab5 : MonoBehaviour
{
    [Header("-----------------------Properties-----------------------")]
    [SerializeField] float speed;
    [SerializeField] float jump;
    [Header("-----------------------Component-----------------------")]
    [SerializeField] Transform GroundCheck;
    [SerializeField] LayerMask layerMask;
    [SerializeField] TextMeshProUGUI Score;
    [SerializeField] GameObject fruit;
    [SerializeField] GameObject _YouWin;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator ani;
    bool IsGround, moveButton, jumping;
    float xDir, running = 0;
    int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        IsGround = Physics2D.OverlapCircle(GroundCheck.position, 0.5f, layerMask);
        Move();
        Jump();
        Flip();
        AnimationUpDate();
        YouWin();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(xDir * speed, rb.linearVelocity.y);
    }
    public void Move()
    {
        if (!moveButton) xDir = Input.GetAxisRaw("Horizontal");
        if (xDir == 0) return;
        RunSFX();
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && IsGround)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);
            AudioManager.instance.SFX(AudioManager.instance.JumpSFX);
        }
    }

    public void MoveLeft()
    {
        moveButton = true;
        xDir = -1;
        RunSFX();
    }

    public void MoveRight()
    {
        moveButton = true;
        xDir = 1;
        RunSFX();
    }

    public void moveStop()
    {
        moveButton = false;
        xDir = 0;
    }
    public void _Jump()
    {
        if (IsGround)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);
            AudioManager.instance.SFX(AudioManager.instance.JumpSFX);
        }
    }

    public void Flip()
    {
        if (xDir > 0) sr.flipX = false;
        else if (xDir < 0) sr.flipX = true;
    }

    public void AnimationUpDate()
    {
        bool running = xDir != 0;
        jumping = !IsGround;
        ani.SetBool("run", running);
        ani.SetBool("jump", jumping);
    }

    public void RunSFX()
    {
        running += Time.deltaTime;
        if (running >= 0.5f)
        {
            AudioManager.instance.SFX(AudioManager.instance.RunSFX);
            running = 0;
        }
    }

    public void YouWin()
    {
        if (fruit.transform.childCount == 0)
        {
            Time.timeScale = 0;
            _YouWin.SetActive(true);
            AudioManager.instance.SFX(AudioManager.instance.WinSFX);
        }
    }

    public void OnTriggerEnter2D(Collider2D fruit)
    {
        if (fruit.CompareTag("fruit"))
        {
            Destroy(fruit.gameObject);
            score++;
            Score.text = "Score: " + score.ToString();
            AudioManager.instance.SFX(AudioManager.instance.CollectSFX);
        }
    }
}
