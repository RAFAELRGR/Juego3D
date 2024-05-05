using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISerializer
{
    string Serialize<T>(T obj);
    T Deserialize<T>(string json);
}