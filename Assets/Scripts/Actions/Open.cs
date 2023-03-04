using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Open")]
public class Open : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        //check items in room
        if (CheckItems(controller, controller.player.currentLocation.items, noun))
        {
            return;
        }

        //check item in inventory
        if (CheckItems(controller, controller.player.inventory, noun))
        {
            return;
        }
        controller.currentText.text = "You can't open a " + noun;
    }

    private bool CheckItems(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun)
            {
                if (item.InteractWith(controller, "open"))
                    return true;
                controller.currentText.text = "" + item.description;

                return true;
            }
        }
        return false;
    }



}
