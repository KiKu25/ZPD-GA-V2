using System.Collections;
using System.Collections.Generic;
using System;

public class HexEncoderDecoder{

    /// <summary>
    /// Decodes from hex to int
    /// </summary>
    /// <param name="hexString"></param>
    /// <returns></returns>
    public int DecodHex(string hexString)
    {
        return Convert.ToInt32(hexString, 16);
    }

    /// <summary>
    /// Encodes from int to hex
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public string EncodeHex(int value)
    {
        return value.ToString("X");
    }

    /// <summary>
    /// Decodes from hex to flot with an offset
    /// </summary>
    /// <param name="hexString"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    public float DecodHexWithOffset(string hexString, float xy)
    {
        float value = Convert.ToInt32(hexString, 16);
        return (value * -0.01f) + xy;
    }

    /// <summary>
    /// Encodes from float to hex with an offset
    /// </summary>
    /// <param name="value"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    public string EncodeHexWithOffset(float value, float xy)
    {
        float maxXY = 2.55f;
        value = value - xy;

        if (value > maxXY)
        {
            value = maxXY;
        }
        if (value > 0)
        {
            value = 0;
        }

        value = (float)Math.Round(value, 2);
        value = value / -0.01f;
        return EncodeHex((int)value);
    }

    /// <summary>
    /// Decodes from hex to float, who has a floating point
    /// </summary>
    /// <param name="hexString"></param>
    /// <param name="decimalPlace"></param>
    /// <returns></returns>
    public float DecodHexToFloat(string hexString, int decimalPlace)
    {
        float value = Convert.ToInt32(hexString, 16);
        return (value * (1 / (float)Math.Pow(10, decimalPlace)));
    }

    /// <summary>
    /// Encodes from float, who has a floating, point to hex
    /// </summary>
    /// <param name="value"></param>
    /// <param name="decimalPlace"></param>
    /// <returns></returns>
    public string EncodeFloatToHex(float value, int decimalPlace)
    {
        value = value / (1 / (float)Math.Pow(10, decimalPlace));
        return EncodeHex((int)value);
    }
}
