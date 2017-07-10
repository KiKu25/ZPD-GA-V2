using System.Collections;
using System.Collections.Generic;
using System;

public class HexEncoderDecoder{

    public int DecodHex(string hexString)
    {
        return Convert.ToInt32(hexString, 16);
    }

    public string EncodeHex(int value)
    {
        return value.ToString("X");
    }

    public float DecodHexXY(string hexString, float xy)
    {
        float value = Convert.ToInt32(hexString, 16);
        return (value * -0.01f) + xy;
    }

    public string EncodeHexXY(float value, float xy)
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

    public float DecodHexToFloat(string hexString, int decimalPlace)
    {
        float value = Convert.ToInt32(hexString, 16);
        return (value * (1 / (float)Math.Pow(10, decimalPlace)));
    }

    public string EncodeFloatToHex(float value, int decimalPlace)
    {
        value = value / (1 / (float)Math.Pow(10, decimalPlace));
        return EncodeHex((int)value);
    }
}
