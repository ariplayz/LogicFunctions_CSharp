using System;

namespace LogicFunctions;

class Program
{
    enum Operation
    {
        INVALID = 0,
        NOT = 1,
        AND = 2,
        OR = 3,
        XOR = 4,
        MUX = 5,
        DMUX = 6,
        NOT16 = 7,
        AND16 = 8,
        OR16 = 9,
        MUX16 = 10,
        OR8WAY = 11
    }

    static string ToUpper(string s)
    {
        return s.ToUpper();
    }

    static Operation StringToOp(string s)
    {
        return s switch
        {
            "NOT" => Operation.NOT,
            "AND" => Operation.AND,
            "OR" => Operation.OR,
            "XOR" => Operation.XOR,
            "MUX" => Operation.MUX,
            "DMUX" => Operation.DMUX,
            "NOT16" => Operation.NOT16,
            "AND16" => Operation.AND16,
            "OR16" => Operation.OR16,
            "MUX16" => Operation.MUX16,
            "OR8WAY" => Operation.OR8WAY,
            _ => Operation.INVALID
        };
    }

    static string Startup()
    {
        string operation = "";
        bool started = false;

        while (!started)
        {
            Console.WriteLine("       LogicComputer v1.0       ");
            Console.WriteLine("    Developed by Ari Cummings   ");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("           Operations:          ");
            Console.WriteLine("--------------NOT---------------");
            Console.WriteLine("--------------AND---------------");
            Console.WriteLine("--------------OR----------------");
            Console.WriteLine("--------------XOR---------------");
            Console.WriteLine("--------------MUX---------------");
            Console.WriteLine("--------------DMUX--------------");
            Console.WriteLine("--------------NOT16-------------");
            Console.WriteLine("--------------AND16-------------");
            Console.WriteLine("--------------OR16--------------");
            Console.WriteLine("--------------MUX16-------------");
            Console.WriteLine("--------------OR8WAY------------");
            Console.WriteLine();
            Console.Write("Enter Operation: ");
            operation = Console.ReadLine() ?? "";
            Console.WriteLine();

            operation = ToUpper(operation);
            if (StringToOp(operation) != Operation.INVALID)
            {
                Console.WriteLine($"Operation {operation} is Valid.");
                started = true;
            }
            else
            {
                Console.WriteLine($"Operation {operation} is Invalid.");
            }
        }

        return operation;
    }

    static bool TryReadBool(out bool value)
    {
        string? input = Console.ReadLine();
        if (input != null && (input.Equals("true", StringComparison.OrdinalIgnoreCase) || input.Equals("1", StringComparison.OrdinalIgnoreCase)))
        {
            value = true;
            return true;
        }
        else if (input != null && (input.Equals("false", StringComparison.OrdinalIgnoreCase) || input.Equals("0", StringComparison.OrdinalIgnoreCase)))
        {
            value = false;
            return true;
        }
        value = false;
        return false;
    }

