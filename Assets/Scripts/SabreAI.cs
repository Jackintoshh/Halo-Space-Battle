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
    int killcount;
    public GameObject finalDialogue;

    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        audioS.clip = sabreShot;
        audioS2 = cam.GetComponent<AudioSource>();
        audioS2.clip = explode;

        killcount = 0;

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
            
            Destroy(collision.transform.parent.gameObject);
            killcount++;
            //Debug.Log(killcount);

            audioS2.Play();

            if (killcount >= 5)
            {
                finalDialogue.GetComponent<AudioSource>().Play();
            }
            
            spawner.GetComponent<Spawner>().banshees.RemoveAt(rand);
            amount = spawner.GetComponent<Spawner>().banshees.Count;
            
            banshee = GameObject.Find("Banshee(Clone)").GetComponentInChildren<BansheeBoid>().gameObject;//spawner.GetComponent<Spawner>().banshees[rand];
            sabreBoid.banshee = banshee;
            
        }

        
    }

    public int getKillCount()
    {
        return killcount;
    }
}
