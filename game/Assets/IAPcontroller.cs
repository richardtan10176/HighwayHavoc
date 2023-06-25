using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPcontroller : MonoBehaviour
{
    private string gems100 = "com.aetherix.highwayhavoc.100gems";
    private string gems500 = "com.aetherix.highwayhavoc.500gems";
    private string gems1000 = "com.aetherix.highwayhavoc.1000gems";
    
    public void OnPurchaseComplete(Product product)
    {
        Debug.Log(product.definition.id);
        if (product.definition.id == gems100)
        {
            //give user 100 gems
            addGems(100);
            return;
        }
        else if (product.definition.id == gems500)
        {
            //give user 500 gems
            addGems(500);
            return;
        }
        else if(product.definition.id == gems1000)
        {
            //give user 1000 gems
            addGems(1000);
            return;
        }
    }
    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase of " + product.definition.id + " failed due to " + reason);
    }
    //give the user their gems
    void addGems(int amount)
    {
        Debug.Log(amount);
    }
    
}
