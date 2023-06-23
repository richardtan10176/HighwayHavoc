using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StoreMenuController : MonoBehaviour
{

    public Button button1, button2, button3, button4, button5, button6, button7, button8; //cars
    public Button returnToMainMenu;
    public Button goToGemStore;
    public Button goToCoinStore;
    GameObject activeMenu;
    public GameObject CarStore, gemStore, coinStore;
    static public int userGearsAmount;
    static public int userCoinsAmount;

    

    // Start is called before the first frame update
    void Start() {
        //GameObject activeMenu = mainMenu;

        button1.onClick.AddListener(activateCar1);
        button2.onClick.AddListener(activateCar2);
        button3.onClick.AddListener(activateCar3);
        button4.onClick.AddListener(activateCar4);
        button5.onClick.AddListener(activateCar5);
        button6.onClick.AddListener(activateCar6);
        button7.onClick.AddListener(activateCar7);
        button8.onClick.AddListener(activateCar8);
        returnToMainMenu.onClick.AddListener(returnToMenu);
        goToGemStore.onClick.AddListener(openGemMenu);
        goToCoinStore.onClick.AddListener(openCoinMenu);


        void activateCar1()
        {
            Debug.Log("car1 selected");
        }
        void activateCar2()
        {
            Debug.Log("car2 selected"); 
        }
        void activateCar3()
        {
            Debug.Log("car3 selected");
        }
        void activateCar4()
        {
            Debug.Log("car4 selected");
        }
        void activateCar5()
        {
            Debug.Log("car5 selected");
        }
        void activateCar6()
        {
            Debug.Log("car6 selected");
        }
        void activateCar7()
        {
            Debug.Log("car7 selected");
        }
        void activateCar8()
        {
            Debug.Log("car8 selected");
        }
        void returnToMenu()
        {
            Debug.Log("openining main menu");
            activeMenu.SetActive(false);
            //mainMenu.SetActive(true);
        }
        void openGemMenu()
        {
            Debug.Log("opening gem store");
            //activeMenu.SetActive(false);
            gemStore.SetActive(true);
        }
        void openCoinMenu()
        {
            Debug.Log("opening coin store");
            //activeMenu.SetActive(false);
            coinStore.SetActive(true);
        }
        void openCarMenu()
        {

        }



    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

}
