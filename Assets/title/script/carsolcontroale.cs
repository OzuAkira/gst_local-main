using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;
using UnityEngine.Animations;

public class carsolcontroale : MonoBehaviour
{
    int Cursor = 0;
    public carsol[] MenuTable;
    public SpriteRenderer CursorRenderer;
    
    private bool i = false;
    private bool ii = false;
    
    // Start is called before the first frame update
    void Start()
    {
        UpdateMenu();
        
    }
    void OnNavigate(InputValue value)
    {
        
        var axis = value.Get<Vector2>();
        Debug.Log(axis);
        if(axis.y == 1 && i == false)
        {
            i = true;
            //Task.Delay(500);
        }
        else if(axis.y == -1 && ii == false)
        {
            ii = true;
            //await Task.Delay(500);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log();
        int oldCursor = Cursor;
        int cursorMax = MenuTable.Length;

        if (i )
        {
            Cursor--;
            i = false;
        }
        else if (ii)
        {
            Cursor++;
            ii = false;
        }
       /* var gamepad = Gamepad.current;
        if(gamepad == null)return;
        var stic = gamepad.leftStick.ReadValue();
        //var downstic = gamepad.leftStick.down.ReadValue();
        if(stic.y > 1 && i)
        {
            Cursor++;
            i = false;
        }
        else if(stic.y < -1 && ii)
        {
            Cursor--;
            ii = false;
        }
        else if(stic.y == 0)
        {
            i = true;
            ii = true;
        }*/
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            MenuTable[Cursor].Select();
        }

        // カーソルの制御
        if(Cursor < 0)
        {
            Cursor = MenuTable.Length - 1;
        }
        if(Cursor >= cursorMax)
        {
            Cursor = 0;
        }

        // カーソルに変更があったら
        if(Cursor != oldCursor)
        {
            UpdateMenu();
        }
    }

    // メニューの更新
    void UpdateMenu()
    {
        int cursor = 0;
        foreach (carsol menu in MenuTable)
        {
            if (Cursor == cursor)
            {
                menu.On();

                // カーソルの位置を設定
                CursorRenderer.transform.position = menu.transform.position - new Vector3(3,0,0);
            }
            else
            {
                menu.Off();
            }

            ++cursor;
        }
    }
}
