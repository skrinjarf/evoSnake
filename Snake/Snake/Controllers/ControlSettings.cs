using System.Collections.Generic;
using System.Windows.Input;

namespace SnakeGame.Controllers
{
    class ControlSettings
    {
        public static object [] allKeys;

        public enum Control { jump1, jump2, jump3, jump4, jump5, jump6, jump7, jump8, jump9, borderJump, bodyJump };
        public static Dictionary<Control, Key> controlMap;

        static ControlSettings ()
        {
            allKeys = new object [] {
                Key.Back,
                Key.Tab,
                Key.Return,
                Key.Enter,
                Key.CapsLock,
                Key.Escape,
                Key.Space,
                Key.Insert,
                Key.Delete,
                Key.D0,
                Key.D1,
                Key.D2,
                Key.D3,
                Key.D4,
                Key.D5,
                Key.D6,
                Key.D7,
                Key.D8,
                Key.D9,
                Key.A,
                Key.B,
                Key.C,
                Key.D,
                Key.E,
                Key.F,
                Key.G,
                Key.H,
                Key.I,
                Key.J,
                Key.K,
                Key.L,
                Key.M,
                Key.N,
                Key.O,
                Key.P,
                Key.Q,
                Key.R,
                Key.S,
                Key.T,
                Key.U,
                Key.V,
                Key.W,
                Key.X,
                Key.Y,
                Key.Z,
                Key.NumPad0,
                Key.NumPad1,
                Key.NumPad2,
                Key.NumPad3,
                Key.NumPad4,
                Key.NumPad5,
                Key.NumPad6,
                Key.NumPad7,
                Key.NumPad8,
                Key.NumPad9,
                Key.Multiply,
                Key.Add,
                Key.Separator,
                Key.Subtract,
                Key.Decimal,
                Key.Divide,
                Key.LeftShift,
                Key.RightShift,
                Key.LeftCtrl,
                Key.RightCtrl,
                Key.LeftAlt,
                Key.RightAlt
            };
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
