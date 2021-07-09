using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombScript : MonoBehaviour
{
    //Declare variables
    [SerializeField] private GameObject bombObject;

    public bool bombActive = false;

    [SerializeField] private Image image;
    public Sprite bombImage;

    // Start is called before the first frame update
    private void Start()
    {
        bombActive = false;
    }
    //OnMouseDown function which is called when the mouse cursor clicks on a collider
    private void OnMouseDown()
    {
        bombActive = true;

        image.enabled = true;
        image.sprite = bombImage;

        if (GameModeController.endless)
        {


            bombObject.SetActive(false);
        }
    }


    
}
