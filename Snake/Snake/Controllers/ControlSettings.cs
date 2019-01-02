using System.Collections.Generic;
using System.Windows.Input;

namespace SnakeGame.Controllers
{
    class ControlSettings
    {
        public enum Control { jump1, jump2, jump3, jump4, jump5, jump6, jump7, jump8, jump9, borderJump, bodyJump };
        public static Dictionary<Control, Key> controlMap;

        static ControlSettings ()
        {
            controlMap = new Dictionary<Control, Key> {
                { Control.jump1, Key.D1 },
                { Control.jump2, Key.D2 },
                { Control.jump3, Key.D3 },
                { Control.jump4, Key.D4 },
                { Control.jump5, Key.D5 },
                { Control.jump6, Key.D6 },
                { Control.jump7, Key.D7 },
                { Control.jump8, Key.D8 },
                { Control.jump9, Key.D9 },
                { Control.borderJump, Key.LeftShift },
                { Control.bodyJump, Key.LeftCtrl }
            };
        }
    }
}
