using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DeathScreen;

    public Button retryButton;
    public Button returnToMenuButton;

    public Button respawnButton;
    void Start()
    {
        respawnButton.onClick.AddListener(respawn);
        retryButton.onClick.AddListener(retry);
        returnToMenuButton.onClick.AddListener(returnToMenu);
    }

    void retry()
    {
        SceneManager.LoadScene(1);
    }
    
    void returnToMenu()
    {
        DeathScreen.SetActive(false);
        SceneManager.LoadScene(0);
    }
    void respawn()
    {
        DeathScreen.SetActive(false);
        SpawnPlayerCar.playerCar.GetComponent<Rigidbody>().isKinematic = true;
        SpawnPlayerCar.playerCar.GetComponent<Playermovement>().enabled = true;
        SpawnPlayerCar.playerCar.GetComponent<Playermovement>().forwardSpeed = 0;
        SpawnPlayerCar.playerCar.GetComponent<Playermovement>().explosion.SetActive(false);
        SpawnPlayerCar.playerCar.GetComponent<Playermovement>().fire.SetActive(false);
        SpawnPlayerCar.playerCar.GetComponent<Playermovement>().forwardSpeed = 8;

        StartCoroutine(DisableCrashing(5.0f));
        InvokeRepeating("flash", 0, 0.25f);

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
