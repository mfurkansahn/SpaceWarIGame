using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UzayGemisi 
{
    //~Fields olu�tur~
    /// <summary>
    /// Geminin Maksimum H�z Limiti
    /// </summary>
    int maksimumHiz;

    /// <summary>
    /// Geminin Rengi
    /// </summary>
    string renk;



    //~Property olu�tur~
    /// <summary>
    /// Maksimum H�z De�erini D�ner
    /// </summary>
    public int MaksimumHiz
    {
        get{return maksimumHiz; } //Maksimum h�z de�erine ula��lacak
    }

    /// <summary>
    /// Geminin Rengini D�ner
    /// </summary>
    public string GemininRengi
    {
        get { return renk; } //Renk de�erine ula��lacak
    }



    //~Constructor olu�tur~
    /// <summary>
    /// Maksimum H�z ve Rengi Yaz�n
    /// </summary>
    /// <param name="maksimumHiz"></param>
    /// <param name="renk"></param>
    public UzayGemisi(int maksimumHiz, string renk)
    {
        this.maksimumHiz = maksimumHiz;
        this.renk = renk;
    }

    /// <summary>
    /// Rengi Olmayan Uzay Gemisi Constructor'�
    /// </summary>
    public UzayGemisi(int maksimumHiz)
    {
        this.maksimumHiz = maksimumHiz;
    }

    

    /// <summary>
    /// Uzay Gemisini H�zland�rma S�per G�c�
    /// </summary>
    public void Hizlandirici()
    {
        maksimumHiz += Random.Range(10, 30);
        Debug.Log(maksimumHiz);
    }

    /// <summary>
    /// Uzay Gemisini Yava�latma S�per G�c�
    /// </summary>
    public void Yavaslatici()
    {
        maksimumHiz -= Random.Range(10, 30);
        Debug.Log(maksimumHiz);
    }
}
