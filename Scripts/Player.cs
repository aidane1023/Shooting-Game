using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    //borders 8.5 and 6.5
    public float speed;
    public float horizontalInput;
    public float verticalInput;
    public float horizontalScreenLimit;
    public float verticalScreenLimit;
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public GameObject thruster;
    public GameObject shield;
    private GameManager gms;
    public int lives;
    public AudioClip coinSound;
    public AudioClip heartSound;
    public AudioClip powerupSound;
    public AudioClip powerdownSound;
    private bool betterWeapon;
    private int blocksRemaining;

    // Start is called before the first frame update
    void Start()
    {
        gms = GameObject.Find("GameManager").GetComponent<GameManager>();
        speed = 4f;
        horizontalScreenLimit = 9.5f;
        verticalScreenLimit = 4.5f; 
        lives = 3;
        thruster.SetActive(false);
        shield.SetActive(false);
        betterWeapon = false;
        blocksRemaining = 0;
    }

    // Update is called once per frame; if computer runs at 60 fps
    void Update()
    {
        Movement();
        Shooting();
    }

    
    public void Movement() 
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * speed);
        if(transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }

        if(transform.position.y < -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, -verticalScreenLimit, 0);
        } else if(transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
    }

    void Shooting()
    {
         //if I pres SPACE, shoot
        if(Input.GetKeyDown(KeyCode.Space) && !betterWeapon)
        {
            //create bullet
            Instantiate(bulletPrefab, transform.position + new Vector3(0,1,0), Quaternion.identity);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && betterWeapon)
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0.5f,1,0), Quaternion.Euler(0,0,-45f));
            Instantiate(bulletPrefab, transform.position + new Vector3(0,1,0), Quaternion.identity);
            Instantiate(bulletPrefab, transform.position + new Vector3(-0.5f,1,0), Quaternion.Euler(0,0,45f));
        }
    }

    public void LifeChange(int change)
    {
        if (change > 0)
        {
            lives++;

            if (lives >= 5)
            {
                lives = 5;
                gms.EarnScore(1);
            }
        }
        else if (change < 0)
        {
            if (blocksRemaining <= 0) 
            {
                lives--;
            }
            if (lives <= 0)
            {
                gms.livesText.text = "Lives: "+ lives;
                gms.GameOver();
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
            blocksRemaining--;
            if (blocksRemaining <= 0)
            {
                shield.SetActive(false);
            }
        }
        gms.livesText.text = "Lives: "+ lives;
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if(whatIHit.tag == "Coin") //Coin
        {
            gms.EarnScore(1);
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            Destroy(whatIHit.gameObject);
        }
        else if(whatIHit.tag == "Heart") //Heart
        {
            LifeChange(1);
            AudioSource.PlayClipAtPoint(heartSound, transform.position);
            Destroy(whatIHit.gameObject);
        }
        else if(whatIHit.tag == "Powerup") //Power Up
        {   
            AudioSource.PlayClipAtPoint(powerupSound, transform.position);
            int tempInt = Random.Range(1, 4);
            if (tempInt == 1) //Speed Up
            {
                gms.powerupText.text = "Speed Boost";
                speed = 6f;
                gms.moveSpeed = 6f;
                thruster.SetActive(true);
                StartCoroutine("SpeedPowerDown");
            }
            if (tempInt == 2) //Weapon Boost
            {
                gms.powerupText.text = "Weapon Boost";
                betterWeapon = true;
                StartCoroutine("WeaponPowerDown");
            }
            if (tempInt == 3) //Shield
            {
                shield.SetActive(true);
                blocksRemaining = 3;
                gms.powerupText.text = "Shield";
                StartCoroutine("ShieldPowerDown");
            }
            Destroy(whatIHit.gameObject);
        }
    }

    IEnumerator SpeedPowerDown ()
    {
        yield return new WaitForSeconds(4f);
        speed = 4f;
        gms.moveSpeed = 4f;
        thruster.SetActive(false);
        AudioSource.PlayClipAtPoint(powerdownSound, transform.position);
        if (gms.powerupText.text == "Speed Boost")
        {
            gms.powerupText.text = "";
        }
    }

    IEnumerator WeaponPowerDown ()
    {
        yield return new WaitForSeconds(4f);
        betterWeapon = false;
        AudioSource.PlayClipAtPoint(powerdownSound, transform.position);
        if (gms.powerupText.text == "Weapon Boost")
        {
            gms.powerupText.text = "";
        }
    }

    IEnumerator ShieldPowerDown ()
    {
        yield return new WaitForSeconds(4f);
        shield.SetActive(false);
        blocksRemaining = 0;
        if (gms.powerupText.text == "Shield")
        {
            gms.powerupText.text = "";
        }
    }
}
