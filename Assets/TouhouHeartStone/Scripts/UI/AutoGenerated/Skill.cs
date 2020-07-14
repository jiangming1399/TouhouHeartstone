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
    
    public partial class Skill : UIObject
    {
        protected override void Awake()
        {
            base.Awake();
            this.autoBind();
            this.onAwake();
        }
        public void autoBind()
        {
            this.m_as_Button = this.GetComponent<Button>();
            this._Mask = this.transform.Find("Mask").GetComponent<Mask>();
            this._Image = this.transform.Find("Mask").Find("Image").GetComponent<Image>();
            this._FrameImage = this.transform.Find("Frame").GetComponent<Image>();
            this._Frame_Image = this.transform.Find("Frame").Find("Image").GetComponent<Image>();
            this._CostImage = this.transform.Find("Cost").GetComponent<Image>();
            this._CostPropNumber = this.transform.Find("Cost").Find("Cost").GetComponent<PropNumber>();
            this._BackImage = this.transform.Find("Back").GetComponent<Image>();
        }
        [SerializeField()]
        private Button m_as_Button;
        public Button asButton
        {
            get
            {
                if ((this.m_as_Button == null))
                {
                    this.m_as_Button = this.GetComponent<Button>();
                }
                return this.m_as_Button;
            }
        }
        [SerializeField()]
        private Mask _Mask;
        public Mask Mask
        {
            get
            {
                if ((this._Mask == null))
                {
                    this._Mask = this.transform.Find("Mask").GetComponent<Mask>();
                }
                return this._Mask;
            }
        }
        [SerializeField()]
        private Image _Image;
        public Image Image
        {
            get
            {
                if ((this._Image == null))
                {
                    this._Image = this.transform.Find("Mask").Find("Image").GetComponent<Image>();
                }
                return this._Image;
            }
        }
        [SerializeField()]
        private Image _FrameImage;
        public Image FrameImage
        {
            get
            {
                if ((this._FrameImage == null))
                {
                    this._FrameImage = this.transform.Find("Frame").GetComponent<Image>();
                }
                return this._FrameImage;
            }
        }
        [SerializeField()]
        private Image _Frame_Image;
        public Image Frame_Image
        {
            get
            {
                if ((this._Frame_Image == null))
                {
                    this._Frame_Image = this.transform.Find("Frame").Find("Image").GetComponent<Image>();
                }
                return this._Frame_Image;
            }
        }
        [SerializeField()]
        private Image _CostImage;
        public Image CostImage
        {
            get
            {
                if ((this._CostImage == null))
                {
                    this._CostImage = this.transform.Find("Cost").GetComponent<Image>();
                }
                return this._CostImage;
            }
        }
        [SerializeField()]
        private PropNumber _CostPropNumber;
        public PropNumber CostPropNumber
        {
            get
            {
                if ((this._CostPropNumber == null))
                {
                    this._CostPropNumber = this.transform.Find("Cost").Find("Cost").GetComponent<PropNumber>();
                }
                return this._CostPropNumber;
            }
        }
        [SerializeField()]
        private Image _BackImage;
        public Image BackImage
        {
            get
            {
                if ((this._BackImage == null))
                {
                    this._BackImage = this.transform.Find("Back").GetComponent<Image>();
                }
                return this._BackImage;
            }
        }
        partial void onAwake();
        public enum IsUsable
        {
            False,
            True,
        }
        public IsUsable IsUsableController
        {
            get
            {
                return ((IsUsable)(Enum.Parse(typeof(IsUsable), this.getController("IsUsable", Enum.GetNames(typeof(IsUsable))))));
            }
            set
            {
                this.setController("IsUsable", Enum.GetName(typeof(IsUsable), value));
            }
        }
        public enum IsUsed
        {
            False,
            True,
        }
        public IsUsed IsUsedController
        {
            get
            {
                return ((IsUsed)(Enum.Parse(typeof(IsUsed), this.getController("IsUsed", Enum.GetNames(typeof(IsUsed))))));
            }
            set
            {
                this.setController("IsUsed", Enum.GetName(typeof(IsUsed), value));
            }
        }
    }
}
