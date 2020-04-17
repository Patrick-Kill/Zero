﻿using System;
using UnityEngine;
using UnityEngine.UI;
using ZeroHot;

namespace ILDemo
{
    public class MenuPanel : AView
    {
        GameObject buttonPrefab;
        Transform content;

        protected override void OnInit(object data)
        {
            base.OnInit(data);
            buttonPrefab.SetActive(false);

            AddBtn("Roushan", RoushanTest);
            AddBtn("TestAndroidBridge", TestAndroidBridge);
        }

        private void TestAndroidBridge()
        {
            var bridge = new AndroidJavaClass("pieces.jing.zerolib.UnityBridge");
            bridge.CallStatic<bool>("showToast", "Bridge Test!!!");
        }

        void RoushanTest()
        {
            UIPanelMgr.Ins.Switch<StartupPanel>();
        }

        void AddBtn(string label, Action action)
        {
            var go = GameObject.Instantiate(buttonPrefab, content);
            go.name = label;
            go.SetActive(true);
            go.GetComponentInChildren<Text>().text = label;            
            go.GetComponent<Button>().onClick.AddListener(() => { action.Invoke(); });           
        }
    }
}
