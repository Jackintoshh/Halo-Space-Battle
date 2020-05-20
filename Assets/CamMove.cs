using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public GameObject cam;
    public bool camSwitch = true;
    // Start is called before the first frame update
    void Start()
    {
        Camera cameramain = cam.GetComponent<Camera>();
        StartCoroutine(switchCams());
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, 10f, 0);
    }

    IEnumerator switchCams()
    {
        yield return new WaitForSeconds(10);
        cam.SetActive(camSwitch);
    }
}
