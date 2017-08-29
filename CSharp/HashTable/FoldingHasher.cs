using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    public class FoldingHasher
    {
        public int Hash(string input)
        {
            int hashValue = 0;
            int startIndex = 0;
            int currentFourBytes;
            do
            {
                currentFourBytes = GetNextBytes(startIndex, input);
                hashValue += currentFourBytes;
                startIndex += 4;
            } while (currentFourBytes != 0);

            return hashValue;
        }

        private int GetNextBytes(int startIndex, string input)
        {
            int currentFourBytes = 0;

            currentFourBytes += GetByte(input, startIndex);
            currentFourBytes += GetByte(input, startIndex + 1) << 8;
            currentFourBytes += GetByte(input, startIndex + 2) << 16;
            currentFourBytes += GetByte(input, startIndex + 3) << 24;

            return currentFourBytes;
        }

        private int GetByte(string input, int index)
        {
            if (index < input.Length)
            {
                return input[index];
            }
            return 0;
        }
    }
}
