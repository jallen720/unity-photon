using System;
using UnityEngine;
using UnityUtils.EventUtils;
using UnityUtils.Extensions;
using UObject = UnityEngine.Object;

namespace UnityPhoton {
    public class ListDisplay<ElementData, Element>
        where Element : Component, IListDisplayElement<ElementData> 
    {
        private RectTransform elementContainer;
        private UObject elementPrefab;

        public readonly Event<Element> LoadElementDisplayEvent;

        public ListDisplay(RectTransform elementContainer, UObject elementPrefab) {
            this.elementContainer = elementContainer;
            this.elementPrefab = elementPrefab;
            LoadElementDisplayEvent = new Event<Element>();
        }

        public void Load(ElementData[] elementDatas) {
            DestroyOldElementDisplays();
            Array.ForEach(elementDatas, LoadElementDisplay);
        }

        private void DestroyOldElementDisplays() {
            foreach (Transform element in elementContainer) {
                UObject.Destroy(element.gameObject);
            }
        }

        private void LoadElementDisplay(ElementData elementData) {
            var element = elementContainer.InstantiateChild<Element>(elementPrefab);
            element.Init(elementData);
            LoadElementDisplayEvent.Trigger(element);
        }
    }
}