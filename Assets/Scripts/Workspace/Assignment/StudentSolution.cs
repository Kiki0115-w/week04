using UnityEngine;
using AssignmentSystem.Services;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Assignment
{
    public class StudentSolution : MonoBehaviour, IAssignment
    {
        #region Lecture

        public void LCT01_SyntaxLinkedList()
        {
            LinkedList<string> linkedlist = new LinkedList<string>();
            linkedlist.AddLast("Node 1"); // ["Node 1"]
            linkedlist.AddLast("Node 2"); // ["Node 1"]<->["Node 2"]
            linkedlist.AddFirst("Node 0"); // ["Node 0"]<->["Node 1"]<->["Node 2"]

            PrintLCT01(linkedlist);

            LinkedListNode<string> firstNode = linkedlist.First;
            LinkedListNode<string> lastNode = linkedlist.Last;
            Debug.Log($"first {firstNode.Value}");
            Debug.Log($"last {lastNode.Value}");

            LinkedListNode<string> node1 = linkedlist.Find("Node 1");
            Debug.Log(node1.Previous.Value);
            Debug.Log(node1.Next.Value);

            if (firstNode.Previous == null)
            {
                Debug.Log("firstNode.Previous is null");
            }
            if (lastNode.Next == null)
            {
                Debug.Log("lastNode.Next is null");
            }

            linkedlist.AddAfter(node1, "Node 1.5");
            // ["Node 0"]<->["Node 1"]<->["Node 1.5"]<->["Node 2"]
            linkedlist.AddBefore(node1, "Node 0.5");
            // ["Node 0"]<->["Node 0.5"]<->["Node 1"]<->["Node 1.5"]<->["Node 2"]
            PrintLCT01(linkedlist);

            linkedlist.RemoveFirst();
            PrintLCT01(linkedlist);

            linkedlist.Remove("Node 2");
            PrintLCT01(linkedlist);
            // ["Node 0.5"]<->["Node 1"]<->["Node 1.5"]

            //linkedlist.Count; ขนาดของ linkedList
        }

        private void PrintLCT01(LinkedList<string> l)
        {
            Debug.Log("LinkedList ...");
            foreach (string s in l)
            {
                Debug.Log(s);
            }
        }

        public void LCT02_SyntaxHashTable()
        {
            // 1. สร้าง Hashtable
            Hashtable hashtable = new Hashtable();

            // 2. การเพิ่มข้อมูลลงใน Hashtable
            hashtable.Add(1, "Apple");
            hashtable.Add(2, "Banana");
            hashtable.Add("bad-fruit", "Rotten Tomato");

            // 3. เข้าถึงข้อมูลใน Hashtable ด้วย Key
            string fruit1 = (string)hashtable[1];
            string fruit2 = (string)hashtable[2];
            string badFruit = (string)hashtable["bad-fruit"];
            Debug.Log($"fruit1: {fruit1}");
            Debug.Log($"fruit2: {fruit2}");
            Debug.Log($"badFruit: {badFruit}");

            // 4. แสดงข้อมูลใน Hashtable
            LCT02_PrintHashTable(hashtable);

            // 5. ตรวจสอบการมีอยู่ของ Key
            int key = 2;
            if (hashtable.ContainsKey(key))
            {
                Debug.Log($"found {key}");
            }
            else
            {
                Debug.Log($"not found {key}");
            }

            // 6. ลบข้อมูลออกจาก Hashtable
            int keyToRemove = 1;
            hashtable.Remove(keyToRemove);
            LCT02_PrintHashTable(hashtable);
        }

        private void LCT02_PrintHashTable(Hashtable hashtable)
        {
            // 4. แสดงข้อมูลใน Hashtable
            Debug.Log("table ...");
            foreach (DictionaryEntry entry in hashtable)
            {
                Debug.Log($"Key: {entry.Key}, Value: {entry.Value}");
            }
        }

        public void LCT03_SyntaxDictionary()
        {
            //Dictionary<int, string> dict = new Dictionary<int, string>();
            var dict = new Dictionary<int, string>();

            dict.Add(1, "Apple");
            dict.Add(2, "Banana");
            dict[3] = "Cherry"; // dict.Add(3, "Cherry");

            PrintLCT03(dict);

            bool hasKey = dict.ContainsKey(1);
            Debug.Log($"has key 1 : {hasKey}");
            if (hasKey)
            {
                string value = dict[1];
                Debug.Log($"value of key 1 : {value}");
            }


            Debug.Log("All keys in dictionary:");
            foreach (int key in dict.Keys)
            { 
                Debug.Log(key);
            }


            int keyToRemove = 1;
            dict.Remove(keyToRemove);
            PrintLCT03(dict);

            dict.Clear();
        }

        private void PrintLCT03(Dictionary<int, string> dict)
        {
            Debug.Log($"Dictionary has {dict.Count} keys");
            foreach (KeyValuePair<int, string> pair in dict)
            {
                Debug.Log($"Key: {pair.Key}, Value: {pair.Value}");
            }
        }

        #endregion

        #region Assignment

        public void AS01_CountWords(string[] words)
        {
            throw new System.NotImplementedException();
        }

        public void AS02_CountNumber(int[] numbers)
        {
            throw new System.NotImplementedException();
        }

        public void AS03_CheckValidBrackets(string input)
        {
            throw new System.NotImplementedException();
        }

        public void AS04_PrintReverseLinkedList(LinkedList<int> list)
        {
            throw new System.NotImplementedException();
        }

        public void AS05_FindMiddleElement(LinkedList<string> list)
        {
            throw new System.NotImplementedException();
        }

        public void AS06_MergeDictionaries(Dictionary<string, int> dict1, Dictionary<string, int> dict2)
        {
            throw new System.NotImplementedException();
        }

        public void AS07_RemoveDuplicatesFromLinkedList(LinkedList<int> list)
        {
            throw new System.NotImplementedException();
        }

        public void AS08_TopFrequentNumber(int[] numbers)
        {
            throw new System.NotImplementedException();
        }

        public void AS09_PlayerInventory(Dictionary<string, int> inventory, string itemName, int quantity)
        {
            throw new System.NotImplementedException();
        }

        #endregion 

        #region Extra

        public void EX01_GameEventQueue(LinkedList<GameEvent> eventQueue)
        {
            throw new System.NotImplementedException();
        }

        public void EX02_PlayerStatsTracker(Dictionary<string, int> playerStats, string statName, int value)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}