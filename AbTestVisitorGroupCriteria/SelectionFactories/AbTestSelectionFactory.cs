using System;
using System.Collections.Generic;
using System.Linq;
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
            var allTests = _marketingTestingWebRepository.Service.GetTestList(new TestCriteria()).Where(x => x.State == EPiServer.Marketing.Testing.Core.DataClass.Enums.TestState.Active).ToList();
            foreach(var abTest in allTests)
            {
                selectItems.Add(new SelectListItem() { Value = abTest.Id.ToString(), Text = abTest.Title });
            }
            return selectItems;
        }
    }
}
