using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSkript : MonoBehaviour
{

    public int speed;
    int x;
    bool isMoveRight;
    private void Start()
    {
        isMoveRight = true;
    }
    void Update()
    {
        if(transform.position.x > 15)
        {
            isMoveRight = false;

        }
        else if(transform.position.x < 11.5)
        {
            isMoveRight = true;
        }
        if(isMoveRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x  - speed * Time.deltaTime, transform.position.y);
        }
    }
    
}
