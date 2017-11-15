using System;
using System.Linq;
using System.Security.Principal;
using System.Web;
using AbTestVisitorGroupCriteria.Models;
using EPiServer.Marketing.Testing.Web.Helpers;
using EPiServer.Personalization.VisitorGroups;
using EPiServer.ServiceLocation;

namespace AbTestVisitorGroupCriteria.Criterion
{
    [VisitorGroupCriterion(
        Category = "A/B Test criteria",
        Description = "Check if current user is partcipating in A/B test or not",
        DisplayName = "Partcipating in A/B test",
        LanguagePath = "/visitorgroupsforabtest/criteria"
        )]
    public class ParticipatingInAbTestCriterion : CriterionBase<ParticipatingInAbTestCriterionModel>
    {
#pragma warning disable 649
        private Injected<ITestDataCookieHelper> _testDataCookieHelper;
#pragma warning restore 649

        public override bool IsMatch(IPrincipal principal, HttpContextBase httpContext)
        {
            var testId = Guid.Parse(Model.Test);
            var allActiveTests = _testDataCookieHelper.Service.GetTestDataFromCookies();
            var activeTest = allActiveTests.FirstOrDefault(x => x.TestId == testId);
            if (activeTest != null)
            {
                switch (Model.ViewingVersion)
                {
                    case "Any":
                        return true;

                    case "Control":
                        if (activeTest.ShowVariant == false)
                            return true;
                        break;

                    case "Challenger":
                        if (activeTest.ShowVariant)
                            return true;
                        break;
                }
            }

            return false;
        }
    }
}