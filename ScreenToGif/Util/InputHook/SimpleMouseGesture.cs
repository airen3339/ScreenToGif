using System.Runtime.Serialization;
using System.Windows.Input;

namespace ScreenToGif.Util.InputHook
{
    /// <summary>
    /// Custom mouse event arguments.
    /// </summary>
    [DataContract]
    public class SimpleMouseGesture
    {
        #region Properties
        
        /// <summary>
        /// The type of the mouse event.
        /// </summary>
        public InputHook.MouseEventType EventType { get; }


        public long Timestamp { get; set; }


        /// <summary>
        /// X Axis position
        /// </summary>
        public int PosX { get; }

        /// <summary>
        /// Y Axis position.
        /// </summary>
        public int PosY { get; }
        

        /// <summary>
        /// State of the left mouse button.
        /// </summary>
        public MouseButtonState LeftButton { get; }

        /// <summary>
        /// State of the right mouse button.
        /// </summary>
        public MouseButtonState RightButton { get; }

        /// <summary>
        /// State of the middle mouse button.
        /// </summary>
        public MouseButtonState MiddleButton { get; }

        /// <summary>
        /// State of the first extra mouse buttons.
        /// </summary>
        public MouseButtonState FirstExtraButton { get; }

        /// <summary>
        /// State of the second extra mouse buttons.
        /// </summary>
        public MouseButtonState SecondExtraButton { get; }

        /// <summary>
        /// The state of the scroll wheel. Up or down scroll flow.
        /// </summary>
        public short MouseDelta { get; }

        
        /// <summary>
        /// True if this event args is a registration of a mouse down event.
        /// </summary>
        public bool IsMouseDown => EventType == InputHook.MouseEventType.LeftButtonDown || EventType == InputHook.MouseEventType.RightButtonDown || EventType == InputHook.MouseEventType.MiddleButtonDown || 
            EventType == InputHook.MouseEventType.ExtraButtonDown || EventType == InputHook.MouseEventType.OutsideExtraButtonDown;

        /// <summary>
        /// True if this event args is a registration of a mouse double click event.
        /// </summary>
        public bool IsMouseDoubleClick => EventType == InputHook.MouseEventType.LeftButtonDoubleClick || EventType == InputHook.MouseEventType.RightButtonDoubleClick || EventType == InputHook.MouseEventType.MiddleButtonDoubleClick ||
            EventType == InputHook.MouseEventType.ExtraButtonDoubleClick || EventType == InputHook.MouseEventType.OutsideExtraButtonDoubleClick;

        /// <summary>
        /// True if the action of clicking or scrolling happened.
        /// </summary>
        public bool IsInteraction => IsMouseDown || IsMouseDoubleClick || MouseDelta != 0;

        /// <summary>
        /// True if the any button is being clicked.
        /// </summary>
        public bool IsClicked => LeftButton == MouseButtonState.Pressed || RightButton == MouseButtonState.Pressed || MiddleButton == MouseButtonState.Pressed;

        /// <summary>
        /// True if the scroll event is upwards.
        /// </summary>
        public bool IsScrollUp => EventType == InputHook.MouseEventType.MouseWheel && MouseDelta > 0;

        /// <summary>
        /// True if the scroll event is downwards.
        /// </summary>
        public bool IsScrollDown => EventType == InputHook.MouseEventType.MouseWheel && MouseDelta < 0;

        /// <summary>
        /// True if the scroll event is upwards.
        /// </summary>
        public bool IsScrollLeft => EventType == InputHook.MouseEventType.MouseWheelHorizontal && MouseDelta < 0;

        /// <summary>
        /// True if the scroll event is downwards.
        /// </summary>
        public bool IsScrollRight => EventType == InputHook.MouseEventType.MouseWheelHorizontal && MouseDelta > 0;

        #endregion

        public SimpleMouseGesture(InputHook.MouseEventType eventType, int x, int y, MouseButtonState left, MouseButtonState right, MouseButtonState middle, MouseButtonState firstExtra, MouseButtonState secondExtra, short mouseDelta = 0)
        {
            EventType = eventType;

            PosX = x;
            PosY = y;

            LeftButton = left;
            RightButton = right;
            MiddleButton = middle;
            FirstExtraButton = firstExtra;
            SecondExtraButton = secondExtra;
            MouseDelta = mouseDelta;
        }
    }
}