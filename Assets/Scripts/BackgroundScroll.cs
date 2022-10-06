using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private Swipe swipe;


    public float scrollSpeed = 1f;

    private void Awake() 
    {
        meshRenderer = GetComponent<MeshRenderer>(); 
        swipe = FindObjectOfType<Swipe>();
    }

    void Update()
    {
        if(swipe.isDead == true)
        {
            return;
        }
        meshRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0);
    }
}
