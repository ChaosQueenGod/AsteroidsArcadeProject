//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/InputSystem/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Control"",
            ""id"": ""42561fac-d336-4691-88a8-24d6967e2995"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""de6c6d30-0cdf-4df1-aae0-203f348ba659"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""ec6c4ca2-a770-4d32-881f-1d7a528e3437"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Hyperspace"",
                    ""type"": ""Button"",
                    ""id"": ""e54ef60f-23c7-4439-a55f-f53c84354a63"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""ad3752f2-0208-4843-a1d1-366b8a67afec"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""96ff29b5-aae6-4a3f-8665-1707e9ffeb07"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0c1bb99a-af1a-40b5-b161-9d5f7f5078c7"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""e8cad5b6-702b-4f22-aee7-a435ee97e1fb"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""65d31570-b4b6-4546-abdf-aef3af7957b7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0d26a931-651d-4936-bfde-c69ebc3a4178"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6b7e5d06-927b-4fb1-b4a4-abd3b397a829"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hyperspace"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Control
        m_Control = asset.FindActionMap("Control", throwIfNotFound: true);
        m_Control_Move = m_Control.FindAction("Move", throwIfNotFound: true);
        m_Control_Shoot = m_Control.FindAction("Shoot", throwIfNotFound: true);
        m_Control_Hyperspace = m_Control.FindAction("Hyperspace", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Control
    private readonly InputActionMap m_Control;
    private IControlActions m_ControlActionsCallbackInterface;
    private readonly InputAction m_Control_Move;
    private readonly InputAction m_Control_Shoot;
    private readonly InputAction m_Control_Hyperspace;
    public struct ControlActions
    {
        private @PlayerInput m_Wrapper;
        public ControlActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Control_Move;
        public InputAction @Shoot => m_Wrapper.m_Control_Shoot;
        public InputAction @Hyperspace => m_Wrapper.m_Control_Hyperspace;
        public InputActionMap Get() { return m_Wrapper.m_Control; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControlActions set) { return set.Get(); }
        public void SetCallbacks(IControlActions instance)
        {
            if (m_Wrapper.m_ControlActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnMove;
                @Shoot.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnShoot;
                @Hyperspace.started -= m_Wrapper.m_ControlActionsCallbackInterface.OnHyperspace;
                @Hyperspace.performed -= m_Wrapper.m_ControlActionsCallbackInterface.OnHyperspace;
                @Hyperspace.canceled -= m_Wrapper.m_ControlActionsCallbackInterface.OnHyperspace;
            }
            m_Wrapper.m_ControlActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Hyperspace.started += instance.OnHyperspace;
                @Hyperspace.performed += instance.OnHyperspace;
                @Hyperspace.canceled += instance.OnHyperspace;
            }
        }
    }
    public ControlActions @Control => new ControlActions(this);
    public interface IControlActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnHyperspace(InputAction.CallbackContext context);
    }
}
