using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public static AudioSource click;
    public static AudioSource success;
    public GameObject clickSource;
    public GameObject successSource;


    public Button buy1000coins;
    public Button buy5000coins;
    public Button buy10000coins;
    public Button playButton;


    public GameObject highScoreTxt;

    public GameObject mainMenu, CarStore, gemStore, coinStore;
    public GameObject car1select, car2select, car3select, car4select, car5select, car6select, car7select, car8select;
    public GameObject carParent;

    




    //for coin popup menu
    public GameObject popupMenuGem;
    public Button exitGemPopupButton;
    public Button buyMoreGems;

    //for car popup menu
    public GameObject popupMenuCar;
    public Button exitCarPopupButton;
    public Button confirm;
    public GameObject carNameTxt;
    int carIndexBeingPurchased;
    int costOfCarBeingPurchased;
    string nameOfCarBeingPurchased;


    void Awake()
    {
        click = clickSource.GetComponent<AudioSource>();
        success = successSource.GetComponent<AudioSource>();




    }
    // Start is called before the first frame update
    void Start() {
        //PlayerPrefs.DeleteAll();


        Debug.Log("Coins: " + PlayerPrefs.GetInt("coinScore"));



        IAPcontroller.mainPlayer.addCoins(PlayerPrefs.GetInt("coinScore"));
        PlayerPrefs.SetInt("coinScore",0);

        if (PlayerPrefs.GetInt("highScore") < PlayerPrefs.GetInt("score"))
        {
            highScoreTxt.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("score").ToString();
            PlayerPrefs.SetInt("highScore", PlayerPrefs.GetInt("score"));
            PlayerPrefs.SetInt("score", 0);
        }
        else
        {
            highScoreTxt.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("highScore").ToString();
        }

        if (!PlayerPrefs.HasKey("firsttime")) //first time in game
        {
            PlayerPrefs.SetInt("firsttime", 0);
            

            //set default selected car to the first car
            car1select.SetActive(true);
            PlayerPrefs.SetInt("playerCar", 1);
            




        }
        else
        {
            carParent.transform.GetChild(PlayerPrefs.GetInt("playerCar")-1).GetChild(4).gameObject.SetActive(true);
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

        exitGemPopupButton.onClick.AddListener(closePopupGem);
        buyMoreGems.onClick.AddListener(openGemMenu);

        exitCarPopupButton.onClick.AddListener(closePopupCar);
        confirm.onClick.AddListener(purchaseCar);

        playButton.onClick.AddListener(startGame);

        
        


        void activateCar1()
        {
            click.Play();
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
            click.Play();
            carIndexBeingPurchased = 1;
            costOfCarBeingPurchased = 250;
            nameOfCarBeingPurchased = "Mitsubishi Lancer GSR";
            if (IAPcontroller.mainPlayer.car1 == 1)
            {
                car2select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 2);
                car1select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                return;
            }
            
            if (IAPcontroller.mainPlayer.coins >= 250)
            {
                if(IAPcontroller.mainPlayer.car1 == 0) //verify car has not already been purchased
                {
                    openPopupCar();
                }
            }
            else
            {
                openPopupGem();
                return;
            }
            

        }


        void activateCar3()
        {
            carIndexBeingPurchased = 2;
            costOfCarBeingPurchased = 500;
            nameOfCarBeingPurchased = "Ford RS 200";
            click.Play();
            if (IAPcontroller.mainPlayer.car2 == 1)
            {
                car3select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 3);
                car2select.SetActive(false);
                car1select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                return;
            }
            if (IAPcontroller.mainPlayer.coins >= 500)
            {
                if (IAPcontroller.mainPlayer.car2 == 0)
                {
                    openPopupCar();
                }
            }
            else
            {
                openPopupGem();
                return;
            }


        }


        void activateCar4()
        {
            carIndexBeingPurchased = 3;
            costOfCarBeingPurchased = 1000;
            nameOfCarBeingPurchased = "Citroeen Xsaara WRC";
            click.Play();
            if (IAPcontroller.mainPlayer.car3 == 1)
            {
                car4select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 4);

                car2select.SetActive(false);
                car3select.SetActive(false);
                car1select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                return;
            }
            if (IAPcontroller.mainPlayer.coins >= 1000)
            {
                if (IAPcontroller.mainPlayer.car3 == 0)
                {
                    openPopupCar();
                }
            }
            else
            {
                openPopupGem();
                return;
            }

        }


        void activateCar5()
        {
            carIndexBeingPurchased = 4;
            costOfCarBeingPurchased = 1750;
            nameOfCarBeingPurchased = "Fiat 131";
            click.Play();
            if (IAPcontroller.mainPlayer.car4 == 1)
            {
                car5select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 5);

                car2select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car1select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                return;
            }
            if (IAPcontroller.mainPlayer.coins >= 1750)
            {
                if (IAPcontroller.mainPlayer.car4 == 0)
                {
                    openPopupCar();
                }
            }
            else
            {
                openPopupGem();
                return;
            }

        }


        void activateCar6()
        {
            carIndexBeingPurchased = 5;
            costOfCarBeingPurchased = 2800;
            nameOfCarBeingPurchased = "Subaruu Impreeza WRC";
            click.Play();
            if (IAPcontroller.mainPlayer.car5 == 1)
            {
                car6select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 6);

                car2select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car1select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                return;
            }
            if (IAPcontroller.mainPlayer.coins >= 2800)
            {
                if (IAPcontroller.mainPlayer.car5 == 0)
                {
                    openPopupCar();
                }
            }
            else
            {
                openPopupGem();
                return;
            }

        }


        void activateCar7()
        {
            carIndexBeingPurchased = 6;
            costOfCarBeingPurchased = 5000;
            nameOfCarBeingPurchased = "MG Metro 6R4";
            click.Play();
            if (IAPcontroller.mainPlayer.car6 == 1)
            {
                car7select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 7);

                car2select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car1select.SetActive(false);
                car8select.SetActive(false);
                return;
            }
            if (IAPcontroller.mainPlayer.coins >= 5000)
            {
                if (IAPcontroller.mainPlayer.car6 == 0)
                {
                    openPopupCar();
                }
            }
            else
            {
                openPopupGem();
                return;
            }

        }


        void activateCar8()
        {
            carIndexBeingPurchased = 7;
            nameOfCarBeingPurchased = "Citroeen C4 WRC";
            click.Play();
            if (IAPcontroller.mainPlayer.car7 == 1)
            {
                car8select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 8);

                car2select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car1select.SetActive(false);
                return;
            }
            if (IAPcontroller.mainPlayer.gems >= 250)
            {
                if (IAPcontroller.mainPlayer.car7 == 0)
                {
                    openPopupCar();
                }
            }
            else
            {
                openPopupGem();
                return;
            }

        }


        void returnToMenu()
        {
            if (CarStore.activeSelf)
            {
                PlayerPrefs.Save();
            }
            click.Play();
            gemStore.SetActive(false);
            coinStore.SetActive(false);
            CarStore.SetActive(false);

            mainMenu.SetActive(true);
            returnToMainMenu.transform.parent.gameObject.SetActive(false);
        }
        void openGemMenu()
        {
            click.Play();
            mainMenu.SetActive(false);
            coinStore.SetActive(false);
            CarStore.SetActive(false);
            closePopupGem();

            gemStore.SetActive(true);
            returnToMainMenu.transform.parent.gameObject.SetActive(true);
        }
        void openCoinMenu()
        {
            click.Play();
            mainMenu.SetActive(false);
            gemStore.SetActive(false);
            CarStore.SetActive(false);

            coinStore.SetActive(true);
            returnToMainMenu.transform.parent.gameObject.SetActive(true);
        }
        void openCarMenu()
        {
            click.Play();
            mainMenu.SetActive(false);
            coinStore.SetActive(false);
            gemStore.SetActive(false);

            CarStore.SetActive(true);
            returnToMainMenu.transform.parent.gameObject.SetActive(true);
        }
        void openPopupGem()
        {
            popupMenuGem.SetActive(true);
        }
        void closePopupGem()
        {
            popupMenuGem.SetActive(false);
            click.Play();
        }
        void openPopupCar()
        {
            popupMenuCar.SetActive(true);
            carNameTxt.GetComponent<TMPro.TextMeshProUGUI>().text = nameOfCarBeingPurchased;

        }
        void closePopupCar()
        {
            popupMenuCar.SetActive(false);
            click.Play();
        }



        void addCoins1000()
        {
            click.Play();
            //give player coins, but check if player has enough first, else bring up insufficient gems popup
            if (IAPcontroller.mainPlayer.gems < 100)
            {
                openPopupGem();
            }
            else
            {
                
                IAPcontroller.mainPlayer.addCoins(1000);
                IAPcontroller.mainPlayer.removeGems(100);
                success.Play();
            }
            
           
        }
        void addCoins5000()
        {
            click.Play();
            //give player coins, but check if player has enough first, else bring up insufficient gems popup
            if (IAPcontroller.mainPlayer.gems < 500)
            {
                openPopupGem();
            }
            else
            {
               
                IAPcontroller.mainPlayer.addCoins(5000);
                IAPcontroller.mainPlayer.removeGems(500);
                success.Play();
            }
        }
        void addCoins10000()
        {
            click.Play();
            //give player coins, but check if player has enough first, else bring up insufficient gems popup
            if (IAPcontroller.mainPlayer.gems < 1000)
            {
                openPopupGem();
            }
            else
            {
                
                IAPcontroller.mainPlayer.addCoins(10000);
                IAPcontroller.mainPlayer.removeGems(1000);
                success.Play();
            }
        }
        void purchaseCar()
        {
            click.Play();
            if(carIndexBeingPurchased == 7)
            {
                IAPcontroller.mainPlayer.removeGems(250);
                carParent.transform.GetChild(7).GetChild(5).gameObject.SetActive(false);
                IAPcontroller.mainPlayer.car7 = 1;

                car8select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 8);

                car2select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car1select.SetActive(false);

                IAPcontroller.mainPlayer.Save();
                popupMenuCar.SetActive(false);
                return;
            }
            

            IAPcontroller.mainPlayer.removeCoins(costOfCarBeingPurchased);
            carParent.transform.GetChild(carIndexBeingPurchased).GetChild(5).gameObject.SetActive(false);
            if(carIndexBeingPurchased == 1) 
            {
                IAPcontroller.mainPlayer.car1 = 1;
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
            if (carIndexBeingPurchased == 2)
            {
                IAPcontroller.mainPlayer.car2 = 1;
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
            if (carIndexBeingPurchased == 3)
            {
                IAPcontroller.mainPlayer.car3 = 1;
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
            if (carIndexBeingPurchased == 4)
            {
                IAPcontroller.mainPlayer.car4 = 1;
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
            if (carIndexBeingPurchased == 5)
            {
                IAPcontroller.mainPlayer.car5 = 1;
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
            if (carIndexBeingPurchased == 6)
            {
                IAPcontroller.mainPlayer.car6 = 1;
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

            IAPcontroller.mainPlayer.Save();
            success.Play();
            popupMenuCar.SetActive(false);
        }
        void startGame()
        {
            //switch to game scene
            SceneManager.LoadScene(1);
            click.Play(); 
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
