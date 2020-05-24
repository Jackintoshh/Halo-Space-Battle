using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public List<GameObject> waypoints = new List<GameObject>();
    int rand;
    BansheeBoid banboid;

    // Start is called before the first frame update
    void Start()
    {
        banboid = GetComponent<BansheeBoid>();
        rand = (int)Random.Range(0, 3);

        for(int i = 0; i < 3; i++ )
        {
            waypoints.Add(GameObject.Find("Waypoint" + i.ToString()));
        }

        banboid.target = waypoints[rand].transform.position;


    }

    // Update is called once per frame
    void Update()
    {

        if (this.transform.position.x < waypoints[rand].transform.position.x - 10000 && this.transform.position.z < waypoints[rand].transform.position.z - 10000)
        {
            rand = (int)Random.Range(0, 3);
            banboid.target = waypoints[rand].transform.position;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("entered");
        if(collision.transform.tag == "waypoint")
        {
            rand = (int)Random.Range(0, rand);
            banboid.target = waypoints[rand].transform.position;
            Debug.Log("enteredCollision");
        }
    }
}
