using System;
using System.Collections.Generic;
using MyBox;
using UnityEngine;

public class Thinker : MonoBehaviour
{
    [ReadOnly] public string developerDescription = "punchInterval";

    [Serializable]
    private class Field
    {
        [SerializeField] private string key;
        [SerializeField] private string obj;
        public string Key => key;
        public object Obj => obj;
    }

    [SerializeField] private Brain brain;
    [SerializeField] private Field[] overrideSettings;

    private Dictionary<string, object> memory;

    private void Awake()
    {
        memory = new Dictionary<string, object>();
        foreach (var field in overrideSettings)
        {
            memory[field.Key] = field.Obj;
        }

        if (brain != null)
        {
            brain.Initialize(this);
        }
    }

    private void Update()
    {
        if (brain != null)
        {
            brain.Think(this);
        }
    }

    public T Remember<T>(string key)
    {
        object result;
        if (!memory.TryGetValue(key, out result))
            return default(T);
        return (T) result;
    }

    public void Remember<T>(string key, T value)
    {
        memory[key] = value;
    }

    public bool HasMemory(string key)
    {
        return memory.ContainsKey(key);
    }
}