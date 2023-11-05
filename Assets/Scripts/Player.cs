using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //borders 8.5 and 6.5

    public float speed;
    public float horizontalInput;
    public float verticalInput;
    public float horizontalScreenLimit;
    public float verticalScreenLimit;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
       speed = 4f;
       horizontalScreenLimit = 9.5f;
       verticalScreenLimit = 6.5f; 
    }

    // Update is called once per frame; if computer runs at 60 fps
    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement() 
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);
        if(transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
        if(transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        if(transform.position.y < -6.5f)
        {
            transform.position = new Vector3(transform.position.x, -6.5f, 0);
        }
    }

    void Shooting()
    {
         //if I pres SPACE, shoot
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //create bullet
            Instantiate(bulletPrefab, transform.position + new Vector3(0,1,0), Quaternion.identity);
        }
    }
}
