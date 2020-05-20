using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabreAI : MonoBehaviour
{
    int amount, rand;
    public GameObject spawner;
    GameObject banshee;
    BoxCollider bc;
    BigBoid sabreBoid;

    // Start is called before the first frame update
    void Start()
    {

        /*amount = spawner.GetComponent<Spawner>().banshees.Count;
        rand = (int)Random.Range(0, amount-1);
        Debug.Log(amount);
        banshee = spawner.GetComponent<Spawner>().banshees[rand];
        bc = GetComponent<BoxCollider>();
        sabreBoid = GetComponent<BigBoid>();*/
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(3);
        amount = spawner.GetComponent<Spawner>().banshees.Count;
        rand = (int)Random.Range(0, amount);
        Debug.Log(amount);
        banshee = spawner.GetComponent<Spawner>().banshees[rand];
        bc = GetComponent<BoxCollider>();
        sabreBoid = GetComponent<BigBoid>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "waypoint")
        {
            Destroy(collision.gameObject);
            amount = spawner.GetComponent<Spawner>().banshees.Count;
            rand = (int)Random.Range(0, amount);
            banshee = spawner.GetComponent<Spawner>().banshees[rand];
            sabreBoid.banshee = banshee;
        }
    }
}
