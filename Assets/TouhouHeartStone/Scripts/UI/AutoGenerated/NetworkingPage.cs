//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UI
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;
    using BJSYGameCore.UI;
    
    public partial class NetworkingPage : UIObject
    {
        protected override void Awake()
        {
            base.Awake();
            this.autoBind();
            this.onAwake();
        }
        public void autoBind()
        {
            this.m_as_Image = this.GetComponent<Image>();
            this._ControlPanelImage = this.transform.Find("ControlPanel").GetComponent<Image>();
            this._BtnGroupVerticalLayoutGroup = this.transform.Find("ControlPanel").Find("BtnGroup").GetComponent<VerticalLayoutGroup>();
            this._IPFieldInput = this.transform.Find("ControlPanel").Find("BtnGroup").Find("IPField").GetComponent<InputField>();
            this._DirectLinkButton = this.transform.Find("ControlPanel").Find("BtnGroup").Find("DirectLink").GetComponent<Button>();
            this._LANButton = this.transform.Find("ControlPanel").Find("BtnGroup").Find("LAN").GetComponent<Button>();
            this._WANButton = this.transform.Find("ControlPanel").Find("BtnGroup").Find("WAN").GetComponent<Button>();
            this._StatusText = this.transform.Find("ControlPanel").Find("StatusText").GetComponent<Text>();
            this._RoomListsImage = this.transform.Find("RoomLists").GetComponent<Image>();
            this._RoomListParent = this.transform.Find("RoomLists").Find("Local").Find("RoomListParent").GetComponent<RoomList>();
            this._Text = this.transform.Find("RoomLists").Find("Local").Find("Text").GetComponent<Text>();
            this._Remote_RoomListParent = this.transform.Find("RoomLists").Find("Remote").Find("RoomListParent").GetComponent<RoomList>();
            this._Remote_Text = this.transform.Find("RoomLists").Find("Remote").Find("Text").GetComponent<Text>();
        }
        private Main _parent;
        public Main parent
        {
            get
            {
                return this.transform.parent.GetComponent<Main>();
            }
        }
        [SerializeField()]
        private Image m_as_Image;
        public Image asImage
        {
            get
            {
                if ((this.m_as_Image == null))
                {
                    this.m_as_Image = this.GetComponent<Image>();
                }
                return this.m_as_Image;
            }
        }
        [SerializeField()]
        private Image _ControlPanelImage;
        public Image ControlPanelImage
        {
            get
            {
                if ((this._ControlPanelImage == null))
                {
                    this._ControlPanelImage = this.transform.Find("ControlPanel").GetComponent<Image>();
                }
                return this._ControlPanelImage;
            }
        }
        [SerializeField()]
        private VerticalLayoutGroup _BtnGroupVerticalLayoutGroup;
        public VerticalLayoutGroup BtnGroupVerticalLayoutGroup
        {
            get
            {
                if ((this._BtnGroupVerticalLayoutGroup == null))
                {
                    this._BtnGroupVerticalLayoutGroup = this.transform.Find("ControlPanel").Find("BtnGroup").GetComponent<VerticalLayoutGroup>();
                }
                return this._BtnGroupVerticalLayoutGroup;
            }
        }
        [SerializeField()]
        private InputField _IPFieldInput;
        public InputField IPFieldInput
        {
            get
            {
                if ((this._IPFieldInput == null))
                {
                    this._IPFieldInput = this.transform.Find("ControlPanel").Find("BtnGroup").Find("IPField").GetComponent<InputField>();
                }
                return this._IPFieldInput;
            }
        }
        [SerializeField()]
        private Button _DirectLinkButton;
        public Button DirectLinkButton
        {
            get
            {
                if ((this._DirectLinkButton == null))
                {
                    this._DirectLinkButton = this.transform.Find("ControlPanel").Find("BtnGroup").Find("DirectLink").GetComponent<Button>();
                }
                return this._DirectLinkButton;
            }
        }
        [SerializeField()]
        private Button _LANButton;
        public Button LANButton
        {
            get
            {
                if ((this._LANButton == null))
                {
                    this._LANButton = this.transform.Find("ControlPanel").Find("BtnGroup").Find("LAN").GetComponent<Button>();
                }
                return this._LANButton;
            }
        }
        [SerializeField()]
        private Button _WANButton;
        public Button WANButton
        {
            get
            {
                if ((this._WANButton == null))
                {
                    this._WANButton = this.transform.Find("ControlPanel").Find("BtnGroup").Find("WAN").GetComponent<Button>();
                }
                return this._WANButton;
            }
        }
        [SerializeField()]
        private Text _StatusText;
        public Text StatusText
        {
            get
            {
                if ((this._StatusText == null))
                {
                    this._StatusText = this.transform.Find("ControlPanel").Find("StatusText").GetComponent<Text>();
                }
                return this._StatusText;
            }
        }
        [SerializeField()]
        private Image _RoomListsImage;
        public Image RoomListsImage
        {
            get
            {
                if ((this._RoomListsImage == null))
                {
                    this._RoomListsImage = this.transform.Find("RoomLists").GetComponent<Image>();
                }
                return this._RoomListsImage;
            }
        }
        [SerializeField()]
        private RoomList _RoomListParent;
        public RoomList RoomListParent
        {
            get
            {
                if ((this._RoomListParent == null))
                {
                    this._RoomListParent = this.transform.Find("RoomLists").Find("Local").Find("RoomListParent").GetComponent<RoomList>();
                }
                return this._RoomListParent;
            }
        }
        [SerializeField()]
        private Text _Text;
        public Text Text
        {
            get
            {
                if ((this._Text == null))
                {
                    this._Text = this.transform.Find("RoomLists").Find("Local").Find("Text").GetComponent<Text>();
                }
                return this._Text;
            }
        }
        [SerializeField()]
        private RoomList _Remote_RoomListParent;
        public RoomList Remote_RoomListParent
        {
            get
            {
                if ((this._Remote_RoomListParent == null))
                {
                    this._Remote_RoomListParent = this.transform.Find("RoomLists").Find("Remote").Find("RoomListParent").GetComponent<RoomList>();
                }
                return this._Remote_RoomListParent;
            }
        }
        [SerializeField()]
        private Text _Remote_Text;
        public Text Remote_Text
        {
            get
            {
                if ((this._Remote_Text == null))
                {
                    this._Remote_Text = this.transform.Find("RoomLists").Find("Remote").Find("Text").GetComponent<Text>();
                }
                return this._Remote_Text;
            }
        }
        partial void onAwake();
    }
}
