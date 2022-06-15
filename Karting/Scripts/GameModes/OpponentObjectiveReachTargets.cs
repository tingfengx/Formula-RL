﻿using System.Collections;
using UnityEngine;

public class OpponentObjectiveReachTargets : Objective
{

    [Tooltip("Choose whether you need to collect all pickups or only a minimum amount")]
    public bool mustCollectAllPickups = true;
    
    [Tooltip("If MustCollectAllPickups is false, this is the amount of pickups required")]
    public int pickupsToCompleteObjective = 5;
    
    [Header("Notification")]
    [Tooltip("Start sending notification about remaining pickups when this amount of pickups is left")]
    public int notificationPickupsRemainingThreshold = 1;
    
    

    IEnumerator Start()
    {
   
        // TimeManager.OnSetTime(totalTimeInSecs, isTimed, gameMode);
        
        yield return new WaitForEndOfFrame();

        title = "Opponent's progress";
        
        if (mustCollectAllPickups)
            pickupsToCompleteObjective = NumberOfPickupsTotal;
        
        Register();
    }

    protected override void ReachCheckpoint(int remaining)
    {
        if (isCompleted)
            return;
        
        if (mustCollectAllPickups) 
            pickupsToCompleteObjective = NumberOfPickupsTotal;

        m_PickupTotal = NumberOfPickupsTotal - remaining;
        int targetRemaining = mustCollectAllPickups ? remaining : pickupsToCompleteObjective - m_PickupTotal;

        if (targetRemaining == 0)
        {
            CompleteObjective(string.Empty, GetUpdatedCounterAmount(),
                "Your Opponent Completed Objective complete: " + title);
        }
        else if (targetRemaining > 1)
        {
            // create a notification text if needed, if it stays empty, the notification will not be created
            string notificationText = notificationPickupsRemainingThreshold >= targetRemaining
                ? targetRemaining + " " + targetName + "s to collect left"
                : string.Empty;

            UpdateObjective(string.Empty, GetUpdatedCounterAmount(), notificationText);
        }
    
    }

    public override string GetUpdatedCounterAmount()
    {
        return m_PickupTotal + " / " + pickupsToCompleteObjective;
    }
    
}
