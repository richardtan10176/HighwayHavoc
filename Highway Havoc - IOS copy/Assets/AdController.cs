using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdController : MonoBehaviour
{
    public GameObject ad;
    // Start is called before the first frame update
    void Start()
    {
        int randNum = Random.Range(1, 5);
        if (randNum <= 2)
        {
            ad.SetActive(false);
        }
    }
}
