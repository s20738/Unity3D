using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatroler : MonoBehaviour
{
    public float speed;
    public int patrol;
    public Transform point;
    bool moveLeft;
    Transform player;
    public float stopDistance;
    private SpriteRenderer sr;
    bool stay, angry, back = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Vector2.Distance(transform.position,point.position)  < patrol && angry == false)
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
        if(stay)
        {
            Stay();
        }
        else if(angry)
        {

        }
        else if(back)
        {
            Back();
        }


    }
    public void Stay()
    {
        if (transform.position.x > point.position.x + patrol)
        {
            sr.flipX = true;
            moveLeft = true;
        }
        else if (transform.position.x < point.position.x - patrol)
        {
            sr.flipX = false;
            moveLeft = false;
        }
        if(moveLeft)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime,transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        
    }


    public void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    public void Back()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }
}   

