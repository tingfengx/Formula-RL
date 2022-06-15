using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    List<Objective> m_Objectives = new List<Objective>();

    public List<Objective> Objectives => m_Objectives;

    public static Action<Objective> RegisterObjective;

    public void OnEnable()
    {
        RegisterObjective += OnRegisterObjective;
    }
    
    public bool AreAllObjectivesCompleted()
    {
        if (m_Objectives.Count == 0)
            return false;

        for (int i = 0; i < m_Objectives.Count; i++)
        {
            // pass every objectives to check if they have been completed
            if (m_Objectives[i].isBlocking())
            {
                // break the loop as soon as we find one uncompleted objective
                return false;
            }
        }

        // found no uncompleted objective
        return true;
    }

    public bool IsPlayerObjectiveCompleted()
    {
        if (m_Objectives.Count == 0)
            return false;
        return (!m_Objectives[0].isBlocking());
    }

    public bool AreOpponentsObjectiveCompleted()
    {
        if (m_Objectives.Count < 1)
            return false;

        for (int i = 1; i < m_Objectives.Count; i++)
        {   
            // check if thie opponent wins
            if (!m_Objectives[i].isBlocking())
            {
                // break the loop as soon as we find a winning opponent
                return true;
            }
        }

        return false;
    }

    public void OnRegisterObjective(Objective objective)
    {
        m_Objectives.Add(objective);
    }
}
