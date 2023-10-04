using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColorOnHover : MonoBehaviour
{
    [SerializeField]
    Color color;
    [SerializeField]
    Renderer meshRenderer;

    Color[] originalColors;


    private void Start()
    {
        if(meshRenderer == null)
        {
            meshRenderer = GetComponent<Renderer>();
        }
        originalColors = meshRenderer.materials.Select(x => x.color).ToArray();
    }


    private void OnMouseEnter()
    {
        foreach(Material material in meshRenderer.materials)
        {
            material.color = color;
        }
    }


    private void OnMouseExit()
    {
        for(int i = 0; i < originalColors.Length; i++)
        {
            meshRenderer.materials[i].color = originalColors[i];
        }
    }
}
