using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{


    public static int Lives;
    public int startLives = 10;

    private int enemyKilled;


	// Use this for initialization
	void Start ()
    {
        Lives = startLives;
	}
    
	
}
