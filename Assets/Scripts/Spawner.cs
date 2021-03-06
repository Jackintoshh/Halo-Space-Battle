﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> banshees = new List<GameObject>();
    public List<GameObject> locations = new List<GameObject>();
    int maxBanshees = 5;
    public GameObject bansheePref;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < maxBanshees; i++)
        {
            yield return new WaitForSeconds(3f);
            int rand = (int)Random.Range(0, 3);
            GameObject banshee = Instantiate(bansheePref, locations[rand].transform.position, Quaternion.identity, this.transform);
            banshees.Add(banshee);
        }
       
    }
}
