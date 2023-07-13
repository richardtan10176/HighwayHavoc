using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boxophobic.StyledGUI;

public class SkyControl : MonoBehaviour
{
    private Material skybox;
    
    // Start is called before the first frame update
    void Start()
    {
        skybox = RenderSettings.skybox;
        Color day = new Color(98f, 40f, 42f, 1f);
  

        RenderSettings.skybox.SetColor("Cubemap Tint Color", day);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
