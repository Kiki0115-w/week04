using UnityEngine;
using AssignmentSystem.Services;
using Debug = AssignmentSystem.Services.AssignmentDebugConsole;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;

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

            //linkedlist.Count; ¢¹Ò´¢Í§ linkedList
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
            // 1. ÊÃéÒ§ Hashtable
            Hashtable hashtable = new Hashtable();

            // 2. ¡ÒÃà¾ÔèÁ¢éÍÁÙÅÅ§ã¹ Hashtable
            hashtable.Add(1, "Apple");
            hashtable.Add(2, "Banana");
            hashtable.Add("bad-fruit", "Rotten Tomato");

            // 3. à¢éÒ¶Ö§¢éÍÁÙÅã¹ Hashtable ´éÇÂ Key
            string fruit1 = (string)hashtable[1];
            string fruit2 = (string)hashtable[2];
            string badFruit = (string)hashtable["bad-fruit"];
            Debug.Log($"fruit1: {fruit1}");
            Debug.Log($"fruit2: {fruit2}");
            Debug.Log($"badFruit: {badFruit}");

            // 4. áÊ´§¢éÍÁÙÅã¹ Hashtable
            LCT02_PrintHashTable(hashtable);

            // 5. µÃÇ¨ÊÍº¡ÒÃÁÕÍÂÙè¢Í§ Key
            int key = 2;
            if (hashtable.ContainsKey(key))
            {
                Debug.Log($"found {key}");
            }
            else
            {
                Debug.Log($"not found {key}");
            }

            // 6. Åº¢éÍÁÙÅÍÍ¡¨Ò¡ Hashtable
            int keyToRemove = 1;
            hashtable.Remove(keyToRemove);
            LCT02_PrintHashTable(hashtable);
        }

        private void LCT02_PrintHashTable(Hashtable hashtable)
        {
            // 4. áÊ´§¢éÍÁÙÅã¹ Hashtable
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
            if (words == null) return;
            var freq = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                var w = words[i];
                if (w == null) continue;
                if (freq.ContainsKey(w)) freq[w]++;
                else freq[w] = 1;
            }

            foreach (var kv in freq)
                Debug.Log($"word: '{kv.Key}' count: {kv.Value}");
        }

        public void AS02_CountNumber(int[] numbers)
        {
            if (numbers == null) return;
            var freq = new Dictionary<int, int>();
            foreach (var n in numbers)
            {
                if (freq.ContainsKey(n)) freq[n]++;
                else freq[n] = 1;
            }

            foreach (var kv in freq)
                Debug.Log($"number: {kv.Key} count: {kv.Value}");
        }

        public void AS03_CheckValidBrackets(string input)
        {
            if (input == null) { Debug.Log("Invalid"); return; }
            var map = new Dictionary<char, char> { { '(', ')' }, { '[', ']' }, { '{', '}' } };
            var stack = new LinkedList<char>();

            foreach (var ch in input)
            {
                if (map.ContainsKey(ch))
                {
                    stack.AddLast(ch);
                }
                else if (map.ContainsValue(ch))
                {
                    if (stack.Count == 0) { Debug.Log("Invalid"); return; }
                    var lastOpen = stack.Last.Value;
                    if (map[lastOpen] == ch) stack.RemoveLast();
                    else { Debug.Log("Invalid"); return; }
                }
            }

            Debug.Log(stack.Count == 0 ? "Valid" : "Invalid");
        }

        public void AS04_PrintReverseLinkedList(LinkedList<int> list)
        {
            if (list == null || list.Count == 0) { Debug.Log("List is empty"); return; }
            var node = list.Last;
            while (node != null)
            {
                Debug.Log(node.Value);
                node = node.Previous;
            }
        }

        public void AS05_FindMiddleElement(LinkedList<string> list)
        {
            if (list == null || list.Count == 0) { Debug.Log("List is empty"); return; }
            var slow = list.First;
            var fast = list.First;
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            Debug.Log(slow.Value);
        }

        public void AS06_MergeDictionaries(Dictionary<string, int> dict1, Dictionary<string, int> dict2)
        {
            var merged = new Dictionary<string, int>();
            if (dict1 != null)
            {
                foreach (var kv in dict1) merged[kv.Key] = kv.Value;
            }

            if (dict2 != null)
            {
                foreach (var kv in dict2)
                {
                    if (merged.ContainsKey(kv.Key)) merged[kv.Key] += kv.Value;
                    else merged[kv.Key] = kv.Value;
                }
            }
            foreach (var kv in merged) Debug.Log($"key: {kv.Key}, value: {kv.Value}");
        }

        public void AS07_RemoveDuplicatesFromLinkedList(LinkedList<int> list)
        {
            if (list == null) { Debug.Log("List is null"); return; }
            if (list.Count <= 1)
            {
                foreach (var v in list) Debug.Log(v);
                return;
            }

            var seen = new Dictionary<int, bool>();
            var node = list.First;
            while (node != null)
            {
                var next = node.Next;
                if (seen.ContainsKey(node.Value))
                {
                    list.Remove(node);
                }
                else
                {
                    seen[node.Value] = true;
                }
                node = next;
            }

            foreach (var v in list) Debug.Log(v);
        }

        public void AS08_TopFrequentNumber(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) { Debug.Log("Input array is empty"); return; }

            var freq = new Dictionary<int, int>();
            foreach (var n in numbers) if (freq.ContainsKey(n)) freq[n]++; else freq[n] = 1;
            int maxCount = freq.Values.Max();

            int chosen = numbers[0];
            foreach (var n in numbers)
            {
                if (freq[n] == maxCount) { chosen = n; break; }
            }

            Debug.Log($"{chosen} count: {maxCount}");
        }

        public void AS09_PlayerInventory(Dictionary<string, int> inventory, string itemName, int quantity)
        {

            if (inventory == null) { Debug.Log("Inventory is null"); return; }
            if (string.IsNullOrEmpty(itemName)) return;
            if (inventory.ContainsKey(itemName)) inventory[itemName] += quantity;
            else inventory[itemName] = quantity;

            foreach (var kv in inventory) Debug.Log($"{kv.Key}: {kv.Value}");
        }

        #endregion 

        #region Extra

        public void EX01_GameEventQueue(LinkedList<GameEvent> eventQueue)
        {
            if (eventQueue == null || eventQueue.Count == 0)
            {
                Debug.Log("Event queue is empty");
                return;
            }

            while (eventQueue.Count > 0)
            {
                GameEvent ev = eventQueue.First.Value;
                eventQueue.RemoveFirst();

                Debug.Log($"Processing event: {ev.Name}");
                Debug.Log($"Remaining events in queue: {eventQueue.Count}");

                string type = ev.EventType?.ToLower(); 

                switch (type)
                {
                    case "enemy":
                        Debug.Log($"Enemy event processed - {ev.Name}");
                        break;
                    case "powerup":
                        Debug.Log($"Power-up event processed - {ev.Name}");
                        break;
                    case "level":
                        Debug.Log($"Level event processed - {ev.Name}");
                        break;
                    case "achievement":
                        Debug.Log($"Achievement unlocked - {ev.Name}");
                        break;
                    default:
                        Debug.Log($"Generic event processed - {ev.Name}");
                        break;
                }
            }
        }

        public void EX02_PlayerStatsTracker(Dictionary<string, int> playerStats, string statName, int value)
        {
            if (playerStats == null) { Debug.Log("PlayerStats is null"); return; }
            if (string.IsNullOrEmpty(statName)) return;
            if (playerStats.ContainsKey(statName)) playerStats[statName] += value;
            else playerStats[statName] = value;

            Debug.Log($"Updated {statName}: {playerStats[statName]}");
            Debug.Log("Current player statistics:");
            foreach (var kv in playerStats) Debug.Log($"{kv.Key}: {kv.Value}");
        }

        #endregion
    }
}