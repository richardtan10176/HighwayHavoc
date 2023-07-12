using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_new : MonoBehaviour
{


	private void OnTriggerEnter(Collider other)
	{
		if(other.tag.Equals("Player"))
		{
			Time.timeScale = 0;
		}
	}
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
