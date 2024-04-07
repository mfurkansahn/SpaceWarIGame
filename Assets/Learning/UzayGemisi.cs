using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayGemisi 
{
    //~Fields oluþtur~
    /// <summary>
    /// Geminin Maksimum Hýz Limiti
    /// </summary>
    int maksimumHiz;

    /// <summary>
    /// Geminin Rengi
    /// </summary>
    string renk;



    //~Property oluþtur~
    /// <summary>
    /// Maksimum Hýz Deðerini Döner
    /// </summary>
    public int MaksimumHiz
    {
        get{return maksimumHiz; } //Maksimum hýz deðerine ulaþýlacak
    }

    /// <summary>
    /// Geminin Rengini Döner
    /// </summary>
    public string GemininRengi
    {
        get { return renk; } //Renk deðerine ulaþýlacak
    }



    //~Constructor oluþtur~
    /// <summary>
    /// Maksimum Hýz ve Rengi Yazýn
    /// </summary>
    /// <param name="maksimumHiz"></param>
    /// <param name="renk"></param>
    public UzayGemisi(int maksimumHiz, string renk)
    {
        this.maksimumHiz = maksimumHiz;
        this.renk = renk;
    }

    /// <summary>
    /// Rengi Olmayan Uzay Gemisi Constructor'ý
    /// </summary>
    public UzayGemisi(int maksimumHiz)
    {
        this.maksimumHiz = maksimumHiz;
    }

    

    /// <summary>
    /// Uzay Gemisini Hýzlandýrma Süper Gücü
    /// </summary>
    public void Hizlandirici()
    {
        maksimumHiz += Random.Range(10, 30);
        Debug.Log(maksimumHiz);
    }

    /// <summary>
    /// Uzay Gemisini Yavaþlatma Süper Gücü
    /// </summary>
    public void Yavaslatici()
    {
        maksimumHiz -= Random.Range(10, 30);
        Debug.Log(maksimumHiz);
    }
}
