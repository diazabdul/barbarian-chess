using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class networkHero : MonoBehaviourPun
{
    private GameObject path;
    public static networkHero  Instance;
    string test;

    private void Awake()
    {
        Instance = this;
    }
    public enum state
    {
        spawn,
        moving,
        nonactive,
        win
    }
    state currState;

    public void setState(state _state)
    {
        currState = _state;
    }

    // Start is called before the first frame update
    void Start()
    {
        setState(state.spawn);
        if (photonView.IsMine)
        {
            if (photonView.ViewID.ToString() == "1001")
            {
                test = "Aku Owner Cuk";
            }
            else
            {
                test = "You Are Not Owner";
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {        
        
        if (photonView.IsMine)
        {
            this.transform.position = UnitManager.Instance.path.transform.position;

            if (currState == state.nonactive)
            {
                UnitManager.Instance.turnOff();
                setState(state.spawn);
            }
            if(currState == state.win)
            {
                return;
            }
            //Debug.Log(photonView.ViewID.ToString());
            Debug.Log(currState.ToString());
            Debug.Log(currState);
            
        }  
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Uraa");
        }
    }
    private void OnMouseEnter()
    {
        
    }    
    private void OnMouseDown()
    {
        if (photonView.IsMine)
        {
            if (currState == state.spawn)
            {
                Debug.Log("Hello Bitch");                
                UnitManager.Instance.highlightTurn(this.transform,true);
                setState(state.moving);
                return;
            }
            if (currState == state.moving)
            {
                Tile.Instance.OnMouseUp();
                setState(state.nonactive);
                return;
            }            
        }
        
         
            if (!photonView.IsMine)
            {
                UnitManager.Instance.path.transform.position = this.transform.position;
                photonization.Instance.lose = true;
                photonization.Instance.showWin();
                Debug.Log("Nt");
                setState(state.win);
            }
                
                    
                
            
        
    }
    private void OnMouseUp()
    {
        //if (photonView.IsMine)
        //{
        //    if (currState == state.nonactive)
        //    {
        //        UnitManager.Instance.turnOff();
        //        setState(state.spawn);
        //    }
        //}

    }
    public state getState()
    {
        return currState;
    }
    public void SetState(state ste)
    {
        currState = ste;
    }
}
