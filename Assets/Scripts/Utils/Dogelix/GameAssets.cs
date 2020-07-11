using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dogelix
{
    /// <summary>
    /// The class of GameAssets that can be used to spawn in to the game.
    /// Usage: GameAssests.i.{AssetRequired}
    /// Example: GameGameAssets.i.PointsPopup
    /// </summary>
    public class GameAssets : MonoBehaviour
    {
        private static GameAssets _i;

        public static GameAssets i
        {
            get
            {
                if ( _i == null )
                {
                    var sManager = GameObject.FindGameObjectWithTag("GameManager");
                    if ( sManager == null )
                    {
                        _i = Instantiate(Resources.Load("GameManager") as GameObject).GetComponent<GameAssets>();

                    }
                    else
                    {
                        _i = sManager.GetComponent<GameAssets>();
                    }

                }
                return _i;
            }
        }

        public Transform TestCube;
        public Transform EditorPlane;
        public RectTransform EditorButton;

        public Transform Player;

        //Blocks
        public Transform Block;
        public Transform LBlock;
        public Transform RBlock;
        public Transform Start;
        public Transform Goal;

    }

}