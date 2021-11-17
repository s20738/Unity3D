using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStay : MonoBehaviour
{
    public float speed;

    public Transform point;
    Animator animator;
    Transform player;
    public float stopDistance;

    bool stay, angry, back = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {


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
            animator.SetBool("isHeroDedected", false);

        }
        if (angry)
        {

            Angry();
        }
        if (back)
        {
            animator.SetBool("isHeroDedected", true);
            Back();
        }


    }



    public void Angry()
    {
        animator.SetBool("isHeroDedected", true);
        transform.localScale = new Vector3(3, 3, 3);
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    public void Back()
    {
        if (Vector2.Distance(transform.position, player.position) > 1)
        {
            animator.SetBool("isHeroDedected", false);
        }
        transform.localScale = new Vector3(-3, 3, 3);
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
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


