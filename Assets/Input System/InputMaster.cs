// GENERATED AUTOMATICALLY FROM 'Assets/Input System/InputMaster.inputactions'

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
            ""name"": ""Car"",
            ""id"": ""d2b61a3b-cc08-478f-9837-957e6d914465"",
            ""actions"": [
                {
                    ""name"": ""Left Right"",
                    ""type"": ""Value"",
                    ""id"": ""8cf21919-b487-415c-84f3-4dd3cd5d6bd3"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Brake Peddle Brake"",
                    ""type"": ""Value"",
                    ""id"": ""42fc6593-fca9-4d4b-923d-1502d7ab3342"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Brake Peddle Gas"",
                    ""type"": ""Value"",
                    ""id"": ""65f31328-1f18-45f3-bb09-a751dfcd1d2f"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Gas"",
                    ""type"": ""Value"",
                    ""id"": ""175f1bfb-eb60-41c7-8a74-981b2a0240dd"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Button Triangle"",
                    ""type"": ""Button"",
                    ""id"": ""e932f43c-f4a3-494d-a954-1ab7d71b533d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Button Square"",
                    ""type"": ""Button"",
                    ""id"": ""1e3611bc-63b5-457d-9e42-e3818c32c8f9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Button Circle"",
                    ""type"": ""Button"",
                    ""id"": ""5c484551-712e-42cc-a94d-d7c4aeaba5a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Button X"",
                    ""type"": ""Button"",
                    ""id"": ""07df03a6-ee55-4eae-b276-fd06d8e0d4df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shift Gear"",
                    ""type"": ""Button"",
                    ""id"": ""2a2ddc09-57a7-4b77-8c11-2d95be433db1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Tilt Test 0"",
                    ""type"": ""Button"",
                    ""id"": ""80842a4a-525c-4ac7-a380-a599be5b4a20"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Tilt Test 8"",
                    ""type"": ""Button"",
                    ""id"": ""553cfadb-8f70-49c0-b068-92230ce95dc9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""03cfd5eb-e1e7-478b-b8c0-fb3eb77e39ea"",
                    ""path"": ""<Joystick>/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""T150 Controller"",
                    ""action"": ""Brake Peddle Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ec4d952-4ccd-43fa-97aa-c7c81fa7b2ec"",
                    ""path"": ""<HID::44F B677>/rz"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""T150 Controller"",
                    ""action"": ""Gas"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1cb8b511-191c-4fa1-9104-3fb20e351058"",
                    ""path"": ""<HID::44F B677>/stick/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""T150 Controller"",
                    ""action"": ""Left Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""f8183fbc-7af3-4432-b7a2-d9425edfd2bf"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left Right"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b7bf15b-0bda-4ec2-b7d8-01ace7c4a92b"",
                    ""path"": ""<HID::44F B677>/button3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""T150 Controller"",
                    ""action"": ""Button Triangle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ff03456-cdfd-4bdb-8954-ed38d74e4795"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""T150 Controller"",
                    ""action"": ""Button Triangle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c1cfb3c-7f1e-458e-8355-28f67d046361"",
                    ""path"": ""<HID::44F B677>/button4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""T150 Controller"",
                    ""action"": ""Button Square"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4f843dd5-9846-4acc-b611-ae2053572e49"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""T150 Controller"",
                    ""action"": ""Button Square"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""058a045d-d686-4299-9b97-3fe666ea7aa0"",
                    ""path"": ""<HID::44F B677>/button5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""T150 Controller"",
                    ""action"": ""Button Circle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23eb3107-4c61-43e0-b681-54ca935b3300"",
                    ""path"": ""<HID::44F B677>/button6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""T150 Controller"",
                    ""action"": ""Button X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""T150"",
                    ""id"": ""36b410a1-1b83-4ee4-8617-fd79bfa0be18"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shift Gear"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""834dc3b5-8802-4e47-8add-31c07b61a65b"",
                    ""path"": ""<HID::44F B677>/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""T150 Controller"",
                    ""action"": ""Shift Gear"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""4a2b3607-bb08-4c9c-8009-0519894134a0"",
                    ""path"": ""<HID::44F B677>/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""T150 Controller"",
                    ""action"": ""Shift Gear"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""35b44920-2cdb-4861-a19c-d4d55e6f3e20"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shift Gear"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""653149a1-fc9a-4522-88d5-8b7c4a8b77ac"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""T150 Controller"",
                    ""action"": ""Shift Gear"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a2883828-a21e-4f4b-8a7c-4df4d5aeb0be"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""T150 Controller"",
                    ""action"": ""Shift Gear"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""92718eb8-3cdf-4f2b-b1b9-971a328b0f01"",
                    ""path"": ""<Keyboard>/comma"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""T150 Controller"",
                    ""action"": ""Tilt Test 0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7cac79ad-ee33-400b-8fb8-bdf74d46b0ce"",
                    ""path"": ""<Keyboard>/period"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""T150 Controller"",
                    ""action"": ""Tilt Test 8"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9955901a-328e-49ec-8455-9563e011c654"",
                    ""path"": ""<HID::44F B677>/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""T150 Controller"",
                    ""action"": ""Brake Peddle Gas"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""T150 Controller"",
            ""bindingGroup"": ""T150 Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<HID::44F B677>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Car
        m_Car = asset.FindActionMap("Car", throwIfNotFound: true);
        m_Car_LeftRight = m_Car.FindAction("Left Right", throwIfNotFound: true);
        m_Car_BrakePeddleBrake = m_Car.FindAction("Brake Peddle Brake", throwIfNotFound: true);
        m_Car_BrakePeddleGas = m_Car.FindAction("Brake Peddle Gas", throwIfNotFound: true);
        m_Car_Gas = m_Car.FindAction("Gas", throwIfNotFound: true);
        m_Car_ButtonTriangle = m_Car.FindAction("Button Triangle", throwIfNotFound: true);
        m_Car_ButtonSquare = m_Car.FindAction("Button Square", throwIfNotFound: true);
        m_Car_ButtonCircle = m_Car.FindAction("Button Circle", throwIfNotFound: true);
        m_Car_ButtonX = m_Car.FindAction("Button X", throwIfNotFound: true);
        m_Car_ShiftGear = m_Car.FindAction("Shift Gear", throwIfNotFound: true);
        m_Car_TiltTest0 = m_Car.FindAction("Tilt Test 0", throwIfNotFound: true);
        m_Car_TiltTest8 = m_Car.FindAction("Tilt Test 8", throwIfNotFound: true);
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

    // Car
    private readonly InputActionMap m_Car;
    private ICarActions m_CarActionsCallbackInterface;
    private readonly InputAction m_Car_LeftRight;
    private readonly InputAction m_Car_BrakePeddleBrake;
    private readonly InputAction m_Car_BrakePeddleGas;
    private readonly InputAction m_Car_Gas;
    private readonly InputAction m_Car_ButtonTriangle;
    private readonly InputAction m_Car_ButtonSquare;
    private readonly InputAction m_Car_ButtonCircle;
    private readonly InputAction m_Car_ButtonX;
    private readonly InputAction m_Car_ShiftGear;
    private readonly InputAction m_Car_TiltTest0;
    private readonly InputAction m_Car_TiltTest8;
    public struct CarActions
    {
        private @InputMaster m_Wrapper;
        public CarActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftRight => m_Wrapper.m_Car_LeftRight;
        public InputAction @BrakePeddleBrake => m_Wrapper.m_Car_BrakePeddleBrake;
        public InputAction @BrakePeddleGas => m_Wrapper.m_Car_BrakePeddleGas;
        public InputAction @Gas => m_Wrapper.m_Car_Gas;
        public InputAction @ButtonTriangle => m_Wrapper.m_Car_ButtonTriangle;
        public InputAction @ButtonSquare => m_Wrapper.m_Car_ButtonSquare;
        public InputAction @ButtonCircle => m_Wrapper.m_Car_ButtonCircle;
        public InputAction @ButtonX => m_Wrapper.m_Car_ButtonX;
        public InputAction @ShiftGear => m_Wrapper.m_Car_ShiftGear;
        public InputAction @TiltTest0 => m_Wrapper.m_Car_TiltTest0;
        public InputAction @TiltTest8 => m_Wrapper.m_Car_TiltTest8;
        public InputActionMap Get() { return m_Wrapper.m_Car; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CarActions set) { return set.Get(); }
        public void SetCallbacks(ICarActions instance)
        {
            if (m_Wrapper.m_CarActionsCallbackInterface != null)
            {
                @LeftRight.started -= m_Wrapper.m_CarActionsCallbackInterface.OnLeftRight;
                @LeftRight.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnLeftRight;
                @LeftRight.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnLeftRight;
                @BrakePeddleBrake.started -= m_Wrapper.m_CarActionsCallbackInterface.OnBrakePeddleBrake;
                @BrakePeddleBrake.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnBrakePeddleBrake;
                @BrakePeddleBrake.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnBrakePeddleBrake;
                @BrakePeddleGas.started -= m_Wrapper.m_CarActionsCallbackInterface.OnBrakePeddleGas;
                @BrakePeddleGas.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnBrakePeddleGas;
                @BrakePeddleGas.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnBrakePeddleGas;
                @Gas.started -= m_Wrapper.m_CarActionsCallbackInterface.OnGas;
                @Gas.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnGas;
                @Gas.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnGas;
                @ButtonTriangle.started -= m_Wrapper.m_CarActionsCallbackInterface.OnButtonTriangle;
                @ButtonTriangle.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnButtonTriangle;
                @ButtonTriangle.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnButtonTriangle;
                @ButtonSquare.started -= m_Wrapper.m_CarActionsCallbackInterface.OnButtonSquare;
                @ButtonSquare.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnButtonSquare;
                @ButtonSquare.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnButtonSquare;
                @ButtonCircle.started -= m_Wrapper.m_CarActionsCallbackInterface.OnButtonCircle;
                @ButtonCircle.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnButtonCircle;
                @ButtonCircle.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnButtonCircle;
                @ButtonX.started -= m_Wrapper.m_CarActionsCallbackInterface.OnButtonX;
                @ButtonX.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnButtonX;
                @ButtonX.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnButtonX;
                @ShiftGear.started -= m_Wrapper.m_CarActionsCallbackInterface.OnShiftGear;
                @ShiftGear.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnShiftGear;
                @ShiftGear.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnShiftGear;
                @TiltTest0.started -= m_Wrapper.m_CarActionsCallbackInterface.OnTiltTest0;
                @TiltTest0.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnTiltTest0;
                @TiltTest0.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnTiltTest0;
                @TiltTest8.started -= m_Wrapper.m_CarActionsCallbackInterface.OnTiltTest8;
                @TiltTest8.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnTiltTest8;
                @TiltTest8.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnTiltTest8;
            }
            m_Wrapper.m_CarActionsCallbackInterface = instance;
            if (instance != null)
            {
                @LeftRight.started += instance.OnLeftRight;
                @LeftRight.performed += instance.OnLeftRight;
                @LeftRight.canceled += instance.OnLeftRight;
                @BrakePeddleBrake.started += instance.OnBrakePeddleBrake;
                @BrakePeddleBrake.performed += instance.OnBrakePeddleBrake;
                @BrakePeddleBrake.canceled += instance.OnBrakePeddleBrake;
                @BrakePeddleGas.started += instance.OnBrakePeddleGas;
                @BrakePeddleGas.performed += instance.OnBrakePeddleGas;
                @BrakePeddleGas.canceled += instance.OnBrakePeddleGas;
                @Gas.started += instance.OnGas;
                @Gas.performed += instance.OnGas;
                @Gas.canceled += instance.OnGas;
                @ButtonTriangle.started += instance.OnButtonTriangle;
                @ButtonTriangle.performed += instance.OnButtonTriangle;
                @ButtonTriangle.canceled += instance.OnButtonTriangle;
                @ButtonSquare.started += instance.OnButtonSquare;
                @ButtonSquare.performed += instance.OnButtonSquare;
                @ButtonSquare.canceled += instance.OnButtonSquare;
                @ButtonCircle.started += instance.OnButtonCircle;
                @ButtonCircle.performed += instance.OnButtonCircle;
                @ButtonCircle.canceled += instance.OnButtonCircle;
                @ButtonX.started += instance.OnButtonX;
                @ButtonX.performed += instance.OnButtonX;
                @ButtonX.canceled += instance.OnButtonX;
                @ShiftGear.started += instance.OnShiftGear;
                @ShiftGear.performed += instance.OnShiftGear;
                @ShiftGear.canceled += instance.OnShiftGear;
                @TiltTest0.started += instance.OnTiltTest0;
                @TiltTest0.performed += instance.OnTiltTest0;
                @TiltTest0.canceled += instance.OnTiltTest0;
                @TiltTest8.started += instance.OnTiltTest8;
                @TiltTest8.performed += instance.OnTiltTest8;
                @TiltTest8.canceled += instance.OnTiltTest8;
            }
        }
    }
    public CarActions @Car => new CarActions(this);
    private int m_T150ControllerSchemeIndex = -1;
    public InputControlScheme T150ControllerScheme
    {
        get
        {
            if (m_T150ControllerSchemeIndex == -1) m_T150ControllerSchemeIndex = asset.FindControlSchemeIndex("T150 Controller");
            return asset.controlSchemes[m_T150ControllerSchemeIndex];
        }
    }
    public interface ICarActions
    {
        void OnLeftRight(InputAction.CallbackContext context);
        void OnBrakePeddleBrake(InputAction.CallbackContext context);
        void OnBrakePeddleGas(InputAction.CallbackContext context);
        void OnGas(InputAction.CallbackContext context);
        void OnButtonTriangle(InputAction.CallbackContext context);
        void OnButtonSquare(InputAction.CallbackContext context);
        void OnButtonCircle(InputAction.CallbackContext context);
        void OnButtonX(InputAction.CallbackContext context);
        void OnShiftGear(InputAction.CallbackContext context);
        void OnTiltTest0(InputAction.CallbackContext context);
        void OnTiltTest8(InputAction.CallbackContext context);
    }
}
