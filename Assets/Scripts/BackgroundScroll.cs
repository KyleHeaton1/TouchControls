using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    public float scrollSpeed = 1f;

    private void Awake() 
    {
       meshRenderer = GetComponent<MeshRenderer>(); 
    }

    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0);
    }
}
