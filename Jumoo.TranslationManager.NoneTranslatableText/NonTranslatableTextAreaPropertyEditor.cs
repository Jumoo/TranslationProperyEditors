using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;

namespace Jumoo.TranslationManager.NoneTranslatableText
{
    [PropertyEditor("NonTranslatable.Textarea", "Non-Translatable Textarea", "~/umbraco/Views/propertyeditors/textarea/textarea.html",
        Group = "common", ValueType = PropertyEditorValueTypes.Text, IsParameterEditor = true, Icon = "icon-application-window-alt color-grey")]
    public class NonTranslatableTextAreaPropertyEditor : PropertyEditor
    {
        protected override PreValueEditor CreatePreValueEditor()
        {
            return new NonTranslatableTextAreaPreValueEditor();
        }
    }

    public class NonTranslatableTextAreaPreValueEditor : PreValueEditor
    {
        [PreValueField("maxChars", "Maximum allowed characters", "number", Description = "If empty - no character limit")]
        public int MaxChars { get; set; }

        [PreValueField("rows", "Number of rows", "number", Description = "If empty - 10 rows would be set as the default value")]
        public int Rows { get; set; }
    }


    [PropertyValueType(typeof(string))]
    [PropertyValueCache(PropertyCacheValue.All, PropertyCacheLevel.Content)]
    public class NonTranslatableTextAreaPropertyConverter : PropertyValueConverterBase
    {
        public override bool IsConverter(PublishedPropertyType propertyType)
        {
            return propertyType.PropertyEditorAlias.Equals("NonTranslatable.Textarea");
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