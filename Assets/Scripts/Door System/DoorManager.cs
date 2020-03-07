using UnityEngine;

namespace Door_System
{
    public class DoorManager : MonoBehaviour
    {
        public delegate void OnBeginUpdatePosition(Vector2 position);
    
        public static event OnBeginUpdatePosition onBeginUpdatePawnPosition;

        public Door doorA;
        public Door doorB;

        private void Awake()
        {
            doorA.ConnectsTo(doorB);
            doorB.ConnectsTo(doorA);
        }

        public static void RaiseOnBeginUpdatePawnPosition(Vector2 position)
        {
            onBeginUpdatePawnPosition?.Invoke(position);
        }
    }
}
