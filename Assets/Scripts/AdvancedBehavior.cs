using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedBehavior : MonoBehaviour
{
    public float horizontalScreenLimit;
    int randomDirection;

    // Start is called before the first frame update
    void Start()
    {
        horizontalScreenLimit = 9.5f;
        if(Random.value < 0.5f) {
            randomDirection = 1;
        } else {
            randomDirection = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(randomDirection == 1)
        {
            direction1();
        } else {
            direction2();
        }
    }

    void direction1()
    {
        transform.Translate(new Vector3(0,-1,0) * Time.deltaTime*1);
        transform.Translate(new Vector3(1,0,0) * Time.deltaTime*5);
        if(transform.position.x > horizontalScreenLimit || transform.position.x < -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
        if(transform.position.y < -8f)
        {
            Destroy(this.gameObject);
        }
    }

    void direction2()
    {
        transform.Translate(new Vector3(0,-1,0) * Time.deltaTime*1);
        transform.Translate(new Vector3(-1,0,0) * Time.deltaTime*5);
        if(transform.position.x > horizontalScreenLimit || transform.position.x < -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
        if(transform.position.y < -8f)
        {
            Destroy(this.gameObject);
        }
    }
}
