using UnityEngine;

namespace Door_System
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Door : MonoBehaviour
    {
        private Door _other;
        private Pawn _pawn;
    
        public void ConnectsTo(Door other)
        {
            _other = other;
        }

        private void EnterConnectingDoor(Pawn pawn)
        {
            // Move pawn location to other.gameObject.transform.position
            pawn.UpdatePosition(_other.transform.position);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var pawn = other.gameObject.GetComponent<Pawn>();
            if (pawn == null) return;
        
            _pawn = pawn;
            
            // Add delegate
            EventManager.onUpKeyPressed += OnUpKeyPressed;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            var pawn = other.gameObject.GetComponent<Pawn>();
            if (pawn == null) return;
        
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var pawn = other.gameObject.GetComponent<Pawn>();
            if (pawn == null) return;
            _pawn = pawn;
            
            // Remove delegate 
            EventManager.onUpKeyPressed -= OnUpKeyPressed;
        }
    
        // Delegate 

        private void OnUpKeyPressed()
        {    
            EnterConnectingDoor(_pawn);
        }
    }
}
