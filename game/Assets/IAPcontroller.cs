using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPcontroller : MonoBehaviour
{
    private string gems100 = "com.aerstudios.highwayhavoc.100gems";
    private string gems500 = "com.aerstudios.highwayhavoc.500gems";
    private string gems1000 = "com.aerstudios.highwayhavoc.1000gems";
    
    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == gems100)
        {
            //give user 100 gems
        }
        else if (product.definition.id == gems500)
        {
            //give user 500 gems
        }
        else
        {
            //give user 1000 gems
        }
    }
    public void OnPurchaseFailed(Product product, Purchasing.Extension.PurchaseFailureDescription description)
    {
        Debug.Log("Purchase of " + product.definition.id + " failed due to " + description);
    }
    
}
