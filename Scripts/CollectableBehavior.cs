using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBehavior : MonoBehaviour
{
    private GameManager gms;

    // Start is called before the first frame update
    void Start()
    {
        gms = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        int moving = gms.screenMove;
        transform.Translate(new Vector3(0,-1,0) * Time.deltaTime*2*moving);
        if(transform.position.y < -8f)
        {
            Destroy(this.gameObject);
        }
    }
    
}
