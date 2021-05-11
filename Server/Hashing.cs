using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Server
{
    class Hashing
    {
        static Hashtable InfoHash;

        public static int arraySize = 53;
        public string Value { get; set; }

        public Hashing()
        {
            InfoHash = new Hashtable();

            //Setting up hash table
            for (int i = 0; i < arraySize; i++)
            {
                InfoHash.Add(i, null);
            }
        }

        public int HashKey(string pi)
        {
            int Key = 0;
            int divider = 3;
            int charValue = 0;

            char[] piChars = pi.ToCharArray();

            for (int i = 0; i < piChars.Length; i++)
            {
                charValue = piChars[i];
                Key = Key * divider + piChars[i]; //gives more randon numbers that %
            }

            Key = Key % arraySize; //make sures the key is valid to the size of array

            return Key;
        }

        public int AddingHash(int a_k)
        {
            bool added = false;
            int indices = 0;

            do
            {
                if (InfoHash.ContainsKey(a_k + indices * indices) && InfoHash[a_k + indices * indices] == null)
                {
                    InfoHash[a_k + indices * indices] = Value;
                    Console.WriteLine($"{a_k + indices * indices} YES");

                    added = true;
                }
                else
                {
                    if (indices <= arraySize)
                    {
                        Console.WriteLine($"{a_k + indices * indices} NO");
                        indices++;
                    }
                    else
                    {
                        added = true;
                    }
                }

            } while (!added);

            Console.Write($"Added Key: {a_k + indices * indices} / Value: {InfoHash[a_k + indices * indices]} \n");

            return a_k + indices * indices;
        }

        public int FindingHashing(int f_k, string pi)
        {
            bool found = false;
            int indices = 0;

            int i = 0;

            do
            {
                Console.WriteLine(i);
                bool value = (Convert.ToString(InfoHash[f_k + indices * indices]) == pi);
                if (InfoHash.ContainsKey(f_k + indices * indices) && value)
                {
                    Console.WriteLine($"Found Key: {f_k + indices * indices} / Value: {InfoHash[f_k + indices * indices]} \n");
                    found = true;
                }
                else if (indices <= arraySize)
                {
                    indices++;
                }
                else
                {
                    found = true;
                }
                i++;

            } while (!found);

            return f_k + indices * indices;
        }

        public static void PrintHashTable()
        {
            foreach (DictionaryEntry entry in InfoHash)
            {
                Console.WriteLine($"Key: {entry.Key} / Value: {entry.Value}");
                Console.WriteLine(ServerModel.store.FindingStorage(Int32.Parse($"{entry.Key}")));
            }
        }

        public static string SendHashTable()
        {
            //HTD = Hash Table Data 
            string hashtable = "HTD"; 

            foreach (DictionaryEntry entry in InfoHash)
            {
                hashtable = hashtable + $"¶¶Key: {entry.Key} Value: {entry.Value}¶" + ServerModel.store.FindingStorage(Int32.Parse($"{entry.Key}"));
            }

            return hashtable;
        }
    }
}
