using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;

namespace Jumoo.TranslationManager.NoneTranslatableText
{
    [PropertyEditor("NonTranslatable.Textbox", "Non-Translatable Textbox", "~/umbraco/Views/propertyeditors/textbox/textbox.html",
        Group = "common", IsParameterEditor = true, Icon = "icon-autofill color-grey")]
    public class NonTranslatableTextBoxPropertyEditor : PropertyEditor
    {
        protected override PreValueEditor CreatePreValueEditor()
        {
            return new NonTranslatableTextBoxPreValueEditor();
        }
    }

    public class NonTranslatableTextBoxPreValueEditor : PreValueEditor
    {
        [PreValueField("maxChars", "Maximum allowed characters", "textstringlimited", Description = "If empty - 500 character limit")]
        public bool MaxChars { get; set; }
    }

    [PropertyValueType(typeof(string))]
    [PropertyValueCache(PropertyCacheValue.All, PropertyCacheLevel.Content)]
    public class NonTranslatableTextBoxPropertyConverter : PropertyValueConverterBase
    {
        public override bool IsConverter(PublishedPropertyType propertyType)
        {
            return propertyType.PropertyEditorAlias.Equals("NonTranslatable.Textbox");
        }

        public override object ConvertDataToSource(PublishedPropertyType propertyType, object source, bool preview)
        {
            return source;
        }

        public override object ConvertSourceToObject(PublishedPropertyType propertyType, object source, bool preview)
        {
            return source ?? string.Empty;
        }

        public override object ConvertSourceToXPath(PublishedPropertyType propertyType, object source, bool preview)
        {
            return source;
        }
    }
}
