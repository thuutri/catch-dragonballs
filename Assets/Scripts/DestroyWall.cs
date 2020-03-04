using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyWall : MonoBehaviour {

    public DestroyOnContact desobj;
    public GameController gamobj;
    void OnCollisionEnter2D(Collision2D other)
    {
        //Nếu va chạm với vật thể -> xóa vật thể
        if (other.gameObject.tag == "Ball" || other.gameObject.tag == "Heart" || other.gameObject.tag == "Boom"|| other.gameObject.tag=="Energy"|| other.gameObject.tag=="Shuriken"||other.gameObject.tag=="GenkiDama")
        {
            Destroy(other.gameObject);
            //khi bóng rơi xuống đất thì mất điểm
            if (other.gameObject.tag == "Ball")
                if(gamobj.health>0)
                   gamobj.health--;
            //cập nhật điểm
            desobj.UpdateScore();
            //cập nhật health
            gamobj.UpdateHealthText();
        }
    }
}
