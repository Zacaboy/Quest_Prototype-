using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{

    public GameObject itemCollectedImage;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming the player has the "Player" tag
        {
            

            if (itemCollectedImage != null && TriggerNPCTalk.spokeToNPC == true)
            {
                TriggerNPCTalk.playerHasItem = true; // Notify the NPC that the player has the item

                itemCollectedImage.gameObject.SetActive(true); // Show the item as collected in the UI
                                                               
                // Optionally, add some feedback here, like a sound effect or a visual effect

                // Destroy the parent GameObject, which will destroy all children as well
                Destroy(transform.parent.gameObject);
            }

            
        }
    }

}
