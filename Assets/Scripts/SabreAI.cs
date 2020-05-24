using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabreAI : MonoBehaviour
{
    int amount, rand;
    public GameObject spawner;
    public GameObject banshee, cam;
    BoxCollider bc;
    BigBoid sabreBoid;
    List<GameObject> banshees = new List<GameObject>();
    public AudioClip explode, sabreShot;
    AudioSource audioS, audioS2;

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
        banshees = spawner.GetComponent<Spawner>().banshees;
        amount = spawner.GetComponent<Spawner>().banshees.Count;
        rand = (int)Random.Range(0, amount);
        Debug.Log(amount);
        banshee = spawner.GetComponent<Spawner>().banshees[rand].GetComponentInChildren<BansheeBoid>().gameObject;
        bc = GetComponent<BoxCollider>();
        sabreBoid = GetComponent<BigBoid>();
        audioS = GetComponent<AudioSource>();
        audioS.clip = sabreShot;
        audioS2 = cam.GetComponent<AudioSource>();
        audioS2.clip = explode;

        
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag != "waypoint" && collision.gameObject.name == banshee.transform.name)
        {

            audioS.Play();

            //collision.GetComponent<BansheeBoid>().audsource.Play();
            
            Destroy(collision.transform.parent.gameObject);
            audioS2.Play();
            //sabreBoid.velocity = Vector3.zero;
            //sabreBoid.acceleration = Vector3.zero;
            //sabreBoid.force = Vector3.zero;
            //sabreBoid.speed = 0f;
            //sabreBoid.pursueEnabled = false;
            //audioS.clip = explode;
            //audioS.Play();

            spawner.GetComponent<Spawner>().banshees.RemoveAt(rand);
            amount = spawner.GetComponent<Spawner>().banshees.Count;
            //rand = (int)Random.Range(0, amount);
            banshee = GameObject.Find("Banshee(Clone)").GetComponentInChildren<BansheeBoid>().gameObject;//spawner.GetComponent<Spawner>().banshees[rand];
            sabreBoid.banshee = banshee;
        }
    }
}
