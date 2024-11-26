using System;
using UnityEngine;

public class Counter : MonoBehaviour,IService
{
    public event Action LevelComplited;
    private int _trackCount;

    public void AddCount()
    {
        _trackCount++;
    }

    public void RemoveCount()
    {
        _trackCount--;
        if (_trackCount <= 0)
        {
            LevelComplited?.Invoke();
        }
    }
}