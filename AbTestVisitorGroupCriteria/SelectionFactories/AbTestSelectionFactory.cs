using System;
using System.Collections.Generic;
using System.Web.Mvc;
using EPiServer.Marketing.Testing.Core.DataClass;
using EPiServer.Marketing.Testing.Web.Repositories;
using EPiServer.Personalization.VisitorGroups;
using EPiServer.ServiceLocation;

namespace AbTestVisitorGroupCriteria.SelectionFactories
{
    public class AbTestSelectionFactory : ISelectionFactory
    {
        private readonly Injected<IMarketingTestingWebRepository> _marketingTestingWebRepository;

        public IEnumerable<SelectListItem> GetSelectListItems(Type propertyType)
        {
            List<SelectListItem> selectItems = new List<SelectListItem>();
            var allTests = _marketingTestingWebRepository.Service.GetTestList(new TestCriteria());
            foreach(var abTest in allTests)
            {
                selectItems.Add(new SelectListItem() { Value = abTest.Id.ToString(), Text = abTest.Title });
            }
            return selectItems;
        }
    }
}