using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

    public GameObject prefabPlatform;
    public int numberPlatforms = 200;
    public float levelWidth = 3f;
    public float minY = 0.2f;
    public float maxY = 1.5f;

	// Use this for initialization
	void Start ()
    {
        Vector3 spawnPos = new Vector3();
        for(int i = 0; i < numberPlatforms; i++)
        {
            spawnPos.y += Random.Range(minY, maxY);
            spawnPos.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(prefabPlatform, spawnPos, Quaternion.identity);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
