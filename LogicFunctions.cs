using System;

namespace LogicFunctions;

public static class LogicFunctions
{

    public static bool NOT(bool input)
    {
        return !input;
    }

    public static bool AND(bool a, bool b)
    {
        return a && b;
    }
    
    public static bool OR(bool a, bool b)
    {
        return a || b;
    }
    
    public static bool XOR(bool a, bool b)
    {
        return a ^ b;
    }
    
    public static bool MUX(bool sel, bool a, bool b)
    {
        return sel ? a : b;
    }

    public static BoolModels.ab DMUX(bool input, bool sel)
    {
        bool a = input && !sel;
        bool b = input && sel;
        BoolModels.ab output = new BoolModels.ab();
        output.a = a;
        output.b = b;
        return output;
    }
    
    public static bool NAND(bool a, bool b)
    {
        return !(a && b);
    }
    
    public static bool NOR(bool a, bool b)
    {
        return !(a || b);
    }

    public static BoolModels.bool16 NOT16(BoolModels.bool16 input)
    {
        BoolModels.bool16 output = new BoolModels.bool16();

        for (int i = 0; i < 16; i++)
        {
            output[i] = !input[i];
        }
        
        return output;
    }

    public static BoolModels.bool16 AND16(BoolModels.bool16 a, BoolModels.bool16 b)
    {
        BoolModels.bool16 output = new BoolModels.bool16();

        for (int i = 0; i < 16; i++)
        {
            output[i] = a[i] && b[i];
        }
        
        return output;
    }
    
    public static BoolModels.bool16 OR16(BoolModels.bool16 a, BoolModels.bool16 b)
    {
        BoolModels.bool16 output = new BoolModels.bool16();

        for (int i = 0; i < 16; i++)
        {
            output[i] = a[i] || b[i];
        }
        
        return output;
    }
    
    public static BoolModels.bool16 MUX16(BoolModels.bool16 a, BoolModels.bool16 b, bool sel)
    {
        BoolModels.bool16 output = new BoolModels.bool16();

        for (int i = 0; i < 16; i++)
        {
            output[i] = sel ? a[i] : b[i];
        }
        
        return output;
    }
    
    public static bool OR8WAY(BoolModels.bool8 input) {
        bool output = input[0] || input[1] || input[2] || input[3] || input[4] || input[5] || input[6] || input[7];
        return output;
    }
    
}