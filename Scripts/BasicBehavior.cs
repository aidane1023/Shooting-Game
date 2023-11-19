using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBehavior : MonoBehaviour
{
    public GameObject explosionPrefab;
    public GameObject powerPrefab;
    private GameManager gms;
    private int temp;

    // Start is called before the first frame update
    void Start()
    {
        temp = Random.Range(0,4);
        gms = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        int moving = gms.screenMove;
        transform.Translate(new Vector3(0,-1,0) * Time.deltaTime*3*moving);
        if(transform.position.y < -8f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if(whatIHit.tag == "Player")
        {
            if (temp == 0)
            {
                Instantiate(powerPrefab, transform.position, Quaternion.identity);
            } 
            gms.EarnScore(2);
            whatIHit.GetComponent<Player>().LifeChange(-1);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if(whatIHit.tag == "Weapon")
        {
            if (temp == 0)
            {
                Instantiate(powerPrefab, transform.position, Quaternion.identity);
            } 
            gms.EarnScore(2);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        }
        else if(whatIHit.tag == "Shield")
        {
            gms.EarnScore(2);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