    static void Main(string[] args)
    {
        bool continu = true;

        while (continu)
        {
            string opStr = Startup();
            Operation op = StringToOp(opStr);

            switch (op)
            {
                case Operation.NOT:
                {
                    Console.Write("\nBoolean input: ");
                    TryReadBool(out bool inNot);
                    bool outNot = LogicFunctions.NOT(inNot);
                    Console.WriteLine($"Output: {outNot}");
                    break;
                }
                case Operation.AND:
                {
                    Console.Write("\nBoolean input A: ");
                    TryReadBool(out bool a);
                    Console.Write("Boolean input B: ");
                    TryReadBool(out bool b);
                    bool outAnd = LogicFunctions.AND(a, b);
                    Console.WriteLine($"Output: {outAnd}");
                    break;
                }
                case Operation.OR:
                {
                    Console.Write("\nBoolean input A: ");
                    TryReadBool(out bool a);
                    Console.Write("Boolean input B: ");
                    TryReadBool(out bool b);
                    bool outOr = LogicFunctions.OR(a, b);
                    Console.WriteLine($"Output: {outOr}");
                    break;
                }
                case Operation.XOR:
                {
                    Console.Write("\nBoolean input A: ");
                    TryReadBool(out bool a);
                    Console.Write("Boolean input B: ");
                    TryReadBool(out bool b);
                    bool outXor = LogicFunctions.XOR(a, b);
                    Console.WriteLine($"Output: {outXor}");
                    break;
                }
                case Operation.MUX:
                {
                    Console.Write("\nBoolean input A: ");
                    TryReadBool(out bool a);
                    Console.Write("Boolean input B: ");
                    TryReadBool(out bool b);
                    Console.Write("Selector: ");
                    TryReadBool(out bool sel);
                    bool outMux = LogicFunctions.MUX(sel, a, b);
                    Console.WriteLine($"Output: {outMux}");
                    break;
                }
                case Operation.DMUX:
                {
                    Console.Write("\nBoolean input: ");
                    TryReadBool(out bool inDmux);
                    Console.Write("Selector: ");
                    TryReadBool(out bool selDmux);
                    BoolModels.ab outDmux = LogicFunctions.DMUX(inDmux, selDmux);
                    Console.WriteLine($"Output A: {outDmux.a}");
                    Console.WriteLine($"Output B: {outDmux.b}");
                    break;
                }
                case Operation.NOT16:
                {
                    Console.Write("\n16-bit bool (as integer): ");
                    if (ushort.TryParse(Console.ReadLine(), out ushort inInt))
                    {
                        BoolModels.bool16 inNot16 = new BoolModels.bool16();
                        for (int i = 0; i < 16; i++)
                        {
                            inNot16[i] = ((inInt >> i) & 1) != 0;
                        }
                        BoolModels.bool16 outNot16 = LogicFunctions.NOT16(inNot16);
                        ushort result = 0;
                        for (int i = 0; i < 16; i++)
                        {
                            if (outNot16[i]) result |= (ushort)(1 << i);
                        }
                        Console.WriteLine($"Output: {result}");
                    }
                    break;
                }
                case Operation.AND16:
                {
                    Console.Write("\n16-bit bool A (as integer): ");
                    if (ushort.TryParse(Console.ReadLine(), out ushort aInt))
                    {
                        Console.Write("16-bit bool B (as integer): ");
                        if (ushort.TryParse(Console.ReadLine(), out ushort bInt))
                        {
                            BoolModels.bool16 aAnd16 = new BoolModels.bool16();
                            BoolModels.bool16 bAnd16 = new BoolModels.bool16();
                            for (int i = 0; i < 16; i++)
                            {
                                aAnd16[i] = ((aInt >> i) & 1) != 0;
                                bAnd16[i] = ((bInt >> i) & 1) != 0;
                            }
                            BoolModels.bool16 outAnd16 = LogicFunctions.AND16(aAnd16, bAnd16);
                            ushort result = 0;
                            for (int i = 0; i < 16; i++)
                            {
                                if (outAnd16[i]) result |= (ushort)(1 << i);
                            }
                            Console.WriteLine($"Output: {result}");
                        }
                    }
                    break;
                }
                case Operation.OR16:
                {
                    Console.Write("\n16-bit bool A (as integer): ");
                    if (ushort.TryParse(Console.ReadLine(), out ushort aInt))
                    {
                        Console.Write("16-bit bool B (as integer): ");
                        if (ushort.TryParse(Console.ReadLine(), out ushort bInt))
                        {
                            BoolModels.bool16 aOr16 = new BoolModels.bool16();
                            BoolModels.bool16 bOr16 = new BoolModels.bool16();
                            for (int i = 0; i < 16; i++)
                            {
                                aOr16[i] = ((aInt >> i) & 1) != 0;
                                bOr16[i] = ((bInt >> i) & 1) != 0;
                            }
                            BoolModels.bool16 outOr16 = LogicFunctions.OR16(aOr16, bOr16);
                            ushort result = 0;
                            for (int i = 0; i < 16; i++)
                            {
                                if (outOr16[i]) result |= (ushort)(1 << i);
                            }
                            Console.WriteLine($"Output: {result}");
                        }
                    }
                    break;
                }
                case Operation.MUX16:
                {
                    Console.Write("\n16-bit bool A (as integer): ");
                    if (ushort.TryParse(Console.ReadLine(), out ushort aInt))
                    {
                        Console.Write("16-bit bool B (as integer): ");
                        if (ushort.TryParse(Console.ReadLine(), out ushort bInt))
                        {
                            Console.Write("Selector: ");
                            TryReadBool(out bool selMux16);
                            BoolModels.bool16 aMux16 = new BoolModels.bool16();
                            BoolModels.bool16 bMux16 = new BoolModels.bool16();
                            for (int i = 0; i < 16; i++)
                            {
                                aMux16[i] = ((aInt >> i) & 1) != 0;
                                bMux16[i] = ((bInt >> i) & 1) != 0;
                            }
                            BoolModels.bool16 outMux16 = LogicFunctions.MUX16(aMux16, bMux16, selMux16);
                            ushort result = 0;
                            for (int i = 0; i < 16; i++)
                            {
                                if (outMux16[i]) result |= (ushort)(1 << i);
                            }
                            Console.WriteLine($"Output: {result}");
                        }
                    }
                    break;
                }
                case Operation.OR8WAY:
                {
                    Console.Write("\n8-bit bool (as integer): ");
                    if (byte.TryParse(Console.ReadLine(), out byte inByteInt))
                    {
                        BoolModels.bool8 inOr8 = new BoolModels.bool8();
                        for (int i = 0; i < 8; i++)
                        {
                            inOr8[i] = ((inByteInt >> i) & 1) != 0;
                        }
                        bool outOr8way = LogicFunctions.OR8WAY(inOr8);
                        Console.WriteLine($"Output: {outOr8way}");
                    }
                    break;
                }
                default:
                {
                    Console.WriteLine("Invalid operation selected.");
                    break;
                }
            }

            Console.Write("\nWould you like to perform another operation? (Y for yes, n for no): ");
            char continuChar = Console.ReadLine()?[0] ?? 'n';
            continu = (continuChar == 'y' || continuChar == 'Y');
        }
    }
}