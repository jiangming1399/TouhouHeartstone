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
    
    public partial class ServantPlaceHolder : UIObject
    {
        protected override void Awake()
        {
            base.Awake();
            this.autoBind();
            this.onAwake();
        }
        public void autoBind()
        {
            this._Servant = this.transform.Find("Servant").GetComponent<Servant>();
        }
        private Main _parent;
        public Main parent
        {
            get
            {
                return this.transform.parent.parent.parent.parent.GetComponent<Main>();
            }
        }
        [SerializeField()]
        private Servant _Servant;
        public Servant Servant
        {
            get
            {
                if ((this._Servant == null))
                {
                    this._Servant = this.transform.Find("Servant").GetComponent<Servant>();
                }
                return this._Servant;
            }
        }
        partial void onAwake();
    }
}
