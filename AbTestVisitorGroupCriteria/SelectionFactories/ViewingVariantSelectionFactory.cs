using System;
using System.Collections.Generic;
using System.Web.Mvc;
using EPiServer.Framework.Localization;
using EPiServer.Personalization.VisitorGroups;
using EPiServer.ServiceLocation;

namespace AbTestVisitorGroupCriteria.SelectionFactories
{
    public class ViewingVariantSelectionFactory : ISelectionFactory
    {
#pragma warning disable 649
        Injected<LocalizationService> _localizationService;
#pragma warning restore 649

        public IEnumerable<SelectListItem> GetSelectListItems(Type propertyType)
        {
            List<SelectListItem> selectItems = new List<SelectListItem>();
            selectItems.Add(new SelectListItem()
            {
                Value = "Any",
                Text = _localizationService.Service.GetString("/visitorgroupsforabtest/viewingversion/any", "Viewing any version of content")
            });
            selectItems.Add(new SelectListItem()
            {
                Value = "Control",
                Text = _localizationService.Service.GetString("/visitorgroupsforabtest/viewingversion/control", "Viewing control version of content")
            });
            selectItems.Add(new SelectListItem()
            {
                Value = "Challenger",
                Text = _localizationService.Service.GetString("/visitorgroupsforabtest/viewingversion/challenger", "Viewing challenger version of content")
            });
            return selectItems;
        }
    }
}