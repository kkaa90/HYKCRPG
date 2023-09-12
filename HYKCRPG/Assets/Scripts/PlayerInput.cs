using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput playerInstance;
    public GameObject player;
    public Rigidbody2D rigid;
    public Canvas canvas;
    Vector3 cScale;
    Animator animator;

    public string currentMap;
    public int portalNum;

    float maxSpeed = 5.0f;
    float maxJump = 15.0f;
    public float jumpPower = 6.0f;
    public float jumpCount = 0;
    bool isWall;
    public bool canMove;
    

    // Start is called before the first frame update
    void Start()
    {
        if (playerInstance == null)
        {
            playerInstance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        rigid = GetComponent<Rigidbody2D>();
        currentMap = SceneManager.GetActiveScene().name;
        portalNum = 0;
        canMove = true;
        cScale = canvas.transform.localScale;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (Input.GetButtonDown("Jump") && jumpCount < 2)
            {
                if (isWall)
                {
                    rigid.velocity = new Vector2(transform.localScale.x * (-2), 6);
                    canMove = false;
                    animator.SetBool("isJump", true);
                    Invoke("CanMove", 0.1f);
                }
                else
                {
                    animator.SetBool("isJump", true);
                    rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
                    jumpCount++;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetTrigger("isAttack");
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            float h = Input.GetAxisRaw("Horizontal");
            rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);
            if (h > 0)
            {
                transform.localScale = new Vector3(2, 2, 1);
            }
            else if (h < 0)
            {
                transform.localScale = new Vector3(-2, 2, 1);
            }
            if (rigid.velocity.x > maxSpeed)
            {
                rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
            }
            else if (rigid.velocity.x < maxSpeed * (-1))
            {
                rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
            }
            if (rigid.velocity.y > maxJump)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, maxJump);
            }
            if (isWall)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, -2);
            }
        }
        animator.SetFloat("moveSpeed", rigid.velocity.x>0?rigid.velocity.x:rigid.velocity.x*(-1));
        animator.SetFloat("jumpSpeed", rigid.velocity.y);
        
        Debug.Log(rigid.velocity);
        if (transform.localScale.x > 0)
        {
            canvas.transform.localScale = cScale;
        }
        else
        {
            canvas.transform.localScale = new Vector3(cScale.x * (-1), cScale.y, cScale.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                jumpCount = 0;
                animator.SetBool("isWall", false);
                animator.SetBool("isJump", false);
                break;

            case "Wall":
                isWall = true;
                jumpCount = 0;
                animator.SetBool("isWall",true);
                animator.SetBool("isJump", false);
                break;
            case "Monster":
                collision.gameObject.GetComponent<MonsterController>().HpDecrease();
                break;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Wall":
                isWall = false;
                animator.SetBool("isWall", false);
                break;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Water":
                jumpCount = 0;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    void CanMove()
    {
        canMove = true;
    }
}
