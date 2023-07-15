using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PausePR : MonoBehaviour
{ 
   public TextMeshProUGUI Pause;

    // Update is called once per frame
    private void Start()
    {
        Pause.enabled = false;//text
    }


    void Update()

    {
        if (Input.GetButtonDown("Equip Eighth Item"))// equip 7 and 8 as joystick button 7// left menu

        {
            Pause.enabled = true;// text
            Time.timeScale = 0;

        }
        if (Input.GetButtonDown("Equip Seventh Item"))// equip 6 and  as joystick button 6// right menu /p

        {
            Pause.enabled = false;
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown("p"))// equip 7 and 8 as joystick button 5 and 6//

        {
            Pause.enabled = false;
            Time.timeScale = 1;
        }

        //  if (Input.GetButtonDown("Equip Next Item"))// equip 7 and 8 as joystick button 5 and 6//

        //{
        //      Time.timeScale = 1;
        //}
        //if (Input.GetAxisRaw("Fire1") != 0)
        // {
        //      Time.timeScale = 1;


    }
}
