using UnityEngine;
using NUnit.Framework;

public class UnitTest
{
[TestFixture]
public class BoundaryTimerForWinTests
{
    private GameObject player;
    private GameObject boundaryObject;
    private BoundaryTimerForWin boundaryTimer;

    [SetUp]
    public void Setup()
    {
        // Create a test player GameObject with the "Player" tag
        player = new GameObject();
        player.tag = "Player";
        
        // Create a test boundary GameObject with the script attached
        boundaryObject = new GameObject();
        boundaryTimer = boundaryObject.AddComponent<BoundaryTimerForWin>();
    }

    [TearDown]
    public void Teardown()
    {
        // Cleanup objects after each test
        Object.Destroy(player);
        Object.Destroy(boundaryObject);
    }

    [Test]
    public void OnTriggerStay_TimerIncreasesAndPlayerWinsAfterWaitTime()
    {
        // Simulate the "Player" staying within the trigger
        Collider playerCollider = player.AddComponent<BoxCollider>();

        // Call the OnTriggerStay method using reflection
        boundaryTimer.GetType().GetMethod("OnTriggerStay", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .Invoke(boundaryTimer, new object[] { playerCollider });

        // Simulate time passing and check the timer
        boundaryTimer.GetType().GetField("timer", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(boundaryTimer, 3.1f); // Simulate timer exceeding waitTime

        // Validate playerWon is true
        bool playerWon = (bool)boundaryTimer.GetType().GetField("playerWon", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .GetValue(boundaryTimer);
        
        Assert.IsTrue(playerWon, "Player should win after staying within the trigger for the required time.");
    }

    [Test]
    public void OnTriggerExit_ResetsTimerWhenPlayerLeaves()
    {
        // Simulate the "Player" exiting the trigger
        Collider playerCollider = player.AddComponent<BoxCollider>();
        boundaryTimer.GetType().GetField("timer", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .SetValue(boundaryTimer, 2.0f);

        // Call the OnTriggerExit method using reflection
        boundaryTimer.GetType().GetMethod("OnTriggerExit", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .Invoke(boundaryTimer, new object[] { playerCollider });

        // Check that timer is reset
        float timer = (float)boundaryTimer.GetType().GetField("timer", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            .GetValue(boundaryTimer);

        Assert.AreEqual(0.0f, timer, "Timer should reset when the player exits the trigger.");
    }
}
}