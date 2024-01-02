using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DeathScreen;
    public GameObject RespawnScreen;

    public Button retryButton;
    public Button returnToMenuButton;

    public GameObject InsFunds;
    public Button closePopupButton;
    public Button respawnButton;
    void Start()
    {
        respawnButton.onClick.AddListener(respawn);
        retryButton.onClick.AddListener(retry);
        returnToMenuButton.onClick.AddListener(returnToMenu);
        closePopupButton.onClick.AddListener(closePopup);
        //showbannerad = GameObject.Find("AdDisplayObject").GetComponent<showBannerAd>();
        //showbannerad.ShowBannerAd();
    }

    void retry()
    {
        //PlayerPrefs.SetInt("coinScore", PlayerPrefs.GetInt("coinScore") + Playermovement.NumOfCoins);
        if(PlayerPrefs.GetInt("score") > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", PlayerPrefs.GetInt("score"));
        }
        SceneManager.LoadScene(1);
    }
    
    void returnToMenu()
    {
        //showbannerad.HideBannerAd();

        DeathScreen.SetActive(false);
        RespawnScreen.SetActive(false);
        SceneManager.LoadScene(0);
    }
    void respawn()
    {
        if(loadPlayerData.gemsAmount >= 20)
        {
            
            PlayerPrefs.SetInt("gemsOwed", 20);
            DeathScreen.SetActive(false);
            RespawnScreen.SetActive(false);
            SpawnPlayerCar.playerCar.GetComponent<Rigidbody>().isKinematic = true;
            SpawnPlayerCar.playerCar.GetComponent<Playermovement>().playerMove = true;
            SpawnPlayerCar.playerCar.GetComponent<Playermovement>().explosion.SetActive(false);
            SpawnPlayerCar.playerCar.GetComponent<Playermovement>().fire.SetActive(false);
            SpawnPlayerCar.playerCar.GetComponent<Playermovement>().forwardSpeed = 8;
            SpawnPlayerCar.playerCar.GetComponent<CollisionDetection>().hasRespawned = true;
            StartCoroutine(DisableCrashing(5.0f));
            InvokeRepeating("flash", 0, 0.25f);
        }
        else
        {
            InsFunds.SetActive(true);
        }
        

    }
    void closePopup()
    {
        Debug.Log("bruh");
        InsFunds.SetActive(false);
    }
    void flash()
    {
        SpawnPlayerCar.playerCar.transform.GetChild(0).GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = !SpawnPlayerCar.playerCar.transform.GetChild(0).GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled;
    }
    IEnumerator DisableCrashing(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SpawnPlayerCar.playerCar.GetComponent<Rigidbody>().isKinematic = false;
        CancelInvoke("flash");
        SpawnPlayerCar.playerCar.transform.GetChild(0).GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = true;


    }
}
