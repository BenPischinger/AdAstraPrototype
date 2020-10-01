using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConsume {
    //Interface wo der Controller drauf zugreift und die gewünschte Methode ( mit oder ohne Stats aufruft)
    void Consume();
    void Consume(CharackterStats stats);

}
