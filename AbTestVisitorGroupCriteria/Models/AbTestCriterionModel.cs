using System.ComponentModel.DataAnnotations;
using AbTestVisitorGroupCriteria.SelectionFactories;
using EPiServer.Personalization.VisitorGroups;

namespace AbTestVisitorGroupCriteria.Models
{
    public class ParticipatingInAbTestCriterionModel : CriterionModelBase
    {
        [Required, DojoWidget(SelectionFactoryType = typeof(AbTestSelectionFactory),
            LabelTranslationKey = "/visitorgroupsforabtest/model/testdescriptionfieldlabel")]
        public string Test { get; set; }

        [Required, DojoWidget(SelectionFactoryType = typeof(ViewingVariantSelectionFactory), 
            LabelTranslationKey = "/visitorgroupsforabtest/model/viewingversionfieldlabel")]
        public string ViewingVersion { get; set; }

        public override ICriterionModel Copy() => ShallowCopy();
    }
}