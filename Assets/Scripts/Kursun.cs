using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kursun : MonoBehaviour
{
    GeriSayimSayaci geriSayimSayaci;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 10), ForceMode2D.Impulse); //Yukarý doðru hamle için kod
        geriSayimSayaci = gameObject.AddComponent<GeriSayimSayaci>(); //Geri sayým objesi eklendi
        geriSayimSayaci.ToplamSure = 3;
        geriSayimSayaci.Calistir();
    }

    // Update is called once per frame
    void Update()
    {
        if(geriSayimSayaci.Bitti)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Asteroid")
        {
            Destroy(this.gameObject);
        }
    }
}
