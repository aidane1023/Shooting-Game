using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    public int objectType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objectType == 1)
        {
            //bullet
            transform.Translate(new Vector3(0,1,0) * Time.deltaTime * 9f);
            if (transform.position.y > 11f)
            {
                Destroy(this.gameObject);
            }
        } else if (objectType == 2) 
        {
        //cloud
        transform.Translate(new Vector3(0,-1,0) * Time.deltaTime * Random.Range(3f, 8f));
        if(transform.position.y < -6f)
         {
            Destroy(this.gameObject);
         }
        }
        

        
    }
}
