using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Piece : MonoBehaviour
{
    public bool bomb;
    public int x,y;

    private void OnMouseDown()
    {
        if(bomb)
            GetComponent<SpriteRenderer>().material.color = Color.red;
        else
            transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text=
                Generator.gen.GetBombs(x,y).ToString();
    }

}
