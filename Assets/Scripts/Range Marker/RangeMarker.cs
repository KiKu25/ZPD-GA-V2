using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeMarker : MonoBehaviour {

    private List<string> numbersToGenerate;

    private Dictionary<string, Sprite> dictSprite;

    private float offset = 0.3f;

    // Use this for initialization
    void Start () {
        dictSprite = new Dictionary<string, Sprite>();
        numbersToGenerate = new List<string>();
        GetSprites();
        SpawnNumbers();
	}
	
    /// <summary>
    /// Spawns Numbers who show range
    /// </summary>
	private void SpawnNumbers()
    {

        float currentOffset = 0;

        ToNumber();
        for (int i = 0; i < numbersToGenerate.Count; i++)
        {
            GameObject go = new GameObject();
            go.name = numbersToGenerate[i];
            go.transform.position = new Vector3(transform.position.x + currentOffset - StartingXOffset(), transform.position.y, transform.position.z);
            go.transform.SetParent(gameObject.transform, true);
            SpriteRenderer sp = go.AddComponent<SpriteRenderer>();
            sp.sprite = GetSprite(numbersToGenerate[i]);
            currentOffset += offset;
        }
    }

    /// <summary>
    /// Generates a string from a position
    /// </summary>
    /// <returns></returns>
    private string GenString()
    {
        return Mathf.RoundToInt(gameObject.transform.position.x).ToString();
    }

    /// <summary>
    /// Converts striong to number
    /// </summary>
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
                    numbersToGenerate.Add("Minus");
                    break;
                case '0':
                    numbersToGenerate.Add("0");
                    break;
                case '1':
                    numbersToGenerate.Add("1");
                    break;
                case '2':
                    numbersToGenerate.Add("2");
                    break;
                case '3':
                    numbersToGenerate.Add("3");
                    break;
                case '4':
                    numbersToGenerate.Add("4");
                    break;
                case '5':
                    numbersToGenerate.Add("5");
                    break;
                case '6':
                    numbersToGenerate.Add("6");
                    break;
                case '7':
                    numbersToGenerate.Add("7");
                    break;
                case '8':
                    numbersToGenerate.Add("8");
                    break;
                case '9':
                    numbersToGenerate.Add("9");
                    break;
                default:
                    Debug.LogError("Can not transform char: " + chare);
                    break;
            }
        }
    }

    /// <summary>
    /// Gets all sprites in a file
    /// </summary>
    private void GetSprites()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Images/Numbers");
        foreach (Sprite sprite in sprites)
        {
            dictSprite.Add(sprite.name, sprite);
        }
    }

    /// <summary>
    /// Adds sprites to a dictionary
    /// </summary>
    /// <param name="sprite"></param>
    /// <returns></returns>
    private Sprite GetSprite(string sprite)
    {
        sprite = "Number_" + sprite;
        return dictSprite[sprite];
    }

    /// <summary>
    /// To center the number
    /// </summary>
    /// <returns></returns>
    private float StartingXOffset()
    {
        if (numbersToGenerate[0] == "0")
        {
            return 0;
        }
        else
        {
            return (numbersToGenerate.Count * offset) / 5;
        }
    }
}
