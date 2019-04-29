﻿using System;
using System.Collections.Generic;

using UnityEngine;

using TouhouHeartstone.Frontend.ViewModel;
using TouhouHeartstone.Frontend.View.Animation;

using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using IGensoukyo.Utilities;

namespace TouhouHeartstone.Frontend.View
{
    /// <summary>
    /// 卡片的View
    /// </summary>
    public class CardView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        #region animation_base
        Dictionary<string, ICardAnimation> cardAnimations = new Dictionary<string, ICardAnimation>();

        /// <summary>
        /// 播放卡片动画
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <param name="callback"></param>
        public void PlayAnimation(object sender, EventArgs args, GenericAction callback)
        {
            CardAnimationEventArgs aniArgs = Utilities.CheckType<CardAnimationEventArgs>(args);
            ICardAnimation ani;

            if (cardAnimations.ContainsKey(aniArgs.AnimationName))
            {
                // 在卡片本体上的
                ani = cardAnimations[aniArgs.AnimationName];
            }
            else if (CardAnimationComponentLibrary.AnimationExists(aniArgs.AnimationName))
            {
                // 在库里面可以实例化调用的
                var c = CardAnimationComponentLibrary.CreateAnimation(aniArgs.AnimationName, gameObject);
                ani = c;

                cardAnimations.Add(aniArgs.AnimationName, c);
            }
            else if (CardAnimationDynamicLibrary.ContainsAnimation(aniArgs.AnimationName))
            {
                // 在库里面的普通类
                var ca = CardAnimationDynamicLibrary.CreateAnimation(aniArgs.AnimationName);
                ca.SetGameObject(gameObject);
                ani = ca;
            }
            else
            {
                ani = null;
                Debug.LogError($"没有找到动画: {aniArgs.AnimationName}");
            }

            ani.PlayAnimation(sender, aniArgs.EventArgs, callback);
        }

        /// <summary>
        /// 重载动画组件列表
        /// </summary>
        void reloadAnimationList()
        {
            cardAnimations.Clear();

            var cards = gameObject.GetComponents<ICardAnimation>();
            foreach (var item in cards)
            {
                cardAnimations.Add(item.AnimationName, item);
            }
        }
        #endregion

        CardFaceViewModel cardVM;

        protected void Awake()
        {
            // 注册VM事件
            cardVM = GetComponent<CardFaceViewModel>();
            if (cardVM == null)
                throw new Exception("关联的ViewModel未找到");

            cardVM.OnAnimationPlay += PlayAnimation;
            cardVM.OnIndexChangeEvent += CardVM_OnIndexChangeEvent;

            checker.OnClick += onMouseClick;
            checker.OnDrag += onMouseDrag;
            checker.OnRelease += onMouseRelease;
        }

        bool drawed = false;

        private void CardVM_OnIndexChangeEvent()
        {
            if (drawed)
            {
                switch (CurrentState)
                {
                    case state.center:
                        // 调整中心位置
                        if (Deck.ThrowingCard)
                        {
                            PlayAnimation(this, new CardAnimationEventArgs()
                            {
                                AnimationName = "CardToCenter",
                                EventArgs = new CardPositionEventArgs() { GroupCount = Deck.ThrowingCardCount, GroupID = cardVM.Index }
                            }, null);
                        }
                        break;
                    case state.hand:
                        // 调整手牌位置
                        PlayAnimation(this, new CardAnimationEventArgs()
                        {
                            AnimationName = "CardToHand",
                            EventArgs = new CardPositionEventArgs() { GroupCount = Deck.HandCardCount, GroupID = cardVM.Index }
                        }, null);
                        break;
                }
            }
            else
            {
                // 首次抽卡动画
                PlayAnimation(this, new CardAnimationEventArgs()
                {
                    AnimationName = "DrawCard",
                    EventArgs = new CardPositionEventArgs(Deck.HandCardCount, cardVM.Index)
                }, (a, b) => { cardVM.OnDrawCard(); });
                drawed = true;
            }
        }

