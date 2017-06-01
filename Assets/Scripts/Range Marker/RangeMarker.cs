using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeMarker : MonoBehaviour {


    //TODO make this use a list
    string[] numbersToGenerate = new string[];

	// Use this for initialization
	void Start () {
        SpawnNumbers();
	}
	
	private void SpawnNumbers()
    {
        ToNumber();
        for (int i = 0; i < numbersToGenerate.Length; i++)
        {
            GameObject go = new GameObject();
            go.name = numbersToGenerate[i];
            go.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            go.transform.SetParent(gameObject.transform, true);
        }
    }

    private string GenString()
    {
        return Mathf.RoundToInt(gameObject.transform.position.x).ToString();
    }

    private void ToNumber()
    {
        string number = GenString();

        char chare;

        for (int i = 0; i < number.Length; i++)
        {
            chare = number[i];
            switch (chare)
            {
                case '-':
                    numbersToGenerate[i] = "Minus";
                    break;
                case '0':
                    numbersToGenerate[i] = "0";
                    break;
                case '1':
                    numbersToGenerate[i] = "1";
                    break;
                case '2':
                    numbersToGenerate[i] = "2";
                    break;
                case '3':
                    numbersToGenerate[i] = "3";
                    break;
                case '4':
                    numbersToGenerate[i] = "4";
                    break;
                case '5':
                    numbersToGenerate[i] = "5";
                    break;
                case '6':
                    numbersToGenerate[i] = "6";
                    break;
                case '7':
                    numbersToGenerate[i] = "7";
                    break;
                case '8':
                    numbersToGenerate[i] = "8";
                    break;
                case '9':
                    numbersToGenerate[i] = "9";
                    break;
                default:
                    Debug.LogError("Can not transform char: " + chare);
                    break;
            }
        }
    }
}
