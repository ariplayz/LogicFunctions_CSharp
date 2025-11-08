using System;

namespace LogicFunctions;

public class BoolModels
{

    public struct ab
    {
        public bool a;
        public bool b;
    }
    
    public struct bool16
    {
        private ushort bits;

        public bool16()
        {
            bits = 0;
        }

        // Indexer for get and set operations
        public bool this[int n]
        {
            get
            {
                if (n < 0 || n >= 16)
                    throw new ArgumentOutOfRangeException(nameof(n), "index out of range for 16-bit value");
                return ((bits >> n) & 1) != 0;
            }
            set
            {
                if (n < 0 || n >= 16)
                    throw new ArgumentOutOfRangeException(nameof(n), "index out of range for 16-bit value");
                if (value)
                    bits |= (ushort)(1u << n);
                else
                    bits &= (ushort)~(1u << n);
            }
        }

        public void Set(int n, bool v)
        {
            this[n] = v;
        }

        public bool Get(int n)
        {
            return this[n];
        }
    }
    
    public struct bool8
    {
        private ushort bits;

        public bool8()
        {
            bits = 0;
        }

        // Indexer for get and set operations
        public bool this[int n]
        {
            get
            {
                if (n < 0 || n >= 8)
                    throw new ArgumentOutOfRangeException(nameof(n), "index out of range for 8-bit value");
                return ((bits >> n) & 1) != 0;
            }
            set
            {
                if (n < 0 || n >= 8)
                    throw new ArgumentOutOfRangeException(nameof(n), "index out of range for 8-bit value");
                if (value)
                    bits |= (ushort)(1u << n);
                else
                    bits &= (ushort)~(1u << n);
            }
        }

        public void Set(int n, bool v)
        {
            this[n] = v;
        }

        public bool Get(int n)
        {
            return this[n];
        }
    }
    
    
    
}