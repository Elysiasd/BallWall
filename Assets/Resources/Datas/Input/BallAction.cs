//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Resources/Datas/Input/BallAction.inputactions
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

public partial class @BallAction: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @BallAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""BallAction"",
    ""maps"": [
        {
            ""name"": ""Common"",
            ""id"": ""1405acb5-8836-4b2f-bf5e-c7e79d1b6cb0"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""e89a7795-3ffc-4c46-aeb3-22924497fa88"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Read"",
                    ""type"": ""Button"",
                    ""id"": ""9cfa0052-cbd9-4a73-8f70-ba8c7340104b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""fc52e19d-0276-4b6b-a053-19db1d09dd01"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d046207f-7512-4711-8376-3bbcdffda644"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b436e57-d364-4bc3-a41c-663ddb81110e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Read"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1fc3965e-1342-4451-ba7d-6531d74abcd0"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Read"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Common
        m_Common = asset.FindActionMap("Common", throwIfNotFound: true);
        m_Common_Move = m_Common.FindAction("Move", throwIfNotFound: true);
        m_Common_Read = m_Common.FindAction("Read", throwIfNotFound: true);
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

    // Common
    private readonly InputActionMap m_Common;
    private List<ICommonActions> m_CommonActionsCallbackInterfaces = new List<ICommonActions>();
    private readonly InputAction m_Common_Move;
    private readonly InputAction m_Common_Read;
    public struct CommonActions
    {
        private @BallAction m_Wrapper;
        public CommonActions(@BallAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Common_Move;
        public InputAction @Read => m_Wrapper.m_Common_Read;
        public InputActionMap Get() { return m_Wrapper.m_Common; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CommonActions set) { return set.Get(); }
        public void AddCallbacks(ICommonActions instance)
        {
            if (instance == null || m_Wrapper.m_CommonActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CommonActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Read.started += instance.OnRead;
            @Read.performed += instance.OnRead;
            @Read.canceled += instance.OnRead;
        }

        private void UnregisterCallbacks(ICommonActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Read.started -= instance.OnRead;
            @Read.performed -= instance.OnRead;
            @Read.canceled -= instance.OnRead;
        }

        public void RemoveCallbacks(ICommonActions instance)
        {
            if (m_Wrapper.m_CommonActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICommonActions instance)
        {
            foreach (var item in m_Wrapper.m_CommonActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CommonActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CommonActions @Common => new CommonActions(this);
    public interface ICommonActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRead(InputAction.CallbackContext context);
    }
}
