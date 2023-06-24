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
        if (product.definition.id == gems100)
        {
            Debug.Log("gave 100");
            //give user 100 gems
        }
        else if (product.definition.id == gems500)
        {
            Debug.Log("gave 00");
            //give user 500 gems
        }
        else if(product.definition.id == gems1000)
        {
            Debug.Log("gave 1000");
            //give user 1000 gems
        }
    }
    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase of " + product.definition.id + " failed due to " + reason);
    }
    
}
