using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;

public class StoreMenuController : MonoBehaviour
{

    public Button button1, button2, button3, button4, button5, button6, button7, button8; //cars
    public Button returnToMainMenu;
    public Button goToGemStore;
    public Button goToCoinStore;
    public Button goToCarStore;

    public Button buy1000coins;
    public Button buy5000coins;
    public Button buy10000coins;

    public GameObject mainMenu, CarStore, gemStore, coinStore;
    static public int userGearsAmount;
    static public int userCoinsAmount;


    //for coin popup menu
    public GameObject popupMenu;
    public Button exitPopupButton;
    public Button buyMoreGems;



    // Start is called before the first frame update
    void Start() {



        StandardPurchasingModule.Instance().useFakeStoreAlways = true; //remove for final releaseE

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
        goToCarStore.onClick.AddListener(openCarMenu);

        
        
        buy1000coins.onClick.AddListener(addCoins1000);
        buy5000coins.onClick.AddListener(addCoins5000);
        buy10000coins.onClick.AddListener(addCoins10000);

        exitPopupButton.onClick.AddListener(closePopup);
        buyMoreGems.onClick.AddListener(openGemMenu);
        


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
            gemStore.SetActive(false);
            coinStore.SetActive(false);
            CarStore.SetActive(false);

            mainMenu.SetActive(true);
            returnToMainMenu.transform.parent.gameObject.SetActive(false);
        }
        void openGemMenu()
        {
            mainMenu.SetActive(false);
            coinStore.SetActive(false);
            CarStore.SetActive(false);

            gemStore.SetActive(true);
            returnToMainMenu.transform.parent.gameObject.SetActive(true);
        }
        void openCoinMenu()
        {
            mainMenu.SetActive(false);
            gemStore.SetActive(false);
            CarStore.SetActive(false);

            coinStore.SetActive(true);
            returnToMainMenu.transform.parent.gameObject.SetActive(true);
        }
        void openCarMenu()
        {
            mainMenu.SetActive(false);
            coinStore.SetActive(false);
            gemStore.SetActive(false);

            CarStore.SetActive(true);
            returnToMainMenu.transform.parent.gameObject.SetActive(true);
        }
        void openPopup()
        {
            popupMenu.SetActive(true);
        }
        void closePopup()
        {
            popupMenu.SetActive(false);
        }




        //===========unfinished================



        void addCoins1000()
        {
            //give player coins, but check if player has enough first, else bring up insufficient gems popup
            Debug.Log("giving 1000 coins");
           
        }
        void addCoins5000()
        {
            //give player coins, but check if player has enough first, else bring up insufficient gems popup
            Debug.Log("giving 5000 coins");
        }
        void addCoins10000()
        {
            //give player coins, but check if player has enough first, else bring up insufficient gems popup
            Debug.Log("giving 10000 coins");
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

}
