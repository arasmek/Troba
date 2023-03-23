using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCollecting : MonoBehaviour
{
    public Text MyscoreText;
    private int ScoreNum;
    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        MyscoreText.text = "" + ScoreNum;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
