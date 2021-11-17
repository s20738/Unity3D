using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public int patrol;
    public Transform point;
    bool moveLeft;
    Transform player;
    public float stopDistance;
    Animator animator;
    bool stay, angry, back = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
       
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, point.position) < patrol && angry == false)
        {
            stay = true;
        }
        if (Vector2.Distance(transform.position, player.position) < stopDistance)
        {
            angry = true;
            stay = false;
            back = false;
        }
        if (Vector2.Distance(transform.position, player.position) > stopDistance)
        {
            back = true;
            angry = false;
        }
        if (stay)
        {
            Stay();
        }
        else if (angry)
        {
            Angry();
        }
        else if (back)
        {
            Back();
        }


    }
    public void Stay()
    {
        if(transform.position.x > point.position.x + patrol)
        {
            transform.localScale = new Vector3(-3, 3, 3);
            moveLeft = true;
        }
        if (transform.position.x < point.position.x - patrol)
        {
            transform.localScale = new Vector3(3, 3, 3);
            moveLeft = false; ;
        }
        if(!moveLeft)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        if (moveLeft)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }

    }


    public void Angry()
    {
        animator.SetBool("heroIsDetected", true);
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    public void Back()
    {
        animator.SetBool("heroIsDetected", false);
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Attack");
            HealthSript.health -= 1;
        }
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Destroy(gameObject);
        }
    }
}

