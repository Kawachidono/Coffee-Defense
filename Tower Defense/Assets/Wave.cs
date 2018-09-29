using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wave : MonoBehaviour {

    public Text waveText;

    // Update is called once per frame
    void Update()
    {
        waveText.text = Wavemanager.currentWave + " Wave";
    }
}