using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinsCollecting : MonoBehaviour
{
    public TextMeshProUGUI MyscoreText;
    private int ScoreNum;
    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        MyscoreText.text = "" + ScoreNum;
    }
}
