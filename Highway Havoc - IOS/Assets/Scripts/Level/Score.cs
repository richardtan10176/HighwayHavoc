using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    Transform player;
    public TextMeshProUGUI score;
    public static int pScore;
    private void Start()
    {
        player = GameObject.Find("playerCar").transform;
    }
    // Update is called once per frame
    void Update()
    {
        score.text =  player.position.z.ToString("0");
        pScore = (int) player.position.z;
    }
}
