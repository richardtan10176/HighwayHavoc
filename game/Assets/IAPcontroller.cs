using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPcontroller : MonoBehaviour
{
    
    private string gems100 = "com.aetherix.highwayhavoc.100gems";
    private string gems500 = "com.aetherix.highwayhavoc.500gems";
    private string gems1000 = "com.aetherix.highwayhavoc.1000gems";
    public static Player mainPlayer;
    private void Awake()
    {

        mainPlayer = new Player();
        PlayerData temp = SaveSystem.LoadPlayer();
        mainPlayer.gems = temp.gems;
        mainPlayer.coins = temp.coins;
        mainPlayer.car1 = temp.car1;
        mainPlayer.car2 = temp.car2;
        mainPlayer.car3 = temp.car3;
        mainPlayer.car4 = temp.car4;
        mainPlayer.car5 = temp.car5;
        mainPlayer.car6 = temp.car6;
        mainPlayer.car7 = temp.car7;
        
    }

    public void OnPurchaseComplete(Product product)
    {
        StoreMenuController.success.Play();
        if (product.definition.id == gems100)
        {
            //give user 100 gems
            mainPlayer.addGems(100);
            return;
        }
        else if (product.definition.id == gems500)
        {
            //give user 500 gems
            mainPlayer.addGems(500);
            return;
        }
        else if(product.definition.id == gems1000)
        {
            //give user 1000 gems
            mainPlayer.addGems(1000);
            return;
        }
    }
    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase of " + product.definition.id + " failed due to " + reason);
    }
    
}
