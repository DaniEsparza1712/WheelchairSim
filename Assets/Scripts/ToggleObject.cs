using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    public bool canToggle = true;
    public void SetToggle(bool toggle){
        canToggle = toggle;
    }
    public void ToggleGameObject(GameObject gogogo)
    {
        if(canToggle)
            gogogo.SetActive(!gogogo.activeSelf);
    }

    public void ActivateGameObject(GameObject gogogo)
    {
        gogogo.SetActive(true);
    }

    public void DeactivateGameObject (GameObject gogogo) 
    {
        gogogo.SetActive(false);
    }
}
