using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;
using Umbraco.Core.PropertyEditors.ValueConverters;
using Umbraco.Web.PropertyEditors;

namespace Jumoo.TranslationManager.NoneTranslatableText
{
    [DataEditor("NonTranslatable.Textarea", 
        EditorType.PropertyValue | EditorType.MacroParameter,        
        "Non-Translatable Textarea", 
        "textarea",
        ValueType = ValueTypes.Text,  
        Group = "Common",
        Icon = "icon-application-window-alt color-grey")]
    public class NonTranslatableTextAreaPropertyEditor : DataEditor
    {
        public NonTranslatableTextAreaPropertyEditor(ILogger logger) 
            : base(logger)
        { }

        protected override IDataValueEditor CreateValueEditor()
            => new TextOnlyValueEditor(Attribute);

        protected override IConfigurationEditor CreateConfigurationEditor()
            => new TextboxConfigurationEditor();
    }

    public class NonTranslatableTextAreaValueConverter : PropertyValueConverterBase

    {
        private static readonly string[] PropertyTypeAliases =
        {
            "NonTranslatable.Textbox",
            "NonTranslatable.Textarea"
        };

        public override bool IsConverter(IPublishedPropertyType propertyType)
            => PropertyTypeAliases.Contains(propertyType.EditorAlias);

        public override Type GetPropertyValueType(IPublishedPropertyType propertyType)
            => typeof(string);

        public override PropertyCacheLevel GetPropertyCacheLevel(IPublishedPropertyType propertyType)
            => PropertyCacheLevel.Element;

        public override object ConvertSourceToIntermediate(IPublishedElement owner, IPublishedPropertyType propertyType, object source, bool preview)
            => source;

        public override object ConvertIntermediateToObject(IPublishedElement owner, IPublishedPropertyType propertyType, PropertyCacheLevel referenceCacheLevel, object inter, bool preview)
            => inter ?? string.Empty;

        public override object ConvertIntermediateToXPath(IPublishedElement owner, IPublishedPropertyType propertyType, PropertyCacheLevel referenceCacheLevel, object inter, bool preview)
            => inter;
    }
}