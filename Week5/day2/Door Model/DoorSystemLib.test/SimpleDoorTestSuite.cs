using Microsoft.VisualStudio.TestTools.UnitTesting;
using DoorSystemLib; 

namespace DoorSystemLib.Tests
{
    [TestClass]
    public class SimpleDoorTests
    {
        private SimpleDoor simpleDoor;

        [TestInitialize]
        public void InitializeBeforeEachTest()
        {
            // Initializes a new instance of SimpleDoor before each test to ensure a clean state
            simpleDoor = new SimpleDoor();
        }

        [TestMethod]
        public void ActivatingClosedDoorShouldOpenIt()
        {
            // Arrange: Set the door state to Closed
            simpleDoor.CurrentState = DoorState.Closed;

            // Act: Try to open the door
            simpleDoor.Activate();

            // Assert: Verify the door is now Open
            Assert.AreEqual(DoorState.Opened, simpleDoor.CurrentState, "Activating a closed door should change its state to Opened.");
        }

        [TestMethod]
        public void ActivatingOpenedDoorShouldNotChangeItsState()
        {
            // Arrange: Ensure the door is already open
            simpleDoor.CurrentState = DoorState.Opened;

            // Act: Attempt to open the door again
            simpleDoor.Activate();

            // Assert: Confirm the door remains Open
            Assert.AreEqual(DoorState.Opened, simpleDoor.CurrentState, "Activating an already opened door should not alter its state.");
        }

        [TestMethod]
        public void DeactivatingOpenedDoorShouldCloseIt()
        {
            // Arrange: Start with the door open
            simpleDoor.CurrentState = DoorState.Opened;

            // Act: Close the door
            simpleDoor.Deactivate();

            // Assert: Check that the door is now Closed
            Assert.AreEqual(DoorState.Closed, simpleDoor.CurrentState, "Deactivating an opened door should change its state to Closed.");
        }

        [TestMethod]
        public void DeactivatingClosedDoorShouldNotChangeItsState()
        {
            // Arrange: Ensure the door is closed
            simpleDoor.CurrentState = DoorState.Closed;

            // Act: Try to close the door again
            simpleDoor.Deactivate();

            // Assert: The door should remain Closed
            Assert.AreEqual(DoorState.Closed, simpleDoor.CurrentState, "Deactivating a closed door should not alter its state.");
        }
    }
}
