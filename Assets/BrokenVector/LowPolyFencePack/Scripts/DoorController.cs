using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Enum to define the door states (Open or Closed)
    public enum DoorState
    {
        Open,
        Closed
    }

    // Public properties for setting door states
    public DoorState CurrentState { get; private set; }
    public DoorState InitialState = DoorState.Closed;

    // Reference to the Animator component for controlling door animations
    private Animator animator;

    void Awake()
    {
        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();

        // Check if the Animator is attached to the GameObject
        if (animator == null)
        {
            Debug.LogError("Animator component is missing from the GameObject.");
        }

        // Initialize the door state
        CurrentState = InitialState;

        // Set initial animation state
        UpdateDoorAnimation();
    }

    // Open the door
    public void OpenDoor()
    {
        if (CurrentState == DoorState.Closed)
        {
            CurrentState = DoorState.Open;
            UpdateDoorAnimation();
        }
    }

    // Close the door
    public void CloseDoor()
    {
        if (CurrentState == DoorState.Open)
        {
            CurrentState = DoorState.Closed;
            UpdateDoorAnimation();
        }
    }

    // Toggle door state (open if closed, close if open)
    public void ToggleDoor()
    {
        if (CurrentState == DoorState.Open)
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
    }

    // Update the animation based on the door's current state
    private void UpdateDoorAnimation()
    {
        // Set the animator parameter to control the animation (Open or Closed)
        animator.SetBool("IsOpen", CurrentState == DoorState.Open);
    }
}
