using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class photonization : MonoBehaviourPunCallbacks, IPunObservable
{

    public static photonization Instance;
    [SerializeField] GameObject view, loseV;
    public bool lose;
    // Start is called before the first frame update
    void Start()
    {    
        
        
    }
    
    public void showWin()
    {
        view.SetActive(true);
    }
    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine)
        if (lose == true)
        {
            loseV.SetActive(true);
            
        }
        if(view.active == true)
        {
            loseV.SetActive(false);
        }
     //if(PhotonNetwork.CountOfPlayers > 1)
     //   {
     //       var photonViews = UnityEngine.Object.FindObjectsOfType<PhotonView>();
     //       foreach (var view in photonViews)
     //       {
     //           var player = view.Owner;
     //           //Objects in the scene don't have an owner, its means view.owner will be null
     //           if (player != null)
     //           {
     //               var playerPrefabObject = view.gameObject;
     //               //do works...
     //           }
     //       }
     //   }   
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(lose);
        }
        else
        {
            lose = (bool)stream.ReceiveNext();
        }
    }
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        stream.Serialize(ref lose);
    }

    //void validation()
    //{
    //    if(view.transform.position == view1.transform.position)
    //    {
    //        Debug.Log("Hello Bitchaz");
    //    }
    //    if(view.transform.position.y == view1.transform.position.y)
    //    {
    //        if (view.transform.position.x + 1 == view1.transform.position.x || view.transform.position.x - 1 == view1.transform.position.x)
    //        {
    //            Debug.Log("Hello Bitchaz");
    //        }
    //    }

    //    if(view.transform.position.x == view1.transform.position.x)
    //    {
    //        if (view.transform.position.y + 1 == view1.transform.position.y || view.transform.position.y - 1 == view1.transform.position.y)
    //        {
    //            Debug.Log("Hello Bitchaz");
    //        }
    //    }

    //}


}
