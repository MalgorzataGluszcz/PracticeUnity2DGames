using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CollectItems : MonoBehaviour
{
    [SerializeField] private Text cherryCollectText;

    private int cherryCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cherry")
        { 
            //gameObject.SetActive(false);
            Destroy(collision.gameObject);
            cherryCount++;
            cherryCollectText.text = "Cherry " + cherryCount;
        }
    }
}