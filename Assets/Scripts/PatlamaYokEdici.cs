using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatlamaYokEdici : MonoBehaviour
{

    GeriSayimSayaci geriSayimSayaci;

    //SiraliYokEdici _siraliYokEdici; //S�radaki asteroidin yok edilmesi i�in patlaman�n bitti�ini bilmemiz gerekiyor

    // Start is called before the first frame update
    void Start()
    {
        geriSayimSayaci = gameObject.AddComponent<GeriSayimSayaci>();
        //_siraliYokEdici = Camera.main.GetComponent<SiraliYokEdici>(); //Bu bile�eni main kameradan almas� gerekti�ini s�yleyece�iz
        geriSayimSayaci.ToplamSure = 1;
        geriSayimSayaci.Calistir();
    }

    // Update is called once per frame
    void Update()
    {
        if (geriSayimSayaci.Bitti)
        {
            //_siraliYokEdici.HedefiYokEt();
            Destroy(gameObject);
        }
    }
}
