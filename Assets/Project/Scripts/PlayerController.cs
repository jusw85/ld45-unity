using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stuff")]
    public float moveSpeed;

    public float jumpHeight;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private Vector2 moveInput;
    private bool toJump;
    private bool isGrounded;
    private bool isFacingRight = true;

//    private Animator anim;
    private Rigidbody2D rb2d;
    private AudioManager audioManager;

    [NonSerialized]
    public SpawnPointController spawnPoint;

    private void Awake()
    {
//        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
//        audioManager = AudioManager.instance;
//        if (audioManager == null) Debug.LogError("No audio Manager found");
//        Camera.main.GetComponent<Camera2DFollow>().target = transform;
    }

    private void FixedUpdate()
    {
//        if (isSpawning || isDying) return;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        var newVelocity = rb2d.velocity;
        newVelocity.x = moveInput.x * moveSpeed;
        if (toJump)
        {
            toJump = false;
            newVelocity.y = jumpHeight;
        }

        rb2d.velocity = newVelocity;
    }

//    private bool isSpawning = true;
//    private bool isDying = false;

//    public bool IsDying
//    {
//        get { return isDying; }
//        set { isDying = value; }
//    }
//
//    public bool IsSpawning
//    {
//        get { return isSpawning; }
//        set { isSpawning = value; }
//    }

    private void Update()
    {
//        if (isSpawning || isDying) return;

        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Debug.Log(moveInput);
        if (moveInput.x != 0)
            SetIsFacingRight(moveInput.x > 0);

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                toJump = true;
//                audioManager.PlaySound("Jump");
            }
        }

    }

    private Vector2 oldVel;

//    public void Death()
//    {
//        if (!isDying)
//        {
//            isDying = true;
//            anim.Play("Death");
//            oldVel = rb2d.velocity;
//            Destroy(rb2d);
//            GetComponentInChildren<CircleCollider2D>().enabled = false;
//            GetComponentInChildren<BoxCollider2D>().enabled = false;
//        }
//    }

    public void PostDeathAnimation()
    {
        if (spawnPoint != null)
        {
            spawnPoint.Spawn();
        }

        Destroy(gameObject);
    }

    public IEnumerator DoAfterSeconds(float delay, Action op)
    {
        yield return new WaitForSeconds(delay);
        op();
    }

    private void LateUpdate()
    {
//        if (isSpawning || isDying) return;
//        anim.SetBool("Ground", isGrounded);
//        anim.SetFloat("vSpeed", rb2d.velocity.y);
//        anim.SetFloat("Speed", Mathf.Abs(moveInput.x));
    }

    private void SetIsFacingRight(bool isFacingRight)
    {
        if (this.isFacingRight ^ isFacingRight)
        {
            var scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

        this.isFacingRight = isFacingRight;
    }
}