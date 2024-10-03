using System.Collections;
using TMPro;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public TextMeshPro textCompentent;
    public string[] lines;
    public float textspeed;

    private int index;


    // Start is called before the first frame update
    void Start()
    {
        textCompentent.text = string.Empty;
        startdialog();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textCompentent.text == lines[index])
            {
                nextLine();
            }
            else
            {
                StopAllCoroutines();
                textCompentent.text = lines[index];
            }
            if (Input.GetMouseButtonDown(1))
            {
                textspeed += 0.3f;
            }


        }

    }

    void startdialog()
    {
        index = 0;
        StartCoroutine(Typeline());

    }
    void nextLine()
    {
        if (index < lines.Length)
        {
            index++;
            textCompentent.text = string.Empty;
            StartCoroutine(Typeline());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    IEnumerator Typeline()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textCompentent.text += c;
            yield return new WaitForSeconds(textspeed);
        }


    }
}