        #region Card_state_event
        public void OnPointerEnter(PointerEventData eventData)
        {
            GetComponent<CardHighlight>()?.SetHighlight(true);
            if (CurrentState == state.hand)
                CurrentState = state.hand_hover;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            GetComponent<CardHighlight>()?.SetHighlight(false);
            if (CurrentState == state.hand_hover)
                CurrentState = state.hand;
        }

        state currentState = state.hand;
        public state CurrentState
        {
            get { return currentState; }
            set
            {
                if (currentState != value)
                {
                    onStateChange(currentState, value);
                    currentState = value;
                }
            }
        }

        void onStateChange(state original, state current)
        {
            switch(current)
            {

            }
        }

        DragInputChecker checker = new DragInputChecker();

        protected void Update()
        {
            checker.Update(Time.time);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            checker.PointerDown(Time.time);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            checker.PointerUp();
        }

        Controller.UserDeckController Deck => GetComponentInParent<Controller.UserDeckController>();

        void setThrowing(bool state)
        {
            Deck.PrepareThrowCard(GetComponent<CardFaceViewModel>(), state);
        }

        void onMouseDrag()
        {
            DebugUtils.Trace("鼠标按住");

            if (Deck.ThrowingCard)
            {
                switch (CurrentState)
                {
                    case state.hand:
                    case state.hand_hover:
                        CurrentState = state.center;
                        setThrowing(true);
                        break;
                    case state.free:
                    case state.center:
                        CurrentState = state.hand;
                        setThrowing(false);
                        break;
                }
            }
            else
            {
                switch (CurrentState)
                {
                    case state.hand:
                    case state.hand_hover:
                        CurrentState = state.free;
                        break;
                }
            }
        }

        void onMouseRelease()
        {
            DebugUtils.Trace("鼠标松开");
            if (Deck.ThrowingCard)
            {
                // do nothing
            }
            else
            {
                switch (CurrentState)
                {
                    case state.free:
                        if (checkTarget()) Use();
                        else CurrentState = state.hand;
                        break;
                }
            }
        }

        private void onMouseClick()
        {
            DebugUtils.Trace("鼠标按下");
            if (Deck.ThrowingCard)
            {
                switch (CurrentState)
                {
                    case state.hand:
                    case state.hand_hover:
                        CurrentState = state.center;
                        setThrowing(true);
                        break;
                    case state.center:
                        CurrentState = state.hand;
                        setThrowing(false);
                        break;
                    case state.free:
                        break;
                }
            }
            else
            {
                switch (CurrentState)
                {
                    case state.hand:
                    case state.hand_hover:
                        CurrentState = state.free;
                        break;
                    case state.free:
                        if (checkTarget()) Use();
                        else CurrentState = state.hand;
                        break;
                    case state.center:
                        break;
                }
            }
        }

        bool checkTarget()
        {
            return true;
        }
        void Use()
        {
            CurrentState = state.undefined;
        }
        #endregion

        public enum state
        {
            hand,
            hand_hover,
            free,
            center,
            undefined
        }
    }

    class DragInputChecker
    {
        public event Action OnDrag;
        public event Action OnRelease;
        public event Action OnClick;

        /// <summary>
        /// 上次按下时间。若为空则意味着触发或OnDrag事件了
        /// </summary>
        float? lastPointerDownTime;
        const float dragThresold = 0.25f;

        public void Update(float time)
        {
            if (lastPointerDownTime != null)
            {
                if (time - lastPointerDownTime > dragThresold)
                {
                    OnDrag?.Invoke();
                    lastPointerDownTime = null;
                }
            }
        }

        public void PointerDown(float time)
        {
            lastPointerDownTime = time;
        }

        public void PointerUp()
        {
            if (lastPointerDownTime != null)
            {
                OnClick?.Invoke();
                lastPointerDownTime = null;
            }
            else
            {
                OnRelease?.Invoke();
            }
        }
    }
}
