// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""7a95da69-e004-4756-bd4f-ce425d5d5bba"",
            ""actions"": [
                {
                    ""name"": ""Left Flipper"",
                    ""type"": ""PassThrough"",
                    ""id"": ""86c317ab-2b10-472b-8a98-89676b9eac3b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Right Flipper"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f828c83c-84e8-4dc7-a815-41605a6bbe61"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2ced12fc-352d-414b-b2a4-98813004f78d"",
                    ""path"": ""<Touchscreen>/position/x"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone(min=0.01,max=0.5)"",
                    ""groups"": """",
                    ""action"": ""Left Flipper"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""296a99ab-3545-4a87-a3e0-7411af0e0ce4"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Flipper"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81c35444-1499-4953-90a2-a2d7d0b76205"",
                    ""path"": ""<Touchscreen>/position/x"",
                    ""interactions"": """",
                    ""processors"": ""AxisDeadzone(min=0.5,max=1)"",
                    ""groups"": """",
                    ""action"": ""Right Flipper"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ac05301-3377-49c0-bde6-43c0fadb9d47"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right Flipper"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_LeftFlipper = m_Player.FindAction("Left Flipper", throwIfNotFound: true);
        m_Player_RightFlipper = m_Player.FindAction("Right Flipper", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_LeftFlipper;
    private readonly InputAction m_Player_RightFlipper;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftFlipper => m_Wrapper.m_Player_LeftFlipper;
        public InputAction @RightFlipper => m_Wrapper.m_Player_RightFlipper;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @LeftFlipper.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftFlipper;
                @LeftFlipper.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftFlipper;
                @LeftFlipper.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftFlipper;
                @RightFlipper.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightFlipper;
                @RightFlipper.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightFlipper;
                @RightFlipper.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRightFlipper;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftFlipper.started += instance.OnLeftFlipper;
                @LeftFlipper.performed += instance.OnLeftFlipper;
                @LeftFlipper.canceled += instance.OnLeftFlipper;
                @RightFlipper.started += instance.OnRightFlipper;
                @RightFlipper.performed += instance.OnRightFlipper;
                @RightFlipper.canceled += instance.OnRightFlipper;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnLeftFlipper(InputAction.CallbackContext context);
        void OnRightFlipper(InputAction.CallbackContext context);
    }
}
