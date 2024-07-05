using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    public void ActivateGameObject(GameObject gogogo)
    {
        gogogo.SetActive(true);
    }

    public void DeactivateGameObject (GameObject gogogo) 
    {
        gogogo.SetActive(false);
    }
}
