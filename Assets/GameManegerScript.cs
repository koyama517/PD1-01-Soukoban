using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class GameManegerScript : MonoBehaviour
{

    int[] map;

    void PrintArry()
    {
        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            debugText += map[i].ToString() + ", ";
        }
        Debug.Log(debugText);
    }

    int GetPlayerIndex() 
    {
        for (int i = 0; i < map.Length; i++)
        {
            if (map[i] == 1)　{　return i;　}
        }
        return -1;
    }

    bool MoveNumber(int number, int moveFrom, int moveTo)
    {
        if(moveTo < 0 || moveTo >= map.Length) { return false; }

        if (map[moveTo] == 2)
        {
            int velocity = moveTo - moveFrom;

            bool success = MoveNumber(2, moveTo, moveTo + velocity);

            if (!success) { return false; }
        }
        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {

       map = new int[] { 0, 0, 0, 1, 0, 2, 0, 0, 0 };
       //出力
       PrintArry();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //位置取得
            int playerIndex = GetPlayerIndex();
            //移動
            MoveNumber(1, playerIndex, playerIndex + 1);
            //出力
            PrintArry();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //位置取得
            int playerIndex = GetPlayerIndex();
            //移動
            MoveNumber(1, playerIndex, playerIndex - 1);
            //出力
            PrintArry();

        }
    }
}
