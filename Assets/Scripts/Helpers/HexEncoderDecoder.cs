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
}
