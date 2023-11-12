using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    private GameObject gM;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.Find("GameManager");
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        int moving = gM.GetComponent<GameManager>().screenMove;
        transform.Translate(new Vector3(0,-1,0) * Time.deltaTime*2*moving);
        if(transform.position.y < -8f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if(whatIHit.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().EarnScore(1);
            source.Play();
            Destroy(this.gameObject);
        }
    }
}
