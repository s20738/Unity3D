using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public int speed;
    public int jumpForce;
    public Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;
    private bool isAttacking;
    private bool isDead;
    [SerializeField]
    GameObject attatckHitBox;
    public GameObject text;

    void Start() {
 
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isGrounded = true;
        isAttacking = false;
        attatckHitBox.SetActive(false);
        isDead = false;
        text.SetActive(false);
    }

    void Update() {
        if (!isDead)
        {
        Move();
        Jump();
        Attack();
            Death();
        }




    }

    private void Death()
    {
        if(HealthSript.health == 0)
        {
            text.SetActive(true);
            isDead = true;
            animator.SetBool("Dead", true);
            Invoke("ResetScene", 1.7f);
       
        }
    }

    private void Move()
    {
        float xDisplacement = Input.GetAxis("Horizontal");
        Vector3 displacementVector = new Vector3(xDisplacement, 0, 0);
        if(xDisplacement > 0)
        {
            transform.localScale = new Vector3(3, 3, 3);
           
        }
        else if(xDisplacement < 0)
            {
            
            transform.localScale = new Vector3(-3, 3, 3);
        }
        if (Input.GetButton("Sprint")&&!isAttacking)
        {
            rb.velocity = new Vector2(xDisplacement * speed, rb.velocity.y);
            animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        }
        else if(!isAttacking)
        {
            rb.velocity = new Vector2(xDisplacement * speed, rb.velocity.y);
            animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        }

    }
    private void Attack()
    {
        if (Input.GetButton("Fire1") && !isAttacking)
        {
            attatckHitBox.SetActive(true);
            isAttacking = true;
            animator.SetBool("isAttack", true);
            Invoke("ResetAttack", 1.0f);

        }

    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            
            isGrounded = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground") && !isAttacking) {
            animator.SetBool("Jump", false);
            isGrounded = true;
            this.transform.parent = collision.transform;
        }
       

    }
    private void ResetScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !isAttacking)
        {
            animator.SetBool("Jump", true);
            isGrounded = false;
            this.transform.parent = null;
        }

    }
    private void ResetAttack()
    {
        attatckHitBox.SetActive(false);
        isAttacking = false;
        animator.SetBool("isAttack", false);
    }
   





}
