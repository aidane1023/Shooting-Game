using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyBasicPrefab;
    public GameObject enemyAdvancedPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateBasic", 1.0f, 3.0f);
        InvokeRepeating("CreateAdvanced", 6.0f, 6.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateBasic()
    {
        Instantiate(enemyBasicPrefab, new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.identity);
    }

    void CreateAdvanced()
    {
        Instantiate(enemyAdvancedPrefab, new Vector3(Random.Range(-8, 8), 7, 0), Quaternion.identity);
    }
}
