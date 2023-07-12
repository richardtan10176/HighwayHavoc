using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI score;
    public int pScore;
    // Update is called once per frame
    void Update()
    {
        score.text =  player.position.z.ToString("0");
        pScore = (int) player.position.z;
    }
}
