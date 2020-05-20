using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    List<GameObject> banshees = new List<GameObject>();
    public List<GameObject> locations = new List<GameObject>();
    int maxBanshees = 20;
    public GameObject bansheePref;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxBanshees; i++)
        {
            int rand = (int)Random.Range(0, 2);
            GameObject banshee = Instantiate(bansheePref, locations[rand].transform.position, Quaternion.identity, this.transform);
            banshees.Add(banshee);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //int rand = (int)Random.Range(0, 2);
        
    }
}
