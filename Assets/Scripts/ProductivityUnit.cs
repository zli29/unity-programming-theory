using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{

    private ResourcePile m_CurrentPile = null;
    public float productivityMultiplier = 2;
    // // Start is called before the first frame update
    // void Start()
    // {

    // }


    // // Update is called once per frame
    // void Update()
    // {

    // }

    protected override void BuildingInRange()
    {
        // Debug.Log(m_CurrentPile);
        if (m_CurrentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if (pile != null)
            {
                m_CurrentPile = pile;
                m_CurrentPile.ProductionSpeed *= productivityMultiplier;
            }
        }
    }

    public override void GoTo(Building target)
    {
        ResetProductivity();
        base.GoTo(target);
    }

    public override void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position);
    }

    private void ResetProductivity()
    {
        if (m_CurrentPile != null)
        {
            m_CurrentPile.ProductionSpeed /= productivityMultiplier;
            m_CurrentPile = null;
        }
    }
}
