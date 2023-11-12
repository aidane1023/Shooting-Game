using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBehavior : MonoBehaviour
{
    public GameObject explosionPrefab;
    private GameObject gM;

    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        int moving = gM.GetComponent<GameManager>().screenMove;
        transform.Translate(new Vector3(0,-1,0) * Time.deltaTime*3*moving);
        if(transform.position.y < -8f)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if(whatIHit.tag == "Player")
        {
            whatIHit.GetComponent<Player>().LoseLife();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if(whatIHit.tag == "Weapon")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().EarnScore(2);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        }
    }
}
