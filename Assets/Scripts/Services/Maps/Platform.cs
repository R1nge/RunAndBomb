using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;

namespace Services.Maps
{
    public class Platform : MonoBehaviour
    {
        public void Drop() => Destroy(gameObject);
    }
}