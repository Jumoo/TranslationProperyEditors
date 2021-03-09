using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;
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
}