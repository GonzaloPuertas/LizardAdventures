using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollector : MonoBehaviour
{
    public int collecteKeys;
    public void CollectKey(int amount)
    {
        if (amount > 0)
        {
            collecteKeys += amount;
        }
    }

    public bool ConsumeKey(int amount)
    {
        if (amount <= collecteKeys)
        {
            collecteKeys -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }
}
