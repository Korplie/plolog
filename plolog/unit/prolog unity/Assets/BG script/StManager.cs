using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StManager : MonoBehaviour
{
    public Transform Titlet;

    public SpriteRenderer PAKt;
    public SpriteRenderer Titles;
    public Image str;
    public Image opr;
    public Image exr;

    enum State { start, menu, option }
    int temp;
    int lt = 0;
    float i = -2f;
    int ll = 0;
    State stat;

    // Start is called before the first frame update
    void Start()
    {
        stat = State.start;
        temp = (int)Titlet.position.y;



        Titlet.position = new Vector2(Titlet.position.x, temp - 2);
        Titles.color = new Color32(255, 255, 255, 0);
        PAKt.color = new Color32(255, 255, 255, 0);
        str.color = new Color32(255, 255, 255, 0);
        opr.color = new Color32(255, 255, 255, 0);
        exr.color = new Color32(255, 255, 255, 0);
        StartCoroutine("start");


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && stat == State.start)
        {
            StopCoroutine("start");
            StopCoroutine("s2");
            stat = State.menu;
            PAKt.color = new Color32(255, 255, 255, 0);
            Titles.color = new Color32(255, 255, 255, 255);

            lt = 0; StartCoroutine("anyDown");

        }

        //if (Input.anyKey)
        //{

        //}

    }
    IEnumerator start()
    {
        if (stat != State.start)
        {
           
            StopCoroutine("start");
        }
        lt += 5;
        i += 0.05f;
        if (lt < 256) { Titles.color = new Color32(255, 255, 255, (byte)lt); }
        if (i < temp + 1) { Titlet.position = new Vector2(Titlet.position.x, i); }
        yield return new WaitForSeconds(0.01f);
        if (lt > 255 && i > temp)
        {
            lt = 0;
            StartCoroutine("s2");
            yield return new WaitForSeconds(1f);
            StopCoroutine("start");
        }
        else StartCoroutine("start");

    }
    IEnumerator s2()
    {
        if (stat != State.start)
        {
         
            StopCoroutine("s2");
        }
        if (lt == 250)
            for (int i = 1; i <= 50; i++)
            {
                lt -= 5;
                PAKt.color = new Color32(255, 255, 255, (byte)lt); yield return new WaitForSeconds(0.02f);
            }
        else if (lt == 0)
            for (int i = 1; i <= 50; i++)
            {
                lt += 5;
                PAKt.color = new Color32(255, 255, 255, (byte)lt); yield return new WaitForSeconds(0.02f);
            }

        StartCoroutine("s2");

    }
    IEnumerator anyDown()
    {
       
        i += 0.05f;
        
       
        if (i < 2.2f) { Titlet.position = new Vector2(Titlet.position.x, i); }
        else
        {
            lt += 10;
            if (lt < 256)
            {
                str.color = new Color32(255, 255, 255, (byte)lt);
                opr.color = new Color32(255, 255, 255, (byte)lt);
                exr.color = new Color32(255, 255, 255, (byte)lt);
            }
        }
        yield return new WaitForSeconds(0.01f);
        if (lt > 255 && i >= 2f)
        {
            StopCoroutine("anyDown");

        }
        else StartCoroutine("anyDown");


    }

}
