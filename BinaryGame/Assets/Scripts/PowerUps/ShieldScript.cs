using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldScript : MonoBehaviour
{
    //Declare variables
    [SerializeField] private GameObject shieldObject;

    public bool shieldActive = false;

    [SerializeField] private Image image;
    public Sprite shieldImage;

    //OnMouseDown function which is called when the mouse cursor clicks on a collider
    void OnMouseDown()
    {
        shieldActive = true;
        image.enabled = true;
        image.sprite = shieldImage;

        if (GameModeController.endless)
        {


            shieldObject.SetActive(false);
        }
    }

    
}
