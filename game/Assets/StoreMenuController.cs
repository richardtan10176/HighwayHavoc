using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StoreMenuController : MonoBehaviour
{
    public Button button1, button2, button3, button4, button5, button6, button7, button8, button9;
    static public int userGearsAmount;
    static public int use;
    public static GameObject CarStore, gemStore;

    // Start is called before the first frame update
    void Start() {
        GameObject CarStore = new GameObject();
        GameObject gemStore = new GameObject();

        button1.onClick.AddListener(TaskOnClick);
        button2.onClick.AddListener(TaskOnClick);
        button3.onClick.AddListener(TaskOnClick);
        button4.onClick.AddListener(TaskOnClick);
        button5.onClick.AddListener(TaskOnClick);
        button6.onClick.AddListener(TaskOnClick);
        button7.onClick.AddListener(TaskOnClick);
        button8.onClick.AddListener(TaskOnClick);
        button9.onClick.AddListener(TaskOnClick);


    }
    void TaskOnClick()
    { 
    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    static void enableCarStore()
    {
        CarStore.SetActive(true);
    }
    static void disableCarStore()
    {
        CarStore.SetActive(false);
    }
    static void enableGemStore()
    {
        CarStore.SetActive(true);
    }
    static void disableGemStore()
    {
        CarStore.SetActive(false);
    }
   

}
