using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCam : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;

    private void Update()
    {
        //Vcam 1
        if(transform.position.y >=6 && transform.position.y <16)
        { 
            cam1.SetActive(false);
        }
        else if(transform.position.y <6)
        {
             cam1.SetActive(true);
        }

        //Vcam 2
        if(transform.position.y >=16 && transform.position.y < 25)
        {
            cam2.SetActive(false);
        }
        else if (transform.position.y <16 && transform.position.y > 6)
        {
            cam2.SetActive(true);
        }

        //Vcam 3
        if (transform.position.y >=25)
        {
            cam3.SetActive(false);
        }
        else if (transform.position.y <25)
        {
            cam3 .SetActive(true);
        }
    }
}
