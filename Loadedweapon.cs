using System.Collections;
using System.Collections.Generic;// By Paul Rose
using UnityEngine;// this is the equip detector for each and every w

// if player happen to be hold thid weapon this this should happen etc
// loadweapon when detecting swordequip/rifle equip collider attached to player hand
//Best own script written where I'm getting to function with solid results//previously made a toggle switch
//but this was unreliable as used synchin with the toggle and animation. By using colliders we get to know when
//the item is really physically equipped regardless to physics anim delays. Sword has collider set to trigger and so does rifle.
//-Much like a pick up item only attached to the player object the sword/ the rifle (tag the correct item)


// Simple error 9/5 where collider missing of players machine gun so no way to detect equip in this script fixed this 
//script handles unequipped phases for each scenario
public class Loadedweapon : MonoBehaviour// up script this is not as complicated as it looks just enabling what you need activaed each time unequipped
{
    public GameObject Machinegunloaded;//new09/5/23
    public GameObject Spawngunloaded;
    public GameObject Spawngunempty;
    public GameObject Crosshair;
    public GameObject Machinegunspawn;
    public GameObject Gunspawn;

    void OnTriggerEnter(Collider other)
    // works attached to player
    {
        //equip tag for rifle is equip, for sword swordequip
        if (other.tag == "swordequip")// trigger to detect weapon not player , so to determine isequipped to prevent fire when unequipped
        {

            Spawngunloaded.SetActive(false);
            Machinegunloaded.SetActive(false);
            Spawngunempty.SetActive(true);//sword
            Crosshair.SetActive(false);
            gameObject.GetComponent<MeshRenderMelee>().enabled = true;// check
        }
        // using unique tags seems to help error when having swordequip and rifleequip too similar
        //equip tag for rifle is equip, for sword swordequip
        if (other.tag == "rifleequip")// trigger to detect weapon not player , so to determine isequipped to prevent fire when unequipped

        {
            Spawngunloaded.SetActive(true);
            Machinegunloaded.SetActive(false);
            Spawngunempty.SetActive(false);//sword no bullets so set empty
            Crosshair.SetActive(true);
            Machinegunspawn.SetActive(false);
            Gunspawn.SetActive(true);

        }
        if (other.tag == "machinegunequip")// trigger to detect weapon not player , so to determine isequipped to prevent fire when unequipped

        {
            Machinegunloaded.SetActive(true);
            Spawngunloaded.SetActive(false);
            Spawngunempty.SetActive(false);
            Crosshair.SetActive(true);// Spawngunempty missing
            Machinegunspawn.SetActive(true);
            Machinegunspawn.SetActive(true);
            Gunspawn.SetActive(false);
        }

    }

}
// trigger collider is attached on sword not actual player. When the sword is equipped triiger collider detect player has sword.
// note when coming up with the script above realised you must identify the objects in the scene when tagging can get
// confusing I have 3 rifles set up one is anim other is mesh rifle and main one in scene. Must tag obj in scene
