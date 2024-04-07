using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arkaplan : MonoBehaviour
{
    MeshRenderer meshRenderer;


    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>(); //Oyun objesinde ekli oldu�u i�in direkt getComponent yaz�yorum.
    }

    // Update is called once per frame
    void Update()
    {
        float y = 0.1f * Time.time; //her xaman art���nda 0.1 artan y de�eri olu�turdum
        meshRenderer.material.SetTextureOffset("_MainTex", new Vector2(0, y));
    }
}
