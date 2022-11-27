using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Tile : MonoBehaviourPunCallbacks
{
    public static Tile Instance;
    public string TileName;
    [SerializeField] protected SpriteRenderer _renderer;
    [SerializeField] public GameObject _highlight;
    [SerializeField] private bool _isWalkable;
    public bool _done = false;
    public BaseUnit OccupiedUnit;
    public bool Walkable => _isWalkable && OccupiedUnit == null;
    public string[] tiled;
    public string nameTile;
    public bool check = false;
    int count = 0;
    public bool way = true;




    private void Awake()
    {
        Instance = this;
    }
    public void highlight(bool activator)
    {
       _highlight.SetActive(activator);       

    }
    private void Start()
    {
        UnitManager.Instance.getPos(this);        
    }
    private void Update()
    {
        
    }

    
    public Vector2 getVector2(string rString)
    {
        string[] temp = rString.Split(' ');
        float x = System.Convert.ToSingle(temp[1]);
        float y = System.Convert.ToSingle(temp[2]);
        Vector2 rValue = new Vector2(x, y);
        return rValue;
    }
    private void OnMouseEnter()
    {
        
    }
    
    private void OnMouseExit()
    {
        
    }
    public void SetUnit(BaseUnit unit)
    {
        if (unit.OccupiedTile != null) unit.OccupiedTile.OccupiedUnit = null;
        unit.transform.position = transform.position;
        OccupiedUnit = unit;
        unit.OccupiedTile = this;
    }
    public virtual void Init(int x, int y)
    {

    }
    public void OnMouseUp()
    {
        UnitManager.Instance.getMove(this);
        
        
    }
    public void OnMouseDown()
    {
        //if(tag == "Player")
        //{
        //    UnitManager.Instance.path.transform.position = this.transform.position;
        //}

    }

    public void movement()
    {
        UnitManager.Instance.getMove(this);
        Debug.Log("Bitch Tile");
    }
}

