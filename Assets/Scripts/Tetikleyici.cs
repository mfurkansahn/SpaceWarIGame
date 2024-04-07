using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetikleyici : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        EkranHesaplayicisi.Init();
        List<int> myList = new List<int>();

        //Örnek Serfika Sorusu
        //for (int i = 50; 5 < i; i -= 5)
        //{
        //    myList.Add(i);
        //}
        //int sayi1 = myList[0];
        //foreach (int item in myList)
        //{
        //    if (item < sayi1)
        //    {
        //        sayi1 = item;
        //    }
        //}
        //Debug.Log(sayi1);

        //Örnek Serfika Sorusu
        //for (int i = 0; i <= 101; i += 2)
        //{
        //    Debug.Log("Unity");
        //}
    }
    // Update is called once per frame
    void Update()
    {

    }
}
