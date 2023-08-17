using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Purchasing;
using TMPro;
//IOS VERSION
public class StoreMenuController : MonoBehaviour
{
    public Button button1, button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12, button13, button14, button15, button16; //cars
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
    public GameObject car1select, car2select, car3select, car4select, car5select, car6select, car7select, car8select, car9select, car10select, car11select, car12select, car13select, car14select, car15select, car16select;
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
        Application.targetFrameRate = 90;



    }
    // Start is called before the first frame update
    void Start() {
        //PlayerPrefs.DeleteAll();



        IAPcontroller.mainPlayer.removeGems(PlayerPrefs.GetInt("gemsOwed"));
        PlayerPrefs.SetInt("gemsOwed", 0);

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


        //StandardPurchasingModule.Instance().useFakeStoreAlways = true; //remove for final release

        button1.onClick.AddListener(activateCar1);
        button2.onClick.AddListener(activateCar2);
        button3.onClick.AddListener(activateCar3);
        button4.onClick.AddListener(activateCar4);
        button5.onClick.AddListener(activateCar5);
        button6.onClick.AddListener(activateCar6);
        button7.onClick.AddListener(activateCar7);
        button8.onClick.AddListener(activateCar8);
        button9.onClick.AddListener(activateCar9);
        button10.onClick.AddListener(activateCar10);
        button11.onClick.AddListener(activateCar11);
        button12.onClick.AddListener(activateCar12);
        button13.onClick.AddListener(activateCar13);
        button14.onClick.AddListener(activateCar14);
        button15.onClick.AddListener(activateCar15);
        button16.onClick.AddListener(activateCar16);

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
            car9select.SetActive(false);
            car10select.SetActive(false);
            car11select.SetActive(false);
            car12select.SetActive(false);
            car13select.SetActive(false);
            car14select.SetActive(false);
            car15select.SetActive(false);
            car16select.SetActive(false);
        }
        void activateCar2()
        {
            click.Play();
            carIndexBeingPurchased = 1;
            costOfCarBeingPurchased = 100;
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
                car9select.SetActive(false);
                car10select.SetActive(false);
                car11select.SetActive(false);
                car12select.SetActive(false);
                car13select.SetActive(false);
                car14select.SetActive(false);
                car15select.SetActive(false);
                car16select.SetActive(false);
                return;
            }
            
            if (IAPcontroller.mainPlayer.coins >= 100)
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
            costOfCarBeingPurchased = 250;
            nameOfCarBeingPurchased = "Ford RS 200";
            click.Play();
            if (IAPcontroller.mainPlayer.car2 == 1)
            {
                car3select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 3);
                car1select.SetActive(false);
                car2select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                car9select.SetActive(false);
                car10select.SetActive(false);
                car11select.SetActive(false);
                car12select.SetActive(false);
                car13select.SetActive(false);
                car14select.SetActive(false);
                car15select.SetActive(false);
                car16select.SetActive(false);
                return;
            }
            if (IAPcontroller.mainPlayer.coins >= 250)
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
            costOfCarBeingPurchased = 500;
            nameOfCarBeingPurchased = "Citroeen Xsaara WRC";
            click.Play();
            if (IAPcontroller.mainPlayer.car3 == 1)
            {
                car4select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 4);

                car1select.SetActive(false);
                car3select.SetActive(false);
                car2select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                car9select.SetActive(false);
                car10select.SetActive(false);
                car11select.SetActive(false);
                car12select.SetActive(false);
                car13select.SetActive(false);
                car14select.SetActive(false);
                car15select.SetActive(false);
                car16select.SetActive(false);
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
            costOfCarBeingPurchased = 1000;
            nameOfCarBeingPurchased = "Fiat 131";
            click.Play();
            if (IAPcontroller.mainPlayer.car4 == 1)
            {
                car5select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 5);

                car1select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car2select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                car9select.SetActive(false);
                car10select.SetActive(false);
                car11select.SetActive(false);
                car12select.SetActive(false);
                car13select.SetActive(false);
                car14select.SetActive(false);
                car15select.SetActive(false);
                car16select.SetActive(false);
                return;
            }
            if (IAPcontroller.mainPlayer.coins >= 1000)
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
            costOfCarBeingPurchased = 1500;
            nameOfCarBeingPurchased = "Subaruu Impreeza WRC";
            click.Play();
            if (IAPcontroller.mainPlayer.car5 == 1)
            {
                car6select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 6);

                car1select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car2select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                car9select.SetActive(false);
                car10select.SetActive(false);
                car11select.SetActive(false);
                car12select.SetActive(false);
                car13select.SetActive(false);
                car14select.SetActive(false);
                car15select.SetActive(false);
                car16select.SetActive(false);
                return;
            }
            if (IAPcontroller.mainPlayer.coins >= 1500)
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
            costOfCarBeingPurchased = 2000;
            nameOfCarBeingPurchased = "MG Metro 6R4";
            click.Play();
            if (IAPcontroller.mainPlayer.car6 == 1)
            {
                car7select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 7);

                car1select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car2select.SetActive(false);
                car8select.SetActive(false);
                car9select.SetActive(false);
                car10select.SetActive(false);
                car11select.SetActive(false);
                car12select.SetActive(false);
                car13select.SetActive(false);
                car14select.SetActive(false);
                car15select.SetActive(false);
                car16select.SetActive(false);
                return;
            }
            if (IAPcontroller.mainPlayer.coins >= 2000)
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
            costOfCarBeingPurchased = 2500;
            nameOfCarBeingPurchased = "Peugiot 405 T16";
            click.Play();
            if (IAPcontroller.mainPlayer.car7 == 1)
            {
                car8select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 8);

                car1select.SetActive(false);
                car2select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car9select.SetActive(false);
                car10select.SetActive(false);
                car11select.SetActive(false);
                car12select.SetActive(false);
                car13select.SetActive(false);
                car14select.SetActive(false);
                car15select.SetActive(false);
                car16select.SetActive(false);
                return;
            }
            if (IAPcontroller.mainPlayer.coins >= 2500)
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

        void activateCar9()
        {
            carIndexBeingPurchased = 8;
            costOfCarBeingPurchased = 3000;
            nameOfCarBeingPurchased = "Audi Sport Quattro S1";
            click.Play();
            if (IAPcontroller.mainPlayer.car8 == 1)
            {
                car9select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 9);

                car1select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                car2select.SetActive(false);
                car10select.SetActive(false);
                car11select.SetActive(false);
                car12select.SetActive(false);
                car13select.SetActive(false);
                car14select.SetActive(false);
                car15select.SetActive(false);
                car16select.SetActive(false);
                return;
            }
            if (IAPcontroller.mainPlayer.coins >= 3000)
            {
                if (IAPcontroller.mainPlayer.car8 == 0)
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
        void activateCar10()
        {
            carIndexBeingPurchased = 9;
            costOfCarBeingPurchased = 3500;
            nameOfCarBeingPurchased = "Porsche 959 Paris Bakar";
            click.Play();
            if (IAPcontroller.mainPlayer.car9 == 1)
            {
                car10select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 10);

                car1select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                car9select.SetActive(false);
                car2select.SetActive(false);
                car11select.SetActive(false);
                car12select.SetActive(false);
                car13select.SetActive(false);
                car14select.SetActive(false);
                car15select.SetActive(false);
                car16select.SetActive(false);
                return;
            }
            if (IAPcontroller.mainPlayer.coins >= 3500)
            {
                if (IAPcontroller.mainPlayer.car9 == 0)
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
        void activateCar11()
        {
            carIndexBeingPurchased = 10;
            costOfCarBeingPurchased = 4000;
            nameOfCarBeingPurchased = "Toyota Celicca GT";
            click.Play();
            if (IAPcontroller.mainPlayer.car10 == 1)
            {
                car11select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 11);

                car1select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                car9select.SetActive(false);
                car10select.SetActive(false);
                car2select.SetActive(false);
                car12select.SetActive(false);
                car13select.SetActive(false);
                car14select.SetActive(false);
                car15select.SetActive(false);
                car16select.SetActive(false);
                return;
            }
            if (IAPcontroller.mainPlayer.coins >= 4000)
            {
                if (IAPcontroller.mainPlayer.car10 == 0)
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
        void activateCar12()
        {
            carIndexBeingPurchased = 11;
            costOfCarBeingPurchased = 4500;
            nameOfCarBeingPurchased = "Lancia Stratoss Group 4";
            click.Play();
            if (IAPcontroller.mainPlayer.car11 == 1)
            {
                car12select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 12);

                car1select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                car9select.SetActive(false);
                car10select.SetActive(false);
                car11select.SetActive(false);
                car2select.SetActive(false);
                car13select.SetActive(false);
                car14select.SetActive(false);
                car15select.SetActive(false);
                car16select.SetActive(false);
                return;
            }
            if (IAPcontroller.mainPlayer.coins >= 4500)
            {
                if (IAPcontroller.mainPlayer.car11 == 0)
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

        void activateCar13()
        {
            carIndexBeingPurchased = 12;
            costOfCarBeingPurchased = 5000;
            nameOfCarBeingPurchased = "Suzuki Escudo";
            click.Play();
            if (IAPcontroller.mainPlayer.car12 == 1)
            {
                car13select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 13);

                car1select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                car9select.SetActive(false);
                car10select.SetActive(false);
                car11select.SetActive(false);
                car12select.SetActive(false);
                car2select.SetActive(false);
                car14select.SetActive(false);
                car15select.SetActive(false);
                car16select.SetActive(false);
                return;
            }
            if (IAPcontroller.mainPlayer.coins >= 5000)
            {
                if (IAPcontroller.mainPlayer.car12 == 0)
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
        void activateCar14()
        {
            carIndexBeingPurchased = 13;
            costOfCarBeingPurchased = 5500;
            nameOfCarBeingPurchased = "Renault Alpine A110";
            click.Play();
            if (IAPcontroller.mainPlayer.car13 == 1)
            {
                car14select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 14);

                car1select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                car9select.SetActive(false);
                car10select.SetActive(false);
                car11select.SetActive(false);
                car12select.SetActive(false);
                car13select.SetActive(false);
                car2select.SetActive(false);
                car15select.SetActive(false);
                car16select.SetActive(false);
                return;
            }
            if (IAPcontroller.mainPlayer.coins >= 5500)
            {
                if (IAPcontroller.mainPlayer.car13 == 0)
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

        void activateCar15()
        {
            carIndexBeingPurchased = 14;
            costOfCarBeingPurchased = 6000;
            nameOfCarBeingPurchased = "Peugeot 205";
            click.Play();
            if (IAPcontroller.mainPlayer.car14 == 1)
            {
                car15select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 15);

                car1select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                car9select.SetActive(false);
                car10select.SetActive(false);
                car11select.SetActive(false);
                car12select.SetActive(false);
                car13select.SetActive(false);
                car14select.SetActive(false);
                car2select.SetActive(false);
                car16select.SetActive(false);
                return;
            }
            if (IAPcontroller.mainPlayer.coins >= 6000)
            {
                if (IAPcontroller.mainPlayer.car14 == 0)
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

        void activateCar16()
        {
            carIndexBeingPurchased = 15;
            nameOfCarBeingPurchased = "Citroeen C4 WRC";
            click.Play();
            if (IAPcontroller.mainPlayer.car15 == 1)
            {
                car16select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 16);

                car1select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                car9select.SetActive(false);
                car10select.SetActive(false);
                car11select.SetActive(false);
                car12select.SetActive(false);
                car13select.SetActive(false);
                car14select.SetActive(false);
                car15select.SetActive(false);
                car2select.SetActive(false);
                return;
            }
            if (IAPcontroller.mainPlayer.gems >= 250)
            {
                if (IAPcontroller.mainPlayer.car15 == 0)
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
            if(carIndexBeingPurchased == 15)
            {
                IAPcontroller.mainPlayer.removeGems(250);
                carParent.transform.GetChild(15).GetChild(5).gameObject.SetActive(false);
                IAPcontroller.mainPlayer.car15 = 1;

                car16select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 16);

                car1select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                car9select.SetActive(false);
                car10select.SetActive(false);
                car11select.SetActive(false);
                car12select.SetActive(false);
                car13select.SetActive(false);
                car14select.SetActive(false);
                car15select.SetActive(false);
                car2select.SetActive(false);

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
                car9select.SetActive(false);
                car10select.SetActive(false);
                car11select.SetActive(false);
                car12select.SetActive(false);
                car13select.SetActive(false);
                car14select.SetActive(false);
                car15select.SetActive(false);
                car16select.SetActive(false);
            }
            if (carIndexBeingPurchased == 2)
            {
                IAPcontroller.mainPlayer.car2 = 1;
                car3select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 3);
                car1select.SetActive(false);
                car2select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                car9select.SetActive(false);
                car10select.SetActive(false);
                car11select.SetActive(false);
                car12select.SetActive(false);
                car13select.SetActive(false);
                car14select.SetActive(false);
                car15select.SetActive(false);
                car16select.SetActive(false);
            }
            if (carIndexBeingPurchased == 3)
            {
                IAPcontroller.mainPlayer.car3 = 1;
                car4select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 4);

                car1select.SetActive(false);
                car3select.SetActive(false);
                car2select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                car9select.SetActive(false);
                car10select.SetActive(false);
                car11select.SetActive(false);
                car12select.SetActive(false);
                car13select.SetActive(false);
                car14select.SetActive(false);
                car15select.SetActive(false);
                car16select.SetActive(false);
            }
            if (carIndexBeingPurchased == 4)
            {
                IAPcontroller.mainPlayer.car4 = 1;
                car5select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 5);

                car1select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car2select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                car9select.SetActive(false);
                car10select.SetActive(false);
                car11select.SetActive(false);
                car12select.SetActive(false);
                car13select.SetActive(false);
                car14select.SetActive(false);
                car15select.SetActive(false);
                car16select.SetActive(false);
            }
            if (carIndexBeingPurchased == 5)
            {
                IAPcontroller.mainPlayer.car5 = 1;
                car6select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 6);

                car1select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car2select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                car9select.SetActive(false);
                car10select.SetActive(false);
                car11select.SetActive(false);
                car12select.SetActive(false);
                car13select.SetActive(false);
                car14select.SetActive(false);
                car15select.SetActive(false);
                car16select.SetActive(false);
            }
            if (carIndexBeingPurchased == 6)
            {
                IAPcontroller.mainPlayer.car6 = 1;
                car7select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 7);

                car1select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car2select.SetActive(false);
                car8select.SetActive(false);
                car9select.SetActive(false);
                car10select.SetActive(false);
                car11select.SetActive(false);
                car12select.SetActive(false);
                car13select.SetActive(false);
                car14select.SetActive(false);
                car15select.SetActive(false);
                car16select.SetActive(false);
            }
            if (carIndexBeingPurchased == 7)
            {
                IAPcontroller.mainPlayer.car7 = 1;
                car8select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 8);

                car1select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car2select.SetActive(false);
                car9select.SetActive(false);
                car10select.SetActive(false);
                car11select.SetActive(false);
                car12select.SetActive(false);
                car13select.SetActive(false);
                car14select.SetActive(false);
                car15select.SetActive(false);
                car16select.SetActive(false);
            }
            if (carIndexBeingPurchased == 8)
            {
                IAPcontroller.mainPlayer.car8 = 1;
                car9select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 9);

                car1select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                car2select.SetActive(false);
                car10select.SetActive(false);
                car11select.SetActive(false);
                car12select.SetActive(false);
                car13select.SetActive(false);
                car14select.SetActive(false);
                car15select.SetActive(false);
                car16select.SetActive(false);
            }
            if (carIndexBeingPurchased == 9)
            {
                IAPcontroller.mainPlayer.car9 = 1;
                car10select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 10);

                car1select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                car9select.SetActive(false);
                car2select.SetActive(false);
                car11select.SetActive(false);
                car12select.SetActive(false);
                car13select.SetActive(false);
                car14select.SetActive(false);
                car15select.SetActive(false);
                car16select.SetActive(false);
            }
            if (carIndexBeingPurchased == 10)
            {
                IAPcontroller.mainPlayer.car10 = 1;
                car11select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 11);

                car1select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                car9select.SetActive(false);
                car10select.SetActive(false);
                car2select.SetActive(false);
                car12select.SetActive(false);
                car13select.SetActive(false);
                car14select.SetActive(false);
                car15select.SetActive(false);
                car16select.SetActive(false);
            }
            if (carIndexBeingPurchased == 11)
            {
                IAPcontroller.mainPlayer.car11 = 1;
                car12select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 12);

                car1select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                car9select.SetActive(false);
                car10select.SetActive(false);
                car11select.SetActive(false);
                car2select.SetActive(false);
                car13select.SetActive(false);
                car14select.SetActive(false);
                car15select.SetActive(false);
                car16select.SetActive(false);
            }
            if (carIndexBeingPurchased == 12)
            {
                IAPcontroller.mainPlayer.car12 = 1;
                car13select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 13);

                car1select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                car9select.SetActive(false);
                car10select.SetActive(false);
                car11select.SetActive(false);
                car12select.SetActive(false);
                car2select.SetActive(false);
                car14select.SetActive(false);
                car15select.SetActive(false);
                car16select.SetActive(false);
            }
            if (carIndexBeingPurchased == 13)
            {
                IAPcontroller.mainPlayer.car13 = 1;
                car14select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 14);

                car1select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                car9select.SetActive(false);
                car10select.SetActive(false);
                car11select.SetActive(false);
                car12select.SetActive(false);
                car13select.SetActive(false);
                car2select.SetActive(false);
                car15select.SetActive(false);
                car16select.SetActive(false);
            }
            if (carIndexBeingPurchased == 14)
            {
                IAPcontroller.mainPlayer.car14 = 1;
                car15select.SetActive(true);
                PlayerPrefs.SetInt("playerCar", 15);

                car1select.SetActive(false);
                car3select.SetActive(false);
                car4select.SetActive(false);
                car5select.SetActive(false);
                car6select.SetActive(false);
                car7select.SetActive(false);
                car8select.SetActive(false);
                car9select.SetActive(false);
                car10select.SetActive(false);
                car11select.SetActive(false);
                car12select.SetActive(false);
                car13select.SetActive(false);
                car14select.SetActive(false);
                car2select.SetActive(false);
                car16select.SetActive(false);
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
        if (IAPcontroller.mainPlayer.car8 == 0)
        {
            carParent.transform.GetChild(8).GetChild(5).gameObject.SetActive(true);
        }
        if (IAPcontroller.mainPlayer.car9 == 0)
        {
            carParent.transform.GetChild(9).GetChild(5).gameObject.SetActive(true);
        }
        if (IAPcontroller.mainPlayer.car10 == 0)
        {
            carParent.transform.GetChild(10).GetChild(5).gameObject.SetActive(true);
        }
        if (IAPcontroller.mainPlayer.car11 == 0)
        {
            carParent.transform.GetChild(11).GetChild(5).gameObject.SetActive(true);
        }
        if (IAPcontroller.mainPlayer.car12 == 0)
        {
            carParent.transform.GetChild(12).GetChild(5).gameObject.SetActive(true);
        }
        if (IAPcontroller.mainPlayer.car13 == 0)
        {
            carParent.transform.GetChild(13).GetChild(5).gameObject.SetActive(true);
        }
        if (IAPcontroller.mainPlayer.car14 == 0)
        {
            carParent.transform.GetChild(14).GetChild(5).gameObject.SetActive(true);
        }
        if (IAPcontroller.mainPlayer.car15 == 0)
        {
            carParent.transform.GetChild(15).GetChild(5).gameObject.SetActive(true);
        }
    }
}
