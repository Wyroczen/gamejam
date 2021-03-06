﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one inventory!!!!!!");
        }
        else
            instance = this;
    }
    #endregion
    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;
    public int space = 10;
    public List<Item> items = new List<Item>();

    public bool Add (Item item)
    {
        if(items.Count >= space)
        {
            return false;
        }
        items.Add(item);
        if(OnItemChangedCallback != null)
        OnItemChangedCallback.Invoke();
        return true;
    }
    
    public List<Item> GetList()
    {
        return items;
    }


    public void Remove (Item item)
    {
        items.Remove(item);
        if (OnItemChangedCallback != null)
            OnItemChangedCallback.Invoke();
    }
}
