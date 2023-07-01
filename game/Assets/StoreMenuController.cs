using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;
using TMPro;

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
    public GameObject highScoreTxt;

    public GameObject mainMenu, CarStore, gemStore, coinStore;
    public GameObject car1select, car2select, car3select, car4select, car5select, car6select, car7select, car8select;
    public GameObject carParent;

    




    //for coin popup menu
    public GameObject popupMenu;
    public Button exitPopupButton;
    public Button buyMoreGems;


    // Start is called before the first frame update
    void Start() {

        if (!PlayerPrefs.HasKey("firsttime")) //first time in game
        {
            PlayerPrefs.SetInt("firsttime", 0);
            

            //set default selected car to the first car
            car1select.SetActive(true);
            PlayerPrefs.SetInt("playerCar", 1);


            PlayerPrefs.SetInt("HighScore", 0);



        }
        else
        {
            carParent.transform.GetChild(PlayerPrefs.GetInt("playerCar")-1).GetChild(4).gameObject.SetActive(true);
            updateHighScore(highScoreTxt);

        }

        StartCoroutine(LateStart(0.1f));


        StandardPurchasingModule.Instance().useFakeStoreAlways = true; //remove for final release

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
            car1select.SetActive(true);
            PlayerPrefs.SetInt("playerCar", 1);

            car2select.SetActive(false);
            car3select.SetActive(false);
            car4select.SetActive(false);
            car5select.SetActive(false);
            car6select.SetActive(false);
            car7select.SetActive(false);
            car8select.SetActive(false);
        }
        void activateCar2()
        {
            if(IAPcontroller.mainPlayer.coins >= 250)
            {
                if(IAPcontroller.mainPlayer.car1 == 0)
                {
                    IAPcontroller.mainPlayer.removeCoins(250);
                    carParent.transform.GetChild(1).GetChild(5).gameObject.SetActive(false);
                    IAPcontroller.mainPlayer.car1 = 1;
                    IAPcontroller.mainPlayer.Save();

                }
            }
            else
            {
                openPopup();
                return;
            }
            car2select.SetActive(true);
            PlayerPrefs.SetInt("playerCar", 2);
            car1select.SetActive(false);
            car3select.SetActive(false);
            car4select.SetActive(false);
            car5select.SetActive(false);
            car6select.SetActive(false);
            car7select.SetActive(false);
            car8select.SetActive(false);
        }
        void activateCar3()
        {
            if (IAPcontroller.mainPlayer.coins >= 500)
            {
                if (IAPcontroller.mainPlayer.car2 == 0)
                {
                    IAPcontroller.mainPlayer.removeCoins(500);
                    carParent.transform.GetChild(2).GetChild(5).gameObject.SetActive(false);
                    IAPcontroller.mainPlayer.car2 = 1;
                    IAPcontroller.mainPlayer.Save();
                }

            }
            else
            {
                openPopup();
                return;
            }
            car3select.SetActive(true);
            PlayerPrefs.SetInt("playerCar", 3);

            car2select.SetActive(false);
            car1select.SetActive(false);
            car4select.SetActive(false);
            car5select.SetActive(false);
            car6select.SetActive(false);
            car7select.SetActive(false);
            car8select.SetActive(false);

        }
        void activateCar4()
        {
            if (IAPcontroller.mainPlayer.coins >= 1000)
            {
                if (IAPcontroller.mainPlayer.car3 == 0)
                {
                    IAPcontroller.mainPlayer.removeCoins(1000);
                    carParent.transform.GetChild(3).GetChild(5).gameObject.SetActive(false);
                    IAPcontroller.mainPlayer.car3 = 1;
                    IAPcontroller.mainPlayer.Save();
                }
            }
            else
            {
                openPopup();
                return;
            }
            car4select.SetActive(true);
            PlayerPrefs.SetInt("playerCar", 4);

            car2select.SetActive(false);
            car3select.SetActive(false);
            car1select.SetActive(false);
            car5select.SetActive(false);
            car6select.SetActive(false);
            car7select.SetActive(false);
            car8select.SetActive(false);
        }
        void activateCar5()
        {
            if (IAPcontroller.mainPlayer.coins >= 1750)
            {
                if (IAPcontroller.mainPlayer.car4 == 0)
                {
                    IAPcontroller.mainPlayer.removeCoins(1750);
                    carParent.transform.GetChild(4).GetChild(5).gameObject.SetActive(false);
                    IAPcontroller.mainPlayer.car4 = 1;
                    IAPcontroller.mainPlayer.Save();
                }
            }
            else
            {
                openPopup();
                return;
            }
            car5select.SetActive(true);
            PlayerPrefs.SetInt("playerCar", 5);

            car2select.SetActive(false);
            car3select.SetActive(false);
            car4select.SetActive(false);
            car1select.SetActive(false);
            car6select.SetActive(false);
            car7select.SetActive(false);
            car8select.SetActive(false);
        }
        void activateCar6()
        {
            if (IAPcontroller.mainPlayer.coins >= 2800)
            {
                if (IAPcontroller.mainPlayer.car5 == 0)
                {
                    IAPcontroller.mainPlayer.removeCoins(2800);
                    carParent.transform.GetChild(5).GetChild(5).gameObject.SetActive(false);
                    IAPcontroller.mainPlayer.car5 = 1;
                    IAPcontroller.mainPlayer.Save();
                }
            }
            else
            {
                openPopup();
                return;
            }
            car6select.SetActive(true);
            PlayerPrefs.SetInt("playerCar", 6);

            car2select.SetActive(false);
            car3select.SetActive(false);
            car4select.SetActive(false);
            car5select.SetActive(false);
            car1select.SetActive(false);
            car7select.SetActive(false);
            car8select.SetActive(false);
        }
        void activateCar7()
        {
            if (IAPcontroller.mainPlayer.coins >= 5000)
            {
                if (IAPcontroller.mainPlayer.car6 == 0)
                {
                    IAPcontroller.mainPlayer.removeCoins(5000);
                    carParent.transform.GetChild(6).GetChild(5).gameObject.SetActive(false);
                    IAPcontroller.mainPlayer.car6 = 1;
                    IAPcontroller.mainPlayer.Save();
                }
            }
            else
            {
                openPopup();
                return;
            }
            car7select.SetActive(true);
            PlayerPrefs.SetInt("playerCar", 7);

            car2select.SetActive(false);
            car3select.SetActive(false);
            car4select.SetActive(false);
            car5select.SetActive(false);
            car6select.SetActive(false);
            car1select.SetActive(false);
            car8select.SetActive(false);
        }
        void activateCar8()
        {
            if (IAPcontroller.mainPlayer.gems >= 250)
            {
                if (IAPcontroller.mainPlayer.car7 == 0)
                {
                    IAPcontroller.mainPlayer.removeGems(250);
                    carParent.transform.GetChild(7).GetChild(5).gameObject.SetActive(false);
                    IAPcontroller.mainPlayer.car7 = 1;
                    IAPcontroller.mainPlayer.Save();
                }
            }
            else
            {
                openPopup();
                return;
            }
            car8select.SetActive(true);
            PlayerPrefs.SetInt("playerCar", 8);

            car2select.SetActive(false);
            car3select.SetActive(false);
            car4select.SetActive(false);
            car5select.SetActive(false);
            car6select.SetActive(false);
            car7select.SetActive(false);
            car1select.SetActive(false);
        }
        void returnToMenu()
        {
            if (CarStore.activeSelf)
            {
                PlayerPrefs.Save();
            }
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
            closePopup();

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



        void addCoins1000()
        {
            //give player coins, but check if player has enough first, else bring up insufficient gems popup
            if(IAPcontroller.mainPlayer.gems < 100)
            {
                openPopup();
            }
            else
            {
                IAPcontroller.mainPlayer.addCoins(1000);
                IAPcontroller.mainPlayer.removeGems(100);
            }
            
           
        }
        void addCoins5000()
        {
            //give player coins, but check if player has enough first, else bring up insufficient gems popup
            if (IAPcontroller.mainPlayer.gems < 500)
            {
                openPopup();
            }
            else
            {
                IAPcontroller.mainPlayer.addCoins(5000);
                IAPcontroller.mainPlayer.removeGems(500);
            }
        }
        void addCoins10000()
        {
            //give player coins, but check if player has enough first, else bring up insufficient gems popup
            if (IAPcontroller.mainPlayer.gems < 1000)
            {
                openPopup();
            }
            else
            {
                IAPcontroller.mainPlayer.addCoins(10000);
                IAPcontroller.mainPlayer.removeGems(1000);
            }
        }

        static void updateHighScore(GameObject text)
        {
            text.GetComponent<TMPro.TextMeshProUGUI>().text = PlayerPrefs.GetInt("HighScore").ToString();
        }
    }
    
    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        if (IAPcontroller.mainPlayer.car1 == 0)
        {
            
            carParent.transform.GetChild(1).GetChild(5).gameObject.SetActive(true);
        }
        if (IAPcontroller.mainPlayer.car2 == 0)
        {
            carParent.transform.GetChild(2).GetChild(5).gameObject.SetActive(true);
        }
        if (IAPcontroller.mainPlayer.car3 == 0)
        {
            carParent.transform.GetChild(3).GetChild(5).gameObject.SetActive(true);
        }
        if (IAPcontroller.mainPlayer.car4 == 0)
        {
            carParent.transform.GetChild(4).GetChild(5).gameObject.SetActive(true);
        }
        if (IAPcontroller.mainPlayer.car5 == 0)
        {
            carParent.transform.GetChild(5).GetChild(5).gameObject.SetActive(true);
        }
        if (IAPcontroller.mainPlayer.car6 == 0)
        {
            carParent.transform.GetChild(6).GetChild(5).gameObject.SetActive(true);
        }
        if (IAPcontroller.mainPlayer.car7 == 0)
        {
            carParent.transform.GetChild(7).GetChild(5).gameObject.SetActive(true);
        }

    }
}
