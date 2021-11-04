using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextControllerBehaviour : MonoBehaviour
{

    public GameObject waveText;
    public GameObject baseHealthText;
    public GameObject bugsBeatText;

    public int bugsBeat;

    public GeneralStatsBehaviour generalStats;

    public BugSpawnBehaviour bugSpawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waveText.GetComponent<Text>().text = "" + bugSpawner.waveNumber;
        baseHealthText.GetComponent<Text>().text = "" + generalStats.playerHealth;
    }

    public void increaseBugsBeat() {
        bugsBeat++;
        bugsBeatText.GetComponent<Text>().text = "" + bugsBeat;
    }
}
