using UnityEngine;
using Object = System.Object;

namespace Services
{
    public class Logger
    {
        public void Log(Object o, string message) => Debug.Log($"[{o.GetType()}] : {message}");
    }
}