using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject livesCounter;
    private Player int_script;
    public TextMeshProUGUI text;
    void Start()
    {
        int_script = livesCounter.GetComponent<Player>();
        text.text = ("LIVES - 3");
    }

    // Update is called once per frame
    void Update()
    {
        LivesLost();
    }

    public void LivesLost()
    {
        if (int_script.lives == 3) { text.text = ("LIVES - 3"); }
        else if (int_script.lives == 2) { text.text = ("LIVES - 2"); }
        else if (int_script.lives == 1) { text.text = ("LIVES - 1"); }
        else if (int_script.lives == 0) { text.text = ("LIVES - 0"); }
    }
}
