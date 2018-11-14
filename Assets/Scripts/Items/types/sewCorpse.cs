using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sewCorpse : InteractableItem {

    private Inventory inventory;
    Item headItem;
    public GameObject headObjectPickedUp;
    public GameObject headObjectOnCorpse;
    public GameObject fuse;

    void Start()
    {
        inventory = Inventory.instance;
        ///headObjectPickedUp = GameObject.Find("mannequin_head");
        ///headObjectOnCorpse = GameObject.Find("mannequin_04");
        ///fuse = GameObject.Find("Fuse1");
        this.canInteract = true;
    }

    // Check if head is in the inventory.
    private void checkHasHead()
    {
        this.canInteract = false;
        for (int i = 0; i < inventory.items.Count; i++)
        {
            if (inventory.items[i].itemName == "bodyParts")
            {
                this.canInteract = true;
                return;
            }
        }
    }

    public override void onInteract()
    {

        Item activeItem = inventory.getActiveItem();

        if (headObjectPickedUp == null)
        {
            // Checking for head in the inventory.
            if (activeItem != null && activeItem.itemName == "bodyParts")
            {
                // Putting head back on body.
                headObjectOnCorpse.SetActive(true);

                // Removing head from inventory & making it un-interactable.
                inventory.remove(activeItem);
                interactText = "";
                this.canInteract = false;

                // Making fuse visible.
                fuse.SetActive(true);

            }
        }
    }
}
